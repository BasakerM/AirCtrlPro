#include "hardware.h"

void Led_Init(void);
void Relay_Init(void);
void Tim_Init(void);

void Hardware_Init(void)
{
	Led_Init();
	Relay_Init();
	Tim_Init();
	
	LED_SET(SET_LOW);
	RELAY_0_SET(SET_LOW);
	RELAY_1_SET(SET_LOW);
	RELAY_2_SET(SET_LOW);
	RELAY_3_SET(SET_LOW);
}

void Led_flash(float sec)
{
	unsigned int ms100 = sec*10;
	if(hardware.Value.Tim3_count >= ms100) 
	{
		hardware.Value.Tim3_count = 0;
		LED_REVERSAL;
	}
}

void OpenRelay(Enum_Hardware_Device relay)
{
	switch(relay)
	{
		case enum_relay_1: RELAY_0_SET(SET_HIGH); break;
		case enum_relay_2: RELAY_0_SET(SET_HIGH); break;
		case enum_relay_3: RELAY_0_SET(SET_HIGH); break;
		case enum_relay_4: RELAY_0_SET(SET_HIGH); break;
	}
}

void CloseRelay(Enum_Hardware_Device relay)
{
	switch(relay)
	{
		case enum_relay_1: RELAY_0_SET(SET_HIGH); break;
		case enum_relay_2: RELAY_0_SET(SET_HIGH); break;
		case enum_relay_3: RELAY_0_SET(SET_HIGH); break;
		case enum_relay_4: RELAY_0_SET(SET_HIGH); break;
	}
}

unsigned char GetByteFromUsart(Enum_Hardware_Device usart,unsigned char* dat)
{
	USART_TypeDef* USARTx;
	switch(usart)
	{
		case enum_usart_1: USARTx = USART1; break;
		case enum_usart_2: USARTx = USART2; break;
		case enum_usart_3: USARTx = USART3; break;
	}
	if(USART_GetFlagStatus(USARTx,USART_FLAG_RXNE))
	{
		*dat = USART_ReceiveData(USARTx);
		return 1;
	}
	return 0;
}

void SendByteToUsart(Enum_Hardware_Device usart,unsigned char* dat,unsigned char len)
{
	USART_TypeDef* USARTx;
	switch(usart)
	{
		case enum_usart_1: USARTx = USART1; break;
		case enum_usart_2: USARTx = USART2; break;
		case enum_usart_3: USARTx = USART3; break;
	}
	while(len--)
	{
		USART_SendData(USARTx,*dat++);
		while(!USART_GetFlagStatus(USARTx,USART_FLAG_TC));
	}
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
	TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;

	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
	
	TIM_TimeBaseStructure.TIM_Period = 999;	//100ms
	TIM_TimeBaseStructure.TIM_Prescaler =7199;	//10Khz
	TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
 
	TIM_ITConfig(TIM3,TIM_IT_Update,ENABLE );

	NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 2;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 2;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);

	TIM_Cmd(TIM3, ENABLE);	
}

void TIM3_IRQHandler(void)
{
	if(TIM_GetITStatus(TIM3, TIM_IT_Update) != RESET)
	{
		hardware.Value.Tim3_count++;
		TIM_ClearITPendingBit(TIM3, TIM_IT_Update  );
	}
}
