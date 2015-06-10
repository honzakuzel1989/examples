
#include <gc.h>
#include <stdlib.h>
#include <stdio.h>
#include <assert.h>

const int num_of_strings = 10;
const int num_of_chars=3;
const int num_of_nums = 100;

int main(void)
{
	GC_INIT();
	
	//array of pointers
	char **q = GC_MALLOC(num_of_strings * sizeof(char *));
	assert(q);

	for(int i=0; i<num_of_strings; i++) 
	{
		q[i] = GC_MALLOC_ATOMIC(num_of_chars * sizeof(char));
		assert(q[i]);
	 
		//fill each string (ab - jk) and print them
		char c = (char)((int)'a' + i);
		q[i][0] = c;
		q[i][1] = c + 1;
		q[i][2] = '\0';

		puts(q[i]);
	}

	puts("");

	//array of atomic objects
	int *p = GC_MALLOC_ATOMIC(num_of_nums * sizeof(int));
	p = GC_REALLOC(p, 2 * num_of_nums * sizeof(int));
	assert(p);

	for(int i=0; i<2*num_of_nums; i++)
	{
		p[i] = i;
		printf("%2d, ", i);
	}

	puts("");

	return EXIT_SUCCESS;
}

