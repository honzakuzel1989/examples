
#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <unistd.h>
#include <err.h>

#define __unused __attribute__((__unused__))

void *thread_func(__unused void *arg)
{
	int cancel_state, cancel_type;

	printf("PTHREAD_CANCEL_ENABLE = %d\nPTHREAD_CANCEL_DISABLE = %d\n", 
		PTHREAD_CANCEL_ENABLE, PTHREAD_CANCEL_DISABLE);
	printf("PTHREAD_CANCEL_ASYNCHRONOUS = %d\nPTHREAD_CANCEL_DEFERRED = %d\n", 
		PTHREAD_CANCEL_ASYNCHRONOUS, PTHREAD_CANCEL_DEFERRED);

	// default value = ENABLE
	if(pthread_setcancelstate(PTHREAD_CANCEL_ENABLE, &cancel_state) != 0)
		perror("setcancelstate");
	// default value = DEFERRED
	if(pthread_setcanceltype(PTHREAD_CANCEL_DEFERRED, &cancel_type) != 0)
		perror("setcanceltype");

	printf("old_cancel_state = %d\nold_cancel_type = %d\n", cancel_state, cancel_type); 

	// cancelation point	
	sleep(10);

	return arg; 
}

int main(void)
{
	pthread_t thread;
	
	// the way, how use attributes	
	/*
	pthread_attr_t attr;

	if(pthread_attr_init(&attr) != 0)
		err(EXIT_FAILURE, NULL);

	if(pthread_attr_setdetachstate(&attr, PTHREAD_CREATE_DETACHED) != 0)
		err(EXIT_FAILURE, NULL);
	*/

	if(pthread_create(&thread, /* &attr */ NULL, thread_func, NULL) != 0)
		err(EXIT_FAILURE, NULL);

	// wait some time
	sleep(2);
	pthread_cancel(thread);
	pthread_join(thread, NULL);
	
	/*
	if(pthread_attr_destroy(&attr) != 0)
		err(EXIT_FAILURE, NULL);
	*/
	return EXIT_SUCCESS;
}

