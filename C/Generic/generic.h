
#ifndef __GENERICH__ 
#define __GENERICH__ 

#include <stdlib.h>
#include <stdio.h>

#define TRUE  1
#define FALSE 0

#define swapg(a, b) \
	do { (void) (&a == &b);  typeof(a) _tmp = (a); (a) = (b); (b) = _tmp; } while(FALSE)

#define foreachg(array, size) 									\
	typeof(array[0]) _item;										\
	for(int _i = 0; _i < (int)(size) && (_item = array[_i]); _i++) 		\

#define staticarraysize(array) \
	(sizeof array / sizeof *array)

#endif

