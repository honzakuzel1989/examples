
#include <stdio.h>
#include <stdlib.h>

#define unused __attribute__((unused))

int main(int unused argc, char unused **argv, char **envp)
{
	int i = 0;
	while(envp[i] != NULL)
		puts(envp[i++]);

	return EXIT_SUCCESS;	
}

