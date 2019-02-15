namespace Configure
{
    partial class Form1
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
            this.comboBox_PortName = new System.Windows.Forms.ComboBox();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.label_ProtName = new System.Windows.Forms.Label();
            this.label_BaudRate = new System.Windows.Forms.Label();
            this.label_DataBits = new System.Windows.Forms.Label();
            this.label_StopBits = new System.Windows.Forms.Label();
            this.label_Parity = new System.Windows.Forms.Label();
            this.button_Switch = new System.Windows.Forms.Button();
            this.pictureBox_Switch = new System.Windows.Forms.PictureBox();
            this.button_Relay = new System.Windows.Forms.Button();
            this.pictureBox_Relay = new System.Windows.Forms.PictureBox();
            this.label_ID1 = new System.Windows.Forms.Label();
            this.label_ID2 = new System.Windows.Forms.Label();
            this.textBox_ID1 = new System.Windows.Forms.TextBox();
            this.textBox_ID2 = new System.Windows.Forms.TextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_SetID = new System.Windows.Forms.Button();
            this.textBox_Index = new System.Windows.Forms.TextBox();
            this.label_Index = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Study = new System.Windows.Forms.Button();
            this.pictureBox_Study = new System.Windows.Forms.PictureBox();
            this.pictureBox_Send = new System.Windows.Forms.PictureBox();
            this.label_CRCTitle = new System.Windows.Forms.Label();
            this.textBox_CRCData = new System.Windows.Forms.TextBox();
            this.label_CRCType = new System.Windows.Forms.Label();
            this.comboBox_CRCType = new System.Windows.Forms.ComboBox();
            this.textBox_CRC = new System.Windows.Forms.TextBox();
            this.button_CRC = new System.Windows.Forms.Button();
            this.label_UsartTitle = new System.Windows.Forms.Label();
            this.textBox_UsartRec = new System.Windows.Forms.TextBox();
            this.textBox_UsartSend = new System.Windows.Forms.TextBox();
            this.button_UsartSend = new System.Windows.Forms.Button();
            this.pictureBox_Connect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Switch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Relay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Study)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Send)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Connect)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_PortName
            // 
            this.comboBox_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PortName.Location = new System.Drawing.Point(58, 12);
            this.comboBox_PortName.Name = "comboBox_PortName";
            this.comboBox_PortName.Size = new System.Drawing.Size(80, 20);
            this.comboBox_PortName.TabIndex = 0;
            this.comboBox_PortName.DropDown += new System.EventHandler(this.ComboBox_PortName_DropDown);
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "115200",
            "9600"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(58, 42);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(80, 20);
            this.comboBox_BaudRate.TabIndex = 1;
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Items.AddRange(new object[] {
            "8",
            "7"});
            this.comboBox_DataBits.Location = new System.Drawing.Point(58, 72);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(80, 20);
            this.comboBox_DataBits.TabIndex = 2;
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Items.AddRange(new object[] {
            "2",
            "1"});
            this.comboBox_StopBits.Location = new System.Drawing.Point(58, 102);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(80, 20);
            this.comboBox_StopBits.TabIndex = 3;
            // 
            // comboBox_Parity
            // 
            this.comboBox_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Parity.FormattingEnabled = true;
            this.comboBox_Parity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验"});
            this.comboBox_Parity.Location = new System.Drawing.Point(58, 132);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(80, 20);
            this.comboBox_Parity.TabIndex = 4;
            // 
            // label_ProtName
            // 
            this.label_ProtName.AutoSize = true;
            this.label_ProtName.Location = new System.Drawing.Point(18, 16);
            this.label_ProtName.Name = "label_ProtName";
            this.label_ProtName.Size = new System.Drawing.Size(29, 12);
            this.label_ProtName.TabIndex = 5;
            this.label_ProtName.Text = "端口";
            // 
            // label_BaudRate
            // 
            this.label_BaudRate.AutoSize = true;
            this.label_BaudRate.Location = new System.Drawing.Point(13, 46);
            this.label_BaudRate.Name = "label_BaudRate";
            this.label_BaudRate.Size = new System.Drawing.Size(41, 12);
            this.label_BaudRate.TabIndex = 6;
            this.label_BaudRate.Text = "波特率";
            // 
            // label_DataBits
            // 
            this.label_DataBits.AutoSize = true;
            this.label_DataBits.Location = new System.Drawing.Point(13, 76);
            this.label_DataBits.Name = "label_DataBits";
            this.label_DataBits.Size = new System.Drawing.Size(41, 12);
            this.label_DataBits.TabIndex = 7;
            this.label_DataBits.Text = "数据位";
            // 
            // label_StopBits
            // 
            this.label_StopBits.AutoSize = true;
            this.label_StopBits.Location = new System.Drawing.Point(13, 106);
            this.label_StopBits.Name = "label_StopBits";
            this.label_StopBits.Size = new System.Drawing.Size(41, 12);
            this.label_StopBits.TabIndex = 8;
            this.label_StopBits.Text = "停止位";
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(13, 136);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(41, 12);
            this.label_Parity.TabIndex = 9;
            this.label_Parity.Text = "校验位";
            // 
            // button_Switch
            // 
            this.button_Switch.Location = new System.Drawing.Point(58, 162);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(80, 20);
            this.button_Switch.TabIndex = 10;
            this.button_Switch.Text = "打开串口";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.Button_Switch_Click);
            // 
            // pictureBox_Switch
            // 
            this.pictureBox_Switch.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Switch.Location = new System.Drawing.Point(18, 162);
            this.pictureBox_Switch.Name = "pictureBox_Switch";
            this.pictureBox_Switch.Size = new System.Drawing.Size(30, 20);
            this.pictureBox_Switch.TabIndex = 11;
            this.pictureBox_Switch.TabStop = false;
            // 
            // button_Relay
            // 
            this.button_Relay.Location = new System.Drawing.Point(58, 192);
            this.button_Relay.Name = "button_Relay";
            this.button_Relay.Size = new System.Drawing.Size(80, 20);
            this.button_Relay.TabIndex = 12;
            this.button_Relay.Text = "打开继电器";
            this.button_Relay.UseVisualStyleBackColor = true;
            this.button_Relay.Click += new System.EventHandler(this.Button_Relay_Click);
            // 
            // pictureBox_Relay
            // 
            this.pictureBox_Relay.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Relay.Location = new System.Drawing.Point(18, 192);
            this.pictureBox_Relay.Name = "pictureBox_Relay";
            this.pictureBox_Relay.Size = new System.Drawing.Size(30, 20);
            this.pictureBox_Relay.TabIndex = 13;
            this.pictureBox_Relay.TabStop = false;
            // 
            // label_ID1
            // 
            this.label_ID1.AutoSize = true;
            this.label_ID1.Location = new System.Drawing.Point(144, 16);
            this.label_ID1.Name = "label_ID1";
            this.label_ID1.Size = new System.Drawing.Size(41, 12);
            this.label_ID1.TabIndex = 14;
            this.label_ID1.Text = "子网ID";
            // 
            // label_ID2
            // 
            this.label_ID2.AutoSize = true;
            this.label_ID2.Location = new System.Drawing.Point(144, 46);
            this.label_ID2.Name = "label_ID2";
            this.label_ID2.Size = new System.Drawing.Size(41, 12);
            this.label_ID2.TabIndex = 15;
            this.label_ID2.Text = "设备ID";
            // 
            // textBox_ID1
            // 
            this.textBox_ID1.Location = new System.Drawing.Point(191, 12);
            this.textBox_ID1.Name = "textBox_ID1";
            this.textBox_ID1.Size = new System.Drawing.Size(40, 21);
            this.textBox_ID1.TabIndex = 16;
            this.textBox_ID1.Text = "0";
            this.textBox_ID1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ID2
            // 
            this.textBox_ID2.Location = new System.Drawing.Point(191, 42);
            this.textBox_ID2.Name = "textBox_ID2";
            this.textBox_ID2.Size = new System.Drawing.Size(40, 21);
            this.textBox_ID2.TabIndex = 17;
            this.textBox_ID2.Text = "0";
            this.textBox_ID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(181, 71);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(50, 20);
            this.button_Connect.TabIndex = 18;
            this.button_Connect.Text = "连接";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // button_SetID
            // 
            this.button_SetID.Location = new System.Drawing.Point(151, 101);
            this.button_SetID.Name = "button_SetID";
            this.button_SetID.Size = new System.Drawing.Size(80, 20);
            this.button_SetID.TabIndex = 19;
            this.button_SetID.Text = "配置ID";
            this.button_SetID.UseVisualStyleBackColor = true;
            this.button_SetID.Click += new System.EventHandler(this.Button_SetID_Click);
            // 
            // textBox_Index
            // 
            this.textBox_Index.Location = new System.Drawing.Point(191, 132);
            this.textBox_Index.Name = "textBox_Index";
            this.textBox_Index.Size = new System.Drawing.Size(40, 21);
            this.textBox_Index.TabIndex = 21;
            this.textBox_Index.Text = "0";
            this.textBox_Index.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Index
            // 
            this.label_Index.AutoSize = true;
            this.label_Index.Location = new System.Drawing.Point(149, 135);
            this.label_Index.Name = "label_Index";
            this.label_Index.Size = new System.Drawing.Size(29, 12);
            this.label_Index.TabIndex = 20;
            this.label_Index.Text = "序号";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(181, 192);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(50, 20);
            this.button_Send.TabIndex = 23;
            this.button_Send.Text = "发射";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.Button_Send_Click);
            // 
            // button_Study
            // 
            this.button_Study.Location = new System.Drawing.Point(181, 162);
            this.button_Study.Name = "button_Study";
            this.button_Study.Size = new System.Drawing.Size(50, 20);
            this.button_Study.TabIndex = 22;
            this.button_Study.Text = "学习";
            this.button_Study.UseVisualStyleBackColor = true;
            this.button_Study.Click += new System.EventHandler(this.Button_Study_Click);
            // 
            // pictureBox_Study
            // 
            this.pictureBox_Study.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Study.Location = new System.Drawing.Point(150, 162);
            this.pictureBox_Study.Name = "pictureBox_Study";
            this.pictureBox_Study.Size = new System.Drawing.Size(25, 20);
            this.pictureBox_Study.TabIndex = 24;
            this.pictureBox_Study.TabStop = false;
            // 
            // pictureBox_Send
            // 
            this.pictureBox_Send.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Send.Location = new System.Drawing.Point(150, 192);
            this.pictureBox_Send.Name = "pictureBox_Send";
            this.pictureBox_Send.Size = new System.Drawing.Size(25, 20);
            this.pictureBox_Send.TabIndex = 25;
            this.pictureBox_Send.TabStop = false;
            // 
            // label_CRCTitle
            // 
            this.label_CRCTitle.AutoSize = true;
            this.label_CRCTitle.Location = new System.Drawing.Point(97, 215);
            this.label_CRCTitle.Name = "label_CRCTitle";
            this.label_CRCTitle.Size = new System.Drawing.Size(47, 12);
            this.label_CRCTitle.TabIndex = 26;
            this.label_CRCTitle.Text = "CRC计算";
            // 
            // textBox_CRCData
            // 
            this.textBox_CRCData.Location = new System.Drawing.Point(15, 230);
            this.textBox_CRCData.Name = "textBox_CRCData";
            this.textBox_CRCData.Size = new System.Drawing.Size(160, 21);
            this.textBox_CRCData.TabIndex = 27;
            this.textBox_CRCData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_CRCType
            // 
            this.label_CRCType.AutoSize = true;
            this.label_CRCType.Location = new System.Drawing.Point(13, 261);
            this.label_CRCType.Name = "label_CRCType";
            this.label_CRCType.Size = new System.Drawing.Size(29, 12);
            this.label_CRCType.TabIndex = 28;
            this.label_CRCType.Text = "类型";
            // 
            // comboBox_CRCType
            // 
            this.comboBox_CRCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CRCType.FormattingEnabled = true;
            this.comboBox_CRCType.Items.AddRange(new object[] {
            "CRC-CCITT (XModem)"});
            this.comboBox_CRCType.Location = new System.Drawing.Point(45, 257);
            this.comboBox_CRCType.Name = "comboBox_CRCType";
            this.comboBox_CRCType.Size = new System.Drawing.Size(130, 20);
            this.comboBox_CRCType.TabIndex = 29;
            // 
            // textBox_CRC
            // 
            this.textBox_CRC.Location = new System.Drawing.Point(181, 230);
            this.textBox_CRC.Name = "textBox_CRC";
            this.textBox_CRC.Size = new System.Drawing.Size(50, 21);
            this.textBox_CRC.TabIndex = 30;
            this.textBox_CRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_CRC
            // 
            this.button_CRC.Location = new System.Drawing.Point(181, 257);
            this.button_CRC.Name = "button_CRC";
            this.button_CRC.Size = new System.Drawing.Size(50, 20);
            this.button_CRC.TabIndex = 31;
            this.button_CRC.Text = "计算";
            this.button_CRC.UseVisualStyleBackColor = true;
            // 
            // label_UsartTitle
            // 
            this.label_UsartTitle.AutoSize = true;
            this.label_UsartTitle.Location = new System.Drawing.Point(97, 280);
            this.label_UsartTitle.Name = "label_UsartTitle";
            this.label_UsartTitle.Size = new System.Drawing.Size(53, 12);
            this.label_UsartTitle.TabIndex = 32;
            this.label_UsartTitle.Text = "串口工具";
            // 
            // textBox_UsartRec
            // 
            this.textBox_UsartRec.Location = new System.Drawing.Point(15, 295);
            this.textBox_UsartRec.Name = "textBox_UsartRec";
            this.textBox_UsartRec.Size = new System.Drawing.Size(216, 21);
            this.textBox_UsartRec.TabIndex = 33;
            this.textBox_UsartRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_UsartSend
            // 
            this.textBox_UsartSend.Location = new System.Drawing.Point(15, 325);
            this.textBox_UsartSend.Name = "textBox_UsartSend";
            this.textBox_UsartSend.Size = new System.Drawing.Size(160, 21);
            this.textBox_UsartSend.TabIndex = 34;
            this.textBox_UsartSend.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_UsartSend
            // 
            this.button_UsartSend.Location = new System.Drawing.Point(181, 324);
            this.button_UsartSend.Name = "button_UsartSend";
            this.button_UsartSend.Size = new System.Drawing.Size(50, 20);
            this.button_UsartSend.TabIndex = 35;
            this.button_UsartSend.Text = "发送";
            this.button_UsartSend.UseVisualStyleBackColor = true;
            // 
            // pictureBox_Connect
            // 
            this.pictureBox_Connect.BackColor = System.Drawing.Color.Black;
            this.pictureBox_Connect.Location = new System.Drawing.Point(150, 71);
            this.pictureBox_Connect.Name = "pictureBox_Connect";
            this.pictureBox_Connect.Size = new System.Drawing.Size(25, 20);
            this.pictureBox_Connect.TabIndex = 36;
            this.pictureBox_Connect.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 358);
            this.Controls.Add(this.pictureBox_Connect);
            this.Controls.Add(this.button_UsartSend);
            this.Controls.Add(this.textBox_UsartSend);
            this.Controls.Add(this.textBox_UsartRec);
            this.Controls.Add(this.label_UsartTitle);
            this.Controls.Add(this.button_CRC);
            this.Controls.Add(this.textBox_CRC);
            this.Controls.Add(this.comboBox_CRCType);
            this.Controls.Add(this.label_CRCType);
            this.Controls.Add(this.textBox_CRCData);
            this.Controls.Add(this.label_CRCTitle);
            this.Controls.Add(this.pictureBox_Send);
            this.Controls.Add(this.pictureBox_Study);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Study);
            this.Controls.Add(this.textBox_Index);
            this.Controls.Add(this.label_Index);
            this.Controls.Add(this.button_SetID);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_ID2);
            this.Controls.Add(this.textBox_ID1);
            this.Controls.Add(this.label_ID2);
            this.Controls.Add(this.label_ID1);
            this.Controls.Add(this.pictureBox_Relay);
            this.Controls.Add(this.button_Relay);
            this.Controls.Add(this.pictureBox_Switch);
            this.Controls.Add(this.button_Switch);
            this.Controls.Add(this.label_Parity);
            this.Controls.Add(this.label_StopBits);
            this.Controls.Add(this.label_DataBits);
            this.Controls.Add(this.label_BaudRate);
            this.Controls.Add(this.label_ProtName);
            this.Controls.Add(this.comboBox_Parity);
            this.Controls.Add(this.comboBox_StopBits);
            this.Controls.Add(this.comboBox_DataBits);
            this.Controls.Add(this.comboBox_BaudRate);
            this.Controls.Add(this.comboBox_PortName);
            this.Name = "Form1";
            this.Text = "配置工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Switch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Relay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Study)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Send)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Connect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_PortName;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label_ProtName;
        private System.Windows.Forms.Label label_BaudRate;
        private System.Windows.Forms.Label label_DataBits;
        private System.Windows.Forms.Label label_StopBits;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.PictureBox pictureBox_Switch;
        private System.Windows.Forms.Button button_Relay;
        private System.Windows.Forms.PictureBox pictureBox_Relay;
        private System.Windows.Forms.Label label_ID1;
        private System.Windows.Forms.Label label_ID2;
        public  System.Windows.Forms.TextBox textBox_ID1;
        public  System.Windows.Forms.TextBox textBox_ID2;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_SetID;
        private System.Windows.Forms.TextBox textBox_Index;
        private System.Windows.Forms.Label label_Index;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Study;
        private System.Windows.Forms.PictureBox pictureBox_Study;
        private System.Windows.Forms.PictureBox pictureBox_Send;
        private System.Windows.Forms.Label label_CRCTitle;
        private System.Windows.Forms.TextBox textBox_CRCData;
        private System.Windows.Forms.Label label_CRCType;
        private System.Windows.Forms.ComboBox comboBox_CRCType;
        private System.Windows.Forms.TextBox textBox_CRC;
        private System.Windows.Forms.Button button_CRC;
        private System.Windows.Forms.Label label_UsartTitle;
        private System.Windows.Forms.TextBox textBox_UsartRec;
        private System.Windows.Forms.TextBox textBox_UsartSend;
        private System.Windows.Forms.Button button_UsartSend;
        private System.Windows.Forms.PictureBox pictureBox_Connect;
    }
}

