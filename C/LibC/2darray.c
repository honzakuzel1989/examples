
#include <stdlib.h>
#include <stdio.h>

const int rows = 5;
const int cols = 10;

int **alloc_ar(const int r, const int c)
{
	int **ar = malloc(c * sizeof(*ar));

	for(int i=0; i<c; i++)	
		ar[i] = malloc(r * sizeof(**ar));

	return ar;
}

void free_ar(int **ar, const int c)
{
	for(int i=0; i<c; i++)
		free(ar[i]);

	free(ar);
}

void fill_ar(int **ar, const int r, const int c)
{
	for(int i=0; i<c; i++)
		for(int j=0; j<r; j++)
			ar[i][j] = (i+1)*(j+1);
}

void print_ar(int **ar, const int r, const int c)
{
	for(int i=0; i<c; i++)
	{
		for(int j=0; j<r; j++)
			printf("%3d ", ar[i][j]);
		puts("");
	}
}

int main(void)
{
	int **ar = alloc_ar(rows, cols);	

	if(!ar)
	{
		perror("alloc_ar");
		return EXIT_FAILURE;
	}
	
	fill_ar(ar, rows, cols);
	print_ar(ar, rows, cols);

	free_ar(ar, cols);

	return EXIT_SUCCESS;
}

