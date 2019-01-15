#ifndef _system_h
#define _system_h

#include "hardware.h"

void system_init(void);

typedef struct struct_system
{
	void (*led)(void);
}system;

#endif
