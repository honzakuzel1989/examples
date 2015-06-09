
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <errno.h>
#include <locale.h>

int main(void)
{
	char *loc = "cs_CZ.utf8";
	char *msg = NULL;

	if(!setlocale(LC_ALL, loc))
	{
		perror("setlocale");
		return EXIT_FAILURE;
	}

	char *error = strerror(1000000);

	//0 == Success
	int i= 1;
	while(!strstr((msg = strerror(++i)), error))
		puts(msg);

	return EXIT_SUCCESS;
}

