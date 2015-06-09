
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

const char *filename = "non_exist";

int main(void)
{
	FILE *f = fopen(filename, "r");
	if(!f)
	{
		perror(NULL);
		//another way
		fprintf(stderr, "%s\n", strerror(errno));
		return errno;
	}

	return EXIT_FAILURE;
}

