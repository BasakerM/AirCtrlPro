#ifndef _system_h
#define _system_h

#include "hardware.h"


///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
typedef enum { false, true}bool;
typedef enum { enum_system_status_normal}Enum_System_Status;
///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
void System_Init(void);
void System_StatusLight(void);
bool System_GetByte_485(unsigned char* dat);
bool System_GetByte_IR(unsigned char* dat);
bool System_GetByte_E(unsigned char* dat);
void System_SendByte_485(unsigned char* dat,unsigned char len);
void System_SendByte_IR(unsigned char* dat,unsigned char len);
void System_SendByte_E(unsigned char* dat,unsigned char len);
///////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
struct Struct_System_Value
{
	Enum_System_Status RunStatus;
};
////////////////////////////////////////////////////////
struct Struct_System_Function
{
	void (*StatusLight)(void);
	bool (*GetByte_485)(unsigned char* dat);
	bool (*GetByte_IR)(unsigned char* dat);
	bool (*GetByte_E)(unsigned char* dat);
	void (*SendByte_485)(unsigned char* dat,unsigned char len);
	void (*SendByte_IR)(unsigned char* dat,unsigned char len);
	void (*SendByte_E)(unsigned char* dat,unsigned char len);
};
////////////////////////////////////////////////////////
typedef struct Struct_System
{
	void (*Init)(void);
	
	struct Struct_System_Function Function;
	struct Struct_System_Value Value;
	
}System;
static System system = 
{
	System_Init,
////Function
	System_StatusLight,System_GetByte_485,System_GetByte_IR,System_GetByte_E,System_SendByte_485,System_SendByte_IR,System_SendByte_E,
////Value
	enum_system_status_normal
};

#endif
