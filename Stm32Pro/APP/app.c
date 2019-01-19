#include "app.h"
#include "at24cx.h"

void praser_485(unsigned char* buff);
void praser_IM1253B(unsigned char* buff);
void usart_get(void);
unsigned char usart1_get(unsigned char*buff,unsigned char dat);
unsigned char usart3_get(unsigned char* buff,unsigned char dat);
void clear_buff(unsigned char* buff,unsigned short size);
unsigned short crc_16 ( unsigned char* buff, unsigned char len);
unsigned short crc(unsigned char* buff,unsigned char len);

unsigned char master_addr0 = 0x01;
unsigned char master_addr1 = 0x01;

unsigned char master_id_h = 0x09;
unsigned char master_id_l = 0x09;

#define EEPROM_ADDR_FIRST_POWER 0x00
#define EEPROM_ADDR_MASTER_ID_H 0x01
#define EEPROM_ADDR_MASTER_ID_L 0x02

Usart* usart1 = NULL;
Usart* usart2 = NULL;
Usart* usart3 = NULL;
Led* led = NULL;
Relay* relay1 = NULL;
Relay* relay2 = NULL;
Relay* relay3 = NULL;
Relay* relay4 = NULL;

void App_Init(void)
{
	System.New_Tim(TIM3);
	usart1 = System.New_Usart(USART1);
	usart2 = System.New_Usart(USART2);
	usart3 = System.New_Usart(USART3);
	led = System.New_Led(RCC_APB2Periph_GPIOC,GPIOC,GPIO_Pin_13);
	relay1 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_12);
	relay2 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_13);
	relay3 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_14);
	relay4 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_15);

	relay1->Close(relay1);
	relay2->Close(relay2);
	relay3->Close(relay3);
	relay4->Close(relay4);
	
	usart1->SendStr(usart1,"hello world--USART1\r\n");
	usart2->SendStr(usart2,"hello world--USART2\r\n");
	usart3->SendStr(usart3,"hello world--USART3\r\n");
	
}

void App_Loop(void)
{
	led->Flash(led);
	usart_get();
}

//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
void praser_485(unsigned char* buff)
{
	if((buff[7] == master_addr0) && (buff[8] == master_addr1))
	{
		if((buff[5] == 0xE0) && (buff[6] == 0x1C))
		{/////////////////通用开关///////////////
			if(buff[10] == 0xFF)
			{
				unsigned char SendBuff[5] = {0xA1,0xFD,0x02,0x00,0xDF};
				SendBuff[3] = buff[9];
				usart1->SendByte(usart2,SendBuff,5);
				return;
			}
		}
		else if((buff[5] == 0x00) && (buff[6] == 0x31))
		{/////////////////单路调节///////////////
			unsigned short crcc = 0;
			unsigned char SendBuff[18] = {0xaa,0xaa,0x10,0x00,0x00,0x01,0xBC,0x00,0x32,0xFF,0xFF,0x00,0xF8,0x00,0x04,0x00,0x00,0x00};
			SendBuff[3] = master_addr0; SendBuff[4] = master_addr1;
			switch(buff[9])
			{
				case 1: if(buff[10] == 0x64)
								{
									relay1->Open(relay1);
									SendBuff[11] = 0x01;//回路号
									SendBuff[13] = 0x64;//开关量
									SendBuff[15] = 0x01;//回路状态
								}
								else if(buff[10] == 0x00)
								{
									relay1->Close(relay1);
									SendBuff[11] = 0x01;//回路号
									SendBuff[13] = 0x00;//开关量
									SendBuff[15] = 0x00;//回路状态
								}
								crcc = crc(SendBuff,14);
								SendBuff[16] = crcc>>8;
								SendBuff[17] = crcc&0x00ff;
								usart1->SendByte(usart1,SendBuff,18);
								return;
				case 2:  break;
				case 3:  break;
				case 4:  break;
			}
		}
		else if((buff[5] == 0x19) && (buff[6] == 0x19))
		{/////////////////单路读取///////////////
			unsigned char SendToUsart3[8] = {0x01,0x03,0x00,0x4B,0x00,0x00,0x00,0x00};
			switch(buff[9])
			{
				case 1: SendToUsart3[5] = 0x01; SendToUsart3[6] = 0xF4; SendToUsart3[7] = 0x1C;
								usart3->SendByte(usart3,SendToUsart3,8);
				return;
				case 2:  return;
				case 3:  return;
				case 4:  return;
			}
		}
	}
	clear_buff(buff,32);
}

