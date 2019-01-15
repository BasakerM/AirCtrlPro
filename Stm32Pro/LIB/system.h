#ifndef _system_h
#define _system_h

#include "hardware.h"

void System_Init(void);
void System_StatusLight(void);

typedef enum
{
	SystemStatus_normal
}SystemStatus;

typedef struct Struct_System
{
	SystemStatus RunStatus;
	
	void (*Init)(void);
	void (*StatusLight)(void);
}System;
static System system = {SystemStatus_normal,System_Init,System_StatusLight};

#endif
