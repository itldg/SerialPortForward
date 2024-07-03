using DotNet.Utilities;
using ITLDG;
using ITLDG.DataCheck;
using ITLDG.SerialPortExtend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortForward
{
    public partial class FrmMain : Form
    {
        private Dictionary<string, byte[]> dicCache = new Dictionary<string, byte[]>();
        private string lastSendHex = "";
        string iniFile = Application.StartupPath + "\\config.ini";
        string pluginDir = Application.StartupPath + "\\plugins\\";
        List<IPlugin> listPlugins = new List<IPlugin>();
        List<Plugin> listCheckPlugins = new List<Plugin>();
        string CheckToolPath = "";
        int tipIndex = -1;
        string[] tips = new string[] { "本软件主要作用是转发两个串口的数据,搭配虚拟串口更好用", "校验位如果不是增加在末尾,请在HEX中填写一个错误的校验占位", "定时发送时间设置不要过小,否则可能会引起卡顿" };
        //插件索引,-1为不使用插件
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

        void Com2_DataReceived(object sender, byte[] data)
        {
            DataReceivedHandle(com2Name, false, com2Forward, com2, com1, data);
        }

        void Com1_DataReceived(object sender, byte[] data)
        {
            DataReceivedHandle(com1Name, true, com1Forward, com1, com2, data);
        }
        /// <summary>
        /// 串口收到数据
        /// </summary>
        /// <param name="name">串口名称</param>
        /// <param name="isCom1">是否是串口1</param>
        /// <param name="openForward">是否勾选了转发</param>
        /// <param name="spReceive">收到消息的串口</param>
        /// <param name="spSend">准备转发的串口</param>
        /// <param name="data">收到的数据</param>
        void DataReceivedHandle(string name, bool isCom1, bool openForward, SerialPortInfo spReceive, SerialPortInfo spSend, byte[] data)
        {
            Task.Run(() =>
            {
                AddLog(data, name, isCom1, openForward, spReceive, spSend);
            });
        }

        Regex regGetComName = new Regex("^(COM(\\d+))", RegexOptions.Multiline);
        public string GetCom(string ComName)
        {
            //strs.Add(x.COM.PadRight(5, ' ') + " - " 
            Match match = regGetComName.Match(ComName);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return ComName;
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
            serialLog1.SerialLogType = (ITLDG.LogType)Convert.ToInt32(ini.IniReadValue("Log", "LogType", "0"));
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
            ini.IniWriteValue(Name, "IP", sp.IP.ToString());
            ini.IniWriteValue(Name, "Port", sp.Port.ToString());
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

            sp.IP = IPAddress.Parse(ini.IniReadValue(Name, "IP", "0.0.0.0"));
            sp.Port = Convert.ToInt32(ini.IniReadValue(Name, "Port", "8866"));
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
            cmbPlugins.Items.Add("不使用");
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
            com1.DataReceived += Com1_DataReceived;
            com2.DataReceived += Com2_DataReceived;
        }
        void PluginWrite(IPlugin plugin, bool isCom1, byte[] bytes)
        {
            string hex = bytes.GetString_HEX("");
            Color color = Color.DarkGreen;
            if (!isCom1)
            {
                color = Color.DarkBlue;
            }
            serialLog1.AddLog(plugin.Name, color, hex);
            BitAnalysis(bytes);

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
        private void AddLog(byte[] data, string name, bool isCom1, bool openForward, SerialPortInfo spReceive, SerialPortInfo spSend, bool isAuto = false)
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
            string hex = data.GetString_HEX("");
            Color color = Color.DarkBlue;
            if (!isCom1)
            {
                color = Color.DarkGreen;
            }
            serialLog1.AddLog(name, color, hex);
            BitAnalysis(data);
            if (isAuto) { return; }
            if (rep != null && rep.Length > 0)
            {
                BitAnalysis(rep);
                spReceive.Write(rep, 0, rep.Length);
                AddLog(rep, "插件答复", isCom1: !isCom1, openForward: openForward, spSend, spReceive, true);
                return;
            }
            if (isCom1 && AutoAnswer && dicCache.ContainsKey(hex))
            {
                spReceive.Write(dicCache[hex], 0, dicCache[hex].Length);
                BitAnalysis(dicCache[hex]);
                AddLog(dicCache[hex], "自动应答-" + com2Name, isCom1: false, openForward: false, spSend, spReceive, true);
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
                    dicCache[lastSendHex] = data;
                }
                else
                {
                    dicCache.Add(lastSendHex, data);
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

        void BitAnalysis(byte[] bytes)
        {
            if (frm != null && !frm.IsDisposed)
            {
                frm.NewData(bytes);
            }
        }
        void RunUI(Action action)
        {
            Invoke((MethodInvoker)delegate
            {
                action();

            });
        }
        void OpenSerial(SerialPortInfo sp, ComboBox cmbCom, ComboBox cmbBaudRate, Button btnCom)
        {

            if (cmbCom.SelectedIndex < 0)
            {
                MessageBox.Show("未获取到串口号,不可以打开空的串口", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string comNameTemp = GetCom(cmbCom.Text);
            if ((sp == com1 ? com2 : com1).IsOpen && cmbCom1.Text == cmbCom2.Text)
            {
                MessageBox.Show("不可转发两个相同的串口", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                sp.PortName = comNameTemp;
                sp.BaudRate = Convert.ToInt32(cmbBaudRate.Text);
                sp.Open();
                SaveSerialOption();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RunUI(() =>
            {
                cmbCom.Enabled = false;
                btnCom.Text = "关闭";
                CheckSendEnable();
            });

        }
        void CloseSerial(SerialPortInfo sp, ComboBox cmbCom, Button btnCom)
        {

            try
            {
                sp.Close();
            }
            catch (Exception)
            {
            }
            RunUI(() =>
            {
                cmbCom.Enabled = true;
                btnCom.Text = "打开";
                CheckSendEnable();
            });

        }
        private void btnCom1_Click(object sender, EventArgs e)
        {
            if (btnCom1.Text == "打开")
            {
                OpenSerial(com1, cmbCom1, cmbBaudRate1, btnCom1);
            }
            else
            {
                CloseSerial(com1, cmbCom1, btnCom1);
            }

        }

        private void btnCom2_Click(object sender, EventArgs e)
        {
            if (btnCom2.Text == "打开")
            {
                OpenSerial(com2, cmbCom2, cmbBaudRate2, btnCom2);
            }
            else
            {
                CloseSerial(com2, cmbCom2, btnCom2);
            }
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
                    Dictionary<string, string> dicCacheTemp = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonStr);
                    foreach (var item in dicCacheTemp)
                    {
                        dicCache.Add(item.Key.Replace(" ", ""), item.Value.Replace(" ", "").GetBytes_HEX());
                    }
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
                    Dictionary<string, string> dicJson = new Dictionary<string, string>();
                    foreach (var item in dicCache)
                    {
                        dicJson.Add(item.Key.GetBytes_HEX().GetString_HEX(), item.Value.GetString_HEX());
                    }
                    var settings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented
                    };
                    string jsonStr = JsonConvert.SerializeObject(dicJson, settings);
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
            if (pluginIndex >= 0)
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
            pluginIndex = cmbPlugins.SelectedIndex - 1;
            if (pluginIndex >= 0)
            {
                btnPluginOption.Enabled = listPlugins[pluginIndex].HasOption;
                listPlugins[pluginIndex].Checked(pluginCommon);
            }
            else
            {
                btnPluginOption.Enabled = false;
            }

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
            byte[] bytes = txtSendHex.Text.GetBytes_HEX();
            if (cmbCheck.SelectedIndex <= 0)
            {
                return bytes;
            }
            int start = (int)nudCheckStart.Value - 1;
            int end = (int)nudCheckEnd.Value - 1;
            if (start < 0 || end < 0 || start >= bytes.Length || end >= bytes.Length)
            {
                return bytes;
            }
            int bytesLength = (bytes.Length - end) - start;
            byte[] bytesCheck = new byte[bytesLength];
            Array.Copy(bytes, start, bytesCheck, 0, bytesLength);

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

        private void FrmDatas_SaveDatasEvent(Dictionary<string, byte[]> dic)
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
        FrmBitAnalysis frm;
        private void btnBit_Click(object sender, EventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmBitAnalysis();
            }
            frm.Show();
            frm.Activate();
        }

        void DebugSend(SerialPortInfo sp, byte[] bytes)
        {
            if (sp == null)
            {
                return;
            }
            if (!sp.IsOpen)
            {
                if (sp == com1)
                {
                    CloseSerial(com1, cmbCom1, btnCom1);
                }
                else
                {
                    CloseSerial(com2, cmbCom2, btnCom2);
                }
                return;
            }
            if (sp == com2)
            {
                lastSendHex = bytes.GetString_HEX("");
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
                SerialPortExtensions.GetPortNames().ForEach(x =>
                {
                    strs.Add(x.COM.PadRight(5, ' ') + " - " + x.Name);
                });
                strs.Add(SerialPortInfo.SERIAL_TCP_SERVER);
                strs.Add(SerialPortInfo.SERIAL_TCP_CLIENT);

                this.Invoke((MethodInvoker)delegate ()
                {
                    for (int i = 0; i < strs.Count; i++)
                    {
                        string name = strs[i];
                        cmbCom1.Items.Add(name);
                        cmbCom2.Items.Add(name);
                        if (name == com1.PortName || name.StartsWith(com1.PortName + " "))
                        {
                            cmbCom1.SelectedIndex = i;
                        }
                        if (name == com2.PortName || name.StartsWith(com2.PortName + " "))
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
