#ifndef _hardware_h
#define _hardware_h

#include "systick.h"
#include "usart.h"

void Hardware_Init(void);
void Led_flash(float sec);

///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
typedef enum
{
	enum_led,
	enum_relay_0,enum_relay_1,enum_relay_2,enum_relay_3
}Enum_Hardware_Device;
////////////////////////////////////////////////////////
typedef struct Struct_Hardwar_Device
{
	Enum_Hardware_Device led;
	Enum_Hardware_Device relay0;
	Enum_Hardware_Device relay1;
	Enum_Hardware_Device relay2;
	Enum_Hardware_Device relay3;
}Device;
static Device device =
{
	enum_led,
	enum_relay_0,enum_relay_1,enum_relay_2,enum_relay_3
};
////////////////////////////////////////////////////////
typedef struct Struct_Hardware
{
	void (*Init)(void);
	void (*LedFlash)(float sec);
}Hardware;
static Hardware hardware = 
{
	Hardware_Init,Led_flash
};
///////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////Relay//////////////////////////////////////
#define RELAY_RCC RCC_APB2Periph_GPIOC
#define RELAY_GPIO GPIOC
#define RELAY_ALL_PIN GPIO_Pin_all
#define RELAY_0_PIN GPIO_Pin_0
#define RELAY_1_PIN GPIO_Pin_1
#define RELAY_2_PIN GPIO_Pin_2
#define RELAY_3_PIN GPIO_Pin_3

#define RELAY
//////////Led//////////////////////////////////////
#define LED_RCC RCC_APB2Periph_GPIOC
#define LED_GPIO GPIOC
#define LED_PIN GPIO_Pin_13

#define LED_REVERSAL GPIO_WriteBit(LED_GPIO,LED_PIN,(BitAction)(1-GPIO_ReadInputDataBit(LED_GPIO,LED_PIN)))

#endif
