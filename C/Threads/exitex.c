
#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <unistd.h>

void *thread_func(__attribute__((__unused__)) void *arg)
{
	int counter = 0;
	while(counter < 10)
	{
		printf("%d\n", ++counter);
		sleep(1);
	}
#ifdef FUNCSTDRET
	return NULL;
#else
	pthread_exit(NULL);
#endif
}

int main(void)
{
	pthread_t thread;
	if(pthread_create(&thread, NULL, thread_func, NULL) != 0)
		return EXIT_FAILURE;

#ifdef MAINSTDRET
	// imediate termination of all threads
	return EXIT_SUCCESS;
#else
	// waiting until all the threads finishes
	int ret = EXIT_SUCCESS;
	pthread_exit((void *)&ret);
#endif
}
