
#include <stdlib.h>
#include <stdio.h>

#define CONST __attribute__((const))

int CONST my_const()
{
	return 42;
}

int main(void)
{
	for(int i=1; i<=100; i++)
		printf("The answer is:%d\n", my_const());

	return EXIT_SUCCESS;
}

