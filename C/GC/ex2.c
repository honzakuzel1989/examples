
#include <gc.h>
#include <stdlib.h>
#include <stdio.h>
#include <assert.h>

#define SHOW_HEAP_SIZE() printf("heap size:%zd\n", GC_get_heap_size())

int main(void)
{
	GC_INIT();

	//1000 * 100
	char **p = GC_MALLOC(10000 * sizeof(char *));
		
	for(int i=0; i<10000; i++)
	{
		if(i%1000 == 0)
			SHOW_HEAP_SIZE();

		char *q = GC_MALLOC_ATOMIC(100 * sizeof(char));
		p[i] = q;
	}

	return EXIT_SUCCESS;
}

