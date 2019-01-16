#ifndef _system_h
#define _system_h

//#include "hardware.h"
#include "stm32f10x.h"
#include "memorymanage.h"


///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
typedef enum { false, true}bool;

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
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
typedef struct Struct_System_Tim3
{
	unsigned int TimeCount;
	
	bool (*IsTimeOut)(float sec);
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
	void (*Flash)(struct Struct_System_Led* led,Tim tim);
}Led;
//////////////////////////////////System///////////////////////////////////////
//////////////////////////////////System///////////////////////////////////////
//////////////////////////////////System///////////////////////////////////////
Relay* System_New_Relay(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
Led* System_New_Led(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
void System_New_Tim(TIM_TypeDef* TIMx);
struct Struct_System
{
	Relay* (*New_Relay)(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
	Led* (*New_Led)(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin);
	void (*New_Tim)(TIM_TypeDef* TIMx);
};
static struct Struct_System System = 
{
	System_New_Relay,System_New_Led,System_New_Tim
};
//////////////Old Code//////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
/*
void System_Init(void);
void System_StatusLight(void);
bool System_GetByte_485(unsigned char* dat);
bool System_GetByte_IR(unsigned char* dat);
bool System_GetByte_E(unsigned char* dat);
void System_SendByte_485(unsigned char* dat,unsigned char len);
void System_SendByte_IR(unsigned char* dat,unsigned char len);
void System_SendByte_E(unsigned char* dat,unsigned char len);

struct Struct_System_Value
{
	Enum_System_Status RunStatus;
};
////////////////////////////////////////////////////////
struct Struct_System_Function
{
	void (*StatusLight)(void);
	bool (*GetByte_485)(unsigned char* dat);
	bool (*GetByte_IR)(unsigned char* dat);
	bool (*GetByte_E)(unsigned char* dat);
	void (*SendByte_485)(unsigned char* dat,unsigned char len);
	void (*SendByte_IR)(unsigned char* dat,unsigned char len);
	void (*SendByte_E)(unsigned char* dat,unsigned char len);
};
////////////////////////////////////////////////////////
typedef struct Struct_System
{
	void (*Init)(void);
	
	struct Struct_System_Function Function;
	struct Struct_System_Value Value;
	
}System;
static System system = 
{
	System_Init,
////Function
	System_StatusLight,System_GetByte_485,System_GetByte_IR,System_GetByte_E,System_SendByte_485,System_SendByte_IR,System_SendByte_E,
////Value
	enum_system_status_normal
};
*/
#endif
