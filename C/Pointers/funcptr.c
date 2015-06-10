
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
	int (*f)(int a, int b);
	char *name;
}Tfunc;

int _add(int a, int b)
{
	return a+b;
}

int _sub(int a, int b)
{
	return a-b;
}

int _mul(int a, int b)
{
	return a*b;
}

int _div(int a, int b)
{
	return a/b;
}

#define NUM 4
#define LEN 4

Tfunc* fill_funcbank()
{
	Tfunc* funcbank = malloc(NUM * sizeof(Tfunc));

	funcbank[0].f = _add;
	funcbank[0].name = "add";
	
	funcbank[1].f = _sub;
	funcbank[1].name = "sub";

	funcbank[2].f = _div;
	funcbank[2].name = "div";

	funcbank[3].f = _mul;
	funcbank[3].name = "mul";

	return funcbank;
}

int (*findfunc(const Tfunc *funcbank, const char *funcname))(int a, int b)
{
	for(int j = 0; j < NUM; j++)
	{
		if(strcmp(funcname, funcbank[j].name) == 0)
		{
			return funcbank[j].f;
		}
	}

	printf("%s not found\n", funcname);
	return NULL;
}

void __attribute__ ((noreturn)) usage(const char *name)
{
	printf("%s <space separated func name list>\n", name);
	exit(EXIT_FAILURE);
}

int main(int argc, char **argv)
{
	if(argc <= 1)
		usage(argv[0]);

	int a = 20, b = 10;

	Tfunc* funcbank = fill_funcbank();
	
	int (*fun)(int a, int b)  = NULL;
	
	for(int i=1; i<argc; i++)
	{
		fun = findfunc(funcbank, argv[i]);
		if(fun)
			printf("a=%d, b=%d, %s=%d;\n", a, b, argv[i], fun(a, b));
	}

	free(funcbank);

	return EXIT_SUCCESS;	
}

