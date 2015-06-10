
#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <err.h>
#include <signal.h>

#define ERROR(msg) \
	fprintf(stderr, "%s\n", msg)

void *thread_func(__attribute__((__unused__)) void *arg)
{
	puts(__func__);

	int sig;
	sigset_t set = *((sigset_t *)arg);

	while(1)
	{
		// catch signal from set in this thread 
		//(use kill | pkill -<SIGNAME> <PID>)
		if(sigwait(&set, &sig) != 0)
			ERROR("sigwait");
		else
			printf("catched signal %d\n", sig);
		break;
	}

	return NULL;
}

int main(void)
{
	puts(__func__);
	
	// sigset init
	sigset_t set;
	sigemptyset(&set);
	sigaddset(&set, SIGUSR1);
	sigaddset(&set, SIGUSR2);
	
	// block SIGUSR1 in current thread
	if(pthread_sigmask(SIG_BLOCK, &set, NULL) != 0)
		ERROR("sigmask");

	pthread_t thread;

	// create
	if(pthread_create(&thread, NULL, thread_func, (void *)&set) != 0)
		err(EXIT_FAILURE, NULL);
	
	// wait
	if(pthread_join(thread, NULL) != 0)
		err(EXIT_FAILURE, NULL);	

	puts(__func__);

	return EXIT_SUCCESS;
}

