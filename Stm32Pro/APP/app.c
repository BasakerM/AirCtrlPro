#include "app.h"


void app_init(void)
{
	system_init();
}

void app_loop(void)
{
	system.led();
}