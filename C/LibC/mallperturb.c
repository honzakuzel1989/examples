
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>

#define DUMPMEM(mem, size) { \
	for(size_t _i=0; _i<size; _i++) { \
		int x = (int)mem[_i]; \
		printf("%d|",x < 0 ? -x : x); } \
	puts(""); }
	
const char *ENV_NAME = "MALLOC_PERTURB_";
const size_t SIZE = 50;

void __attribute__ ((noreturn)) die(const char *error)
{
	printf("Error [%s]", error);
	puts("");
	exit(EXIT_FAILURE);
}

int main(void)
{
	char *env = getenv(ENV_NAME);
	if(!env)
		die("getenv");

	char *end;
	errno = 0;
	int perturb = (int)strtol(env, &end, 10);
	
	if(errno || end == env)
		die("strtol");

	printf("%s is %d (iverted %d)\n", ENV_NAME, perturb, ~perturb);

	char *mem = malloc(SIZE * sizeof *mem);
	
	DUMPMEM(mem, SIZE);

	free(mem);

	DUMPMEM(mem, SIZE);

	return EXIT_SUCCESS;
}

