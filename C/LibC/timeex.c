
#include <limits.h>
#include <time.h>
#include <stdio.h>

int main(void)
{
	unsigned int ui = UINT_MAX;
	printf("UINT_MAX = %u\n", ui);

	time_t c0 = clock();
	time_t start = time(NULL);
	for(unsigned int u=0; u<ui; u++)
		;
	time_t end = time(NULL);
	time_t c1 = clock() - c0;

	double dur = difftime(end, start);

	//low precision
	printf("duration=%0.2f s\n", dur);
	//high precision
	printf("clock=%d=%0.2f s\n", (int)c1, ((float)c1)/CLOCKS_PER_SEC);

	return 0; 
}

