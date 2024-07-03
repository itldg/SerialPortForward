using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SerialPortForward
{
    /// <summary>
    /// 串口扩展字段
    /// </summary>
    public class SerialPortInfo : SerialPort
    {
        System.Windows.Forms.Timer timerCom;
        public const string SERIAL_TCP_SERVER = "TCP Server";
        public const string SERIAL_TCP_CLIENT = "TCP Client";
        public SerialPortInfo() : base()
        {
            timerCom = new System.Windows.Forms.Timer();
            timerCom.Tick += TimerCom_Tick;
        }

        private void TimerCom_Tick(object sender, EventArgs e)
        {
            if (!IsOpen)
            {
                return;
            }
            try
            {
                int length = BytesToRead;
                if (length == 0)//没数据，退出去
                    return;
                byte[] rev = new byte[length];
                Read(rev, 0, length);//读数据
                if (rev.Length == 0)
                    return;
                DataReceived?.Invoke(this, rev);
            }
            catch (Exception)
            {
                return;
            }//崩了？
        }

        /// <summary>
        /// 轮询查询时间间隔
        /// </summary>
        public int Timer { get; set; } = 0;

        /// <summary>
        /// 分包合并
        /// </summary>
        public int TimeOut { get; set; } = 30;
        /// <summary>
        /// IP地址
        /// </summary>
        public IPAddress IP { get; set; } = new IPAddress(0);
        /// <summary>
        /// 是否是网络串口
        /// </summary>
        public bool IsNetWork { get { return PortName == SERIAL_TCP_SERVER || PortName == SERIAL_TCP_CLIENT; } }
        bool _IsOpen = false;
        /// <summary>
        /// 串口打开(连接)状态
        /// </summary>
        new public bool IsOpen
        {
            get
            {
                if (IsNetWork)
                {
                    return _IsOpen;
                }
                return base.IsOpen;
            }
        }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; } = 8866;
        bool _CloseIng = false;
        /// <summary>
        /// 串口正在关闭
        /// </summary>
        public bool CloseIng { get { return _CloseIng; } }
        /// <summary>
        /// 接收数据中
        /// </summary>
        public bool Listening { get; set; } = false;

        //收到消息的事件
        new public event EventHandler<byte[]> DataReceived;

        private TcpListener Server = null;
        private List<Socket> Clients = new List<Socket>();

        //暂存一个对象
        SocketObj socketNow = null;
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <exception cref="Exception"></exception>
        public new void Open()
        {
            if (PortName == SERIAL_TCP_SERVER)
            {
                if (Server != null)
                {
                    throw new Exception("已经打开了TCP Server");
                }
                try
                {
                    Server = new TcpListener(IP, Port);
                    Server.Start();
                }
                catch (Exception ex)
                {
                    Server = null;
                    throw ex;
                }


                AsyncCallback newConnectionCb = null;
                newConnectionCb = new AsyncCallback((ar) =>
                {
                    TcpListener listener = (TcpListener)ar.AsyncState;
                    try
                    {
                        Socket client = listener.EndAcceptSocket(ar);//必须有这一句，不然新的请求没反应
                        lock (Clients)
                            Clients.Add(client);//加到列表里

                        //客户端数据接收回调
                        StateObject so = new StateObject();
                        so.workSocket = client;
                        client.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(Read_Callback), so);

                        //恢复服务端的回调函数，方便下次接收
                        Server.BeginAcceptSocket(newConnectionCb, Server);
                    }
                    catch { }
                });
                Server.BeginAcceptSocket(newConnectionCb, Server);
                _IsOpen = true;
            }
            else if (PortName == SERIAL_TCP_CLIENT)
            {
                IPEndPoint ipe = new IPEndPoint(IP, Port);
                Socket s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                StateObject so = new StateObject();
                s.BeginConnect(ipe, new AsyncCallback((r) =>
                {
                    var state = (Socket)r.AsyncState;
                    if (!state.Connected)
                    {
                        _IsOpen = false;
                        return;

                    }
                    if (!so.isSSL)
                        socketNow = new SocketObj(state);
                    _IsOpen = true;
                    so.workSocket = state;
                    state.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(Read_Callback), so);
                }), s);
            }
            else
            {
                base.DataReceived -= SerialPortInfo_DataReceived;
                if (Timer > 0)
                {
                    timerCom.Interval = Timer;
                    timerCom.Enabled = true;
                }
                else
                {
                    base.DataReceived += SerialPortInfo_DataReceived;
                }

                base.Open();
            }

        }

        /// <summary>
        /// 关闭串口,如果正在读取数据,则等待读取完毕后关闭
        /// </summary>
        public new void Close()
        {
            if (PortName == SERIAL_TCP_SERVER)
            {
                lock (Clients)
                {
                    foreach (var c in Clients)
                        try
                        {
                            c.Close();
                            c.Dispose();
                        }
                        catch { }
                    Clients.Clear();
                }
                Server?.Stop();
                Server = null;
                _IsOpen = false;
            }
            else if (PortName == SERIAL_TCP_CLIENT)
            {
                if (socketNow != null)
                {
                    socketNow.Close();
                    socketNow = null;
                }
                _IsOpen = false;
            }
            else
            {
                if (timerCom != null)
                {
                    timerCom.Enabled = false;
                }
                _CloseIng = true;
                while (Listening)
                {
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
                //打开时点击，则关闭串口
                base.Close();
                _CloseIng = false;
            }

        }
        /// <summary>
        /// 原生串口收到数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortInfo_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (CloseIng) { return; }
            try
            {
                Listening = true;
                //分包写法
                List<byte> result = new List<byte>();
                while (true)//循环读
                {
                    if (CloseIng || !IsOpen)//串口被关了，不读了
                    {
                        break;
                    }
                    try
                    {
                        int length = BytesToRead;
                        if (length == 0)//没数据，退出去
                            break;
                        byte[] rev = new byte[length];
                        Read(rev, 0, length);//读数据
                        if (rev.Length == 0)
                            break;
                        result.AddRange(rev);//加到list末尾
                        if (result.Count > 1024)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }//崩了？

                    if (TimeOut > 0)
                    {
                        Thread.Sleep(TimeOut);
                    }
                }
                if (result.Count == 0)
                {
                    return;
                }

                byte[] byteRead = result.ToArray();
                DataReceived?.Invoke(this, byteRead);
            }
            finally
            {
                Listening = false;
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public new void Write(byte[] buffer, int offset, int count)
        {
            if (PortName == SERIAL_TCP_SERVER)
            {
                lock (Clients)
                {
                    foreach (var item in Clients)
                    {
                        try
                        {
                            item.Send(buffer, offset, count, SocketFlags.None);
                        }
                        catch { }
                    }
                }
            }
            else if (PortName == SERIAL_TCP_CLIENT)
            {
                if (socketNow != null)
                {
                    socketNow.Send(buffer);
                }
            }
            else
            {
                base.Write(buffer, offset, count);
            }
        }
        public void Read_Callback(IAsyncResult ar)
        {
            StateObject so = (StateObject)ar.AsyncState;

            if (so.isSSL)//ssl连接
            {
                var ssl = so.workStream;
                try
                {
                    int read = ssl.EndRead(ar);

                    if (read > 0)
                    {
                        var buff = new byte[read];
                        for (int i = 0; i < buff.Length; i++)
                            buff[i] = so.buffer[i];
                        DataReceived?.Invoke(null, buff);
                        ssl.BeginRead(so.buffer, 0, StateObject.BUFFER_SIZE,
                                                 new AsyncCallback(Read_Callback), so);
                    }
                    else//断了？
                    {
                        try
                        {
                            ssl.Close();
                            ssl.Dispose();
                        }
                        catch { }
                        socketNow = null;
                        _IsOpen = false;
                    }
                }
                catch { }

                return;
            }

            Socket s = so.workSocket;
            try
            {

                int read = s.EndReceive(ar);

                if (read > 0)
                {
                    var buff = new byte[read];
                    for (int i = 0; i < buff.Length; i++)
                        buff[i] = so.buffer[i];
                    DataReceived?.Invoke(null, buff);
                    s.BeginReceive(so.buffer, 0, StateObject.BUFFER_SIZE, 0,
                                             new AsyncCallback(Read_Callback), so);
                }
                else//断了？
                {
                    try
                    {
                        s.Close();
                        s.Dispose();
                    }
                    catch { }
                    socketNow = null;
                    _IsOpen = false;
                }
            }
            catch { }
        }
    }
    public class StateObject
    {
        public Socket workSocket = null;
        public SslStream workStream = null;
        public const int BUFFER_SIZE = 204800;
        public byte[] buffer = new byte[BUFFER_SIZE];
        public bool isSSL = false;
    }

    public class SocketObj
    {
        Socket socket;
        SslStream sslStream;
        public SocketObj(Socket s)
        {
            socket = s;
        }
        public SocketObj(SslStream ssl)
        {
            sslStream = ssl;
        }
        public void Send(byte[] buff)
        {
            if (socket != null)
                socket.Send(buff);
            else if (sslStream != null)
            {
                sslStream.Write(buff);
            }

        }

        public void Close()
        {
            if (socket != null)
            {
                socket.Close();
                socket.Dispose();
            }
            else if (sslStream != null)
            {
                sslStream.Close();
                sslStream.Dispose();
            }
        }
    }
}
