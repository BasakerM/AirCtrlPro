#ifndef _memorymanage_h
#define _memorymanage_h

#define MEMORY_SIZE_MAX 8000
#define NULL 0

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

#endif
