using DotNet.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SerialPortForward
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        SerialPortInfo com1 = new SerialPortInfo(), com2= new SerialPortInfo();
        string com1Name="", com2Name = "";
        bool com1Forward = true, com2Forward = true;
        bool SerialCheck()
        {
            string com1NameTemp = GetCom(cmbCom1.Text);
            string com2NameTemp = GetCom(cmbCom2.Text);
            if (string.IsNullOrEmpty(com1NameTemp) || string.IsNullOrEmpty(com2NameTemp))
            {
                MessageBox.Show( "未获取到串口号,不可以打开空的串口","打开失败",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (com1NameTemp == com2NameTemp)
            {
                MessageBox.Show("不可转发两个相同的串口", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Com2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceived(com2Name, false, com2Forward, com2, com1);
        }

        private void Com1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceived(com1Name, true, com1Forward, com1,com2);
        }
        void DataReceived(string name, bool left, bool send, SerialPortInfo spReceive, SerialPortInfo spSend)
        {
            if (!spReceive.IsOpen)
            {
                return;
            }
            //分包写法
            List<byte> result = new List<byte>();
            while (true)//循环读
            {
                //蓝光串口过快,延迟不会发送
                System.Threading.Thread.Sleep(spReceive.TimeOut);
                if (!spReceive.IsOpen)//串口被关了，不读了
                    break;
                try
                {
                    int length = spReceive.BytesToRead;
                    if (length == 0)//没数据，退出去
                        break;
                    byte[] rev = new byte[length];
                    spReceive.Read(rev, 0, length);//读数据
                    if (rev.Length == 0)
                        break;
                    result.AddRange(rev);//加到list末尾
                }
                catch (Exception ex)
                {
                    break;
                }//崩了？

            }
            if (result.Count == 0)
            {
                return;
            }
            byte[] byteRead = result.ToArray();

                //原始写法
                //byteRead = new byte[sp.BytesToRead];
                //if (byteRead.Length == 0)
                //    return;
                //sp.Read(byteRead, 0, byteRead.Length);


            string strHex = ByteToHex(byteRead);
            AddLog(strHex, byteRead, name, left, send, spSend);
        }

        Regex regGetComName = new Regex("\\((COM(\\d+))\\)");
        public string GetCom(string ComName)
        {
            Match match= regGetComName.Match(ComName);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return "";
        }

        private void btnMoreSerialOption_Click(object sender, EventArgs e)
        {
            if (!com1.IsOpen&&!com2.IsOpen)
            {
                FrmMoreSerial fms = new FrmMoreSerial(ref com1, ref com2);
                if (fms.ShowDialog() == DialogResult.OK)
                {
                    SaveSerialOption();
                    ReadSerialOption();
                }
            }
            else
            {
                MessageBox.Show("请先停止串口转发再进行操作", "请先停止", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        void SaveSerialOption()
        {
            INIFileHelper ini = new INIFileHelper(Application.StartupPath + "\\config.ini");
            SerialSave(com1, "Com1", ini);
            SerialSave(com2, "Com2", ini);
            SerialOtherSave(ini);
        }
        void SerialSave(SerialPortInfo sp, string Name, INIFileHelper ini)
        {
            ini.IniWriteValue(Name, "PortName", sp.PortName.ToString());
            ini.IniWriteValue(Name, "Stop", sp.StopBits.ToString());
            ini.IniWriteValue(Name, "Data", sp.DataBits.ToString());
            ini.IniWriteValue(Name, "Parity", sp.Parity.ToString());
            ini.IniWriteValue(Name, "Dtr", sp.DtrEnable.ToString());
            ini.IniWriteValue(Name, "Rts", sp.RtsEnable.ToString());
            ini.IniWriteValue(Name, "BaudRate", sp.BaudRate.ToString());
            ini.IniWriteValue(Name, "Timer", sp.Timer.ToString());
            ini.IniWriteValue(Name, "TimeOut", sp.TimeOut.ToString());
        }
        void SerialOtherSave(INIFileHelper ini)
        {
            
            ini.IniWriteValue("Com1", "Name",com1Name);
            ini.IniWriteValue("Com2", "Name", com2Name);

            ini.IniWriteValue("Com1", "Forward", com1Forward.ToString());
            ini.IniWriteValue("Com2", "Forward", com2Forward.ToString());
        }
        
        void SerialOtherRead(INIFileHelper ini)
        {
            txtName1.Text = ini.IniReadValue("Com1", "Name","" );
            txtName2.Text = ini.IniReadValue("Com2", "Name","" );

            chkForward1.Checked = Convert.ToBoolean(  ini.IniReadValue("Com1", "Forward", "true"));
            chkForward2.Checked = Convert.ToBoolean(ini.IniReadValue("Com2", "Forward", "true"));
        }
        void ReadSerialOption()
        {
            INIFileHelper ini = new INIFileHelper(Application.StartupPath + "\\config.ini");
            SerialRead(com1, "Com1",cmbBaudRate1, ini);
            SerialRead(com2, "Com2",cmbBaudRate2, ini);
            SerialOtherRead(ini);
        }
        void SerialRead(SerialPortInfo sp, string Name,ComboBox cmb, INIFileHelper ini)
        {
            sp.PortName=ini.IniReadValue(Name, "PortName", sp.PortName.ToString());
            sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.IniReadValue(Name, "Stop", sp.StopBits.ToString()));
            sp.DataBits = Convert.ToInt32(ini.IniReadValue(Name, "Data", sp.DataBits.ToString()));
            sp.Parity = (Parity)Enum.Parse(typeof(Parity), ini.IniReadValue(Name, "Parity", sp.Parity.ToString()));
            sp.DtrEnable = Convert.ToBoolean(ini.IniReadValue(Name, "Dtr", sp.DtrEnable.ToString()));
            sp.RtsEnable = Convert.ToBoolean(ini.IniReadValue(Name, "Rts", sp.RtsEnable.ToString()));
            sp.BaudRate = Convert.ToInt32(ini.IniReadValue(Name, "BaudRate", "9600"));
            sp.Timer = Convert.ToInt32(ini.IniReadValue(Name, "Timer", "0"));
            sp.TimeOut = Convert.ToInt32(ini.IniReadValue(Name, "TimeOut", "30"));

            cmb.Text = sp.BaudRate.ToString();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            refreshPortList();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try { 
                ReadSerialOption();
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取配置文件失败：" + ex.Message);
            }
            refreshPortList();
        }

        private void cmbBaudRate2_TextChanged(object sender, EventArgs e)
        {
            ComBaudChange(com2, cmbBaudRate2);
        }

        private void cmbBaudRate1_TextChanged(object sender, EventArgs e)
        {
            ComBaudChange(com1, cmbBaudRate1);
        }

        private void chkForward1_CheckedChanged(object sender, EventArgs e)
        {
            com1Forward = chkForward1.Checked;
        }

        private void chkForward2_CheckedChanged(object sender, EventArgs e)
        {
            com2Forward = chkForward2.Checked;
        }

        private void txtName1_TextChanged(object sender, EventArgs e)
        {
            com1Name = txtName1.Text;
        }

        private void txtName2_TextChanged(object sender, EventArgs e)
        {
            com2Name = txtName2.Text;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        void AddLog(string hex, byte[] data,string name,bool left,bool send,SerialPort sp)
        {
            Color color= Color.DarkBlue;
            if (!left)
            {
                color = Color.DarkGreen;
            }
            serialLog1.AddLog(name,color,hex);
            this.Invoke((MethodInvoker)delegate ()
            {

                if (hex.Contains("0D0D0A"))
                {
                    //忽略转发连接的消息
                    return;
                }
                if (send && sp.IsOpen)
                {
                    sp.Write(data, 0, data.Length);
                }
                
            });
        }


        /// <summary>
        /// Hex转换成Ascii
        /// 将ASC码转换成字符串，如："414243"转换为"ABC"
        /// </summary>
        /// <param name="hex"></param>
        /// <returns>Ascii信息</returns>
        /// <exception cref="Exception"></exception>
        public static string HexToAscii(string hex)
        {
            string strCharacter = "";
            String str = "";
            hex = hex.Replace(" ", "");
            int j = hex.Length;

            for (int i = 0; i < j - 1; i += 2)
            {
                int asciiCode1 = Convert.ToInt32(hex.Substring(i, 2), 16);

                if (asciiCode1 >= 0x00 && asciiCode1 <= 0xFF)
                {
                    ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                    byte[] byteArray = new byte[] { (byte)asciiCode1 };
                    strCharacter = asciiEncoding.GetString(byteArray);

                }
                else
                {
                    throw new Exception("ASCII Code is not valid.");
                }
                str += strCharacter;
            }
            return str;
        }
        /// <summary>
        /// Ascii转Hex
        /// 将字符串转换成ASC码，如："ABC"转换为"414243"
        /// </summary>
        /// <param name="asciiCode">Ascii代码</param>
        /// <returns>返回的hex信息</returns>
        public static string AsciiToHex(string asciiCode)
        {

            byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(asciiCode);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in ba)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();

        }

        /// <summary>
        /// 转换十六进制字符串到字节数组："41 42 43"--{0x41,0x42,0x43}
        /// </summary>
        /// <param name="msg">待转换字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");//移除空格
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            }
            return comBuffer;
        }

        /// <summary>
        /// 转换字节数组到十六进制字符串:{0x41,0x42,0x43}--"414243"
        /// </summary>
        /// <param name="comByte">待转换字节数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ByteToHex(byte[] comByte)
        {
            string returnStr = "";
            if (comByte != null)
            {
                for (int i = 0; i < comByte.Length; i++)
                {
                    returnStr += comByte[i].ToString("X2");
                }
                // returnStr = returnStr.Replace(" ", "");
            }
            return returnStr;
        }



        private void btnCom1_Click(object sender, EventArgs e)
        {
            if (btnCom1.Text == "打开")
            {

                if (SerialCheck())
                {
                    string com1NameTemp = GetCom(cmbCom1.Text);
                    try
                    {
                        com1.PortName = com1NameTemp;
                        com1.BaudRate = Convert.ToInt32(cmbBaudRate1.Text);
                        if (com1.Timer > 0)
                        {
                            timerCom1.Interval = com1.Timer;
                            timerCom1.Enabled = true;
                        }
                        else {
                            com1.DataReceived += Com1_DataReceived;
                        }
                        com1.Open();
                        SaveSerialOption();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmbCom1.Enabled = false;
                    btnCom1.Text = "关闭";
                }
            }
            else
            {
                timerCom1.Enabled = false;
                try
                {
                    com1.Close();
                    com1.Dispose();
                }
                catch (Exception)
                {
                }
                cmbCom1.Enabled = true;
                btnCom1.Text = "打开";
            }
        }

        private void btnCom2_Click(object sender, EventArgs e)
        {
            if (btnCom2.Text == "打开")
            {

                if (SerialCheck())
                {
                    string com2NameTemp = GetCom(cmbCom2.Text);
                    try
                    {
                        com2.PortName = com2NameTemp;
                        com2.BaudRate = Convert.ToInt32(cmbBaudRate2.Text);
                        if (com2.Timer > 0)
                        {
                            timerCom2.Interval = com2.Timer;
                            timerCom2.Enabled = true;
                        }
                        else
                        {
                            com2.DataReceived += Com2_DataReceived;
                        }
                        com2.Open();
                        SaveSerialOption();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmbCom2.Enabled = false;
                    btnCom2.Text = "关闭";
                }
            }
            else
            {
                timerCom2.Enabled = false;
                try
                {
                    com2.Close();
                    com2.Dispose();
                }
                catch (Exception)
                {
                }
                cmbCom2.Enabled = true;
                btnCom2.Text = "打开";
            }
        }

        private void serialLog1_Load(object sender, EventArgs e)
        {

        }

        private void timerCom1_Tick(object sender, EventArgs e)
        {
            DataShow(com1Name, true, com1Forward, com1, com2);
        }

        private void timerCom2_Tick(object sender, EventArgs e)
        {
            DataShow(com2Name, false, com2Forward, com2, com1);
        }
        void DataShow(string name, bool left, bool send, SerialPortInfo spReceive, SerialPortInfo spSend)
        {
            if (!spReceive.IsOpen)
            {
                return;
            }
            try
            {
                int length = spReceive.BytesToRead;
                if (length == 0)//没数据，退出去
                    return;
                byte[] rev = new byte[length];
                spReceive.Read(rev, 0, length);//读数据
                if (rev.Length == 0)
                    return;

                string strHex = ByteToHex(rev);
                AddLog(strHex, rev, name, left, send, spSend);
            }
            catch (Exception ex)
            {
                return;
            }//崩了？
        }
        void ComBaudChange(SerialPortInfo sp,ComboBox cmb)
        {
            if (int.TryParse(cmb.Text,out int baud))
            {
                sp.BaudRate = baud;
            }
        }

        private bool refreshLock = false;
        /// <summary>
        /// 刷新设备列表
        /// </summary>
        private void refreshPortList()
        {
            if (refreshLock)
                return;
            refreshLock = true;
            cmbCom1.Items.Clear();
            cmbCom2.Items.Clear();
            List<string> strs = new List<string>();
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
                        Regex regExp = new Regex("\\(COM\\d+\\)");
                        foreach (ManagementObject queryObj in searcher.Get())
                        {
                            if ((queryObj["Caption"] != null) && regExp.IsMatch(queryObj["Caption"].ToString()))
                            {
                                strs.Add(queryObj["Caption"].ToString());
                            }
                        }
                        break;
                    }
                    catch
                    {
                        Task.Delay(500).Wait();
                    }
                    //MessageBox.Show("fail了");
                }

                try
                {
                    foreach (string p in SerialPort.GetPortNames())//加上缺少的com口
                    {
                        bool notMatch = true;
                        foreach (string n in strs)
                        {
                            if (n.Contains($"({p})"))//如果和选中项目匹配
                            {
                                notMatch = false;
                                break;
                            }
                        }
                        if (notMatch)
                            strs.Add($"Serial Port {p} ({p})");//如果列表中没有，就自己加上
                    }
                }
                catch { }

                this.Invoke((MethodInvoker)delegate ()
                {
                    for (int i = 0; i < strs.Count; i++)
                    {
                        string name = strs[i];
                        cmbCom1.Items.Add(name);
                        cmbCom2.Items.Add(name);
                        if (name.Contains($"({com1.PortName})"))
                        {
                            cmbCom1.SelectedIndex = i;
                        }
                        if (name.Contains($"({com2.PortName})"))
                        {
                            cmbCom2.SelectedIndex = i;
                        }
                    }
                    if (strs.Count >= 1)
                    {
                        cmbCom1.SelectedIndex = cmbCom1.SelectedIndex == -1 ? 0 : cmbCom1.SelectedIndex;
                        cmbCom2.SelectedIndex = cmbCom2.SelectedIndex == -1 ? 0 : cmbCom2.SelectedIndex;
                        btnCom1.Enabled=btnCom2.Enabled = true;
                    }
                    else
                    {
                        btnCom1.Enabled = btnCom2.Enabled = false;
                    }
                    refreshLock = false;

                });

            });
        }
      
    }
}
