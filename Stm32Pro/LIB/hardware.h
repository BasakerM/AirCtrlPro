#ifndef _hardware_h
#define _hardware_h

#include "systick.h"
#include "usart.h"

///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
typedef enum
{
	enum_hardware_device_none,
	enum_usart_1,enum_usart_2,enum_usart_3,
	enum_led,
	enum_relay_1,enum_relay_2,enum_relay_3,enum_relay_4
}Enum_Hardware_Device;
typedef enum {high,off}Enum_Hardware_Status;
///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
void Hardware_Init(void);
void Led_flash(float sec);
void OpenRelay(Enum_Hardware_Device relay);
void CloseRelay(Enum_Hardware_Device relay);
unsigned char GetByteFromUsart(Enum_Hardware_Device usart,unsigned char* dat);
void SendByteToUsart(Enum_Hardware_Device usart,unsigned char* dat,unsigned char len);
///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
struct Struct_Hardwar_Device
{
	Enum_Hardware_Device usart1;
	Enum_Hardware_Device usart2;
	Enum_Hardware_Device usart3;
	Enum_Hardware_Device led;
	Enum_Hardware_Device relay1;
	Enum_Hardware_Device relay2;
	Enum_Hardware_Device relay3;
	Enum_Hardware_Device relay4;
};
////////////////////////////////////////////////////////
struct Struct_Hardwar_Value
{
	unsigned int Tim3_count;
};
////////////////////////////////////////////////////////
struct Struct_Hardwar_Function
{
	void (*LedFlash)(float sec);
	void (*OpenRelay)(Enum_Hardware_Device relay);
	void (*CloseRelay)(Enum_Hardware_Device relay);
	unsigned char (*GetByte)(Enum_Hardware_Device hard,unsigned char* dat);
	void (*SendByte)(Enum_Hardware_Device usart,unsigned char* dat,unsigned char len);
};
////////////////////////////////////////////////////////
typedef struct Struct_Hardware
{
	void (*Init)(void);
	struct Struct_Hardwar_Function Function;
	struct Struct_Hardwar_Device Device;
	struct Struct_Hardwar_Value Value;
}Hardware;

static Hardware hardware = 
{
	Hardware_Init,
////Function
	Led_flash,OpenRelay,CloseRelay,GetByteFromUsart,SendByteToUsart,
////Device
	enum_usart_1,enum_usart_2,enum_usart_3,
	enum_led,enum_relay_1,enum_relay_2,enum_relay_3,enum_relay_4,
////Value
	0
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////
#define SET_HIGH 1
#define SET_LOW 0
//////////Relay//////////////////////////////////////
#define RELAY_RCC RCC_APB2Periph_GPIOB
#define RELAY_GPIO GPIOB
#define RELAY_0_PIN GPIO_Pin_0
#define RELAY_1_PIN GPIO_Pin_1
#define RELAY_2_PIN GPIO_Pin_2
#define RELAY_3_PIN GPIO_Pin_3
#define RELAY_ALL_PIN RELAY_0_PIN|RELAY_1_PIN|RELAY_2_PIN|RELAY_3_PIN

#define RELAY_0_SET(a) if(a) GPIO_WriteBit(RELAY_GPIO,RELAY_0_PIN,Bit_SET); else GPIO_WriteBit(RELAY_GPIO,RELAY_0_PIN,Bit_RESET)
#define RELAY_1_SET(a) if(a) GPIO_WriteBit(RELAY_GPIO,RELAY_1_PIN,Bit_SET); else GPIO_WriteBit(RELAY_GPIO,RELAY_1_PIN,Bit_RESET)
#define RELAY_2_SET(a) if(a) GPIO_WriteBit(RELAY_GPIO,RELAY_2_PIN,Bit_SET); else GPIO_WriteBit(RELAY_GPIO,RELAY_2_PIN,Bit_RESET)
#define RELAY_3_SET(a) if(a) GPIO_WriteBit(RELAY_GPIO,RELAY_3_PIN,Bit_SET); else GPIO_WriteBit(RELAY_GPIO,RELAY_3_PIN,Bit_RESET)
//////////Led//////////////////////////////////////
#define LED_RCC RCC_APB2Periph_GPIOC
#define LED_GPIO GPIOC
#define LED_PIN GPIO_Pin_13

#define LED_SET(a) if(a) GPIO_WriteBit(LED_GPIO,LED_PIN,Bit_SET); else GPIO_WriteBit(LED_GPIO,LED_PIN,Bit_RESET)
#define LED_REVERSAL GPIO_WriteBit(LED_GPIO,LED_PIN,(BitAction)(1-GPIO_ReadOutputDataBit(LED_GPIO,LED_PIN)))

#endif
