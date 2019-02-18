namespace 配置工具
{
    partial class 空调控制器
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
            this.panel_SerialPort = new System.Windows.Forms.Panel();
            this.button_IDChange = new System.Windows.Forms.Button();
            this.button_IDSwitch = new System.Windows.Forms.Button();
            this.pictureBox_IDStatus = new System.Windows.Forms.PictureBox();
            this.textBox_ID2 = new System.Windows.Forms.TextBox();
            this.label_ID2 = new System.Windows.Forms.Label();
            this.textBox_ID1 = new System.Windows.Forms.TextBox();
            this.label_ID1 = new System.Windows.Forms.Label();
            this.button_PortSwitch = new System.Windows.Forms.Button();
            this.pictureBox_PortStatus = new System.Windows.Forms.PictureBox();
            this.comboBox_PortName = new System.Windows.Forms.ComboBox();
            this.label_PortName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_KWhGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_KWh = new System.Windows.Forms.TextBox();
            this.button_RelaySwitch = new System.Windows.Forms.Button();
            this.label_KWh = new System.Windows.Forms.Label();
            this.pictureBox_RelayStatus = new System.Windows.Forms.PictureBox();
            this.comboBox_RelayChannel = new System.Windows.Forms.ComboBox();
            this.label_RelayChannel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox_IRSendStatus = new System.Windows.Forms.PictureBox();
            this.button_IRSend = new System.Windows.Forms.Button();
            this.comboBox_IRTemp = new System.Windows.Forms.ComboBox();
            this.label_IRTemp = new System.Windows.Forms.Label();
            this.comboBox_IRFan = new System.Windows.Forms.ComboBox();
            this.label_IRFan = new System.Windows.Forms.Label();
            this.button_IRStudy = new System.Windows.Forms.Button();
            this.pictureBox_IRStudyStatus = new System.Windows.Forms.PictureBox();
            this.comboBox_IRMode = new System.Windows.Forms.ComboBox();
            this.label_IRMode = new System.Windows.Forms.Label();
            this.label_IRNumber = new System.Windows.Forms.Label();
            this.textBox_IRNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_SerialPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IDStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PortStatus)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RelayStatus)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IRSendStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IRStudyStatus)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_SerialPort
            // 
            this.panel_SerialPort.Controls.Add(this.button_IDChange);
            this.panel_SerialPort.Controls.Add(this.button_IDSwitch);
            this.panel_SerialPort.Controls.Add(this.pictureBox_IDStatus);
            this.panel_SerialPort.Controls.Add(this.textBox_ID2);
            this.panel_SerialPort.Controls.Add(this.label_ID2);
            this.panel_SerialPort.Controls.Add(this.textBox_ID1);
            this.panel_SerialPort.Controls.Add(this.label_ID1);
            this.panel_SerialPort.Controls.Add(this.button_PortSwitch);
            this.panel_SerialPort.Controls.Add(this.pictureBox_PortStatus);
            this.panel_SerialPort.Controls.Add(this.comboBox_PortName);
            this.panel_SerialPort.Controls.Add(this.label_PortName);
            this.panel_SerialPort.Location = new System.Drawing.Point(12, 12);
            this.panel_SerialPort.Name = "panel_SerialPort";
            this.panel_SerialPort.Size = new System.Drawing.Size(700, 30);
            this.panel_SerialPort.TabIndex = 0;
            // 
            // button_IDChange
            // 
            this.button_IDChange.Location = new System.Drawing.Point(618, 4);
            this.button_IDChange.Name = "button_IDChange";
            this.button_IDChange.Size = new System.Drawing.Size(75, 23);
            this.button_IDChange.TabIndex = 10;
            this.button_IDChange.Text = "修改";
            this.button_IDChange.UseVisualStyleBackColor = true;
            this.button_IDChange.Click += new System.EventHandler(this.button_IDChange_Click);
            // 
            // button_IDSwitch
            // 
            this.button_IDSwitch.Location = new System.Drawing.Point(528, 4);
            this.button_IDSwitch.Name = "button_IDSwitch";
            this.button_IDSwitch.Size = new System.Drawing.Size(75, 23);
            this.button_IDSwitch.TabIndex = 9;
            this.button_IDSwitch.Text = "连接";
            this.button_IDSwitch.UseVisualStyleBackColor = true;
            this.button_IDSwitch.Click += new System.EventHandler(this.button_IDSwitch_Click);
            // 
            // pictureBox_IDStatus
            // 
            this.pictureBox_IDStatus.BackColor = System.Drawing.Color.Black;
            this.pictureBox_IDStatus.Location = new System.Drawing.Point(502, 6);
            this.pictureBox_IDStatus.Name = "pictureBox_IDStatus";
            this.pictureBox_IDStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_IDStatus.TabIndex = 8;
            this.pictureBox_IDStatus.TabStop = false;
            // 
            // textBox_ID2
            // 
            this.textBox_ID2.Location = new System.Drawing.Point(452, 5);
            this.textBox_ID2.Name = "textBox_ID2";
            this.textBox_ID2.Size = new System.Drawing.Size(44, 21);
            this.textBox_ID2.TabIndex = 7;
            this.textBox_ID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_ID2
            // 
            this.label_ID2.AutoSize = true;
            this.label_ID2.Location = new System.Drawing.Point(405, 9);
            this.label_ID2.Name = "label_ID2";
            this.label_ID2.Size = new System.Drawing.Size(41, 12);
            this.label_ID2.TabIndex = 6;
            this.label_ID2.Text = "设备ID";
            // 
            // textBox_ID1
            // 
            this.textBox_ID1.Location = new System.Drawing.Point(346, 5);
            this.textBox_ID1.Name = "textBox_ID1";
            this.textBox_ID1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_ID1.Size = new System.Drawing.Size(44, 21);
            this.textBox_ID1.TabIndex = 5;
            this.textBox_ID1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_ID1
            // 
            this.label_ID1.AutoSize = true;
            this.label_ID1.Location = new System.Drawing.Point(299, 9);
            this.label_ID1.Name = "label_ID1";
            this.label_ID1.Size = new System.Drawing.Size(41, 12);
            this.label_ID1.TabIndex = 4;
            this.label_ID1.Text = "子网ID";
            // 
            // button_PortSwitch
            // 
            this.button_PortSwitch.Location = new System.Drawing.Point(193, 4);
            this.button_PortSwitch.Name = "button_PortSwitch";
            this.button_PortSwitch.Size = new System.Drawing.Size(75, 23);
            this.button_PortSwitch.TabIndex = 3;
            this.button_PortSwitch.Text = "打开";
            this.button_PortSwitch.UseVisualStyleBackColor = true;
            this.button_PortSwitch.Click += new System.EventHandler(this.button_PortSwitch_Click);
            // 
            // pictureBox_PortStatus
            // 
            this.pictureBox_PortStatus.BackColor = System.Drawing.Color.Black;
            this.pictureBox_PortStatus.Location = new System.Drawing.Point(167, 6);
            this.pictureBox_PortStatus.Name = "pictureBox_PortStatus";
            this.pictureBox_PortStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_PortStatus.TabIndex = 2;
            this.pictureBox_PortStatus.TabStop = false;
            // 
            // comboBox_PortName
            // 
            this.comboBox_PortName.FormattingEnabled = true;
            this.comboBox_PortName.Location = new System.Drawing.Point(55, 6);
            this.comboBox_PortName.Name = "comboBox_PortName";
            this.comboBox_PortName.Size = new System.Drawing.Size(106, 20);
            this.comboBox_PortName.TabIndex = 1;
            // 
            // label_PortName
            // 
            this.label_PortName.AutoSize = true;
            this.label_PortName.Location = new System.Drawing.Point(20, 9);
            this.label_PortName.Name = "label_PortName";
            this.label_PortName.Size = new System.Drawing.Size(29, 12);
            this.label_PortName.TabIndex = 0;
            this.label_PortName.Text = "端口";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_KWhGet);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_KWh);
            this.panel1.Controls.Add(this.button_RelaySwitch);
            this.panel1.Controls.Add(this.label_KWh);
            this.panel1.Controls.Add(this.pictureBox_RelayStatus);
            this.panel1.Controls.Add(this.comboBox_RelayChannel);
            this.panel1.Controls.Add(this.label_RelayChannel);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 30);
            this.panel1.TabIndex = 1;
            // 
            // button_KWhGet
            // 
            this.button_KWhGet.Location = new System.Drawing.Point(442, 4);
            this.button_KWhGet.Name = "button_KWhGet";
            this.button_KWhGet.Size = new System.Drawing.Size(75, 23);
            this.button_KWhGet.TabIndex = 11;
            this.button_KWhGet.Text = "获取";
            this.button_KWhGet.UseVisualStyleBackColor = true;
            this.button_KWhGet.Click += new System.EventHandler(this.button_KWhGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "KWh";
            // 
            // textBox_KWh
            // 
            this.textBox_KWh.Location = new System.Drawing.Point(301, 6);
            this.textBox_KWh.Name = "textBox_KWh";
            this.textBox_KWh.Size = new System.Drawing.Size(106, 21);
            this.textBox_KWh.TabIndex = 19;
            this.textBox_KWh.Text = "0.0001";
            this.textBox_KWh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_RelaySwitch
            // 
            this.button_RelaySwitch.Location = new System.Drawing.Point(138, 4);
            this.button_RelaySwitch.Name = "button_RelaySwitch";
            this.button_RelaySwitch.Size = new System.Drawing.Size(75, 23);
            this.button_RelaySwitch.TabIndex = 11;
            this.button_RelaySwitch.Text = "打开";
            this.button_RelaySwitch.UseVisualStyleBackColor = true;
            this.button_RelaySwitch.Click += new System.EventHandler(this.button_RelaySwitch_Click);
            // 
            // label_KWh
            // 
            this.label_KWh.AutoSize = true;
            this.label_KWh.Location = new System.Drawing.Point(230, 9);
            this.label_KWh.Name = "label_KWh";
            this.label_KWh.Size = new System.Drawing.Size(65, 12);
            this.label_KWh.TabIndex = 0;
            this.label_KWh.Text = "有功总电量";
            // 
            // pictureBox_RelayStatus
            // 
            this.pictureBox_RelayStatus.BackColor = System.Drawing.Color.Black;
            this.pictureBox_RelayStatus.Location = new System.Drawing.Point(112, 6);
            this.pictureBox_RelayStatus.Name = "pictureBox_RelayStatus";
            this.pictureBox_RelayStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_RelayStatus.TabIndex = 11;
            this.pictureBox_RelayStatus.TabStop = false;
            // 
            // comboBox_RelayChannel
            // 
            this.comboBox_RelayChannel.Enabled = false;
            this.comboBox_RelayChannel.FormattingEnabled = true;
            this.comboBox_RelayChannel.Items.AddRange(new object[] {
            " ",
            "1"});
            this.comboBox_RelayChannel.Location = new System.Drawing.Point(55, 6);
            this.comboBox_RelayChannel.Name = "comboBox_RelayChannel";
            this.comboBox_RelayChannel.Size = new System.Drawing.Size(51, 20);
            this.comboBox_RelayChannel.TabIndex = 11;
            this.comboBox_RelayChannel.SelectedIndexChanged += new System.EventHandler(this.comboBox_RelayChannel_SelectedIndexChanged);
            // 
            // label_RelayChannel
            // 
            this.label_RelayChannel.AutoSize = true;
            this.label_RelayChannel.Location = new System.Drawing.Point(8, 9);
            this.label_RelayChannel.Name = "label_RelayChannel";
            this.label_RelayChannel.Size = new System.Drawing.Size(41, 12);
            this.label_RelayChannel.TabIndex = 0;
            this.label_RelayChannel.Text = "回路号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox_IRSendStatus);
            this.panel2.Controls.Add(this.button_IRSend);
            this.panel2.Controls.Add(this.comboBox_IRTemp);
            this.panel2.Controls.Add(this.label_IRTemp);
            this.panel2.Controls.Add(this.comboBox_IRFan);
            this.panel2.Controls.Add(this.label_IRFan);
            this.panel2.Controls.Add(this.button_IRStudy);
            this.panel2.Controls.Add(this.pictureBox_IRStudyStatus);
            this.panel2.Controls.Add(this.comboBox_IRMode);
            this.panel2.Controls.Add(this.label_IRMode);
            this.panel2.Location = new System.Drawing.Point(12, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 30);
            this.panel2.TabIndex = 12;
            // 
            // pictureBox_IRSendStatus
            // 
            this.pictureBox_IRSendStatus.BackColor = System.Drawing.Color.Black;
            this.pictureBox_IRSendStatus.Location = new System.Drawing.Point(462, 6);
            this.pictureBox_IRSendStatus.Name = "pictureBox_IRSendStatus";
            this.pictureBox_IRSendStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_IRSendStatus.TabIndex = 16;
            this.pictureBox_IRSendStatus.TabStop = false;
            // 
            // button_IRSend
            // 
            this.button_IRSend.Location = new System.Drawing.Point(488, 4);
            this.button_IRSend.Name = "button_IRSend";
            this.button_IRSend.Size = new System.Drawing.Size(75, 23);
            this.button_IRSend.TabIndex = 15;
            this.button_IRSend.Text = "发射";
            this.button_IRSend.UseVisualStyleBackColor = true;
            this.button_IRSend.Click += new System.EventHandler(this.button_IRSend_Click);
            // 
            // comboBox_IRTemp
            // 
            this.comboBox_IRTemp.Enabled = false;
            this.comboBox_IRTemp.FormattingEnabled = true;
            this.comboBox_IRTemp.Items.AddRange(new object[] {
            " ",
            "20"});
            this.comboBox_IRTemp.Location = new System.Drawing.Point(350, 6);
            this.comboBox_IRTemp.Name = "comboBox_IRTemp";
            this.comboBox_IRTemp.Size = new System.Drawing.Size(106, 20);
            this.comboBox_IRTemp.TabIndex = 14;
            this.comboBox_IRTemp.SelectedIndexChanged += new System.EventHandler(this.comboBox_IRTemp_SelectedIndexChanged);
            // 
            // label_IRTemp
            // 
            this.label_IRTemp.AutoSize = true;
            this.label_IRTemp.Location = new System.Drawing.Point(315, 9);
            this.label_IRTemp.Name = "label_IRTemp";
            this.label_IRTemp.Size = new System.Drawing.Size(29, 12);
            this.label_IRTemp.TabIndex = 13;
            this.label_IRTemp.Text = "温度";
            // 
            // comboBox_IRFan
            // 
            this.comboBox_IRFan.Enabled = false;
            this.comboBox_IRFan.FormattingEnabled = true;
            this.comboBox_IRFan.Items.AddRange(new object[] {
            " ",
            "自动"});
            this.comboBox_IRFan.Location = new System.Drawing.Point(203, 6);
            this.comboBox_IRFan.Name = "comboBox_IRFan";
            this.comboBox_IRFan.Size = new System.Drawing.Size(106, 20);
            this.comboBox_IRFan.TabIndex = 13;
            // 
            // label_IRFan
            // 
            this.label_IRFan.AutoSize = true;
            this.label_IRFan.Location = new System.Drawing.Point(168, 9);
            this.label_IRFan.Name = "label_IRFan";
            this.label_IRFan.Size = new System.Drawing.Size(29, 12);
            this.label_IRFan.TabIndex = 12;
            this.label_IRFan.Text = "风速";
            // 
            // button_IRStudy
            // 
            this.button_IRStudy.Location = new System.Drawing.Point(618, 4);
            this.button_IRStudy.Name = "button_IRStudy";
            this.button_IRStudy.Size = new System.Drawing.Size(75, 23);
            this.button_IRStudy.TabIndex = 11;
            this.button_IRStudy.Text = "学习";
            this.button_IRStudy.UseVisualStyleBackColor = true;
            this.button_IRStudy.Click += new System.EventHandler(this.button_IRStudy_Click);
            // 
            // pictureBox_IRStudyStatus
            // 
            this.pictureBox_IRStudyStatus.BackColor = System.Drawing.Color.Black;
            this.pictureBox_IRStudyStatus.Location = new System.Drawing.Point(592, 6);
            this.pictureBox_IRStudyStatus.Name = "pictureBox_IRStudyStatus";
            this.pictureBox_IRStudyStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_IRStudyStatus.TabIndex = 11;
            this.pictureBox_IRStudyStatus.TabStop = false;
            // 
            // comboBox_IRMode
            // 
            this.comboBox_IRMode.Enabled = false;
            this.comboBox_IRMode.FormattingEnabled = true;
            this.comboBox_IRMode.Items.AddRange(new object[] {
            " ",
            "制冷",
            "制热",
            "关机",
            "开机"});
            this.comboBox_IRMode.Location = new System.Drawing.Point(55, 6);
            this.comboBox_IRMode.Name = "comboBox_IRMode";
            this.comboBox_IRMode.Size = new System.Drawing.Size(106, 20);
            this.comboBox_IRMode.TabIndex = 11;
            this.comboBox_IRMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_IRMode_SelectedIndexChanged);
            // 
            // label_IRMode
            // 
            this.label_IRMode.AutoSize = true;
            this.label_IRMode.Location = new System.Drawing.Point(20, 9);
            this.label_IRMode.Name = "label_IRMode";
            this.label_IRMode.Size = new System.Drawing.Size(29, 12);
            this.label_IRMode.TabIndex = 0;
            this.label_IRMode.Text = "模式";
            // 
            // label_IRNumber
            // 
            this.label_IRNumber.AutoSize = true;
            this.label_IRNumber.Location = new System.Drawing.Point(500, 9);
            this.label_IRNumber.Name = "label_IRNumber";
            this.label_IRNumber.Size = new System.Drawing.Size(53, 12);
            this.label_IRNumber.TabIndex = 17;
            this.label_IRNumber.Text = "存储序号";
            // 
            // textBox_IRNumber
            // 
            this.textBox_IRNumber.Location = new System.Drawing.Point(559, 6);
            this.textBox_IRNumber.Name = "textBox_IRNumber";
            this.textBox_IRNumber.Size = new System.Drawing.Size(62, 21);
            this.textBox_IRNumber.TabIndex = 18;
            this.textBox_IRNumber.Text = "1";
            this.textBox_IRNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_IRNumber.TextChanged += new System.EventHandler(this.textBox_IRNumber_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label_IRNumber);
            this.panel3.Controls.Add(this.textBox_IRNumber);
            this.panel3.Location = new System.Drawing.Point(12, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 30);
            this.panel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "(1-255)";
            // 
            // 空调控制器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 161);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_SerialPort);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 200);
            this.MinimumSize = new System.Drawing.Size(740, 200);
            this.Name = "空调控制器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "空调控制";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.空调控制器_FormClosed);
            this.Load += new System.EventHandler(this.空调控制器_Load);
            this.panel_SerialPort.ResumeLayout(false);
            this.panel_SerialPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IDStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PortStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_RelayStatus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IRSendStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IRStudyStatus)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_SerialPort;
        private System.Windows.Forms.Label label_PortName;
        private System.Windows.Forms.ComboBox comboBox_PortName;
        private System.Windows.Forms.Button button_PortSwitch;
        private System.Windows.Forms.PictureBox pictureBox_PortStatus;
        private System.Windows.Forms.TextBox textBox_ID2;
        private System.Windows.Forms.Label label_ID2;
        private System.Windows.Forms.TextBox textBox_ID1;
        private System.Windows.Forms.Label label_ID1;
        private System.Windows.Forms.Button button_IDSwitch;
        private System.Windows.Forms.PictureBox pictureBox_IDStatus;
        private System.Windows.Forms.Button button_IDChange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_RelaySwitch;
        private System.Windows.Forms.PictureBox pictureBox_RelayStatus;
        private System.Windows.Forms.ComboBox comboBox_RelayChannel;
        private System.Windows.Forms.Label label_RelayChannel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_IRSend;
        private System.Windows.Forms.ComboBox comboBox_IRTemp;
        private System.Windows.Forms.Label label_IRTemp;
        private System.Windows.Forms.ComboBox comboBox_IRFan;
        private System.Windows.Forms.Label label_IRFan;
        private System.Windows.Forms.Button button_IRStudy;
        private System.Windows.Forms.PictureBox pictureBox_IRStudyStatus;
        private System.Windows.Forms.ComboBox comboBox_IRMode;
        private System.Windows.Forms.Label label_IRMode;
        private System.Windows.Forms.PictureBox pictureBox_IRSendStatus;
        private System.Windows.Forms.Label label_IRNumber;
        private System.Windows.Forms.TextBox textBox_IRNumber;
        private System.Windows.Forms.Label label_KWh;
        private System.Windows.Forms.Button button_KWhGet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_KWh;
        private System.Windows.Forms.Label label2;
    }
}