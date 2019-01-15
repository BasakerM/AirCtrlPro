#include "hardware.h"

void Led_Init(void);
void Relay_Init(void);
void Tim_Init(void);

void Hardware_Init(void)
{
	Led_Init();
	Relay_Init();
	Tim_Init();
}

void Led_flash(float sec)
{
	LED_REVERSAL;
	
}

/////////////////Stm32 Init/////////////////////

void Led_Init(void)
{
	RCC_APB2PeriphClockCmd(LED_RCC,ENABLE);
	
	GPIO_InitTypeDef GPIO_InitStruct;
	
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStruct.GPIO_Pin = LED_PIN;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(LED_GPIO,&GPIO_InitStruct);
}

void Relay_Init(void)
{
	RCC_APB2PeriphClockCmd(LED_RCC,ENABLE);
	
	GPIO_InitTypeDef GPIO_InitStruct;
	
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStruct.GPIO_Pin = LED_PIN;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(LED_GPIO,&GPIO_InitStruct);
}

void Tim_Init(void)
{
	
}
