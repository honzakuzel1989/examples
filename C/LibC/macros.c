
#include <stdlib.h>
#include <stdio.h>

#define PRINT(x) printf(#x " = %d\n", x);
#define CONCAT(x, y) x##y

#define DBG(...) fprintf(stderr, __VA_ARGS__)
#define SHOW(...) puts(#__VA_ARGS__)

int main(void)
{
	printf("[%d] %s - %s (%s %s)\n", __LINE__, __FILE__, __func__, __DATE__, __TIME__);	

	int x = 0;
	int xx = 10;	

	PRINT(x);
	PRINT(CONCAT(x,x));

	DBG(__func__);
	puts("");
	SHOW(Hello,  World, !);
 
	return EXIT_SUCCESS;
}
