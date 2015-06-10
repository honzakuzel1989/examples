
#include <stdlib.h>
#include <stdio.h>
#include <pthread.h>
#include <err.h>
#include <unistd.h>

#define ERR(msg) \
	fprintf(stderr, "%s\n", msg)

#define BEGIN(threadID, func) \
	printf("[%d] BEGIN - %s\n", threadID, func)

#define END(threadID, func) \
	printf("[%d] END   - %s\n", threadID, func)

#define TRACK(...) \
	printf(__VA_ARGS__)

/*
 * Mutex can unlock only thread, which it locked (instead of semaphore)
 */

// static (fast, NO recursive and NO errorcheck) mutex - set default values
pthread_mutex_t smutex = PTHREAD_MUTEX_INITIALIZER;

// dynamic mutex
pthread_mutex_t dmutex;

const int numOfThreads = 2;

typedef struct
{
	int id;
}pthread_data_t;

void *thread_func(void *arg)
{
	int threadID = ((pthread_data_t *)arg)->id;

	BEGIN(threadID, __func__);

	// CS - start
	if(pthread_mutex_lock(&dmutex) != 0)
		ERR("mutex_lock");

	for(int i=0; i<10; i++)
	{
		sleep(1);
		TRACK("[%d] TRACK - %d\n", threadID, i);
	}

	// CS - end
	if(pthread_mutex_unlock(&dmutex) != 0)
		ERR("mutex_unlock");

	END(threadID, __func__);
	return NULL;
}	

int main(void)
{
	// init dynamic mutex - default values
	if(pthread_mutex_init(&dmutex, NULL) != 0)
		err(EXIT_FAILURE, NULL);

	pthread_t threads[numOfThreads];
	pthread_data_t threads_data[numOfThreads];

	for(int i=0; i<numOfThreads; i++)
	{
		threads_data[i].id = i;
		if(pthread_create(&threads[i], NULL, thread_func, (void *)&threads_data[i]) != 0)
			ERR("pthread_create");
	}

	for(int i=0; i<numOfThreads; i++)
		if(pthread_join(threads[i], NULL) != 0)
			ERR("pthread_join");

	// destroy dynamic mutex
	if(pthread_mutex_destroy(&dmutex) != 0)
		err(EXIT_FAILURE, NULL);

	return EXIT_SUCCESS;
}

