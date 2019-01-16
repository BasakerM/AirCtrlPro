#include "app.h"

void App_Init(void)
{
	system.Init();
}

void App_Loop(void)
{
	system.Function.StatusLight();
	//获取485数据
	//发送485数据
	//获取IR数据
	//发送IR数据
	//获取101S数据
	//发送101S数据
	//设置继电器状态
	//获取继电器状态
}
