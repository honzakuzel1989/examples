#include <stdlib.h>
#include <stdio.h>

static char chr(int i)
{
	return (char)i;
}

static int ord(char c)
{
	return (int)c;
}

int main(void)
{
	int i = 99;
	char c = chr(i);
	int j = ord(c);

	printf("x=%d\nc=%c\nj=%d\n", i, c, j);
	return EXIT_SUCCESS;
}
