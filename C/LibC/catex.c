#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int c;
    while((c = fgetc(stdin)) != EOF)
        fputc(c, stdout);

    return EXIT_SUCCESS;
}

