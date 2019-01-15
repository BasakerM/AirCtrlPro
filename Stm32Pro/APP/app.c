#include "app.h"

void App_Init(void)
{
	system.Init();
}

void App_Loop(void)
{
	system.StatusLight();
}
