#include "system.h"

//////////////////////////////////Relay///////////////////////////////////////
//////////////////////////////////Relay///////////////////////////////////////
//////////////////////////////////Relay///////////////////////////////////////
//////////////////////////////////Relay///////////////////////////////////////
//////////////////////////////////Relay///////////////////////////////////////
void System_Relay_Open(Relay* relay);
void System_Relay_Close(Relay* relay);
bool System_Relay_IsOpen(struct Struct_System_Relay* relay);

Relay* System_New_Relay(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin)
{
	Relay* relay = (Relay*)new(sizeof(Relay));
	relay->RCC_APB2Periph = RCC_APB2Periph;
	relay->GPIOx = GPIOx;
	relay->Pin = Pin;
	relay->Open = System_Relay_Open;
	relay->Close = System_Relay_Close;
	relay->IsOpen = System_Relay_IsOpen;
	
	RCC_APB2PeriphClockCmd(relay->RCC_APB2Periph,ENABLE);
	GPIO_InitTypeDef GPIO_InitStruct;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStruct.GPIO_Pin = relay->Pin;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(relay->GPIOx,&GPIO_InitStruct);
	
	return relay;
}

void System_Relay_Open(Relay* relay)
{
	GPIO_WriteBit(relay->GPIOx,relay->Pin,Bit_SET);
}

void System_Relay_Close(Relay* relay)
{
	GPIO_WriteBit(relay->GPIOx,relay->Pin,Bit_RESET);
}

bool System_Relay_IsOpen(Relay* relay)
{
	if(GPIO_ReadOutputDataBit(relay->GPIOx,relay->Pin) == Bit_SET)
		return true;
	else
		return false;
}

//////////////////////////////////Led///////////////////////////////////////
//////////////////////////////////Led///////////////////////////////////////
//////////////////////////////////Led///////////////////////////////////////
//////////////////////////////////Led///////////////////////////////////////
//////////////////////////////////Led///////////////////////////////////////
void System_Led_Open(Led* Led);
void System_Led_Close(Led* Led);
bool System_Led_IsOn(struct Struct_System_Led* Led);
void System_Led_Switch(Led* led);
void System_Led_Flash(Led* led);

Led* System_New_Led(uint32_t RCC_APB2Periph,GPIO_TypeDef* GPIOx,uint16_t Pin)
{
	Led* led = (Led*)new(sizeof(Led));
	led->RCC_APB2Periph = RCC_APB2Periph;
	led->GPIOx = GPIOx;
	led->Pin = Pin;
	led->FlashTime = 0.7;
	led->On = System_Led_Open;
	led->Off = System_Led_Close;
	led->IsOn = System_Led_IsOn;
	led->Switch = System_Led_Switch;
	led->Flash = System_Led_Flash;
	
	RCC_APB2PeriphClockCmd(led->RCC_APB2Periph,ENABLE);
	GPIO_InitTypeDef GPIO_InitStruct;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStruct.GPIO_Pin = led->Pin;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(led->GPIOx,&GPIO_InitStruct);
	
	return led;
}

void System_Led_Open(Led* led)
{
	GPIO_WriteBit(led->GPIOx,led->Pin,Bit_SET);
}

void System_Led_Close(Led* led)
{
	GPIO_WriteBit(led->GPIOx,led->Pin,Bit_RESET);
}

bool System_Led_IsOn(struct Struct_System_Led* led)
{
	if(GPIO_ReadOutputDataBit(led->GPIOx,led->Pin))
		return true;
	else
		return false;
}

void System_Led_Switch(Led* led)
{
	GPIO_WriteBit(led->GPIOx,led->Pin,(BitAction)(1-GPIO_ReadOutputDataBit(led->GPIOx,led->Pin)));
}

void System_Led_Flash(Led* led)
{
	if(Tim3.IsTimeOut(led->FlashTime,&Tim3))
	{
		led->Switch(led);
	}
}
//////////////////////////////////Usart///////////////////////////////////////
//////////////////////////////////Usart///////////////////////////////////////
//////////////////////////////////Usart///////////////////////////////////////
//////////////////////////////////Usart///////////////////////////////////////
//////////////////////////////////Usart///////////////////////////////////////
void System_Usart_SendStr(Usart* usart,char* dat);
void System_Usart_SendByte(Usart* usart,byte* dat,byte len);
bool System_Usart_RecvByte(Usart* usart,byte* dat);

