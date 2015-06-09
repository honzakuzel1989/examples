
#include <stdio.h>
#include <stdlib.h>

static void create(void) __attribute__((constructor));
static void destroy(void) __attribute__((destructor));

void create(void)
{
    puts("init");
}

void destroy(void)
{
    puts("exit");
}

int main(void)
{
    puts("main");
    return EXIT_SUCCESS;
}

