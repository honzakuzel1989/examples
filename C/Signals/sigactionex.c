
#include <stdio.h>
#include <stdlib.h>
#include <signal.h>
#include <err.h>
#include <unistd.h>

void handler(__attribute__((__unused__)) int signum)
{
	puts(__func__);
}

int main(void)
{
	struct sigaction act;
	act.sa_handler = handler;
	sigemptyset(&act.sa_mask);
	if(sigaction(SIGALRM, &act, NULL) < 0)
		err(EXIT_FAILURE, NULL);
	alarm(2);
	
	puts("sleep");
	sleep(4);

	return EXIT_SUCCESS;	
}

