using DotNet.Utilities;
using ITLDG.DataCheck;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SerialPortForward
{
    public partial class FrmMain : Form
    {
        private Dictionary<string, string> dicCache = new Dictionary<string, string>();
        private string lastSendHex = "";
        string iniFile = Application.StartupPath + "\\config.ini";
        string pluginDir = Application.StartupPath + "\\plugins\\";
        List<IPlugin> listPlugins = new List<IPlugin>();
        List<Plugin> listCheckPlugins = new List<Plugin>();
        string CheckToolPath = "";
        int tipIndex = -1;
        string[] tips = new string[] { "本软件主要作用是转发两个串口的数据,搭配虚拟串口更好用", "校验位如果不是增加在末尾,请在HEX中填写一个错误的校验占位", "定时发送时间设置不要过小,否则可能会引起卡顿" };
        int pluginIndex = -1;
        /// <summary>
        /// 记录数据
        /// </summary>
        bool RecordData = false;
        /// <summary>
        /// 自动应答
        /// </summary>
        bool AutoAnswer = false;
        public FrmMain()
        {
            InitializeComponent();
        }
        SerialPortInfo com1 = new SerialPortInfo(), com2 = new SerialPortInfo(), timerCom;
        byte[] timerSendBytes = new byte[0];
        string timerSendToName = "";
        string com1Name = "", com2Name = "";
        bool com1Forward = true, com2Forward = true;
        PluginCommon pluginCommon;
        bool SerialCheck()
        {
            string com1NameTemp = GetCom(cmbCom1.Text);
            string com2NameTemp = GetCom(cmbCom2.Text);
            if (string.IsNullOrEmpty(com1NameTemp) || string.IsNullOrEmpty(com2NameTemp))
            {
                MessageBox.Show("未获取到串口号,不可以打开空的串口", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void Com2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedHandle(com2Name, false, com2Forward, com2, com1);
        }

        private void Com1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceivedHandle(com1Name, true, com1Forward, com1, com2);
        }
        /// <summary>
        /// 串口收到数据
        /// </summary>
        /// <param name="name">串口名称</param>
        /// <param name="isCom1">是否是串口1</param>
        /// <param name="openForward">是否勾选了转发</param>
        /// <param name="spReceive">收到消息的串口</param>
        /// <param name="spSend">准备转发的串口</param>
        void DataReceivedHandle(string name, bool isCom1, bool openForward, SerialPortInfo spReceive, SerialPortInfo spSend)
        {
            if (spReceive.CloseIng) { return; }
            try
            {
                spReceive.Listening = true;
                if (spReceive.TimeOut > 0)
                {
                    System.Threading.Thread.Sleep(spReceive.TimeOut);
                }
                //分包写法
                List<byte> result = new List<byte>();
                while (true)//循环读
                {
                    if (spReceive.CloseIng || !spReceive.IsOpen)//串口被关了，不读了
                    {
                        break;
                    }
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
                        if (result.Count > 1024)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }//崩了？

                    if (spReceive.TimeOut > 0)
                    {
                        System.Threading.Thread.Sleep(spReceive.TimeOut);
                    }
                }
                if (result.Count == 0)
                {
                    return;
                }

                byte[] byteRead = result.ToArray();
                AddLog(byteRead, name, isCom1, openForward, spReceive, spSend);
            }
            finally
            {
                spReceive.Listening = false;
            }

        }

        Regex regGetComName = new Regex("\\((COM(\\d+))\\)");
        public string GetCom(string ComName)
        {
            Match match = regGetComName.Match(ComName);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return "";
        }

        private void btnMoreSerialOption_Click(object sender, EventArgs e)
        {
            if (!com1.IsOpen && !com2.IsOpen)
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
        void SaveOption()
        {
            INIFileHelper ini = new INIFileHelper(iniFile);
            ini.IniWriteValue("Option", "Plugin", cmbPlugins.Text);
            ini.IniWriteValue("Option", "SendTo", cmbSendTo.SelectedIndex.ToString());
            ini.IniWriteValue("Option", "SendHex", txtSendHex.Text);
            ini.IniWriteValue("Option", "Timer", nudSend.Value.ToString());
            ini.IniWriteValue("Option", "CheckPlugin", cmbCheck.Text.ToString());
            ini.IniWriteValue("Option", "CheckStart", nudCheckStart.Value.ToString());
            ini.IniWriteValue("Option", "CheckEnd", nudCheckEnd.Value.ToString());
            ini.IniWriteValue("Option", "CheckToolPath", CheckToolPath);
            ini.IniWriteValue("Option", "RecordData", RecordData.ToString());
            ini.IniWriteValue("Option", "AutoAnswer", AutoAnswer.ToString());

            ini.IniWriteValue("Log", "Enable", serialLog1.LogEnable.ToString());
            ini.IniWriteValue("Log", "AutoScroll", serialLog1.LogAutoScroll.ToString());
            ini.IniWriteValue("Log", "LogType", ((int)serialLog1.SerialLogType).ToString());

        }
        void ReadOption()
        {
            INIFileHelper ini = new INIFileHelper(iniFile);
            string plugin = ini.IniReadValue("Option", "Plugin", "");
            cmbSendTo.SelectedIndex = Convert.ToInt32(ini.IniReadValue("Option", "SendTo", "0"));
            txtSendHex.Text = ini.IniReadValue("Option", "SendHex", "");
            for (int i = 0; i < cmbPlugins.Items.Count; i++)
            {
                if (cmbPlugins.Items[i].ToString() == plugin)
                {
                    cmbPlugins.SelectedIndex = i;
                    break;
                }
            }
            if (cmbPlugins.SelectedIndex < 0 && cmbPlugins.Items.Count > 0) { cmbPlugins.SelectedIndex = 0; }

            CheckToolPath = ini.IniReadValue("Option", "CheckToolPath", "");
            nudSend.Value = Convert.ToInt32(ini.IniReadValue("Option", "Timer", "1000"));
            nudCheckStart.Value = Convert.ToInt32(ini.IniReadValue("Option", "CheckStart", "1"));
            nudCheckEnd.Value = Convert.ToInt32(ini.IniReadValue("Option", "CheckEnd", "0"));
            string checkPlugin = ini.IniReadValue("Option", "CheckPlugin", "None");
            for (int i = 1; i < cmbCheck.Items.Count; i++)
            {
                if (cmbCheck.Items[i].ToString() == checkPlugin)
                {
                    cmbCheck.SelectedIndex = i;
                    break;
                }
            }

            chkRecordData.Checked = ini.IniReadValue("Option", "RecordData", "False") == "True";
            chkAutoAnswer.Checked = ini.IniReadValue("Option", "AutoAnswer", "False") == "True";

            serialLog1.LogEnable = ini.IniReadValue("Log", "Enable", "True") == "True";
            serialLog1.LogAutoScroll = ini.IniReadValue("Log", "AutoScroll", "True") == "True";
            serialLog1.SerialLogType = (ITLDG.SerialLog.LogType)Convert.ToInt32(ini.IniReadValue("Log", "LogType", "0"));
        }
        void SaveSerialOption()
        {
            INIFileHelper ini = new INIFileHelper(iniFile);
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

            ini.IniWriteValue("Com1", "Name", com1Name);
            ini.IniWriteValue("Com2", "Name", com2Name);

            ini.IniWriteValue("Com1", "Forward", com1Forward.ToString());
            ini.IniWriteValue("Com2", "Forward", com2Forward.ToString());
        }

        void SerialOtherRead(INIFileHelper ini)
        {
            txtName1.Text = ini.IniReadValue("Com1", "Name", "");
            txtName2.Text = ini.IniReadValue("Com2", "Name", "");

            chkForward1.Checked = Convert.ToBoolean(ini.IniReadValue("Com1", "Forward", "true"));
            chkForward2.Checked = Convert.ToBoolean(ini.IniReadValue("Com2", "Forward", "true"));
        }
        void ReadSerialOption()
        {
            INIFileHelper ini = new INIFileHelper(iniFile);
            SerialRead(com1, "Com1", cmbBaudRate1, ini);
            SerialRead(com2, "Com2", cmbBaudRate2, ini);
            SerialOtherRead(ini);
        }
        void SerialRead(SerialPortInfo sp, string Name, ComboBox cmb, INIFileHelper ini)
        {
            sp.PortName = ini.IniReadValue(Name, "PortName", sp.PortName.ToString());
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
        void LoadPlugins()
        {
            pluginCommon = new PluginCommon(com1, com2, PluginWrite);
            string[] files = Directory.GetFiles(Application.StartupPath + "\\Plugins", "*.dll");
            foreach (string file in files)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.GetInterface("IPlugin") != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            listPlugins.Add(plugin);
                            cmbPlugins.Items.Add(plugin.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("加载插件失败：" + ex.Message);
                }
            }
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                ReadSerialOption();
                cmbSendTo.Items[0] = com1Name;
                cmbSendTo.Items[1] = com2Name;
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取配置文件失败：" + ex.Message);
            }
            refreshPortList();
            LoadPlugins();
            InitCheckPlugins();
            ReadOption();
            NextTip();
        }

        void InitCheckPlugins()
        {

            listCheckPlugins = Plugin.GePlugins();
            listCheckPlugins = listCheckPlugins.OrderBy(x => x.Name).ToList();
            cmbCheck.Items.Clear();
            cmbCheck.Items.Add("None");
            cmbCheck.Items.AddRange(listCheckPlugins.ToArray());
            cmbCheck.SelectedIndex = 0;
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
            cmbSendTo.Items[0] = com1Name;
        }

        private void txtName2_TextChanged(object sender, EventArgs e)
        {
            com2Name = txtName2.Text;
            cmbSendTo.Items[1] = com2Name;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(pluginDir))
            {
                Directory.CreateDirectory(pluginDir);
            }
            Text += " V" + Application.ProductVersion;
        }
        void PluginWrite(IPlugin plugin, bool isCom1, byte[] bytes)
        {
            string hex = ByteToHex(bytes);
            Color color = Color.DarkGreen; 
            if (!isCom1)
            {
                color = Color.DarkBlue;
            }
            serialLog1.AddLog(plugin.Name, color, hex);

            SerialPortInfo sp = com1;
            if (!isCom1)
            {
                sp = com2;
            }
            if (sp == null || !sp.IsOpen)
            {
                return;
            }
            sp.Write(bytes, 0, bytes.Length);
            
            

        }
        /// <summary>
        /// 串口添加日志并转发
        /// </summary>
        /// <param name="data">收到的数据</param>
        /// <param name="name">串口名称</param>
        /// <param name="isCom1">是否是串口1</param>
        /// <param name="openForward">是否勾选了转发</param>
        /// <param name="spReceive">收到数据的串口</param>
        /// <param name="spSend">将转发到的串口</param>
        /// <param name="isAuto">这条消息是否来自自动回复</param>
        private void AddLog(byte[] data, string name, bool isCom1, bool openForward, SerialPort spReceive, SerialPort spSend, bool isAuto = false)
        {

            byte[] rep = null;
            if (!isAuto && pluginIndex >= 0)
            {
                try
                {
                    rep = listPlugins[pluginIndex].GetBytes(isCom1, name, ref data);
                }
                catch (Exception ex)
                {
                    serialLog1.AddLog(listPlugins[pluginIndex].Name + " 插件处理异常", Color.DarkRed, Encoding.Default.GetBytes(ex.Message));
                }

            }
            string hex = ByteToHex(data);
            Color color = Color.DarkBlue;
            if (!isCom1)
            {
                color = Color.DarkGreen;
            }
            serialLog1.AddLog(name, color, hex);
            if (isAuto) { return; }
            if (rep != null && rep.Length > 0)
            {
                spReceive.Write(rep, 0, rep.Length);
                AddLog(rep, "插件答复", isCom1: !isCom1, openForward: openForward, spSend, spReceive, true);
                return;
            }
            if (isCom1 && AutoAnswer && dicCache.ContainsKey(hex))
            {
                byte[] array = HexToByte(dicCache[hex]);
                spReceive.Write(array, 0, array.Length);
                AddLog(array, "自动应答-" + com2Name, isCom1: false, openForward: false, spSend, spReceive, true);
                return;
            }

            //!hex.Contains("0D0D0A") &&


            if (isCom1)
            {
                lastSendHex = hex;
            }
            else if (RecordData && !string.IsNullOrEmpty(lastSendHex))
            {
                if (dicCache.ContainsKey(lastSendHex))
                {
                    dicCache[lastSendHex] = hex;
                }
                else
                {
                    dicCache.Add(lastSendHex, hex);
                }
                Invoke((MethodInvoker)delegate
                {
                    UpCacheCount();

                });
            }
            if (openForward && spSend.IsOpen)
            {
                spSend.Write(data, 0, data.Length);
            }
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
            String str = "";
            hex = hex.Replace(" ", "");
            int j = hex.Length;

            for (int i = 0; i < j - 1; i += 2)
            {
                int asciiCode1 = Convert.ToInt32(hex.Substring(i, 2), 16);

                string strCharacter;
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

            byte[] ba = Encoding.Default.GetBytes(asciiCode);
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
                    if (com2.IsOpen && cmbCom1.Text == cmbCom2.Text)
                    {
                        MessageBox.Show("不可转发两个相同的串口", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        com1.PortName = com1NameTemp;
                        com1.BaudRate = Convert.ToInt32(cmbBaudRate1.Text);
                        if (com1.Timer > 0)
                        {
                            timerCom1.Interval = com1.Timer;
                            timerCom1.Enabled = true;
                        }
                        else
                        {
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
                }
                catch (Exception)
                {
                }
                cmbCom1.Enabled = true;
                btnCom1.Text = "打开";
            }
            CheckSendEnable();
        }

        private void btnCom2_Click(object sender, EventArgs e)
        {
            if (btnCom2.Text == "打开")
            {

                if (SerialCheck())
                {
                    if (com1.IsOpen && cmbCom1.Text == cmbCom2.Text)
                    {
                        MessageBox.Show("不可转发两个相同的串口", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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
                }
                catch (Exception)
                {
                }
                cmbCom2.Enabled = true;
                btnCom2.Text = "打开";
            }
            CheckSendEnable();
        }

        void CheckSendEnable()
        {
            bool enable = false;
            if (cmbSendTo.SelectedIndex == 0 && com1.IsOpen)
            {
                enable = true;
            }
            else if (cmbSendTo.SelectedIndex == 1 && com2.IsOpen)
            {
                enable = true;
            }
            btnSend.Enabled = enable;
            if (!enable)
            {
                timerSend.Enabled = false;
                chkTimer.Checked = false;
            }
            chkTimer.Enabled = enable;
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
        void DataShow(string name, bool isCom1, bool openForward, SerialPortInfo spReceive, SerialPortInfo spSend)
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

                AddLog(rev, name, isCom1, openForward, spReceive, spSend);
            }
            catch (Exception)
            {
                return;
            }//崩了？
        }


        private void btnLoadCache_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void UpCacheCount()
        {
            lblDataCount.Text = dicCache.Count.ToString();
        }
        private void Import()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "请选择缓存文件",
                Filter = "缓存数据|*.json"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dicCache.Clear();
                    string jsonStr = File.ReadAllText(ofd.FileName);
                    dicCache = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonStr);
                    UpCacheCount();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "加载失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "选择保存路径",
                Filter = "缓存数据|*.json"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string jsonStr = JsonConvert.SerializeObject(dicCache);
                    File.WriteAllText(sfd.FileName, jsonStr);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cmbPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pluginIndex>=0)
            {
                try
                {
                    listPlugins[pluginIndex].UnCheck();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "插件错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            pluginIndex = cmbPlugins.SelectedIndex;
            btnPluginOption.Enabled = listPlugins[pluginIndex].HasOption;
            listPlugins[pluginIndex].Checked(pluginCommon);
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            dicCache.Clear();
            UpCacheCount();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveOption();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!txtSendHex.IsHex())
            {
                return;
            }
            timerSendToName = cmbSendTo.Text;
            SerialPortInfo sp = com1;
            if (cmbSendTo.SelectedIndex == 1)
            {
                sp = com2;
            }
            byte[] bytes = GetSendBytes();
            DebugSend(sp, bytes);
        }
        byte[] GetSendBytes()
        {
            byte[] bytes = HexToByte(txtSendHex.Text);
            if (cmbCheck.SelectedIndex <= 0)
            {
                return bytes;
            }
            int start = (int)nudCheckStart.Value;
            int end = (int)nudCheckEnd.Value;
            if (start < 0 || end < 0 || start > bytes.Length || end >= bytes.Length)
            {
                return bytes;
            }
            int bytesLength = (bytes.Length - end) - start + 1;
            byte[] bytesCheck = new byte[bytesLength];
            Array.Copy(bytes, start - 1, bytesCheck, 0, bytesLength);

            int checkIndex = cmbCheck.SelectedIndex - 1;
            byte[] bytesCheckResult = listCheckPlugins[checkIndex].CheckData(bytesCheck);
            List<byte> listBytes = new List<byte>();
            listBytes.AddRange(bytes);
            if (end == 0)
            {
                listBytes.AddRange(bytesCheckResult);
            }
            else
            {
                end = bytes.Length - end;
                listBytes.RemoveRange(end, bytesCheckResult.Length);
                listBytes.InsertRange(end, bytesCheckResult);
            }

            return listBytes.ToArray();
        }
        private void lblDataCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool temp = RecordData;
            RecordData = false;
            FrmDatas frmDatas = new FrmDatas(dicCache);
            frmDatas.SaveDatasEvent += FrmDatas_SaveDatasEvent;
            frmDatas.ShowDialog();
            UpCacheCount();
            RecordData = temp;
        }

        private void FrmDatas_SaveDatasEvent(Dictionary<string, string> dic)
        {
            dicCache = dic;
        }

        private void chkTimer_CheckedChanged(object sender, EventArgs e)
        {

            if (chkTimer.Checked && (txtSendHex.Text == "" || !txtSendHex.IsHex()))
            {
                MessageBox.Show("请先输入正确的HEX字符串", "发送消息错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkTimer.Checked = false;
                return;
            }

            if (chkTimer.Checked)
            {
                timerSendBytes = GetSendBytes();
                timerSend.Interval = (int)nudSend.Value;
                timerSendToName = cmbSendTo.Text;
            }
            txtSendHex.Enabled = cmbCheck.Enabled = nudCheckStart.Enabled = nudCheckEnd.Enabled = cmbSendTo.Enabled = !chkTimer.Checked;
            timerSend.Enabled = chkTimer.Checked;
        }

        private void cmbSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerCom = com1;
            if (cmbSendTo.SelectedIndex == 1)
            {
                timerCom = com2;
            }
            CheckSendEnable();
        }

        private void nudSend_ValueChanged(object sender, EventArgs e)
        {
            timerSend.Interval = (int)nudSend.Value;
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            DebugSend(timerCom, timerSendBytes);
        }

        private void tsslTip_MouseHover(object sender, EventArgs e)
        {
            timerTip.Enabled = false;
        }

        private void tsslTip_MouseLeave(object sender, EventArgs e)
        {
            timerTip.Enabled = true;
        }

        private void timerTip_Tick(object sender, EventArgs e)
        {
            NextTip();
        }
        void NextTip()
        {
            tipIndex++;
            if (tipIndex >= tips.Length)
            {
                tipIndex = 0;
            }
            tsslTip.Text = tips[tipIndex];
        }

        private void btnCheckTool_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CheckToolPath) && File.Exists("CheckTool.exe"))
            {
                Process.Start("CheckTool.exe");
                return;
            }
            if (File.Exists(CheckToolPath))
            {
                Process.Start(CheckToolPath);
                return;
            }
            if (MessageBox.Show("工具路径未配置或不存在,是否立即配置?", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "exe文件|*.exe";
            openFileDialog.Title = "选择校验工具";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CheckToolPath = openFileDialog.FileName;
                Process.Start(CheckToolPath);
            }
        }

        private void chkRecordData_CheckedChanged(object sender, EventArgs e)
        {
            RecordData = chkRecordData.Checked;
        }

        private void chkAutoAnswer_CheckedChanged(object sender, EventArgs e)
        {
            AutoAnswer = chkAutoAnswer.Checked;
        }

        private void btnPluginOption_Click(object sender, EventArgs e)
        {
            listPlugins[pluginIndex].Option();
        }

        void DebugSend(SerialPortInfo sp, byte[] bytes)
        {
            if (sp == null || !sp.IsOpen)
            {
                return;
            }
            if (sp == com2)
            {
                lastSendHex = ByteToHex(bytes);
            }
            sp.Write(bytes, 0, bytes.Length);
            serialLog1.AddLog("串口调试-" + timerSendToName, Color.OrangeRed, bytes);
        }
        void ComBaudChange(SerialPortInfo sp, ComboBox cmb)
        {
            if (int.TryParse(cmb.Text, out int baud))
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
                        foreach (ManagementObject queryObj in searcher.Get().Cast<ManagementObject>())
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
                        btnCom1.Enabled = btnCom2.Enabled = true;
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
