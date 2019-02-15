using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 配置工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_空调控制器_Click(object sender, EventArgs e)
        {
            空调控制器 f = new 空调控制器();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Hide();
            if(f.ShowDialog() == DialogResult.Cancel)
            {
                Control.CheckForIllegalCrossThreadCalls = true;
                this.Show();
            }
        }
    }
}
