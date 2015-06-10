
#include <stdlib.h>
#include <stdio.h>

// try valgrind ./alloc for check memory leaks 

#define ERROR(str) { \
	perror(str); \
	return EXIT_FAILURE; \
	}

int main(void)
{
	size_t size = 10;
	//realloc(NULL, x) == malloc(x)
	char *str = realloc(NULL, (size + 1) * sizeof(char));
	//char *str = (char *)malloc((size + 1) * sizeof(char));

	if(!str)
		ERROR("malloc");
	
	for(size_t i = 0; i < size; i++)
		str[i] = ((int)'a' + (rand() % 26));
	str[size] = '\0';
	
	puts((char *)str);		

	free(str);

	//If sizeof operand is expression, than brackets are optional
	int *nums = (int *)calloc(size, sizeof(*nums));
	if(!nums)
		ERROR("calloc");

	//size_t == unsigned int
	for(unsigned int i=0; i<size; i++)
		printf("%d", nums[i]);
	puts("");

	size *= 2;
	nums = (int *)realloc(nums, size * sizeof(int));
	if(!nums)
		ERROR("realloc");

	/*	
	for(unsigned int i=0; i<size; i++)
		printf("%d", nums[i]);
	puts("");
	*/
	
	//realloc(nums, 0); == free(nums)
	free(nums);	

	return EXIT_SUCCESS;
}

