namespace 配置工具
{
    partial class 空调控制器ID修改窗
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_OldID1 = new System.Windows.Forms.TextBox();
            this.textBox_OldID2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_NewID1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_NewID2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧的子网ID";
            // 
            // textBox_OldID1
            // 
            this.textBox_OldID1.Enabled = false;
            this.textBox_OldID1.Location = new System.Drawing.Point(95, 24);
            this.textBox_OldID1.Name = "textBox_OldID1";
            this.textBox_OldID1.Size = new System.Drawing.Size(39, 21);
            this.textBox_OldID1.TabIndex = 1;
            this.textBox_OldID1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_OldID2
            // 
            this.textBox_OldID2.Enabled = false;
            this.textBox_OldID2.Location = new System.Drawing.Point(226, 24);
            this.textBox_OldID2.Name = "textBox_OldID2";
            this.textBox_OldID2.Size = new System.Drawing.Size(39, 21);
            this.textBox_OldID2.TabIndex = 3;
            this.textBox_OldID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "旧的设备ID";
            // 
            // textBox_NewID1
            // 
            this.textBox_NewID1.Location = new System.Drawing.Point(95, 62);
            this.textBox_NewID1.Name = "textBox_NewID1";
            this.textBox_NewID1.Size = new System.Drawing.Size(39, 21);
            this.textBox_NewID1.TabIndex = 5;
            this.textBox_NewID1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "新的子网ID";
            // 
            // textBox_NewID2
            // 
            this.textBox_NewID2.Location = new System.Drawing.Point(226, 62);
            this.textBox_NewID2.Name = "textBox_NewID2";
            this.textBox_NewID2.Size = new System.Drawing.Size(39, 21);
            this.textBox_NewID2.TabIndex = 7;
            this.textBox_NewID2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "新的子网ID";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Cancel.Location = new System.Drawing.Point(49, 116);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 8;
            this.button_Cancel.Text = "放弃";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(176, 116);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "确认";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // 空调控制器ID修改窗
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 151);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.textBox_NewID2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_NewID1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_OldID2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_OldID1);
            this.Controls.Add(this.label1);
            this.Name = "空调控制器ID修改窗";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "空调控制器ID修改窗";
            this.Load += new System.EventHandler(this.空调控制器ID修改窗_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_OldID1;
        private System.Windows.Forms.TextBox textBox_OldID2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_NewID1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_NewID2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
    }
}