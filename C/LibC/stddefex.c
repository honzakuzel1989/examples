/*
 * 21.02.2014
 * Ing. Jan Kužel
 * honza.kuzel.1989@gmail.com
 * stddefex.c
 * GPLv3+
 */

#include <stdio.h>
#include <stdlib.h>
#include <stddef.h>

struct X
{
	char c;
	int a;
	double d;
};

int main(int argc, char **argv)
{
	printf("sX=%zu\n", sizeof(struct X));

	//members offset
	size_t oc = offsetof(struct X, c);
	size_t sc = sizeof(char);

	size_t oa = offsetof(struct X, a);
	size_t sa = sizeof(int);

	size_t od = offsetof(struct X, d);
	size_t sd = sizeof(double);

	printf("oc=%zu, sc=%zu\n", oc, sc);
	printf("oa=%zu, sa=%zu\n", oa, sa);
	printf("od=%zu, sd=%zu\n", od, sd);

	struct X x[10];
	//difference of two pointers to char
	ptrdiff_t dif = (char *)&x[0] - (char *)&x[1];
	printf("dif=%zu\n", dif);

	return EXIT_SUCCESS;
}

