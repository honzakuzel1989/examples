
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int numbers[] = {90, 66, 23, 33, 66, 999, 88, -89, -9969, 1, 2, 15, 178, 99122, 4, 5, 6, 234, 32, -546, -88};
char *strings[] = {"jedna", "auto", "honza", "vilem", "public", "ludmila", "hamster", "zelva", "zelenac", "teraz"};

static int compare_numbers(const void *a, const void *b)
{	
	return (*((const int *)a) - *((const int *)b));
}

static int compare_strings(const void *a, const void *b)
{
	return strcmp(*((const char **)a), *((const char **)b));
}

int main(void)
{
	int (*compare)(const void *, const void *);

	compare = compare_numbers;
	size_t count = sizeof(numbers)/sizeof(*numbers);
	size_t size = sizeof(*numbers);

	printf("count:%zd, size:%zd\n", count, size);

	for(size_t i=0; i<count; i++)	
		printf("%d,", numbers[i]);
	puts("");

	//sort numbers
	qsort(numbers, count, size, compare);

	for(size_t i=0; i<count; i++)	
		printf("%d,", numbers[i]);
	puts("");

	//
	//

	compare = compare_strings;
	count = sizeof(strings)/sizeof(*strings);
	size = sizeof(*strings);

	printf("count:%zd, size:%zd\n", count, size);

	for(size_t i=0; i<count; i++)	
		printf("%s,", strings[i]);
	puts("");

	//sort strings
	qsort(strings, count, size, compare);

	for(size_t i=0; i<count; i++)	
		printf("%s,", strings[i]);
	puts("");

	return EXIT_SUCCESS;
}
