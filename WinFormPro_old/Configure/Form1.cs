using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configure
{
    public partial class Form1 : Form
    {
        //定义端口类
        public static SerialPort ComDevice = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }

        public const int INDEX_OPTION = 7;
        public const int INDEX_ADDR = 9;
        public const int INDEX_DATA = 11;
        public void Data_Parse(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.AppendFormat("{0:x2}" + " ", data[i]);
            }
            BeginInvoke(new MethodInvoker(delegate
            {
                textBox_UsartRec.Text = sb.ToString();
               if(data.Length > 3 && data[2] == data.Length-2 && data[0] == 0xAA && data[1] == 0xAA && data[INDEX_ADDR] == 0xFF && data[INDEX_ADDR+1] == 0xFF)
                {
                    //MessageBox.Show("进入CRC判断");
                    int dat_len = data[2] - 2;
                    byte[] dat = new byte[dat_len];
                    for (int i = 0;i < dat_len; i++)
                    {
                        dat[i] = data[i + 2];
                    }
                   /*sb = new StringBuilder();
                    for (int i = 0; i < dat.Length; i++)
                    {
                        sb.AppendFormat("{0:x2}" + " ", dat[i]);
                    }
                    MessageBox.Show(sb.ToString());
                    MessageBox.Show(dat_len.ToString());*/
                    ushort crc = CRC_Computet(dat, dat_len);
                    //MessageBox.Show(crc.ToString());
                    if (crc>>8 == data[data.Length - 2] && (crc&0x00ff) == data[data.Length - 1])
                    {
                        //MessageBox.Show("进入指令判断");
                        if (data[INDEX_OPTION] == 0xE0 && data[INDEX_OPTION+1] == 0x1D && data[INDEX_DATA + 1] == 0x01)
                        {
                            if (data[INDEX_DATA] == byte.Parse(textBox_Index.Text))
                            {
                                button_Send.Text = "发射";
                                pictureBox_Send.BackColor = Color.Green;
                            }
                            else
                            {
                                button_Send.Text = "发射";
                                pictureBox_Send.BackColor = Color.Red;
                                MessageBox.Show("实际发射序号与设定的不符");
                            }
                            /*if (data[INDEX_DATA] == 0xF8 && data[INDEX_DATA+1] == 0xF8)
                            {

                                if (data[INDEX_DATA] == byte.Parse(textBox_Index.Text))
                                {
                                    button_Send.Text = "发射";
                                    pictureBox_Send.BackColor = Color.Green;
                                }
                                else
                                {
                                    button_Send.Text = "发射";
                                    pictureBox_Send.BackColor = Color.Red;
                                    MessageBox.Show("实际发射序号与设定的不符");
                                }
                            }
                            else if (data[INDEX_DATA] == 0xF5)
                            {
                                pictureBox_Send.BackColor = Color.Red;
                                MessageBox.Show("发射失败,请重试");
                            }*/
                        }
                        else if(data[INDEX_OPTION] == 0x00 && data[INDEX_OPTION+1] == 0x32 && data[INDEX_DATA] == 0x01 && data[INDEX_DATA+1] == 0xF8 && data[INDEX_DATA+3] == 0x01)
                        {
                            //MessageBox.Show("进入继电器判断");
                            if (data[INDEX_DATA + 2] == 0x64 && data[INDEX_DATA + 4] == 0x01)
                            {
                                button_Relay.Text = "关闭继电器";
                                pictureBox_Relay.BackColor = Color.Green;
                            }
                            else if (data[INDEX_DATA + 2] == 0x00 && data[INDEX_DATA + 4] == 0x00)
                            {
                                button_Relay.Text = "打开继电器";
                                pictureBox_Relay.BackColor = Color.Black;
                            }
                        }
                        else if (data[INDEX_OPTION] == 0xFF && data[INDEX_OPTION + 1] == 0x13)
                        {
                            if (data[INDEX_DATA] == 0xF8)
                            {
                                button_Study.Text = "学习";
                                pictureBox_Study.BackColor = Color.Green;
                                textBox_Index.Text = data[INDEX_DATA+1].ToString();
                            }
                            else if (data[INDEX_DATA] == 0xF6)
                            {
                                button_Study.Text = "学习中";
                                pictureBox_Study.BackColor = Color.Yellow;
                            }
                            else if (data[INDEX_DATA] == 0xF5)
                            {
                                button_Study.Text = "学习";
                                pictureBox_Study.BackColor = Color.Red;
                            }
                        }
                        else if (data[INDEX_OPTION] == 0xFF && data[INDEX_OPTION + 1] == 0x17)
                        {
                            if (data[INDEX_DATA] == 0xF8)
                            {
                                textBox_ID1.Enabled = true;
                                textBox_ID2.Enabled = true;
                                textBox_ID1.Text = id1.ToString();
                                textBox_ID2.Text = id2.ToString();
                                button_Connect.Text = "连接";
                                pictureBox_Connect.BackColor = Color.Black;
                                MessageBox.Show("模块地址设置成功");
                            }
                            else if (data[INDEX_DATA] == 0xF5)
                            {
                                textBox_ID1.Enabled = true;
                                textBox_ID2.Enabled = true;
                                MessageBox.Show("模块地址设置失败");
                            }
                        }
                        else if (data[INDEX_OPTION] == 0xFF && data[INDEX_OPTION + 1] == 0x19 && data[INDEX_DATA] == 0xF8)
                        {
                            pictureBox_Connect.BackColor = Color.Green;
                            button_Connect.Text = "断开";
                            textBox_ID1.Enabled = false;
                            textBox_ID2.Enabled = false;
                            //MessageBox.Show("模块连接成功");
                        }
                    }
                }
            }));
        }

        private void Button_Study_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == true)
            {
                if (pictureBox_Connect.BackColor == Color.Green)
                {
                    byte[] dat0 = new byte[15] { 0xAA, 0xAA, 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x12, 0x01, 0x01, 0x00, 0x01, 0x00, 0x00 };
                    byte[] dat1 = new byte[11] { 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x12, 0x01, 0x01, 0x00, 0x01 };
                    try
                    {
                        dat1[7] = byte.Parse(textBox_ID1.Text);
                        dat1[8] = byte.Parse(textBox_ID2.Text);
                        dat1[9] = byte.Parse(textBox_Index.Text);
                        ushort crc = CRC_Computet(dat1, 11);
                        dat0[9] = byte.Parse(textBox_ID1.Text);
                        dat0[10] = byte.Parse(textBox_ID2.Text);
                        dat0[11] = byte.Parse(textBox_Index.Text);
                        dat0[13] = byte.Parse((crc >> 8).ToString());
                        dat0[14] = byte.Parse((crc & 0x00ff).ToString());
                    }
                    catch
                    {
                        MessageBox.Show("ID数据格式转换错误");
                        return;
                    }
                    Data_Send(dat0);
                }
                else if (pictureBox_Connect.BackColor == Color.Black) MessageBox.Show("未连接,请检查ID");
            }
            else MessageBox.Show("串口未打开");
        }

        private void Button_Send_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == true)
            {
                if (pictureBox_Connect.BackColor == Color.Green)
                {
                    byte[] dat0 = new byte[15] { 0xAA, 0xAA, 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0, 0x1C, 0x01, 0x01, 0x00, 0xFF, 0x00, 0x00 };
                    byte[] dat1 = new byte[11] { 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0, 0x1C, 0x01, 0x01, 0x00, 0xFF };
                    try
                    {
                        dat1[7] = byte.Parse(textBox_ID1.Text);
                        dat1[8] = byte.Parse(textBox_ID2.Text);
                        dat1[9] = byte.Parse(textBox_Index.Text);
                        ushort crc = CRC_Computet(dat1, 11);
                        dat0[9] = byte.Parse(textBox_ID1.Text);
                        dat0[10] = byte.Parse(textBox_ID2.Text);
                        dat0[11] = byte.Parse(textBox_Index.Text);
                        dat0[13] = byte.Parse((crc >> 8).ToString());
                        dat0[14] = byte.Parse((crc & 0x00ff).ToString());
                    }
                    catch
                    {
                        MessageBox.Show("ID数据格式转换错误");
                        return;
                    }
                    Data_Send(dat0);
                }
                else if (pictureBox_Connect.BackColor == Color.Black) MessageBox.Show("未连接,请检查ID");
            }
            else MessageBox.Show("串口未打开");
        }

        private void Button_Connect_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == true)
            {
                if(pictureBox_Connect.BackColor == Color.Black)
                {
                    byte[] dat0 = new byte[13] { 0xAA, 0xAA, 0x0B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x18, 0x01, 0x01, 0x00, 0x00 };
                    byte[] dat1 = new byte[9] { 0x0B, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x18, 0x01, 0x01 };
                    try
                    {
                        dat1[7] = byte.Parse(textBox_ID1.Text);
                        dat1[8] = byte.Parse(textBox_ID2.Text);
                        ushort crc = CRC_Computet(dat1, 9);
                        dat0[9] = byte.Parse(textBox_ID1.Text);
                        dat0[10] = byte.Parse(textBox_ID2.Text);
                        dat0[11] = byte.Parse((crc >> 8).ToString());
                        dat0[12] = byte.Parse((crc & 0x00ff).ToString());
                    }
                    catch
                    {
                        MessageBox.Show("ID数据格式转换错误");
                        return;
                    }
                    Data_Send(dat0);
                }
                else if(pictureBox_Connect.BackColor == Color.Green)
                {
                    pictureBox_Connect.BackColor = Color.Black;
                    button_Connect.Text = "连接";
                    textBox_ID1.Enabled = true;
                    textBox_ID2.Enabled = true;
                }
                
            }
            else MessageBox.Show("串口未打开");
        }

        public static ushort id1 = 0;
        public static ushort id2 = 0;
        public static bool id_flag = false;
        private void Button_SetID_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == true)
            {
                if(pictureBox_Connect.BackColor == Color.Green)
                {
                    id1 = ushort.Parse(textBox_ID1.Text);
                    id2 = ushort.Parse(textBox_ID2.Text);
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    if (id_flag)
                    {
                        byte[] dat0 = new byte[15] { 0xAA, 0xAA, 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x16, 0x01, 0x01, 0x01, 0x01, 0x00, 0x00 };
                        byte[] dat1 = new byte[11] { 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x16, 0x01, 0x01, 0x01, 0x01 };
                        try
                        {
                            dat1[7] = byte.Parse(textBox_ID1.Text);
                            dat1[8] = byte.Parse(textBox_ID2.Text);
                            dat1[9] = byte.Parse(id1.ToString());
                            dat1[10] = byte.Parse(id2.ToString());
                            ushort crc = CRC_Computet(dat1, 11);
                            dat0[9] = byte.Parse(textBox_ID1.Text);
                            dat0[10] = byte.Parse(textBox_ID2.Text);
                            dat0[11] = byte.Parse(id1.ToString());
                            dat0[12] = byte.Parse(id2.ToString());
                            dat0[13] = byte.Parse((crc >> 8).ToString());
                            dat0[14] = byte.Parse((crc & 0x00ff).ToString());
                        }
                        catch
                        {
                            MessageBox.Show("ID数据格式转换错误");
                            return;
                        }
                        textBox_ID1.Enabled = false;
                        textBox_ID2.Enabled = false;
                        Data_Send(dat0);
                    }
                }
                else if(pictureBox_Connect.BackColor == Color.Black) MessageBox.Show("未连接,请检查ID");
            }
            else MessageBox.Show("串口未打开");
        }

        private void Button_Relay_Click(object sender, EventArgs e)
        {
            if (ComDevice.IsOpen == true)
            {
                if (pictureBox_Connect.BackColor == Color.Green)
                {
                    byte[] dat0 = new byte[17] { 0xAA, 0xAA, 0x0F, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x31, 0x01, 0x01, 0x01, 0x64, 0x00, 0x00, 0x00, 0x00 };
                    byte[] dat1 = new byte[13] { 0x0F, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x31, 0x01, 0x01, 0x01, 0x64, 0x00, 0x00 };
                    try
                    {
                        if (pictureBox_Relay.BackColor == Color.Black)
                        {
                            dat0[12] = 0x64;
                            dat1[10] = 0x64;
                        }
                        else if (pictureBox_Relay.BackColor == Color.Green)
                        {
                            dat0[12] = 0x00;
                            dat1[10] = 0x00;
                        }
                        else if (pictureBox_Relay.BackColor == Color.Yellow)
                        {
                            pictureBox_Relay.BackColor = Color.Black;
                            button_Relay.Text = "打开继电器";
                            return;
                        }
                        dat1[7] = byte.Parse(textBox_ID1.Text);
                        dat1[8] = byte.Parse(textBox_ID2.Text);
                        ushort crc = CRC_Computet(dat1, 13);
                        dat0[9] = byte.Parse(textBox_ID1.Text);
                        dat0[10] = byte.Parse(textBox_ID2.Text);
                        dat0[15] = byte.Parse((crc >> 8).ToString());
                        dat0[16] = byte.Parse((crc & 0x00ff).ToString());
                    }
                    catch
                    {
                        MessageBox.Show("ID数据格式转换错误");
                        return;
                    }
                    Data_Send(dat0);
                }
                else if (pictureBox_Connect.BackColor == Color.Black) MessageBox.Show("未连接,请检查ID");
            }
            else MessageBox.Show("串口未打开");
        }

        private void Button_Switch_Click(object sender, EventArgs e)
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
                ComDevice.BaudRate = Convert.ToInt32(comboBox_BaudRate.SelectedItem.ToString());
                ComDevice.DataBits = Convert.ToInt32(comboBox_DataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(comboBox_StopBits.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(comboBox_Parity.SelectedIndex.ToString());
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
                button_Switch.Text = "关闭串口";
                pictureBox_Switch.BackColor = Color.Green;
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
                button_Switch.Text = "打开串口";
                pictureBox_Switch.BackColor = Color.Black;
                button_Relay.Text = "打开继电器";
                pictureBox_Relay.BackColor = Color.Black;
                button_Send.Text = "发射";
                pictureBox_Study.BackColor = Color.Black;
                button_Study.Text = "学习";
                pictureBox_Send.BackColor = Color.Black;
                button_Connect.Text = "连接";
                pictureBox_Connect.BackColor = Color.Black;
                textBox_ID1.Enabled = true;
                textBox_ID2.Enabled = true;
            }

            comboBox_PortName.Enabled = !ComDevice.IsOpen;
            comboBox_BaudRate.Enabled = !ComDevice.IsOpen;
            comboBox_DataBits.Enabled = !ComDevice.IsOpen;
            comboBox_StopBits.Enabled = !ComDevice.IsOpen;
            comboBox_Parity.Enabled = !ComDevice.IsOpen;
        }

        private void ComboBox_PortName_DropDown(object sender, EventArgs e)
        {
            //查询主机上存在的串口
            comboBox_PortName.Items.Clear();
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
                MessageBox.Show("未发现可用串口，请检查硬件设备");
            }
        }

        public ushort CRC_Computet(byte[] buff, int len)
        {
            ushort crc_val = 0x0000;
            ushort crc = 0x1021;
            for (int byt = 0; byt < len; byt++)
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

        //public bool Data_Send(byte[] data)
        //{
        //    if (ComDevice.IsOpen)
        //    {
        //        try
        //        {
        //            //将消息传递给串口
        //            ComDevice.Write(data, 0, data.Length);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return false;
        //}

        public static byte[] serialport_dat = new byte[256];
        public static ushort serialport_flag = 0;
        public static byte serialport_len = 0;
        public static byte serialport_index = 0;
        public void Data_choice(byte[] da)
        {
            for(int i = 0;i < da.Length;i++)
            {
                serialport_dat[serialport_index++] = da[i];
                if (serialport_dat[0] == 0xAA && serialport_dat[1] == 0xAA && serialport_dat[2] >= 0x0B)
                {
                    if (serialport_index == serialport_dat[2] + 2)
                    {
                        byte[] dat = new byte[serialport_index-4];
                        for (int j = 0; j < dat.Length; j++)
                            dat[j] = serialport_dat[j + 2];
                        ushort crc = CRC_Computet(dat, dat.Length);
                        if (crc>>8 == serialport_dat[serialport_dat[2]] && (crc&0x00ff) == serialport_dat[serialport_dat[2]+1])
                        {
                            byte[] dat1 = new byte[serialport_index];
                            for (int j = 0; j < dat1.Length; j++)
                                dat1[j] = serialport_dat[j];
                            serialport_index = 0;
                            for (int j = 0; j < serialport_dat.Length; j++)
                                serialport_dat[j] = 0x00;
                            Data_Parse(dat1);
                            return;
                        }
                        else
                        {
                            serialport_index = 0;
                            for (int j = 0; j < serialport_dat.Length; j++)
                                serialport_dat[j] = 0x00;
                        }
                    }
                }
                else if ((serialport_index ==1 && serialport_dat[0] != 0xAA) || (serialport_index == 2 && serialport_dat[1] != 0xAA) || (serialport_index == 3 && serialport_dat[2] < 0x0B))
                {
                    serialport_index = 0;
                    for (int j = 0; j < serialport_dat.Length; j++)
                        serialport_dat[j] = 0x00;
                }
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
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
                MessageBox.Show("未发现可用串口，请检查硬件设备");
            }

            comboBox_BaudRate.SelectedIndex = comboBox_BaudRate.Items.IndexOf("9600");
            comboBox_DataBits.SelectedIndex = comboBox_DataBits.Items.IndexOf("8");
            comboBox_StopBits.SelectedIndex = comboBox_StopBits.Items.IndexOf("1");
            comboBox_Parity.SelectedIndex = comboBox_Parity.Items.IndexOf("偶校验");
            comboBox_CRCType.SelectedIndex = comboBox_CRCType.Items.IndexOf("CRC-CCITT (XModem)");
            pictureBox_Switch.BackColor = Color.Black;
            pictureBox_Relay.BackColor = Color.Black;
            pictureBox_Connect.BackColor = Color.Black;
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public bool Open = true;
        public bool Off = false;

        public void OperateRelay(byte addr0, byte addr1, int channel, bool status)
        {
            byte[] Buff_Relay = new byte[15] { 0xAA, 0xAA, 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x31, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Buff_Relay[9] = addr0;
            Buff_Relay[10] = addr1;
            if (channel > 0 && channel < 5) Buff_Relay[11] = (byte)channel;
            if (status) Buff_Relay[12] = 0x64;
            else Buff_Relay[12] = 0x00;
            Form1.Data_Send(Buff_Relay);
        }

        public void TransmitIR(byte addr0, byte addr1, int channel)
        {
            byte[] Buff_IR = new byte[15] { 0xAA, 0xAA, 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0, 0x1C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Buff_IR[9] = addr0;
            Buff_IR[10] = addr1;
            if (channel > 0 && channel < 255) Buff_IR[11] = (byte)channel;
            Buff_IR[12] = 0xFF;
        }

        public void StudyIR(byte addr0, byte addr1, int channel)
        {
            byte[] Buff_IR = new byte[15] { 0xAA, 0xAA, 0x0D, 0xFF, 0xFF, 0xFF, 0xFF, 0xE0, 0x1C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Buff_IR[9] = addr0;
            Buff_IR[10] = addr1;
            if (channel > 0 && channel < 255) Buff_IR[11] = (byte)channel;
        }
        public ushort CRC_Xmodeom(byte[] buff, int len)
        {
            ushort crc_val = 0x0000;
            ushort crc = 0x1021;
            for (int byt = 2; byt < len; byt++)
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

        private static int DataPrase_Index = 0;
        private static byte[] DataPrase_Buff = new byte[64];
        public void DataPrase(byte dat)
        {
            if (DataPrase_Index < 2)
            {
                if (dat == 0xAA) DataPrase_Buff[DataPrase_Index++] = dat;
            }
            else if (DataPrase_Index == 2)
            {
                DataPrase_Buff[DataPrase_Index++] = dat;
            }
            else if (DataPrase_Index < DataPrase_Buff[2] + 2 - 1) 
            {
                DataPrase_Buff[DataPrase_Index++] = dat;
            }
            else if (DataPrase_Index == DataPrase_Buff[2] + 2 -1)
            {
                DataPrase_Buff[DataPrase_Index] = dat;
                ushort crc = CRC_Xmodeom(DataPrase_Buff, DataPrase_Buff[2]);
                MessageBox.Show(crc.ToString());
            }
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            foreach( byte ch in ReDatas)
                DataPrase(ch);
        }

        public static bool Data_Send(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //将消息传递给串口
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
    }
}
