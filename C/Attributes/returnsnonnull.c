
#include <string.h>
#include <stdio.h>

// returns_nonnull is implemented in gcc 4.9+ versio
static char *echo(char *) __attribute__((returns_nonnull));

static char *echo(char *str)
{
	return str;
}

int main(int argc, char **argv)
{
	if(argc == 2)
	{
		char *str = NULL;
		if(strcmp("NULL", argv[1]))
			str = argv[1];	
		printf("%s\n", echo(str));
	}
	else
		printf("Usage: %s <str>\n", argv[0]);
	return 0;
}
