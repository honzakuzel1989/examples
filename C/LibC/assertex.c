/*
 * 20.02.2014
 * Ing. Jan Kužel
 * honza.kuzel.1989@gmail.com
 * assertex.c
 * GPLv3+
 */

//#define NDEBUG

#include <stdlib.h>
#include <assert.h>
#include <stdio.h>

int main(int __attribute__((unused)) argc, char __attribute__((unused)) **argv)
{
	assert(argc > 1 && argv);

	return EXIT_FAILURE;
}

