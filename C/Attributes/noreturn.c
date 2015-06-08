
#include <stdlib.h>
#include <stdio.h>

void __attribute__((noreturn)) die()
{
	puts(__func__);
	exit(EXIT_FAILURE);
}

int main(void)
{
	die();
	return EXIT_SUCCESS;
}

