#include "system.h"

void System_Init(void)
{
	hardware.Init();
}

void System_StatusLight(void)
{
	switch(system.RunStatus)
	{
		case SystemStatus_normal: hardware.LedFlash(0.5); break;
	}
}
