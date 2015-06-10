
#include <stdlib.h>
#include <stdio.h>
#include <signal.h>
#include <err.h>
#include <unistd.h>

int main(void)
{
	sigset_t set;
	int signum;
	
	puts(__func__);

	sigemptyset(&set);
	sigaddset(&set, SIGINT);

	puts("block");

	if(sigprocmask(SIG_BLOCK, &set, NULL) < 0)
		err(EXIT_FAILURE, NULL);
	
	puts("wait");

	if(sigwait(&set, &signum) > 0)
		err(EXIT_FAILURE, NULL);	

	printf("end (%d)\n", signum);

	return EXIT_SUCCESS;
}

