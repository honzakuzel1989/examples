
#include <stdio.h>
#include <signal.h>
#include <unistd.h>
#include <stdlib.h>

// The function with one integer parameter without return value
typedef void sigfunc(int);

void signal_handler(int signum)
{
	if(signum == SIGINT)
		printf("%s", "SIGINT\n");
}

int main(void)
{
	sigfunc *old, *new;

	new = signal_handler;
	old = signal(SIGINT, new);

	if(old == SIG_ERR)
		fprintf(stderr, "%s", "SIGERR");

	while(1)
		pause();

	return EXIT_SUCCESS;
}
