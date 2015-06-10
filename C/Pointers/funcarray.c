
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <errno.h>

double (*func[])(double x) = { sin, cos, acos, asin, tan, atan };

void apply_func(const double value)
{
	for(unsigned int i=0; i<sizeof(func)/sizeof(*func); i++)
		printf("%f\n", func[i](value));
}

int main(int argc, char **argv)
{
	if(argc != 2)
	{
		printf("Usage: %s double\n", argv[0]);
		return EXIT_FAILURE;
	}

	errno = 0;
	char *endptr;
	double val = strtod(argv[1], &endptr);

	if(errno || argv[1] == endptr)
	{
		fprintf(stderr, "%s\n", "strtod");
		return EXIT_FAILURE;
	}

	apply_func(val);

	return EXIT_SUCCESS;
}

