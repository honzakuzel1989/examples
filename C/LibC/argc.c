
#include <stdlib.h>
#include <stdio.h>

int main(int __attribute__((unused)) argc, char **argv)
{
	int i = 0;
	while(argv[i] != NULL)
	{
		puts(*(argv + i));
		i++;
	}

	return EXIT_SUCCESS;
}

