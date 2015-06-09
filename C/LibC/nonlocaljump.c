
#include <stdlib.h>
#include <stdio.h>
#include <setjmp.h>


void jmp_func(jmp_buf jmp)
{
	static int i;

	puts(__func__);
	longjmp(jmp, ++i);
}

int main(void)
{
	jmp_buf jmp;
	//retval = 0
	int retval = setjmp(jmp);
	if(retval < 10)
		puts(__func__);
	else
		return EXIT_SUCCESS;
	
	jmp_func(jmp);
	return EXIT_FAILURE;
}

