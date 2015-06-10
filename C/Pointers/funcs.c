/*
 * 20.02.2014
 * Ing. Jan Kužel
 * honza.kuzel.1989@gmail.com
 * funcs.c, unrealistic samples how used pointers
 * GPLv3+
 */

#include <stdio.h>
#include <stdlib.h>

void *(*(*f[10])(void *(*g)(void *)))(void *p);

void *gce(void *p)
{
	puts(__func__);
	return p;
}

void *(*fce(void *(*f)(void *p)))(void *q)
{
	puts(__func__);
	return f; 
}

int main(void)
{
	int r = 10;
	void *p = (void *)&r;

	f[0] = fce;
	f[1] = fce;
	//...

	for(unsigned int i=0; i<sizeof(f)/sizeof(*f); i++) 
	{
		if(f[i])
		{
			int* q = (int *)f[i](gce)(p);
			printf("r=%d, q=%d\n", r, *q);
		}
	}

	return EXIT_SUCCESS;
}

