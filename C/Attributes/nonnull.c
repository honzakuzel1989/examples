
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// size_t ic C99 - unsigned integer at least 16 bit

#define NONNULL(...) __attribute__((nonnull(__VA_ARGS__)))

static char *concat(char *, char *) NONNULL(1, 2);
static char *concat(char *_1, char *_2)
{
	// simple and naive implementation, see memcpy ;)

	size_t _1_size = strlen(_1);
	size_t _2_size = strlen(_2);

	char *res = malloc((_1_size + _2_size + 1) * sizeof(char));
	if(res)
	{
		for(size_t i=0; i<_1_size; i++)
			res[i] = _1[i];
		for(size_t i=0; i<_2_size; i++)
			res[_1_size + i] = _2[i];
		res[_1_size + _2_size] = '\0';
	}
	return res;
}

int main(int argc, char **argv)
{
	if(argc == 3)
	{
		char * res = NULL;
		printf("%s\n", concat(argv[1], argv[2]));
		free(res);
	}
	else
		printf("Usage: %s <one> <two>\n", argv[0]);
	return 0;
}
