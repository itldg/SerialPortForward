namespace SerialPortForward
{
    partial class FrmMoreSerial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMoreSerial));
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudCom2Timer = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCom2RTS = new System.Windows.Forms.CheckBox();
            this.cbCom2DTR = new System.Windows.Forms.CheckBox();
            this.cmbCom2Parity = new System.Windows.Forms.ComboBox();
            this.cmbCom2Data = new System.Windows.Forms.ComboBox();
            this.cmbCom2Stop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudCom1Timer = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCom1RTS = new System.Windows.Forms.CheckBox();
            this.cbCom1DTR = new System.Windows.Forms.CheckBox();
            this.cmbCom1Parity = new System.Windows.Forms.ComboBox();
            this.cmbCom1Data = new System.Windows.Forms.ComboBox();
            this.cmbCom1Stop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudCom2TimeOut = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudCom1TimeOut = new System.Windows.Forms.NumericUpDown();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom2Timer)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom1Timer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom2TimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom1TimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(182, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudCom2TimeOut);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.nudCom2Timer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbCom2RTS);
            this.groupBox2.Controls.Add(this.cbCom2DTR);
            this.groupBox2.Controls.Add(this.cmbCom2Parity);
            this.groupBox2.Controls.Add(this.cmbCom2Data);
            this.groupBox2.Controls.Add(this.cmbCom2Stop);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(237, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 219);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口2";
            // 
            // nudCom2Timer
            // 
            this.nudCom2Timer.Location = new System.Drawing.Point(64, 161);
            this.nudCom2Timer.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudCom2Timer.Name = "nudCom2Timer";
            this.nudCom2Timer.Size = new System.Drawing.Size(120, 21);
            this.nudCom2Timer.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "轮询查：";
            // 
            // cbCom2RTS
            // 
            this.cbCom2RTS.AutoSize = true;
            this.cbCom2RTS.Location = new System.Drawing.Point(142, 193);
            this.cbCom2RTS.Name = "cbCom2RTS";
            this.cbCom2RTS.Size = new System.Drawing.Size(42, 16);
            this.cbCom2RTS.TabIndex = 5;
            this.cbCom2RTS.Text = "RTS";
            this.cbCom2RTS.UseVisualStyleBackColor = true;
            // 
            // cbCom2DTR
            // 
            this.cbCom2DTR.AutoSize = true;
            this.cbCom2DTR.Location = new System.Drawing.Point(63, 193);
            this.cbCom2DTR.Name = "cbCom2DTR";
            this.cbCom2DTR.Size = new System.Drawing.Size(42, 16);
            this.cbCom2DTR.TabIndex = 4;
            this.cbCom2DTR.Text = "DTR";
            this.cbCom2DTR.UseVisualStyleBackColor = true;
            // 
            // cmbCom2Parity
            // 
            this.cmbCom2Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom2Parity.FormattingEnabled = true;
            this.cmbCom2Parity.Items.AddRange(new object[] {
            "无校验(None)",
            "奇校验(Odd)",
            "偶校验(Even)",
            "高电平(Mark)",
            "低电平(Space)"});
            this.cmbCom2Parity.Location = new System.Drawing.Point(63, 103);
            this.cmbCom2Parity.Name = "cmbCom2Parity";
            this.cmbCom2Parity.Size = new System.Drawing.Size(121, 20);
            this.cmbCom2Parity.TabIndex = 3;
            // 
            // cmbCom2Data
            // 
            this.cmbCom2Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom2Data.FormattingEnabled = true;
            this.cmbCom2Data.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cmbCom2Data.Location = new System.Drawing.Point(63, 68);
            this.cmbCom2Data.Name = "cmbCom2Data";
            this.cmbCom2Data.Size = new System.Drawing.Size(121, 20);
            this.cmbCom2Data.TabIndex = 2;
            // 
            // cmbCom2Stop
            // 
            this.cmbCom2Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom2Stop.FormattingEnabled = true;
            this.cmbCom2Stop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmbCom2Stop.Location = new System.Drawing.Point(63, 31);
            this.cmbCom2Stop.Name = "cmbCom2Stop";
            this.cmbCom2Stop.Size = new System.Drawing.Size(121, 20);
            this.cmbCom2Stop.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "校验位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "停止位：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudCom1TimeOut);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.nudCom1Timer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbCom1RTS);
            this.groupBox1.Controls.Add(this.cbCom1DTR);
            this.groupBox1.Controls.Add(this.cmbCom1Parity);
            this.groupBox1.Controls.Add(this.cmbCom1Data);
            this.groupBox1.Controls.Add(this.cmbCom1Stop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 219);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口1";
            // 
            // nudCom1Timer
            // 
            this.nudCom1Timer.Location = new System.Drawing.Point(63, 164);
            this.nudCom1Timer.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudCom1Timer.Name = "nudCom1Timer";
            this.nudCom1Timer.Size = new System.Drawing.Size(120, 21);
            this.nudCom1Timer.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "轮询查：";
            // 
            // cbCom1RTS
            // 
            this.cbCom1RTS.AutoSize = true;
            this.cbCom1RTS.Location = new System.Drawing.Point(142, 193);
            this.cbCom1RTS.Name = "cbCom1RTS";
            this.cbCom1RTS.Size = new System.Drawing.Size(42, 16);
            this.cbCom1RTS.TabIndex = 5;
            this.cbCom1RTS.Text = "RTS";
            this.cbCom1RTS.UseVisualStyleBackColor = true;
            // 
            // cbCom1DTR
            // 
            this.cbCom1DTR.AutoSize = true;
            this.cbCom1DTR.Location = new System.Drawing.Point(63, 193);
            this.cbCom1DTR.Name = "cbCom1DTR";
            this.cbCom1DTR.Size = new System.Drawing.Size(42, 16);
            this.cbCom1DTR.TabIndex = 4;
            this.cbCom1DTR.Text = "DTR";
            this.cbCom1DTR.UseVisualStyleBackColor = true;
            // 
            // cmbCom1Parity
            // 
            this.cmbCom1Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom1Parity.FormattingEnabled = true;
            this.cmbCom1Parity.Items.AddRange(new object[] {
            "无校验(None)",
            "奇校验(Odd)",
            "偶校验(Even)",
            "高电平(Mark)",
            "低电平(Space)"});
            this.cmbCom1Parity.Location = new System.Drawing.Point(63, 103);
            this.cmbCom1Parity.Name = "cmbCom1Parity";
            this.cmbCom1Parity.Size = new System.Drawing.Size(121, 20);
            this.cmbCom1Parity.TabIndex = 3;
            // 
            // cmbCom1Data
            // 
            this.cmbCom1Data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom1Data.FormattingEnabled = true;
            this.cmbCom1Data.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cmbCom1Data.Location = new System.Drawing.Point(63, 68);
            this.cmbCom1Data.Name = "cmbCom1Data";
            this.cmbCom1Data.Size = new System.Drawing.Size(121, 20);
            this.cmbCom1Data.TabIndex = 2;
            // 
            // cmbCom1Stop
            // 
            this.cmbCom1Stop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom1Stop.FormattingEnabled = true;
            this.cmbCom1Stop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmbCom1Stop.Location = new System.Drawing.Point(63, 31);
            this.cmbCom1Stop.Name = "cmbCom1Stop";
            this.cmbCom1Stop.Size = new System.Drawing.Size(121, 20);
            this.cmbCom1Stop.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "校验位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据位：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "停止位：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(401, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "* 如果轮询查不等于0，串口收到数据将不会进入中断,需要自行时钟内处理";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "合并包：";
            // 
            // nudCom2TimeOut
            // 
            this.nudCom2TimeOut.Location = new System.Drawing.Point(64, 132);
            this.nudCom2TimeOut.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudCom2TimeOut.Name = "nudCom2TimeOut";
            this.nudCom2TimeOut.Size = new System.Drawing.Size(120, 21);
            this.nudCom2TimeOut.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "合并包：";
            // 
            // nudCom1TimeOut
            // 
            this.nudCom1TimeOut.Location = new System.Drawing.Point(64, 132);
            this.nudCom1TimeOut.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudCom1TimeOut.Name = "nudCom1TimeOut";
            this.nudCom1TimeOut.Size = new System.Drawing.Size(120, 21);
            this.nudCom1TimeOut.TabIndex = 7;
            // 
            // FrmMoreSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 317);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMoreSerial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更多串口设置";
            this.Load += new System.EventHandler(this.FrmMoreSerial_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom2Timer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom1Timer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom2TimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCom1TimeOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbCom2RTS;
        private System.Windows.Forms.CheckBox cbCom2DTR;
        private System.Windows.Forms.ComboBox cmbCom2Parity;
        private System.Windows.Forms.ComboBox cmbCom2Data;
        private System.Windows.Forms.ComboBox cmbCom2Stop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbCom1RTS;
        private System.Windows.Forms.CheckBox cbCom1DTR;
        private System.Windows.Forms.ComboBox cmbCom1Parity;
        private System.Windows.Forms.ComboBox cmbCom1Data;
        private System.Windows.Forms.ComboBox cmbCom1Stop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudCom2Timer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudCom1Timer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudCom2TimeOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudCom1TimeOut;
        private System.Windows.Forms.Label label11;
    }
}