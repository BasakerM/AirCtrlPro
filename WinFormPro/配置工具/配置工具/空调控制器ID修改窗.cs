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
    public partial class 空调控制器ID修改窗 : Form
    {
        public 空调控制器ID修改窗()
        {
            InitializeComponent();
        }

        private void 空调控制器ID修改窗_Load(object sender, EventArgs e)
        {
            textBox_OldID1.Text = 空调控制器.ID1;
            textBox_OldID2.Text = 空调控制器.ID2;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox_NewID1.Text == "" || textBox_NewID2.Text == "")
            {
                MessageBox.Show("未输入ID");
                return;
            }
            if ((int.Parse(textBox_NewID1.Text) >= 1 && int.Parse(textBox_NewID1.Text) <= 255) && (int.Parse(textBox_NewID2.Text) >= 1 && int.Parse(textBox_NewID2.Text) <= 255))
            {
                空调控制器.ID1 = textBox_NewID1.Text;
                空调控制器.ID2 = textBox_NewID2.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("ID超出范围");
            }
        }
    }
}
