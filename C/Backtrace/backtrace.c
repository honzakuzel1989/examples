
//Source: http://www.gnu.org/software/libc/manual/html_node/Backtraces.html

#include <stdio.h>
#include <stdlib.h>
#include <execinfo.h>
#include <unistd.h>

void print_func(void *func)
{
	backtrace_symbols_fd(&func, 1, STDOUT_FILENO);
}

void print_stack(int depth)
{
    void *array[depth];
    char **func;

    int size = backtrace(array, depth);
    func = backtrace_symbols(array, size);

    printf("Obtained %d stack frames.\n", size);
	
	for(int i=0, e=size; i<e; ++i)
		puts(func[i]);

	free(func);
}

void foo(void)
{
	print_stack(10);
}

int main(void)
{
    print_stack(10);
	puts("");
	foo();
	puts("");
	
	print_func(((void *)main));	

    return EXIT_SUCCESS;
}

