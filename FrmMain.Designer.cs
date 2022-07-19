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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnCopyLog = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCom1 = new System.Windows.Forms.Button();
            this.btnCom2 = new System.Windows.Forms.Button();
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
            this.btnReload.Location = new System.Drawing.Point(10, 6);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 46);
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
            this.btnMoreSerialOption.Location = new System.Drawing.Point(91, 6);
            this.btnMoreSerialOption.Name = "btnMoreSerialOption";
            this.btnMoreSerialOption.Size = new System.Drawing.Size(80, 46);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rtbLog);
            this.groupBox1.Controls.Add(this.chkAutoScroll);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 376);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志记录";
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbLog.Location = new System.Drawing.Point(3, 17);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(780, 356);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Checked = true;
            this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScroll.Location = new System.Drawing.Point(448, 0);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(72, 16);
            this.chkAutoScroll.TabIndex = 0;
            this.chkAutoScroll.Text = "自动滚动";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            this.chkAutoScroll.CheckedChanged += new System.EventHandler(this.chkAutoScroll_CheckedChanged);
            // 
            // btnCopyLog
            // 
            this.btnCopyLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyLog.Location = new System.Drawing.Point(629, 58);
            this.btnCopyLog.Name = "btnCopyLog";
            this.btnCopyLog.Size = new System.Drawing.Size(101, 23);
            this.btnCopyLog.TabIndex = 1;
            this.btnCopyLog.Text = "复制文本记录";
            this.btnCopyLog.UseVisualStyleBackColor = true;
            this.btnCopyLog.Click += new System.EventHandler(this.btnCopyLog_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(739, 58);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(548, 58);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(70, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "复制记录";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 450);
            this.Controls.Add(this.btnCom2);
            this.Controls.Add(this.btnCom1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCopyLog);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.Button btnCopyLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCom1;
        private System.Windows.Forms.Button btnCom2;
    }
}

