using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 配置工具
{
    public partial class 空调控制器 : Form
    {
        public 空调控制器()
        {
            InitializeComponent();
        }

        public void CmdPrase(byte[] data)
        {
            if(data[9] != 0xff || data[10] != 0xff)
            {
                return;
            }
            if (data[7] == 0xff && data[8] == 0x1c)
            {
                SetIDStatusConnect();
            }
            else if(data[7] == 0xff && data[8] == 0x1e)
            {
                textBox_ID1.Text = data[3].ToString();
                textBox_ID2.Text = data[4].ToString();
                SetIDStatusDisconnect();
            }
        }

        public static SerialPort ComDevice = new SerialPort();
        
        public ushort CRC_Xmodeom(byte[] buff)
        {
            int startIndex = 2;
            int len = buff.Length - 2;

            ushort crc_val = 0x0000;
            ushort crc = 0x1021;
            for (int byt = startIndex; byt < len; byt++)
            {
                crc_val = ushort.Parse((((crc_val & 0xff00) ^ (buff[byt] << 8)) | (crc_val & 0x00ff)).ToString());
                for (int bit = 0; bit < 8; bit++)
                {
                    if ((crc_val & 0x8000) > 0) { crc_val <<= 1; crc_val ^= crc; }
                    else crc_val <<= 1;
                }
            }
            return crc_val;
        }
        public ushort CRC_Xmodeom(byte[] buff,int len)
        {
            int startIndex = 2;

            ushort crc_val = 0x0000;
            ushort crc = 0x1021;
            for (int byt = startIndex; byt < len; byt++)
            {
                crc_val = ushort.Parse((((crc_val & 0xff00) ^ (buff[byt] << 8)) | (crc_val & 0x00ff)).ToString());
                for (int bit = 0; bit < 8; bit++)
                {
                    if ((crc_val & 0x8000) > 0) { crc_val <<= 1; crc_val ^= crc; }
                    else crc_val <<= 1;
                }
            }
            return crc_val;
        }
        void SetCRC(byte[] data)
        {
            ushort crc = CRC_Xmodeom(data);
            data[data.Length - 2] = byte.Parse((crc >> 8).ToString());
            data[data.Length - 1] = byte.Parse((crc & 0x00ff).ToString());
        }
        bool CRCIsTrue(byte[] data)
        {
            ushort crc = CRC_Xmodeom(data,data[2]);
            //MessageBox.Show(crc.ToString());
            int len = data[2] + 2;
            if (data[len - 2] == byte.Parse((crc >> 8).ToString()) && data[len - 1] == byte.Parse((crc & 0x00ff).ToString()))
            {
                return true;
            }
            return false;

        }

        private static int DataPrase_Index = 0;
        private static byte[] DataPrase_Buff = new byte[64];
        public void DataPrase(byte dat)
        {
            if (DataPrase_Index < 2)
            {
                if (dat == 0xAA) DataPrase_Buff[DataPrase_Index++] = dat;
                else DataPrase_Index = 0;
            }
            else if (DataPrase_Index == 2)
            {
                DataPrase_Buff[DataPrase_Index++] = dat;
            }
            else if (DataPrase_Index < DataPrase_Buff[2] + 2 - 1)
            {
                DataPrase_Buff[DataPrase_Index++] = dat;
            }
            else if (DataPrase_Index == DataPrase_Buff[2] + 2 - 1)
            {
                DataPrase_Buff[DataPrase_Index] = dat;
                DataPrase_Index = 0;
                if (CRCIsTrue(DataPrase_Buff))
                {
                    CmdPrase(DataPrase_Buff);
                }
            }
            else DataPrase_Index = 0;
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            foreach (byte ch in ReDatas)
            {
                DataPrase(ch);
            }
        }

        public bool Data_Send(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    SetCRC(data);
                    ComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void SetIDStatusConnect()
        {
            textBox_ID1.Enabled = false;
            textBox_ID2.Enabled = false;
            pictureBox_IDStatus.BackColor = Color.Green;
            button_IDSwitch.Text = "断开";
        }
        void SetIDStatusDisconnect()
        {
            textBox_ID1.Enabled = true;
            textBox_ID2.Enabled = true;
            pictureBox_IDStatus.BackColor = Color.Black;
            button_IDSwitch.Text = "连接";
        }
        bool IDStatusIsConnect()
        {
            if (button_IDSwitch.Text == "断开") return true;
            return false;
        }

        void SetPortStatusOpen()
        {
            pictureBox_PortStatus.BackColor = Color.Green;
            button_PortSwitch.Text = "关闭";
        }
        void SetPortStatusClose()
        {
            pictureBox_PortStatus.BackColor = Color.Black;
            button_PortSwitch.Text = "打开";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void 空调控制器_Load(object sender, EventArgs e)
        {
            comboBox_PortName.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox_PortName.Items.Count > 1)
            {
                comboBox_PortName.SelectedIndex = 1;
            }
            else if (comboBox_PortName.Items.Count == 1)
            {
                comboBox_PortName.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("未发现可用串口");
            }

            SetPortStatusClose();
            SetIDStatusDisconnect();
            textBox_ID1.Text = "1";
            textBox_ID2.Text = "1";
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }

        private void 空调控制器_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ComDevice.IsOpen == true)
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void button_PortSwitch_Click(object sender, EventArgs e)
        {
            if (comboBox_PortName.Items.Count == 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                ComDevice.PortName = comboBox_PortName.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32("9600");
                ComDevice.DataBits = Convert.ToInt32("8");
                ComDevice.StopBits = (StopBits)Convert.ToInt32("1");
                ComDevice.Parity = (Parity)Convert.ToInt32("2"); //偶校验
                try
                {
                    //开启串口
                    ComDevice.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SetPortStatusOpen();
            }
            else
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SetPortStatusClose();
            }

            SetIDStatusDisconnect();
            comboBox_PortName.Enabled = !ComDevice.IsOpen;
        }

        private void button_IDSwitch_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == false)
            {
                MessageBox.Show("串口未打开");
                return;
            } 
            if(IDStatusIsConnect())
            {
                SetIDStatusDisconnect();
                return;
            }
            string id1 = textBox_ID1.Text;
            string id2 = textBox_ID2.Text;
            if ((int.Parse(id1) >= 1 && int.Parse(id1) <= 255) && (int.Parse(id2) >= 1 && int.Parse(id2) <= 255))
            {
                byte[] sbuff = new byte[13] { 0xaa, 0xaa, 0x0b, 0xff, 0xff, 0xff, 0xff, 0xff, 0x1b, 0x00, 0x00, 0x00, 0x00 };
                sbuff[9] = byte.Parse(id1);
                sbuff[10] = byte.Parse(id2);
                Data_Send(sbuff);
            }
            else
            {
                MessageBox.Show("ID超出范围");
            }
        }

        public static string ID1, ID2;
        private void button_IDChange_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == false)
            {
                MessageBox.Show("串口未打开");
                return;
            }
            if (!IDStatusIsConnect())
            {
                MessageBox.Show("设备未连接");
                return;
            }
            ID1 = textBox_ID1.Text;
            ID2 = textBox_ID2.Text;
            空调控制器ID修改窗 f = new 空调控制器ID修改窗();
            if(f.ShowDialog() == DialogResult.OK)
            {
                byte[] sbuff = new byte[15] { 0xaa, 0xaa, 0x0d, 0xff, 0xff, 0xff, 0xff, 0xff, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                sbuff[9] = byte.Parse(textBox_ID1.Text);
                sbuff[10] = byte.Parse(textBox_ID2.Text);
                sbuff[11] = byte.Parse(ID1);
                sbuff[12] = byte.Parse(ID2);
                Data_Send(sbuff);
            }

        }
    }
}
