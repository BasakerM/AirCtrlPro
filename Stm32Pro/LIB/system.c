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
	else if(USARTx == USART2)
	{
		usart->USARTx = USART2;
		usart->SendStr = System_Usart_SendStr;
		usart->SendByte = System_Usart_SendByte;
		usart->RecvByte = System_Usart_RecvByte;
		
		GPIO_InitTypeDef GPIO_InitStructure;
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA,ENABLE);
		RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART2,ENABLE);
		USART_DeInit(USART2);
		
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_2;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
		GPIO_Init(GPIOA,&GPIO_InitStructure);
		
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_3;
		GPIO_Init(GPIOA,&GPIO_InitStructure);
		
		USART_InitTypeDef USART_InitStruct;
		USART_InitStruct.USART_BaudRate = 9600;
		USART_InitStruct.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
		USART_InitStruct.USART_Mode = USART_Mode_Tx|USART_Mode_Rx;
		USART_InitStruct.USART_Parity = USART_Parity_No;
		USART_InitStruct.USART_StopBits = USART_StopBits_1;
		USART_InitStruct.USART_WordLength = USART_WordLength_8b;
		USART_Init(USART2,&USART_InitStruct);
		
		USART_Cmd(USART2,ENABLE);
		
		USART_ClearFlag(USART2,USART_FLAG_TC);
	}
	else if(USARTx == USART3)
	{
		usart->USARTx = USART3;
		usart->SendStr = System_Usart_SendStr;
		usart->SendByte = System_Usart_SendByte;
		usart->RecvByte = System_Usart_RecvByte;
		
		GPIO_InitTypeDef GPIO_InitStructure;
		RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB,ENABLE);
		RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3,ENABLE);
		USART_DeInit(USART3);
		
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;
		GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
		GPIO_Init(GPIOB,&GPIO_InitStructure);
		
		GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
		GPIO_InitStructure.GPIO_Pin = GPIO_Pin_11;
		GPIO_Init(GPIOB,&GPIO_InitStructure);
		
		USART_InitTypeDef USART_InitStruct;
		USART_InitStruct.USART_BaudRate = 9600;
		USART_InitStruct.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
		USART_InitStruct.USART_Mode = USART_Mode_Tx|USART_Mode_Rx;
		USART_InitStruct.USART_Parity = USART_Parity_No;
		USART_InitStruct.USART_StopBits = USART_StopBits_1;
		USART_InitStruct.USART_WordLength = USART_WordLength_8b;
		USART_Init(USART3,&USART_InitStruct);
		
		USART_Cmd(USART3,ENABLE);
		
		USART_ClearFlag(USART3,USART_FLAG_TC);
	}
	return usart;
}

void System_Usart_SendStr(Usart* usart,char* dat)
{
	USART_GetFlagStatus(usart->USARTx,USART_FLAG_TC);
	while(*dat != '\0')
	{
		USART_SendData(usart->USARTx,*dat++);
		while(!USART_GetFlagStatus(usart->USARTx,USART_FLAG_TC));
	}
}

