
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
//Not supported in cygwin
#include "execinfo.h"

#define notrace __attribute__((no_instrument_function))
#define unused __attribute__((__unused__))

#define DUMP(func, caller)\
    printf("%s: function %p called by %p\n", __func__, func, caller);

#define DUMP_FUNC(func) \
	backtrace_symbols_fd(&func, 1, STDOUT_FILENO);

#define DUMP_FUNC_EX(label) \
	{ \
		int depth = 2; \
		void *array[depth]; \
		int size = backtrace(array, depth); \
		if(size >= depth) { \
			char **fnames = backtrace_symbols(array, size); \
			printf("%s : %s\n", label,  fnames[1]); \
		} \
	}
		

void notrace __cyg_profile_func_enter(unused void *this, unused void *caller)
{
	DUMP_FUNC_EX(__func__);
	
	//DUMP_FUNC(this);
    //DUMP(this, caller);
}

void notrace __cyg_profile_func_exit(unused void *this, unused void *caller)
{
	DUMP_FUNC_EX(__func__);
	
	//DUMP_FUNC(this);
    //DUMP(this, caller);
}

void foo()
{
    puts("foo");
}

void bar()
{
    puts("bar");
}

void baz()
{
    puts("baz");
}

void f()
{
    puts("f");
    foo();
    bar();
    baz();
}

int main(void)
{

//   foo();
//	foo();
//	foo();
//    bar();
//    baz();

    f();

    return EXIT_SUCCESS;
}

