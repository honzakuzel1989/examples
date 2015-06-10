
#include <stdlib.h>
#include <stdio.h>
#include <signal.h>
#include <err.h>
#include <unistd.h>

#define _unused __attribute__((__unused__))

volatile int sum = 0;

void handler(_unused int signum, siginfo_t *info, _unused void *context)
{
	psiginfo(info, "info");
	printf("si_signo:%d\nsi_errno:%d\nsi_code:%d\nsi_pid:%d\nsi_uid:%d\nsi_status:%d\n.....\n",
			info->si_signo,
			info->si_errno,
			info->si_code,
			info->si_pid,
			info->si_uid,
			info->si_status);

	sum+=1;
}

int main(void)
{
	struct sigaction act;
	act.sa_sigaction = handler;
	act.sa_flags = SA_SIGINFO;
	sigemptyset(&act.sa_mask);

	if(sigaction(SIGUSR1, &act, NULL) < 0)
		err(EXIT_FAILURE, NULL);
	if(sigaction(SIGUSR2, &act, NULL) < 0)
		err(EXIT_FAILURE, NULL);

	puts("waiting");
	while(sum < 2)
		sleep(1);

	return EXIT_SUCCESS;
}

