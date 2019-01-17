#include "app.h"

void usart_get(void);
bool usart1_get(unsigned dat);
unsigned short crc(unsigned char* buff,unsigned char len);

Led* led = NULL;
Usart* usart1 = NULL;
Relay* relay1 = NULL;

unsigned char master_addr0 = 0x00;
unsigned char master_addr1 = 0x00;

void App_Init(void)
{
	System.New_Tim(TIM3);
	usart1 = System.New_Usart(USART1);
	led = System.New_Led(RCC_APB2Periph_GPIOC,GPIOC,GPIO_Pin_13);
	relay1 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_12);
	
	usart1->SendStr(usart1,"hello world\r\n");
	relay1->Open(relay1);
	if(relay1->IsOpen(relay1)) 
		usart1->SendStr(usart1,"relay1 is open\r\n");
	else 
		usart1->SendStr(usart1,"relay1 is close\r\n");
}

void App_Loop(void)
{
	led->Flash(led);
	usart_get();
	//获取485数据
	//发送485数据
	//获取IR数据
	//发送IR数据
	//获取101S数据
	//发送101S数据
	//设置继电器状态
	//获取继电器状态
}


unsigned char usart1_recv_buff[32] = {0};
unsigned char usart1_recv_index = 0;
unsigned char usart1_recv_dat_len = 0;
unsigned char usart1_recv_flag = 0;

unsigned char index_addr0_485 = 1;
unsigned char index_addr1_485 = 2;
unsigned char index_code0_485 = 5;
unsigned char index_code1_485 = 6;
unsigned char index_addr3_485 = 7;
unsigned char index_addr4_485 = 8;
unsigned char index_data_485 = 9;

void praser_485(unsigned char* buff)
{
	if((buff[index_addr3_485] == master_addr0) && (buff[index_addr3_485] == master_addr1))
	{
		if((buff[index_code0_485] == 0xE0) && (buff[index_code1_485] == 0x1C))
		{/////////////////通用开关号///////////////
			
		}
		else if((buff[index_code0_485] == 0x00) && (buff[index_code1_485] == 0x31))
		{/////////////////继电器指令///////////////
			unsigned short crcc = 0;
			unsigned char SendBuff[18] = {0x19,0x19,0x10,0x00,0x00,0x01,0xBC,0x00,0x32,0xFF,0xFF,0x00,0xF8,0x00,0x04,0x00,0x00,0x00};
			SendBuff[index_addr0_485] = master_addr0; SendBuff[index_addr1_485] = master_addr1;
			switch(buff[index_data_485])
			{
				case 1: if(buff[index_data_485+1] == 0x64)
								{
									relay1->Open(relay1);
									SendBuff[index_data_485] = 0x01;//回路号
									SendBuff[index_data_485+2] = 0x64;//开关量
									SendBuff[index_data_485+4] = 0x01;//回路状态
								}
								else if(buff[index_data_485+1] == 0x00)
								{
									relay1->Close(relay1);
									SendBuff[index_data_485] = 0x01;//回路号
									SendBuff[index_data_485+2] = 0x00;//开关量
									SendBuff[index_data_485+4] = 0x00;//回路状态
								}
								crcc = crc(SendBuff,14);
								SendBuff[index_data_485+5] = crcc>>8;
								SendBuff[index_data_485+6] = crcc&0x00ff;
					break;
				case 2:  break;
				case 3:  break;
				case 4:  break;
			}
		}
	}
}

unsigned char recv_dat = 0;
void usart_get(void)
{
	if(usart1->RecvByte(usart1,&recv_dat))
	{
		if(usart1_get(recv_dat))
		{
			usart1->SendByte(usart1,usart1_recv_buff,usart1_recv_dat_len);
			relay1->Close(relay1);
		}
	}
}

bool usart1_get(unsigned dat)
{
	if(usart1_recv_flag < 2)
	{
		if(dat == 0xaa) usart1_recv_flag++;
	}
	else if(usart1_recv_flag == 2)
	{
		usart1_recv_dat_len = 0; usart1_recv_index = 0;
		usart1_recv_dat_len = dat;
		usart1_recv_buff[usart1_recv_index++] = dat; usart1_recv_flag++;
	}
	else if(usart1_recv_flag == 3)
	{
		if(usart1_recv_index < usart1_recv_dat_len-1)
		{
			usart1_recv_buff[usart1_recv_index++] = dat;
		}
		else
		{
			usart1_recv_flag = 0;
			usart1_recv_buff[usart1_recv_index] = dat;
			unsigned short cc = crc(usart1_recv_buff,usart1_recv_dat_len-2);
			if((usart1_recv_buff[usart1_recv_dat_len-2] == (cc>>8)) && (usart1_recv_buff[usart1_recv_dat_len-1] == (cc&0x00ff)))
			{
				return true;
			}
		}
	}
	return false;
}



unsigned short crc(unsigned char* buff,unsigned char len)
{
	unsigned short crcin = 0x0000;
	unsigned short crc = 0x1021;
	while(len--)
	{
		crcin = ((crcin&0xff00)^((*buff++)<<8))|(crcin&0x00ff);
		unsigned char bi = 8;
		while(bi--)
		{
			if((crcin & 0x8000) > 0){crcin <<= 1; crcin ^= crc;}
			else crcin <<= 1;
		}
	}
	return crcin;
}
