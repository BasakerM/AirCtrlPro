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
            this.button_IDChange = new System.Windows.Forms.Button();
            this.panel_SerialPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IDStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PortStatus)).BeginInit();
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
            this.panel_SerialPort.Size = new System.Drawing.Size(776, 33);
            this.panel_SerialPort.TabIndex = 0;
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
            // 空调控制器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_SerialPort);
            this.Name = "空调控制器";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "空调控制";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.空调控制器_FormClosed);
            this.Load += new System.EventHandler(this.空调控制器_Load);
            this.panel_SerialPort.ResumeLayout(false);
            this.panel_SerialPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IDStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PortStatus)).EndInit();
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
    }
}