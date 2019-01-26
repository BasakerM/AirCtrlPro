using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configure
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            Form1.id1 = ushort.Parse(textBox_IDNew1.Text);
            Form1.id2 = ushort.Parse(textBox_IDNew2.Text);
            Form1.id_flag = true;
            this.Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Form1.id_flag = false;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox_IDOld1.Text = Form1.id1.ToString();
            textBox_IDOld2.Text = Form1.id2.ToString();
            textBox_IDOld1.Enabled = false;
            textBox_IDOld2.Enabled = false;
        }
    }
}
