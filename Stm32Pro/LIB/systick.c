#include "systick.h"

void systick_init(unsigned int time)
{
	
	SysTick_Config(SystemCoreClock/(1000000/time));
	SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;
}

//
//	设定超时时间,并开启超时
//	sec : 要超时的时间,单位是1sec,小数位一位,例如2.5s
//
unsigned long time_out = 0;
void timeout_start(float sec)
{
	if(sec > 0)
	{
		time_out = sec*10;
		SysTick->CTRL |=SysTick_CTRL_ENABLE_Msk;//开启滴答
	}
}

//
//	关闭超时
void timeout_end(void)
{
	time_out = 0;
	SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;//关闭滴答
}

//
//	获取超时的状态
//	超时后返回 1,未超时则返回0
//
unsigned char timeout_status_get(void)
{
	if(time_out)	//未超时
	{
		return 0;
	}
	else	//超时
	{
		SysTick->CTRL &=~SysTick_CTRL_ENABLE_Msk;//关闭滴答
		return 1;
	}
}

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
	if(time_out)
		time_out--;
	
//	if(Timing!=0)
//		Timing--;
}
