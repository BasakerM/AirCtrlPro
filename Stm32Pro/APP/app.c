#include "app.h"

void praser_485(unsigned char* buff);
void praser_IM1253B(unsigned char* buff);
void usart_get(void);
unsigned char usart1_get(unsigned char*buff,unsigned char dat);
unsigned char usart2_get(unsigned char* buff,unsigned char dat);
unsigned char usart3_get(unsigned char* buff,unsigned char dat);

unsigned char master_addr0 = 0x01;
unsigned char master_addr1 = 0x01;

unsigned char ir_addr0 = 0x5E;
unsigned char ir_addr1 = 0x38;

Usart* usart1 = NULL;
Usart* usart2 = NULL;
Usart* usart3 = NULL;
Led* led = NULL;
EEPRom* at24cx = NULL;
Relay* relay1 = NULL;
Relay* relay2 = NULL;
Relay* relay3 = NULL;
Relay* relay4 = NULL;

void App_Init(void)
{
	System.New_Tim(TIM3);
	System.New_Systick(100000);
	usart1 = System.New_Usart(USART1);
	usart2 = System.New_Usart(USART2);
	usart3 = System.New_Usart(USART3);
	led = System.New_Led(RCC_APB2Periph_GPIOC,GPIOC,GPIO_Pin_13);
	at24cx = System.New_EEPRom();
	relay1 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_12);
	relay2 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_13);
	relay3 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_14);
	relay4 = System.New_Relay(RCC_APB2Periph_GPIOB,GPIOB,GPIO_Pin_15);
	
	relay1->Close(relay1);
	relay2->Close(relay2);
	relay3->Close(relay3);
	relay4->Close(relay4);
	
	at24cx->WriteByte(0x00,0x19);
	unsigned char eep = at24cx->ReadByte(0x00);
	usart1->SendByte(usart1,&eep,1);
	
