using ITLDG;

namespace SerialPortForward
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cmbBaudRate2 = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate1 = new System.Windows.Forms.ComboBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCom2 = new System.Windows.Forms.ComboBox();
            this.cmbCom1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMoreSerialOption = new System.Windows.Forms.Button();
            this.chkForward1 = new System.Windows.Forms.CheckBox();
            this.chkForward2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.btnCom1 = new System.Windows.Forms.Button();
            this.btnCom2 = new System.Windows.Forms.Button();
            this.serialLog1 = new ITLDG.SerialLog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataCount = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoAnswer = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.btnLoadCache = new System.Windows.Forms.Button();
            this.chkRecordData = new System.Windows.Forms.CheckBox();
            this.cmbPlugins = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSendTo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCheck = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudCheckStart = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nudCheckEnd = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCheckTool = new System.Windows.Forms.Button();
            this.chkTimer = new System.Windows.Forms.CheckBox();
            this.nudSend = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerTip = new System.Windows.Forms.Timer(this.components);
            this.txtSendHex = new ITLDG.HexTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPluginOption = new System.Windows.Forms.Button();
            this.btnBit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSend)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBaudRate2
            // 
            this.cmbBaudRate2.FormattingEnabled = true;
            this.cmbBaudRate2.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "43000",
            "57600",
            "76800",
            "115200",
            "128000",
            "230400",
            "256000",
            "460800",
            "921600",
            "1382400"});
            this.cmbBaudRate2.Location = new System.Drawing.Point(472, 33);
            this.cmbBaudRate2.Name = "cmbBaudRate2";
            this.cmbBaudRate2.Size = new System.Drawing.Size(69, 20);
            this.cmbBaudRate2.TabIndex = 30;
            this.cmbBaudRate2.TextChanged += new System.EventHandler(this.cmbBaudRate2_TextChanged);
            // 
            // cmbBaudRate1
            // 
            this.cmbBaudRate1.FormattingEnabled = true;
            this.cmbBaudRate1.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "43000",
            "57600",
            "76800",
            "115200",
            "128000",
            "230400",
            "256000",
            "460800",
            "921600",
            "1382400"});
            this.cmbBaudRate1.Location = new System.Drawing.Point(472, 5);
            this.cmbBaudRate1.Name = "cmbBaudRate1";
            this.cmbBaudRate1.Size = new System.Drawing.Size(69, 20);
            this.cmbBaudRate1.TabIndex = 31;
            this.cmbBaudRate1.TextChanged += new System.EventHandler(this.cmbBaudRate1_TextChanged);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(10, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(79, 24);
            this.btnReload.TabIndex = 27;
            this.btnReload.Text = "刷新串口";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(427, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "波特率：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "波特率：";
            // 
            // cmbCom2
            // 
            this.cmbCom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom2.FormattingEnabled = true;
            this.cmbCom2.Location = new System.Drawing.Point(224, 33);
            this.cmbCom2.Name = "cmbCom2";
            this.cmbCom2.Size = new System.Drawing.Size(197, 20);
            this.cmbCom2.TabIndex = 23;
            // 
            // cmbCom1
            // 
            this.cmbCom1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom1.FormattingEnabled = true;
            this.cmbCom1.Location = new System.Drawing.Point(224, 5);
            this.cmbCom1.Name = "cmbCom1";
            this.cmbCom1.Size = new System.Drawing.Size(197, 20);
            this.cmbCom1.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "串口2：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "串口1：";
            // 
            // btnMoreSerialOption
            // 
            this.btnMoreSerialOption.Location = new System.Drawing.Point(92, 3);
            this.btnMoreSerialOption.Name = "btnMoreSerialOption";
            this.btnMoreSerialOption.Size = new System.Drawing.Size(79, 24);
            this.btnMoreSerialOption.TabIndex = 32;
            this.btnMoreSerialOption.Text = "串口设置";
            this.btnMoreSerialOption.UseVisualStyleBackColor = true;
            this.btnMoreSerialOption.Click += new System.EventHandler(this.btnMoreSerialOption_Click);
            // 
            // chkForward1
            // 
            this.chkForward1.AutoSize = true;
            this.chkForward1.Checked = true;
            this.chkForward1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForward1.Location = new System.Drawing.Point(695, 8);
            this.chkForward1.Name = "chkForward1";
            this.chkForward1.Size = new System.Drawing.Size(48, 16);
            this.chkForward1.TabIndex = 33;
            this.chkForward1.Text = "转发";
            this.chkForward1.UseVisualStyleBackColor = true;
            this.chkForward1.CheckedChanged += new System.EventHandler(this.chkForward1_CheckedChanged);
            // 
            // chkForward2
            // 
            this.chkForward2.AutoSize = true;
            this.chkForward2.Checked = true;
            this.chkForward2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForward2.Location = new System.Drawing.Point(694, 36);
            this.chkForward2.Name = "chkForward2";
            this.chkForward2.Size = new System.Drawing.Size(48, 16);
            this.chkForward2.TabIndex = 33;
            this.chkForward2.Text = "转发";
            this.chkForward2.UseVisualStyleBackColor = true;
            this.chkForward2.CheckedChanged += new System.EventHandler(this.chkForward2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "别名：";
            // 
            // txtName1
            // 
            this.txtName1.Location = new System.Drawing.Point(580, 5);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(109, 21);
            this.txtName1.TabIndex = 35;
            this.txtName1.TextChanged += new System.EventHandler(this.txtName1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "别名：";
            // 
            // txtName2
            // 
            this.txtName2.Location = new System.Drawing.Point(580, 33);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(109, 21);
            this.txtName2.TabIndex = 35;
            this.txtName2.TextChanged += new System.EventHandler(this.txtName2_TextChanged);
            // 
            // btnCom1
            // 
            this.btnCom1.Location = new System.Drawing.Point(739, 4);
            this.btnCom1.Name = "btnCom1";
            this.btnCom1.Size = new System.Drawing.Size(56, 23);
            this.btnCom1.TabIndex = 37;
            this.btnCom1.Text = "打开";
            this.btnCom1.UseVisualStyleBackColor = true;
            this.btnCom1.Click += new System.EventHandler(this.btnCom1_Click);
            // 
            // btnCom2
            // 
            this.btnCom2.Location = new System.Drawing.Point(739, 33);
            this.btnCom2.Name = "btnCom2";
            this.btnCom2.Size = new System.Drawing.Size(56, 23);
            this.btnCom2.TabIndex = 37;
            this.btnCom2.Text = "打开";
            this.btnCom2.UseVisualStyleBackColor = true;
            this.btnCom2.Click += new System.EventHandler(this.btnCom2_Click);
            // 
            // serialLog1
            // 
            this.serialLog1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialLog1.Location = new System.Drawing.Point(10, 167);
            this.serialLog1.LogAutoScroll = true;
            this.serialLog1.LogEnable = true;
            this.serialLog1.MaxLogCount = 500;
            this.serialLog1.MinimumSize = new System.Drawing.Size(560, 200);
            this.serialLog1.Name = "serialLog1";
            this.serialLog1.SerialLogChineseFontFamily = "Microsoft YaHei";
            this.serialLog1.SerialLogEnglishFontFamily = "Consolas";
            this.serialLog1.SerialLogType = ITLDG.LogType.HEX_And_TEXT;
            this.serialLog1.Size = new System.Drawing.Size(785, 309);
            this.serialLog1.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDataCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkAutoAnswer);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClearCache);
            this.groupBox1.Controls.Add(this.btnLoadCache);
            this.groupBox1.Controls.Add(this.chkRecordData);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 49);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // lblDataCount
            // 
            this.lblDataCount.AutoSize = true;
            this.lblDataCount.Location = new System.Drawing.Point(466, 23);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(11, 12);
            this.lblDataCount.TabIndex = 6;
            this.lblDataCount.TabStop = true;
            this.lblDataCount.Text = "0";
            this.lblDataCount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDataCount_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前数据量：";
            // 
            // chkAutoAnswer
            // 
            this.chkAutoAnswer.AutoSize = true;
            this.chkAutoAnswer.Location = new System.Drawing.Point(283, 21);
            this.chkAutoAnswer.Name = "chkAutoAnswer";
            this.chkAutoAnswer.Size = new System.Drawing.Size(102, 16);
            this.chkAutoAnswer.TabIndex = 4;
            this.chkAutoAnswer.Text = "串口1自动应答";
            this.chkAutoAnswer.UseVisualStyleBackColor = true;
            this.chkAutoAnswer.CheckedChanged += new System.EventHandler(this.chkAutoAnswer_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(640, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存数据";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(91, 18);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(75, 23);
            this.btnClearCache.TabIndex = 2;
            this.btnClearCache.Text = "清空数据";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // btnLoadCache
            // 
            this.btnLoadCache.Location = new System.Drawing.Point(10, 18);
            this.btnLoadCache.Name = "btnLoadCache";
            this.btnLoadCache.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCache.TabIndex = 1;
            this.btnLoadCache.Text = "加载数据";
            this.btnLoadCache.UseVisualStyleBackColor = true;
            this.btnLoadCache.Click += new System.EventHandler(this.btnLoadCache_Click);
            // 
            // chkRecordData
            // 
            this.chkRecordData.AutoSize = true;
            this.chkRecordData.Location = new System.Drawing.Point(173, 21);
            this.chkRecordData.Name = "chkRecordData";
            this.chkRecordData.Size = new System.Drawing.Size(102, 16);
            this.chkRecordData.TabIndex = 0;
            this.chkRecordData.Text = "串口2记录数据";
            this.chkRecordData.UseVisualStyleBackColor = true;
            this.chkRecordData.CheckedChanged += new System.EventHandler(this.chkRecordData_CheckedChanged);
            // 
            // cmbPlugins
            // 
            this.cmbPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlugins.FormattingEnabled = true;
            this.cmbPlugins.Location = new System.Drawing.Point(47, 33);
            this.cmbPlugins.Name = "cmbPlugins";
            this.cmbPlugins.Size = new System.Drawing.Size(90, 20);
            this.cmbPlugins.TabIndex = 41;
            this.cmbPlugins.SelectedIndexChanged += new System.EventHandler(this.cmbPlugins_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "串口调试：";
            // 
            // cmbSendTo
            // 
            this.cmbSendTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSendTo.FormattingEnabled = true;
            this.cmbSendTo.Items.AddRange(new object[] {
            "串口1",
            "串口2"});
            this.cmbSendTo.Location = new System.Drawing.Point(73, 89);
            this.cmbSendTo.Name = "cmbSendTo";
            this.cmbSendTo.Size = new System.Drawing.Size(98, 20);
            this.cmbSendTo.TabIndex = 41;
            this.cmbSendTo.SelectedIndexChanged += new System.EventHandler(this.cmbSendTo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "内 容：";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(739, 88);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(56, 23);
            this.btnSend.TabIndex = 37;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "校 验：";
            // 
            // cmbCheck
            // 
            this.cmbCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheck.FormattingEnabled = true;
            this.cmbCheck.Location = new System.Drawing.Point(224, 60);
            this.cmbCheck.Name = "cmbCheck";
            this.cmbCheck.Size = new System.Drawing.Size(197, 20);
            this.cmbCheck.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(427, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 44;
            this.label12.Text = "校验第";
            // 
            // nudCheckStart
            // 
            this.nudCheckStart.Location = new System.Drawing.Point(469, 60);
            this.nudCheckStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCheckStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCheckStart.Name = "nudCheckStart";
            this.nudCheckStart.Size = new System.Drawing.Size(52, 21);
            this.nudCheckStart.TabIndex = 45;
            this.nudCheckStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(526, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 12);
            this.label13.TabIndex = 46;
            this.label13.Text = "个字节至末尾倒数第";
            // 
            // nudCheckEnd
            // 
            this.nudCheckEnd.Location = new System.Drawing.Point(640, 60);
            this.nudCheckEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCheckEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCheckEnd.Name = "nudCheckEnd";
            this.nudCheckEnd.Size = new System.Drawing.Size(52, 21);
            this.nudCheckEnd.TabIndex = 45;
            this.nudCheckEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(695, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 47;
            this.label14.Text = "个字节";
            // 
            // btnCheckTool
            // 
            this.btnCheckTool.Location = new System.Drawing.Point(739, 60);
            this.btnCheckTool.Name = "btnCheckTool";
            this.btnCheckTool.Size = new System.Drawing.Size(56, 23);
            this.btnCheckTool.TabIndex = 48;
            this.btnCheckTool.Text = "工具";
            this.btnCheckTool.UseVisualStyleBackColor = true;
            this.btnCheckTool.Click += new System.EventHandler(this.btnCheckTool_Click);
            // 
            // chkTimer
            // 
            this.chkTimer.AutoSize = true;
            this.chkTimer.Location = new System.Drawing.Point(15, 62);
            this.chkTimer.Name = "chkTimer";
            this.chkTimer.Size = new System.Drawing.Size(60, 16);
            this.chkTimer.TabIndex = 49;
            this.chkTimer.Text = "定时发";
            this.chkTimer.UseVisualStyleBackColor = true;
            this.chkTimer.CheckedChanged += new System.EventHandler(this.chkTimer_CheckedChanged);
            // 
            // nudSend
            // 
            this.nudSend.Location = new System.Drawing.Point(74, 60);
            this.nudSend.Maximum = new decimal(new int[] {
            -159383553,
            46653770,
            5421,
            0});
            this.nudSend.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSend.Name = "nudSend";
            this.nudSend.Size = new System.Drawing.Size(62, 21);
            this.nudSend.TabIndex = 50;
            this.nudSend.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSend.ValueChanged += new System.EventHandler(this.nudSend_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(136, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 51;
            this.label15.Text = "ms/次";
            // 
            // timerSend
            // 
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslTip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 479);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 52;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "小提示：";
            // 
            // tsslTip
            // 
            this.tsslTip.Name = "tsslTip";
            this.tsslTip.Size = new System.Drawing.Size(80, 17);
            this.tsslTip.Text = "欢迎您的使用";
            this.tsslTip.MouseLeave += new System.EventHandler(this.tsslTip_MouseLeave);
            this.tsslTip.MouseHover += new System.EventHandler(this.tsslTip_MouseHover);
            // 
            // timerTip
            // 
            this.timerTip.Enabled = true;
            this.timerTip.Interval = 5000;
            this.timerTip.Tick += new System.EventHandler(this.timerTip_Tick);
            // 
            // txtSendHex
            // 
            this.txtSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendHex.HexMode = true;
            this.txtSendHex.HexSeparator = ' ';
            this.txtSendHex.Location = new System.Drawing.Point(224, 89);
            this.txtSendHex.MaxHexLength = 10923;
            this.txtSendHex.MaxLength = 32768;
            this.txtSendHex.Name = "txtSendHex";
            this.txtSendHex.Size = new System.Drawing.Size(509, 21);
            this.txtSendHex.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "插件：";
            // 
            // btnPluginOption
            // 
            this.btnPluginOption.Location = new System.Drawing.Point(143, 32);
            this.btnPluginOption.Name = "btnPluginOption";
            this.btnPluginOption.Size = new System.Drawing.Size(28, 23);
            this.btnPluginOption.TabIndex = 53;
            this.btnPluginOption.Text = "⚙";
            this.btnPluginOption.UseVisualStyleBackColor = true;
            this.btnPluginOption.Click += new System.EventHandler(this.btnPluginOption_Click);
            // 
            // btnBit
            // 
            this.btnBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBit.Location = new System.Drawing.Point(739, 129);
            this.btnBit.Name = "btnBit";
            this.btnBit.Size = new System.Drawing.Size(56, 23);
            this.btnBit.TabIndex = 37;
            this.btnBit.Text = "位分析";
            this.btnBit.UseVisualStyleBackColor = true;
            this.btnBit.Click += new System.EventHandler(this.btnBit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 501);
            this.Controls.Add(this.btnPluginOption);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nudSend);
            this.Controls.Add(this.chkTimer);
            this.Controls.Add(this.btnCheckTool);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nudCheckEnd);
            this.Controls.Add(this.nudCheckStart);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSendHex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbSendTo);
            this.Controls.Add(this.cmbPlugins);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serialLog1);
            this.Controls.Add(this.btnBit);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCom2);
            this.Controls.Add(this.btnCom1);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMoreSerialOption);
            this.Controls.Add(this.cmbBaudRate2);
            this.Controls.Add(this.cmbBaudRate1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbCheck);
            this.Controls.Add(this.cmbCom2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbCom1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkForward2);
            this.Controls.Add(this.chkForward1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(825, 489);
            this.Name = "FrmMain";
            this.Text = "串口转发";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSend)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBaudRate2;
        private System.Windows.Forms.ComboBox cmbBaudRate1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCom2;
        private System.Windows.Forms.ComboBox cmbCom1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMoreSerialOption;
        private System.Windows.Forms.CheckBox chkForward1;
        private System.Windows.Forms.CheckBox chkForward2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.Button btnCom1;
        private System.Windows.Forms.Button btnCom2;
        private ITLDG.SerialLog serialLog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRecordData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAutoAnswer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.Button btnLoadCache;
        private System.Windows.Forms.ComboBox cmbPlugins;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSendTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSend;
        private HexTextBox txtSendHex;
        private System.Windows.Forms.LinkLabel lblDataCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCheck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudCheckStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudCheckEnd;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCheckTool;
        private System.Windows.Forms.CheckBox chkTimer;
        private System.Windows.Forms.NumericUpDown nudSend;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslTip;
        private System.Windows.Forms.Timer timerTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPluginOption;
        private System.Windows.Forms.Button btnBit;
    }
}