void System_Usart_SendByte(Usart* usart,byte* dat,byte len)
{
	USART_GetFlagStatus(usart->USARTx,USART_FLAG_TC);
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
//////////////////////////////////AT24C02///////////////////////////////////////
//////////////////////////////////AT24C02///////////////////////////////////////
//////////////////////////////////AT24C02///////////////////////////////////////
//////////////////////////////////AT24C02///////////////////////////////////////
//////////////////////////////////AT24C02///////////////////////////////////////


//////////////////////////////////Systick///////////////////////////////////////
//////////////////////////////////Systick///////////////////////////////////////
//////////////////////////////////Systick///////////////////////////////////////
//////////////////////////////////Systick///////////////////////////////////////
//////////////////////////////////Systick///////////////////////////////////////
void System_SystickDelay(unsigned int time);

void System_SystickInit(unsigned long time)
{
	if(time > 0 && time <= 1000000)
	{
		systick.Time = 1;
		systick.Delay = System_SystickDelay;
		
		SysTick_Config(SystemCoreClock/(1000000/time));
		SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;
	}
}

void System_SystickDelay(unsigned int time)
{
	systick.Time = time;
	SysTick->CTRL |=SysTick_CTRL_ENABLE_Msk;
	while(systick.Time);
	SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;
}

//unsigned long time_out = 0;
//void timeout_start(float sec)
//{
//	if(sec > 0)
//	{
//		time_out = sec*10;
//		SysTick->CTRL |=SysTick_CTRL_ENABLE_Msk;
//	}
//}

//void timeout_end(void)
//{
//	time_out = 0;
//	SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;
//}

//unsigned char timeout_status_get(void)
//{
//	if(time_out)
//	{
//		return 0;
//	}
//	else
//	{
//		SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;
//		return 1;
//	}
//}

//void systick_ms(unsigned long time)
//{
//	Timing=time*1000;
//	SysTick->CTRL |=SysTick_CTRL_ENABLE_Msk;
//	while(Timing!=0);
//}

//void systick_us(unsigned long time)
//{
//	Timing=time;
//	SysTick->CTRL |=SysTick_CTRL_ENABLE_Msk;
//	while(Timing!=0);
//}

void SysTick_Handler(void)
{
	if(systick.Time) systick.Time--;
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

//////////////////////////////////IIC///////////////////////////////////////
//////////////////////////////////IIC///////////////////////////////////////
//////////////////////////////////IIC///////////////////////////////////////
//////////////////////////////////IIC///////////////////////////////////////
//////////////////////////////////IIC///////////////////////////////////////
#define GPIO_RCC_IIC RCC_APB2Periph_GPIOA
#define GPIOX_IIC GPIOA
#define GPIO_PIN_IIC_SDA GPIO_Pin_0
#define GPIO_PIN_IIC_SCL GPIO_Pin_1

#define IIC_SDA_H GPIO_SetBits(GPIOX_IIC,GPIO_PIN_IIC_SDA)
#define IIC_SDA_L GPIO_ResetBits(GPIOX_IIC,GPIO_PIN_IIC_SDA)
#define IIC_SDA_R GPIO_ReadInputDataBit(GPIOX_IIC,GPIO_PIN_IIC_SDA)
#define IIC_SCL_H GPIO_SetBits(GPIOX_IIC,GPIO_PIN_IIC_SCL)
#define IIC_SCL_L GPIO_ResetBits(GPIOX_IIC,GPIO_PIN_IIC_SCL)

void System_IICDelayUs(unsigned short us)
{
	unsigned short k = 0;
	while(--us)
	{
		k = 500;
		while(--k);
	}
}

void System_IICInit(void)
{
	GPIO_InitTypeDef GPIO_InitStruct;
	RCC_APB2PeriphClockCmd(GPIO_RCC_IIC,ENABLE);
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStruct.GPIO_Pin = GPIO_PIN_IIC_SCL|GPIO_PIN_IIC_SDA;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOX_IIC,&GPIO_InitStruct);
}

void System_IICSDAIn(void)
{
	GPIO_InitTypeDef GPIO_InitStruct;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_IPU;
	GPIO_InitStruct.GPIO_Pin = GPIO_PIN_IIC_SDA;
	GPIO_Init(GPIOX_IIC,&GPIO_InitStruct);
}

void System_IICSDAOut(void)
{
	GPIO_InitTypeDef GPIO_InitStruct;
	GPIO_InitStruct.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStruct.GPIO_Pin = GPIO_PIN_IIC_SDA;
	GPIO_InitStruct.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(GPIOX_IIC,&GPIO_InitStruct);
}

void System_IICStart(void)
{
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	IIC_SDA_H;
	System_IICDelayUs(5);
	IIC_SCL_H;
	System_IICDelayUs(5);
	IIC_SDA_L;
	System_IICDelayUs(5);
	IIC_SCL_L;
	System_IICDelayUs(5);
}

void System_IICStop(void)
{
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	IIC_SDA_L;
	System_IICDelayUs(5);
	IIC_SCL_H;
	System_IICDelayUs(5);
	IIC_SDA_H;
	System_IICDelayUs(5);
	IIC_SCL_L;
	System_IICDelayUs(5);
}

unsigned char System_IICWaitAck(void)
{
	unsigned short time = 0;
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	IIC_SDA_H;
	System_IICSDAIn();
	System_IICDelayUs(5);
	IIC_SCL_H;
	System_IICDelayUs(5);
	while(IIC_SDA_R)
	{
		time++;
		if(time > 65000) return 0;
	}
	System_IICDelayUs(5);
	IIC_SCL_L;
	System_IICDelayUs(5);
	return 1;
}

void System_IICAck(void)
{
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	IIC_SDA_L;
	System_IICDelayUs(5);
	IIC_SCL_H;
	System_IICDelayUs(5);
	IIC_SCL_L;
	System_IICDelayUs(5);
}

void System_IICNoAck(void)
{
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	IIC_SDA_H;
	System_IICDelayUs(5);
	IIC_SCL_H;
	System_IICDelayUs(5);
	IIC_SCL_L;
	System_IICDelayUs(5);
}

void System_IICWriteByte(unsigned char data)
{
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	for(int i = 0;i < 8;i++)
	{
		if(data&0x80)
			IIC_SDA_H;
		else
			IIC_SDA_L;
		data <<= 1;
		System_IICDelayUs(5);
		IIC_SCL_H;
		System_IICDelayUs(5);
		IIC_SCL_L;
		System_IICDelayUs(5);
	}
}

unsigned char System_IICReadByte(void)
{
	unsigned char data = 0x00;
	IIC_SCL_L;
	System_IICDelayUs(5);
	System_IICSDAOut();
	IIC_SDA_H;
	System_IICSDAIn();
	System_IICDelayUs(5);
	for(int i = 0;i < 8;i++)
	{
		IIC_SCL_H;
		System_IICDelayUs(5);
		data = (data<<1) | IIC_SDA_R;
		System_IICDelayUs(5);
		IIC_SCL_L;
		System_IICDelayUs(5);
	}
	return data;
}

//////////////////////////////////AT24Cx///////////////////////////////////////
//////////////////////////////////AT24Cx///////////////////////////////////////
//////////////////////////////////AT24Cx///////////////////////////////////////
//////////////////////////////////AT24Cx///////////////////////////////////////
//////////////////////////////////AT24Cx///////////////////////////////////////
#define AT24CX_ADDR_W 0xA0
#define AT24CX_ADDR_R 0xA1

unsigned char System_AT24CxReadByte(unsigned char addr);
void System_AT24CxWriteByte(unsigned char addr,unsigned char data);

void System_AT24CxDelay()
{
	unsigned short time = 8000;
	while(--time);
}

EEPRom* System_AT24CxInit(void)
{
	System_IICInit();
	EEPRom* eeprom = (EEPRom*)new(sizeof(EEPRom));
	eeprom->ReadByte = System_AT24CxReadByte;
	eeprom->WriteByte = System_AT24CxWriteByte;
	return eeprom;
}

void System_AT24CxWriteByte(unsigned char addr,unsigned char data)
{
	System_IICStart();
	System_IICWriteByte(AT24CX_ADDR_W);
	System_IICAck();
	System_IICWriteByte(0x00);
	System_IICAck();
	System_IICWriteByte(addr);
	System_IICAck();
	System_IICWriteByte(data);
	System_IICAck();
	System_IICStop();
	System_AT24CxDelay();
}

unsigned char System_AT24CxReadByte(unsigned char addr)
{
	unsigned char data = 0x00;
	System_IICStart();
	System_IICWriteByte(AT24CX_ADDR_W);
	System_IICAck();
	System_IICWriteByte(0x00);
	System_IICAck();
	System_IICWriteByte(addr);
	System_IICAck();
	System_IICStart();
	System_IICWriteByte(AT24CX_ADDR_R);
	System_IICAck();
	data = System_IICReadByte();
	System_IICNoAck();
	System_IICStop();
	System_AT24CxDelay();
	return data;
}
//////////////////////////////////System Function///////////////////////////////////////
//////////////////////////////////System Function///////////////////////////////////////
//////////////////////////////////System Function///////////////////////////////////////
//////////////////////////////////System Function///////////////////////////////////////
//////////////////////////////////System Function///////////////////////////////////////

void System_Delay(unsigned int time)
{
	systick.Time = time;
	SysTick->CTRL |=SysTick_CTRL_ENABLE_Msk;
	while(systick.Time);
	SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;
}

void System_ClearBuff(unsigned char* buff,unsigned short size)
{
	while(size--)
		*buff++ = 0;
}

unsigned char System_Sum(unsigned char* buff,unsigned char len)
{
	unsigned char sum = 0;
	while(len--)
		sum += *buff++;
	return sum;
}

unsigned short System_CRC_16(unsigned char* buff,unsigned char len)
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

unsigned short System_CRC_xModem(unsigned char* buff,unsigned char len)
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

//////////////////////////////////System Base///////////////////////////////////////

static unsigned char Memory[MEMORY_SIZE_MAX] = {0};
static unsigned int MemoryFreeSize = MEMORY_SIZE_MAX;
static unsigned char* MemoryFreeAddr = Memory;

void* new(unsigned char size)
{
	if(size > MemoryFreeSize) return NULL;
	
	void* addr = (void*)MemoryFreeAddr;
	MemoryFreeSize -= size;
	MemoryFreeAddr += size;
	
	return addr;
}


//////////////////////////////////System Base///////////////////////////////////////
