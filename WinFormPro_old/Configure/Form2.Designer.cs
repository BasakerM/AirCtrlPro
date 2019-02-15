namespace Configure
{
    partial class Form2
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
            this.label_IDNew1 = new System.Windows.Forms.Label();
            this.textBox_IDNew1 = new System.Windows.Forms.TextBox();
            this.label_IDNew2 = new System.Windows.Forms.Label();
            this.textBox_IDNew2 = new System.Windows.Forms.TextBox();
            this.textBox_IDOld2 = new System.Windows.Forms.TextBox();
            this.label_IDOld2 = new System.Windows.Forms.Label();
            this.textBox_IDOld1 = new System.Windows.Forms.TextBox();
            this.label_IDOld1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_IDNew1
            // 
            this.label_IDNew1.AutoSize = true;
            this.label_IDNew1.Location = new System.Drawing.Point(28, 54);
            this.label_IDNew1.Name = "label_IDNew1";
            this.label_IDNew1.Size = new System.Drawing.Size(65, 12);
            this.label_IDNew1.TabIndex = 0;
            this.label_IDNew1.Text = "新的子网ID";
            // 
            // textBox_IDNew1
            // 
            this.textBox_IDNew1.Location = new System.Drawing.Point(99, 51);
            this.textBox_IDNew1.Name = "textBox_IDNew1";
            this.textBox_IDNew1.Size = new System.Drawing.Size(47, 21);
            this.textBox_IDNew1.TabIndex = 1;
            // 
            // label_IDNew2
            // 
            this.label_IDNew2.AutoSize = true;
            this.label_IDNew2.Location = new System.Drawing.Point(152, 54);
            this.label_IDNew2.Name = "label_IDNew2";
            this.label_IDNew2.Size = new System.Drawing.Size(65, 12);
            this.label_IDNew2.TabIndex = 2;
            this.label_IDNew2.Text = "新的设备ID";
            // 
            // textBox_IDNew2
            // 
            this.textBox_IDNew2.Location = new System.Drawing.Point(223, 51);
            this.textBox_IDNew2.Name = "textBox_IDNew2";
            this.textBox_IDNew2.Size = new System.Drawing.Size(47, 21);
            this.textBox_IDNew2.TabIndex = 3;
            // 
            // textBox_IDOld2
            // 
            this.textBox_IDOld2.Location = new System.Drawing.Point(223, 12);
            this.textBox_IDOld2.Name = "textBox_IDOld2";
            this.textBox_IDOld2.Size = new System.Drawing.Size(47, 21);
            this.textBox_IDOld2.TabIndex = 7;
            // 
            // label_IDOld2
            // 
            this.label_IDOld2.AutoSize = true;
            this.label_IDOld2.Location = new System.Drawing.Point(152, 15);
            this.label_IDOld2.Name = "label_IDOld2";
            this.label_IDOld2.Size = new System.Drawing.Size(65, 12);
            this.label_IDOld2.TabIndex = 6;
            this.label_IDOld2.Text = "旧的设备ID";
            // 
            // textBox_IDOld1
            // 
            this.textBox_IDOld1.Location = new System.Drawing.Point(99, 12);
            this.textBox_IDOld1.Name = "textBox_IDOld1";
            this.textBox_IDOld1.Size = new System.Drawing.Size(47, 21);
            this.textBox_IDOld1.TabIndex = 5;
            // 
            // label_IDOld1
            // 
            this.label_IDOld1.AutoSize = true;
            this.label_IDOld1.Location = new System.Drawing.Point(28, 15);
            this.label_IDOld1.Name = "label_IDOld1";
            this.label_IDOld1.Size = new System.Drawing.Size(65, 12);
            this.label_IDOld1.TabIndex = 4;
            this.label_IDOld1.Text = "旧的子网ID";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(59, 87);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 8;
            this.button_OK.Text = "确认更改";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(181, 87);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 9;
            this.button_Cancel.Text = "放弃更改";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 133);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_IDOld2);
            this.Controls.Add(this.label_IDOld2);
            this.Controls.Add(this.textBox_IDOld1);
            this.Controls.Add(this.label_IDOld1);
            this.Controls.Add(this.textBox_IDNew2);
            this.Controls.Add(this.label_IDNew2);
            this.Controls.Add(this.textBox_IDNew1);
            this.Controls.Add(this.label_IDNew1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IDNew1;
        private System.Windows.Forms.TextBox textBox_IDNew1;
        private System.Windows.Forms.Label label_IDNew2;
        private System.Windows.Forms.TextBox textBox_IDNew2;
        private System.Windows.Forms.TextBox textBox_IDOld2;
        private System.Windows.Forms.Label label_IDOld2;
        private System.Windows.Forms.TextBox textBox_IDOld1;
        private System.Windows.Forms.Label label_IDOld1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}