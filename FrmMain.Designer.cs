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
            this.serialLog1 = new ITLDG.SerialLog.SerialLog();
            this.timerCom1 = new System.Windows.Forms.Timer(this.components);
            this.timerCom2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoAnswer = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.btnLoadCache = new System.Windows.Forms.Button();
            this.chkAnalysis = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlugins = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
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
            this.btnReload.Location = new System.Drawing.Point(10, 5);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 24);
            this.btnReload.TabIndex = 27;
            this.btnReload.Text = "重载串口";
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
            this.btnMoreSerialOption.Location = new System.Drawing.Point(91, 5);
            this.btnMoreSerialOption.Name = "btnMoreSerialOption";
            this.btnMoreSerialOption.Size = new System.Drawing.Size(80, 24);
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
            this.serialLog1.Location = new System.Drawing.Point(10, 114);
            this.serialLog1.LogAutoScroll = true;
            this.serialLog1.LogEnable = true;
            this.serialLog1.MinimumSize = new System.Drawing.Size(560, 200);
            this.serialLog1.Name = "serialLog1";
            this.serialLog1.SerialLogChineseFontFamily = "Microsoft YaHei";
            this.serialLog1.SerialLogEnglishFontFamily = "Consolas";
            this.serialLog1.SerialLogType = ITLDG.SerialLog.LogType.HEX_And_TEXT;
            this.serialLog1.Size = new System.Drawing.Size(785, 375);
            this.serialLog1.TabIndex = 38;
            // 
            // timerCom1
            // 
            this.timerCom1.Tick += new System.EventHandler(this.timerCom1_Tick);
            // 
            // timerCom2
            // 
            this.timerCom2.Tick += new System.EventHandler(this.timerCom2_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDataCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkAutoAnswer);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClearCache);
            this.groupBox1.Controls.Add(this.btnLoadCache);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 49);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "协议分析";
            // 
            // lblDataCount
            // 
            this.lblDataCount.AutoSize = true;
            this.lblDataCount.Location = new System.Drawing.Point(443, 23);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(11, 12);
            this.lblDataCount.TabIndex = 6;
            this.lblDataCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前数据量：";
            // 
            // chkAutoAnswer
            // 
            this.chkAutoAnswer.AutoSize = true;
            this.chkAutoAnswer.Checked = true;
            this.chkAutoAnswer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoAnswer.Location = new System.Drawing.Point(172, 22);
            this.chkAutoAnswer.Name = "chkAutoAnswer";
            this.chkAutoAnswer.Size = new System.Drawing.Size(174, 16);
            this.chkAutoAnswer.TabIndex = 4;
            this.chkAutoAnswer.Text = "存在缓存的自动应答(串口1)";
            this.chkAutoAnswer.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(682, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存分析结果";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(91, 18);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(75, 23);
            this.btnClearCache.TabIndex = 2;
            this.btnClearCache.Text = "清空缓存";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // btnLoadCache
            // 
            this.btnLoadCache.Location = new System.Drawing.Point(10, 18);
            this.btnLoadCache.Name = "btnLoadCache";
            this.btnLoadCache.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCache.TabIndex = 1;
            this.btnLoadCache.Text = "加载旧数据";
            this.btnLoadCache.UseVisualStyleBackColor = true;
            this.btnLoadCache.Click += new System.EventHandler(this.btnLoadCache_Click);
            // 
            // chkAnalysis
            // 
            this.chkAnalysis.AutoSize = true;
            this.chkAnalysis.Location = new System.Drawing.Point(73, 59);
            this.chkAnalysis.Name = "chkAnalysis";
            this.chkAnalysis.Size = new System.Drawing.Size(15, 14);
            this.chkAnalysis.TabIndex = 0;
            this.chkAnalysis.UseVisualStyleBackColor = true;
            this.chkAnalysis.CheckedChanged += new System.EventHandler(this.chkAnalysis_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 40;
            this.label4.Text = "消息处理：";
            // 
            // cmbPlugins
            // 
            this.cmbPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlugins.FormattingEnabled = true;
            this.cmbPlugins.Location = new System.Drawing.Point(73, 33);
            this.cmbPlugins.Name = "cmbPlugins";
            this.cmbPlugins.Size = new System.Drawing.Size(98, 20);
            this.cmbPlugins.TabIndex = 41;
            this.cmbPlugins.SelectedIndexChanged += new System.EventHandler(this.cmbPlugins_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 501);
            this.Controls.Add(this.cmbPlugins);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAnalysis);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serialLog1);
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
            this.Controls.Add(this.cmbCom2);
            this.Controls.Add(this.cmbCom1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkForward2);
            this.Controls.Add(this.chkForward1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(825, 489);
            this.Name = "FrmMain";
            this.Text = "串口转发";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private ITLDG.SerialLog.SerialLog serialLog1;
        private System.Windows.Forms.Timer timerCom1;
        private System.Windows.Forms.Timer timerCom2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAnalysis;
        private System.Windows.Forms.Label lblDataCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAutoAnswer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.Button btnLoadCache;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlugins;
    }
}

