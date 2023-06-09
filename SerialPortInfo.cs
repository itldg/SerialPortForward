using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortForward
{
    /// <summary>
    /// 串口扩展字段
    /// </summary>
    public class SerialPortInfo:SerialPort
    {
        /// <summary>
        /// 轮询查询时间间隔
        /// </summary>
        public int Timer { get; set; }=0;

        /// <summary>
        /// 分包合并
        /// </summary>
        public int TimeOut { get; set; } = 30;
        bool _CloseIng  = false;
        /// <summary>
        /// 串口正在关闭
        /// </summary>
        public bool CloseIng { get { return _CloseIng; } }
        /// <summary>
        /// 接收数据中
        /// </summary>
        public bool Listening { get; set; } = false;
        public new void Open()
        { 
            base.Open();
        }
        /// <summary>
        /// 关闭串口,如果正在读取数据,则等待读取完毕后关闭
        /// </summary>
        public new void Close()
        {
            _CloseIng = true;
            while (Listening) {
                Thread.Sleep(10);
                Application.DoEvents();
            } 
            //打开时点击，则关闭串口
            base.Close();
            _CloseIng = false;
        }
    }
}
