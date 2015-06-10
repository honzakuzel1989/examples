
#include <stdio.h>
#include <stdlib.h>
#include <err.h>
#include <unistd.h>
#include <time.h>

#include "helper.h"

// consts
const int num_of_threads = 5;

// barrier
pthread_barrier_t barrier;

void *thread_func(UNUSED void *arg)
{
	printf("%s - start\n", __func__);

	// get pseudorandom number
	int wait = 1 + rand() % 5 ;

	printf("sleep(%d)\n", wait);

	sleep(wait);

	// all threads waiting on the barrier
	pthread_barrier_wait(&barrier);

	printf("%s - continue\n", __func__);

	return NULL;
}

int main(void)
{
	printf("%s - start\n", __func__);

	// init random generator
	srand(time(NULL));

	if(pthread_barrier_init(&barrier, NULL, num_of_threads) != 0)
		err(EXIT_FAILURE, NULL);
	
	int retVal;
	pthread_t thrs[num_of_threads];
	CREATE_TRHEADS(thrs, num_of_threads, thread_func, retVal);
	if(retVal != 0)
		err(EXIT_FAILURE, NULL);

	JOIN_THREADS(thrs, num_of_threads, retVal);
	if(retVal != 0)	
		err(EXIT_FAILURE, NULL);

	if(pthread_barrier_destroy(&barrier) != 0)
		err(EXIT_FAILURE, NULL);
	
	printf("%s - continue\n", __func__);

	return EXIT_SUCCESS;
}

