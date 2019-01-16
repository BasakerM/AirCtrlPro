#include "system.h"

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


