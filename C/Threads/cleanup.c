
#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <err.h>
#include <unistd.h>

#define _unused __attribute__((__unused__))

void clean_fce(_unused void *arg)
{
	puts(__func__);
}

void *thread_fce(_unused void *arg)
{
	puts(__func__);

	pthread_cleanup_push(clean_fce, NULL);
	pthread_exit(NULL);
	pthread_cleanup_pop(0);
}

int main(void)
{
	puts(__func__);

	pthread_t thread;
	
	if(pthread_create(&thread, NULL, thread_fce, NULL) != 0)
		err(EXIT_FAILURE, NULL);
	
	sleep(2);

	pthread_join(thread, NULL);

	puts(__func__);

	return EXIT_SUCCESS;
}