Usart* System_New_Usart(USART_TypeDef* USARTx)
{
	Usart* usart = (Usart*)new(sizeof(Usart));
	if(USARTx == USART1)
	{
		usart->USARTx = USART1;
		usart->SendStr = System_Usart_SendStr;
		usart->SendByte = System_Usart_SendByte;
		usart->RecvByte = System_Usart_RecvByte;
		
		GPIO_InitTypeDef GPIO_InitStructure;
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1|RCC_APB2Periph_GPIOA,ENABLE);
		USART_DeInit(USART1);
		
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
		GPIO_Init(GPIOA,&GPIO_InitStructure);
		
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;
		GPIO_Init(GPIOA,&GPIO_InitStructure);
		
		USART_InitTypeDef USART_InitStruct;
		USART_InitStruct.USART_BaudRate = 9600;
		USART_InitStruct.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
		USART_InitStruct.USART_Mode = USART_Mode_Tx|USART_Mode_Rx;
		USART_InitStruct.USART_Parity = USART_Parity_No;
		USART_InitStruct.USART_StopBits = USART_StopBits_1;
		USART_InitStruct.USART_WordLength = USART_WordLength_8b;
		USART_Init(USART1,&USART_InitStruct);
		
		USART_Cmd(USART1,ENABLE);
		
		USART_ClearFlag(USART1,USART_FLAG_TC);
	}
	return usart;
}

void System_Usart_SendStr(Usart* usart,char* dat)
{
	while(*dat != '\0')
	{
		USART_SendData(usart->USARTx,*dat++);
		while(!USART_GetFlagStatus(usart->USARTx,USART_FLAG_TC));
	}
}

void System_Usart_SendByte(Usart* usart,byte* dat,byte len)
{
	while(len--)
	{
		USART_SendData(usart->USARTx,*dat++);
		while(!USART_GetFlagStatus(usart->USARTx,USART_FLAG_TC));
	}
}

bool System_Usart_RecvByte(Usart* usart,byte* dat)
{
	if(USART_GetFlagStatus(usart->USARTx,USART_FLAG_RXNE))
	{
		*dat = USART_ReceiveData(usart->USARTx);
		return true;
	}
	return false;
}
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
//////////////////////////////////Tim///////////////////////////////////////
bool System_Tim_IsTimeOut(float sec,Tim* tim);

void System_New_Tim(TIM_TypeDef* TIMx)
{
	if(TIMx == TIM3)
	{
		Tim3.TimeCount = 0;
		Tim3.IsTimeOut = System_Tim_IsTimeOut;
		
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
		NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
		NVIC_InitStructure.NVIC_IRQChannelSubPriority = 2;
		NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
		NVIC_Init(&NVIC_InitStructure);

		TIM_Cmd(TIM3, ENABLE);
	}
}

bool System_Tim_IsTimeOut(float sec,Tim* tim)
{
	unsigned int ms100 = sec*10;
	if(tim->TimeCount >= ms100)
	{
		tim->TimeCount = 0;
		return true;
	}
	return false;
}

void TIM3_IRQHandler(void)
{
	if(TIM_GetITStatus(TIM3, TIM_IT_Update) != RESET)
	{
		Tim3.TimeCount++;
		TIM_ClearITPendingBit(TIM3, TIM_IT_Update  );
	}
}


//////////////Old Code////////////////////////////////////////////////////////
//////////////Old Code////////////////////////////////////////////////////////
//////////////Old Code////////////////////////////////////////////////////////
/*
void System_Init(void)
{
	hardware.Init();
}

void System_StatusLight(void)
{
	switch(system.Value.RunStatus)
	{
		case enum_system_status_normal: hardware.Function.LedFlash(0.7); break;
	}
}

void System_OpenRelayChannel1(void)
{
	
}

bool System_GetByte_485(unsigned char* dat)
{
	if(hardware.Function.GetByte(hardware.Device.usart1,dat))
		return true;
	return false;
}

bool System_GetByte_IR(unsigned char* dat)
{
	if(hardware.Function.GetByte(hardware.Device.usart2,dat))
		return true;
	return false;
}

bool System_GetByte_E(unsigned char* dat)
{
	if(hardware.Function.GetByte(hardware.Device.usart3,dat))
		return true;
	return false;
}

void System_SendByte_485(unsigned char* dat,unsigned char len)
{
	hardware.Function.SendByte(hardware.Device.usart1,dat,len);
}

void System_SendByte_IR(unsigned char* dat,unsigned char len)
{
	hardware.Function.SendByte(hardware.Device.usart2,dat,len);
}

void System_SendByte_E(unsigned char* dat,unsigned char len)
{
	hardware.Function.SendByte(hardware.Device.usart3,dat,len);
}
*/

