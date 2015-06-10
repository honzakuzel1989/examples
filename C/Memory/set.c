
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

static void die() __attribute__((__noreturn__));

static void die(const char *error)
{
	perror(error);
	exit(EXIT_FAILURE);
}

int main(void)
{
	size_t size = 20;
	char *buff = realloc(NULL, size * sizeof *buff);
	
	if(!buff)
		die("realloc");

	memset(buff, '#', size/2 * sizeof *buff);

	for(size_t i=0; i<size/2; i++)	
		printf("%c,", buff[i]);
	puts("");

	char *r = memset(buff + size/2, '$', size/2 * sizeof *buff);

	for(size_t i = 0; i<size/2; i++)
		printf("%c,", r[i]);
	puts("");

	buff = realloc(buff, 3 * size/2 * sizeof *buff);
	if(!buff)
		die("realloc");

	memcpy(buff + size, buff, size/2 * sizeof *buff);

	for(size_t i = 0; i<size + size/2; i++)
		printf("%c,", buff[i]);
	puts("");
	
//	realloc(buff, 0);
	free(buff);

	return EXIT_SUCCESS;
}

