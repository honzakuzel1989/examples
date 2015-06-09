
#include <stdio.h>
#include <stdarg.h>
#include <stdlib.h>

int sum(int a, int b, ...)
{
	int total = a + b;
	va_list ap;
	int arg;
	
	va_start(ap, b);

	while((arg = va_arg(ap, int)) != 0)
		total += arg;

	va_end(ap);
	return total;
}

int print(char * str, ...)
{
	va_list ap;
	char *s = str;

	int cnt = 1;
	
	va_start(ap, str);

	puts(s);
	while((s = va_arg(ap, char *)) != NULL && ++cnt)
		puts(s);
	
	va_end(ap);

	return cnt;
}

int main(void)
{
	int s = sum(1, 2, 3, 4, 5, 0);
	printf("sum:%d\n", s);
	int c = print("Hello", "World", NULL);
	printf("num:%d\n", c);
	return EXIT_SUCCESS;
}

