
#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>

extern void DEBUG(const char *format, ...) __attribute__((format(printf, 1, 2)));

void DEBUG(const char *format, ...)
{
	va_list arg;
	va_start(arg, format);
	vfprintf(stderr, format, arg);
	va_end(arg);
}

int main(void)
{
	DEBUG("%s", "hello");

	return EXIT_SUCCESS;
}

