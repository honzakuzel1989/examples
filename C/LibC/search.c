
#include <stdlib.h>
#include <stdio.h>

int numbers[] = {90, 66, 23, 33, 66, 999, 88, -89, -9969, 1, 2, 15, 178, 99122, 4, 5, 6, 234, 32, -546, -88};

static int abs_cmp(const void *a, const void *b)
{
	return (abs(*((int *)a)) - abs(*((int *)b)));
}

#define PRINT(_format, _array) \
	for(size_t _i=0; _i<sizeof(_array)/sizeof(*_array); _i++) \
		printf(_format, _array[_i]); \
	puts("");

int main(void)
{
	void *result;
	int (*cmp)(const void *, const void *);
	const void *key;

	PRINT("%d,", numbers);

	size_t count = 	sizeof(numbers)/sizeof(*numbers);
	size_t size = sizeof(*numbers);

	cmp = abs_cmp;
	//sort !
	qsort(numbers, count, size, cmp);
	key = (const void *)&(int){89};
	//search !
	result = bsearch(key, numbers, count, size, cmp);

	if(!result)
		puts("Not found!\n");
	else
		printf("Found! (%d)\n", *((int *)result));

	return EXIT_SUCCESS;
}

