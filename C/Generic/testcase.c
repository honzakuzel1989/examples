
#include "generic.h"

int main(void)
{
	int ia = 0xdead, ib = 0xbeef;
	printf("swap(0x%x, 0x%x)\n", ia, ib); 
	swapg(ia, ib);
	printf("a = 0x%x, b = 0x%x\n", ia, ib);

	char *sa = "dead", *sb = "beef";
	printf("swap(%s, %s)\n", sa, sb); 
	swapg(sa, sb);
	printf("a = %s, b = %s\n", sa, sb);

	char *array[] = {"deadbeef", "beefdead"};
	{
		foreachg(array, 2)
			printf("array[%d] = %s\n", _i, _item);
	}

	char *str = "deadbeef";
	{
		foreachg(str, staticarraysize(str))
			printf("str[%d] = %c\n", _i, _item);
	}

	return EXIT_SUCCESS;
}

