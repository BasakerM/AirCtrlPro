#ifndef _system_h
#define _system_h

#include "stm32f10x.h"
#include "memorymanage.h"

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
//////////////////////////////////System///////////////////////////////////////
//////////////////////////////////System///////////////////////////////////////
//////////////////////////////////System///////////////////////////////////////
Relay* System_New_Relay(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
Led* System_New_Led(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
void System_New_Tim(TIM_TypeDef* TIMx);
Usart* System_New_Usart(USART_TypeDef* USARTx);

struct Struct_System
{
	Relay* (*New_Relay)(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
	Led* (*New_Led)(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
	void (*New_Tim)(TIM_TypeDef* TIMx);
	Usart* (*New_Usart)(USART_TypeDef* USARTx);
};
static struct Struct_System System = 
{
	System_New_Relay,System_New_Led,System_New_Tim,System_New_Usart
};

#endif