//	usart1->SendStr(usart1,"System Start\r\n");
//	usart2->SendStr(usart2,"IR Start\r\n");
//	usart3->SendStr(usart3,"IM1281B Start\r\n");
	
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
	if((buff[9] == master_addr0) && (buff[10] == master_addr1))
	{
		if((buff[7] == 0xE0) && (buff[8] == 0x1C))
		{/////////////////通用开关///////////////
			unsigned short crcc = 0;
			unsigned char SendBuff[15] = {0xaa,0xaa,0x0d,0x00,0x00,0x01,0x3F,0xE0,0x1D,0xFF,0xFF,0x00,0x01,0x00,0x00};
			SendBuff[3] = master_addr0; SendBuff[4] = master_addr1; SendBuff[11] = buff[11];
			if(buff[12] == 0xFF)
			{
				//////回复河东
				crcc = System.CRC_xModem(&SendBuff[2],11);
				SendBuff[13] = crcc>>8;
				SendBuff[14] = crcc&0x00ff;
				usart1->SendByte(usart1,SendBuff,15);
				//////发至IR
				unsigned char SendBuffToUsart2[11] = {0x7e,0x07,0x00,0xFF,0xFF,0x00,0x00,0x14,0x00,0x00,0x00};
				SendBuffToUsart2[5] = ir_addr0; SendBuffToUsart2[6] = ir_addr1;
				SendBuffToUsart2[8] = buff[11]; SendBuffToUsart2[10] = System.Sum(SendBuffToUsart2,10);
				usart2->SendByte(usart2,SendBuffToUsart2,11);
				return;
			}
		}
		else if((buff[7] == 0x00) && (buff[8] == 0x31))
		{/////////////////单路调节///////////////
			unsigned short crcc = 0;
			unsigned char SendBuff[18] = {0xaa,0xaa,0x10,0x00,0x00,0x01,0xBC,0x00,0x32,0xFF,0xFF,0x00,0xF8,0x00,0x04,0x00,0x00,0x00};
			SendBuff[3] = master_addr0; SendBuff[4] = master_addr1;
			switch(buff[11])
			{
				case 1: if(buff[12] == 0x64)
								{
									relay1->Open(relay1);
									SendBuff[11] = 0x01;//回路号
									SendBuff[13] = 0x64;//开关量
									SendBuff[15] = 0x01;//回路状态
								}
								else if(buff[12] == 0x00)
								{
									relay1->Close(relay1);
									SendBuff[11] = 0x01;//回路号
									SendBuff[13] = 0x00;//开关量
									SendBuff[15] = 0x00;//回路状态
								}
								crcc = System.CRC_xModem(&SendBuff[2],14);
								SendBuff[16] = crcc>>8;
								SendBuff[17] = crcc&0x00ff;
								usart1->SendByte(usart1,SendBuff,18);
								return;
				case 2:  break;
				case 3:  break;
				case 4:  break;
			}
		}
		else if((buff[7] == 0x19) && (buff[8] == 0x19))
		{/////////////////单路读取///////////////
			unsigned char SendToUsart3[8] = {0x01,0x03,0x00,0x4B,0x00,0x00,0x00,0x00};
			switch(buff[11])
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
	System.ClearBuff(buff,32);
}

void praser_IR(unsigned char* buff)
{
	if(buff[7] == 0x13 && buff[10] == 0x01)
	{//学习回复
		//学习成功
	}
	else if(buff[7] == 0x15 && buff[10] == 0x01)
	{//发射回复
		//发射成功
	}
	System.ClearBuff(buff,32);
}

void praser_IM1253B(unsigned char* buff)
{
	unsigned char SendBuff[18] = {0xaa,0xaa,0x10,0x00,0x00,0x19,0x19,0x19,0x19,0xff,0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
	SendBuff[3] = master_addr0; SendBuff[4] = master_addr1;
	SendBuff[11] = buff[0];
	SendBuff[12] = buff[3]; SendBuff[13] = buff[4]; SendBuff[14] = buff[5]; SendBuff[15] = buff[6];
	unsigned short crcc = 0;
	crcc = System_CRC_xModem(&SendBuff[2],14);
	SendBuff[16] = crcc>>8; SendBuff[17] = crcc&0x00ff;
	usart1->SendByte(usart1,SendBuff,18);
	System.ClearBuff(buff,32);
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
	if(usart2->RecvByte(usart2,&recv_dat))
	{
		if(usart2_get(usart2_recv_buff,recv_dat))
			praser_IR(usart1_recv_buff);
	}
	if(usart3->RecvByte(usart3,&recv_dat))
	{
		if(usart3_get(usart3_recv_buff,recv_dat))
			praser_IM1253B(usart3_recv_buff);
	}
}

unsigned char usart1_get(unsigned char*buff,unsigned char dat)
{
	static unsigned char usart1_recv_index = 0;
	
	if(usart1_recv_index < 2)
	{
		if(dat == 0xaa) buff[usart1_recv_index++] = dat;
		else
		{
			usart1_recv_index = 0;
			System.ClearBuff(buff,32);
		}
	}
	else if(usart1_recv_index == 2)
	{
		buff[usart1_recv_index++] = dat;
	}
	else if(usart1_recv_index < buff[2]+2-1)
	{
		buff[usart1_recv_index++] = dat;
	}
	else if(usart1_recv_index == buff[2]+2-1)
	{
		buff[usart1_recv_index] = dat;
		unsigned short crcc = System.CRC_xModem(&buff[2],buff[2]-2);
		if((buff[usart1_recv_index-1] == (crcc>>8)) && (buff[usart1_recv_index] == (crcc&0x00ff)))
		{
			usart1_recv_index = 0;
			return buff[2]+2;
		}
		else
		{
			usart1_recv_index = 0;
			System.ClearBuff(buff,32);
			return 0;
		}
	}
	else
	{
		usart1_recv_index = 0;
		System.ClearBuff(buff,32);
	}
	return 0;
}

unsigned char usart2_get(unsigned char* buff,unsigned char dat)
{
	static unsigned char usart2_recv_index = 0;
	
	if(usart2_recv_index == 0)
	{
		if(dat == 0x7e) buff[usart2_recv_index++] = dat;
	}
	else if(usart2_recv_index == 1 || usart2_recv_index == 2)
	{
		buff[usart2_recv_index++] = dat;
	}
	else if(usart2_recv_index < buff[1]+1+2)
	{
		buff[usart2_recv_index++] = dat;
	}
	else if(usart2_recv_index == buff[1]+1+2)
	{
		buff[usart2_recv_index] = dat;
		if(dat == System.Sum(buff,buff[1]+1+2))
		{
			usart2_recv_index = 0;
			return buff[1]+1+2+1;
		}
		else
		{
			usart2_recv_index = 0;
			System.ClearBuff(buff,32);
			return 0;
		}
	}
	else 
	{
		usart2_recv_index = 0;
		System.ClearBuff(buff,32);
	}
	return 0;
}

unsigned char usart3_get(unsigned char* buff,unsigned char dat)
{
	static unsigned char usart3_recv_index = 0;
	
	if(usart3_recv_index == 0)
	{
		if(dat == 0x01) buff[usart3_recv_index++] = dat;
	}
	else if(usart3_recv_index == 1)
	{
		if(dat == 0x03) buff[usart3_recv_index++] = dat;
		else 
		{
			usart3_recv_index = 0;
			System.ClearBuff(buff,32);
		}
	}
	else if(usart3_recv_index == 2)
	{
		buff[usart3_recv_index++] = dat;
	}
	else if(usart3_recv_index < buff[2]+1+1+1+1)
	{
		buff[usart3_recv_index++] = dat;
	}
	else if(usart3_recv_index == buff[2]+1+1+1+1)
	{
		buff[usart3_recv_index] = dat;
		unsigned short crcc = System.CRC_16(buff,buff[2]+1+1+1);
		if((buff[usart3_recv_index-1] == (crcc>>8)) && (buff[usart3_recv_index] == (crcc&0x00ff)))
		{
			usart3_recv_index = 0;
			return buff[2]+1+1+1+2;
		}
		else
		{
			usart3_recv_index = 0;
			System.ClearBuff(buff,32);
			return 0;
		}
	}
	else
	{
		usart3_recv_index = 0;
		System.ClearBuff(buff,32);
	}
	return 0;
}

