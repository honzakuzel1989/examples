
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

static void unload()
{
	puts(__func__);

	//terminated the process after calls functions registred in atexit
	//exit();
	//terminates the process immedietaly
	//_exit(1);
}

static void destroy()
{
	puts(__func__);
}

int main(void)
{
	long a = sysconf(_SC_ATEXIT_MAX);
	printf("sysconf(%s) = %ld\n", "_SC_ATEXIT_MAX", a);
	
	void (*uf)(void) = unload;
	void (*df)(void) = destroy;

	// FIFO
	atexit(df);
	atexit(uf);
	
	puts(__func__);

	return EXIT_SUCCESS;
}

