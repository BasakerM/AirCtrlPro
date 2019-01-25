#ifndef _system_h
#define _system_h

#include "stm32f10x.h"

//////////////////////////////////////////////////////////////////////////////
typedef enum { false, true}bool;
typedef unsigned char byte;

//////////////////////////////////Relay///////////////////////////////////////
//////////////////////////////////Relay///////////////////////////////////////
//////////////////////////////////Relay///////////////////////////////////////
typedef struct Struct_System_Relay
{
	uint32_t RCC_APB2Periph;
	GPIO_TypeDef* GPIOx;
	uint16_t Pin;
	
	void (*Open)(struct Struct_System_Relay* relay);
	void (*Close)(struct Struct_System_Relay* relay);
	bool (*IsOpen)(struct Struct_System_Relay* relay);
}Relay;
//////////////////////////////////Led///////////////////////////////////////
//////////////////////////////////Led///////////////////////////////////////
//////////////////////////////////Led///////////////////////////////////////
typedef struct Struct_System_Led
{
	uint32_t RCC_APB2Periph;
	GPIO_TypeDef* GPIOx;
	uint16_t Pin;
	
	float FlashTime;
	
	void (*On)(struct Struct_System_Led* led);
	void (*Off)(struct Struct_System_Led* led);
	bool (*IsOn)(struct Struct_System_Led* led);
	void (*Switch)(struct Struct_System_Led* led);
	void (*Flash)(struct Struct_System_Led* led);
}Led;
//////////////////////////////////AT24Cx///////////////////////////////////////
//////////////////////////////////AT24Cx///////////////////////////////////////
//////////////////////////////////AT24Cx///////////////////////////////////////
typedef struct Struct_System_EEPRom
{
	unsigned char (*ReadByte)(unsigned char addr);
	void (*WriteByte)(unsigned char addr,unsigned char dat);
}EEPRom;
//////////////////////////////////Usart///////////////////////////////////////
//////////////////////////////////Usart///////////////////////////////////////
//////////////////////////////////Usart///////////////////////////////////////
typedef struct Struct_System_Usart
{
	USART_TypeDef* USARTx;
	
	void (*SendStr)(struct Struct_System_Usart* usart,char* dat);
	void (*SendByte)(struct Struct_System_Usart* usart,byte* dat,byte len);
	bool (*RecvByte)(struct Struct_System_Usart* usart,byte* dat);
}Usart;
//static Usart Usart1 = {USART1,System_Usart_SendByte};
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
typedef struct Struct_System_Tim
{
	unsigned int TimeCount;
	
	bool (*IsTimeOut)(float sec,struct Struct_System_Tim* tim);
}Tim;
static Tim Tim3;
//////////////////////////////////Systick///////////////////////////////////////
//////////////////////////////////Systick///////////////////////////////////////
//////////////////////////////////Systick///////////////////////////////////////
typedef struct Struct_System_Systick
{
	unsigned int Time;
	
	void (*Delay)(unsigned int time);
}Systick;
static Systick systick;
//////////////////////////////////System///////////////////////////////////////
//////////////////////////////////System///////////////////////////////////////
//////////////////////////////////System///////////////////////////////////////
Relay* System_New_Relay(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
Led* System_New_Led(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
EEPRom* System_AT24CxInit(void);
void System_New_Tim(TIM_TypeDef* TIMx);
Usart* System_New_Usart(USART_TypeDef* USARTx);
void System_SystickInit(unsigned long time);

void System_Delay(unsigned int time);
unsigned char System_Sum(unsigned char* buff,unsigned char len);
void System_ClearBuff(unsigned char* buff,unsigned short size);
unsigned short System_CRC_16(unsigned char* buff,unsigned char len);
unsigned short System_CRC_xModem(unsigned char* buff,unsigned char len);
	
struct Struct_System
{
	Relay* (*New_Relay)(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
	Led* (*New_Led)(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
	EEPRom* (*New_EEPRom)(void);
	void (*New_Tim)(TIM_TypeDef* TIMx);
	Usart* (*New_Usart)(USART_TypeDef* USARTx);
	void (*New_Systick)(unsigned long time);
	
	void (*Delay)(unsigned int time);
	unsigned char (*Sum)(unsigned char* buff,unsigned char len);
	void (*ClearBuff)(unsigned char* buff,unsigned short size);
	unsigned short (*CRC_16)(unsigned char* buff,unsigned char len);
	unsigned short (*CRC_xModem)(unsigned char* buff,unsigned char len);
};
static struct Struct_System System = 
{
	System_New_Relay,System_New_Led,System_AT24CxInit,System_New_Tim,System_New_Usart,System_SystickInit,
	System_Delay,System_Sum,System_ClearBuff,System_CRC_16,System_CRC_xModem
};

//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
#define MEMORY_SIZE_MAX 8000
#define NULL 0
void* new(unsigned char size);
//////////////////////////////////////////////////////////////////////////////
#endif