void praser_IM1253B(unsigned char* buff)
{
	unsigned char SendBuff[18] = {0xaa,0xaa,0x10,0x00,0x00,0x19,0x19,0x19,0x19,0xff,0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
	SendBuff[3] = master_addr0; SendBuff[4] = master_addr1;
	SendBuff[11] = buff[0];
	SendBuff[12] = buff[3]; SendBuff[13] = buff[4]; SendBuff[14] = buff[5]; SendBuff[15] = buff[6];
	unsigned short crcc = 0;
	crcc = crc(SendBuff,18);
	SendBuff[16] = crcc>>8; SendBuff[17] = crcc&0x00ff;
	usart1->SendByte(usart1,SendBuff,18);
	clear_buff(buff,32);
}

//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
unsigned char usart1_recv_buff[32] = {0};
unsigned char usart2_recv_buff[32] = {0};
unsigned char usart3_recv_buff[32] = {0};
unsigned char recv_dat = 0;
void usart_get(void)
{
	if(usart1->RecvByte(usart1,&recv_dat))
	{
		if(usart1_get(usart1_recv_buff,recv_dat))
			praser_485(usart1_recv_buff);
	}
	/*if(usart2->RecvByte(usart2,&recv_dat))
	{
		if(usart1_get(usart1_recv_buff,recv_dat))
			praser_485(usart1_recv_buff);
	}*/
	if(usart3->RecvByte(usart3,&recv_dat))
	{
		if(usart3_get(usart3_recv_buff,recv_dat))
			praser_IM1253B(usart3_recv_buff);
	}
}

unsigned char usart1_get(unsigned char*buff,unsigned char dat)
{
	static unsigned char usart1_recv_index = 0;
	static unsigned char usart1_recv_flag = 0;
	static unsigned char usart1_recv_len = 0;
	if(usart1_recv_flag < 2)
	{
		if(dat == 0xaa) usart1_recv_flag++;
	}
	else if(usart1_recv_flag == 2)
	{
		usart1_recv_len = 0; usart1_recv_index = 0;
		usart1_recv_len = dat;
		buff[usart1_recv_index++] = dat; usart1_recv_flag++;
	}
	else if(usart1_recv_flag == 3)
	{
		if(usart1_recv_index < usart1_recv_len-1)
		{
			buff[usart1_recv_index++] = dat;
		}
		else
		{
			usart1_recv_flag = 0;
			buff[usart1_recv_index] = dat;
			unsigned short cc = crc(usart1_recv_buff,usart1_recv_len-2);
			if((usart1_recv_buff[usart1_recv_len-2] == (cc>>8)) && (usart1_recv_buff[usart1_recv_len-1] == (cc&0x00ff)))
			{
				return usart1_recv_len;
			}
		}
	}
	return false;
}

//bool usart2_get(unsigned char* buff,unsigned char dat)
//{
//
//}

unsigned char usart3_get(unsigned char* buff,unsigned char dat)
{
	static unsigned char usart3_recv_index = 0;
	static unsigned char usart3_recv_len = 0;
	static unsigned char usart3_recv_flag = 0;
	if(usart3_recv_flag == 0)
	{
		if(dat == 0x01) { usart3_recv_flag++; buff[0] = dat; }
	}
	else if(usart3_recv_flag == 1)
	{
		if(dat == 0x03 || dat == 0x06) { usart3_recv_flag++; buff[1] = dat; }
	}
	else if(usart3_recv_flag == 2)
	{
		usart3_recv_len = 0; usart3_recv_index = 0;
		usart3_recv_len = dat; usart3_recv_flag++; buff[2] = dat;
	}
	else if(usart3_recv_flag == 3)
	{
		if(usart3_recv_index < usart3_recv_len+1)
		{
			buff[3+usart3_recv_index++] = dat;
		}
		else
		{
			usart3_recv_flag = 0;
			buff[3+usart3_recv_index] = dat;
			unsigned short cc = crc_16(buff,usart3_recv_len+3);
			if(((cc>>8) == buff[3+usart3_recv_index-1]) && ((cc&0x00ff) == buff[3+usart3_recv_index]))
			{
				//usart1->SendByte(usart1,buff,3+usart3_recv_len+2);
				return 3+usart3_recv_len+2;
			}
		}
	}
	return 0;
}

//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////
void clear_buff(unsigned char* buff,unsigned short size)
{
	while(size--)
		*buff++ = 0;
}

unsigned short crc_16 ( unsigned char* buff, unsigned char len)
{
	unsigned short crc=0xFFFF;
	unsigned char i, j;
	for (j = 0;j < len;j++)
	{
		crc = crc^(*buff++);
		for (i = 0;i < 8;i++)
		{
			if((crc&0x0001) > 0) { crc = crc>>1; crc = crc^ 0xa001; }
			else crc = crc>>1;
		}
	}
	crc = (crc>>8 | crc << 8) & 0xffff;
	return crc;
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
