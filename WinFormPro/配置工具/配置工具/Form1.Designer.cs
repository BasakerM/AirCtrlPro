namespace 配置工具
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
            this.button_空调控制器 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_空调控制器
            // 
            this.button_空调控制器.Location = new System.Drawing.Point(75, 37);
            this.button_空调控制器.Name = "button_空调控制器";
            this.button_空调控制器.Size = new System.Drawing.Size(100, 23);
            this.button_空调控制器.TabIndex = 0;
            this.button_空调控制器.Text = "空调控制器";
            this.button_空调控制器.UseVisualStyleBackColor = true;
            this.button_空调控制器.Click += new System.EventHandler(this.Button_空调控制器_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 411);
            this.Controls.Add(this.button_空调控制器);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "昀尚智能";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_空调控制器;
    }
}

