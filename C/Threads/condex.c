
#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <err.h>
#include <string.h>
#include <unistd.h>

// static mutex and condition
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t cond = PTHREAD_COND_INITIALIZER;

const char *msg = "Hello World";

// some shared data
typedef struct 
{
	char *data;
	int len;
}pthread_data_t;

// thread data
pthread_data_t d;

static void *thread_wait(__attribute__((__unused__)) void *argv)
{
	printf("%s - start\n", __func__);
	
	// lock
	pthread_mutex_lock(&mutex);	

	// wait to condition
	while(strlen(d.data) > 0)
		if(pthread_cond_wait(&cond, &mutex) != 0)
			break;

	printf("%s - continue\n", __func__);

	// some operations with shared data

	// unlock
	pthread_mutex_unlock(&mutex);
	return NULL;
}

static void *thread_run(__attribute__((__unused__)) void *argv)
{
	printf("%s - start\n", __func__);
	
	pthread_mutex_lock(&mutex);
	
	// some operation with shared data
	while(d.len > 0)
	{
		d.len--;
		printf("d.data[%d]\t= %c\n", d.len, d.data[d.len]);
		d.data[d.len] = '\0';
		
		sleep(1);
	}
	
	printf("%s - signal\n", __func__);
	
	// signal
	pthread_cond_signal(&cond);

	pthread_mutex_unlock(&mutex);
	return NULL;
}

void free_data()
{
	free(d.data);
}

int main(void)
{
	printf("%s - start\n", __func__);

	// init data
	int data_len = strlen(msg);
	if((d.data = (char *)calloc(data_len + 1, sizeof(*d.data))) == NULL)
		err(EXIT_FAILURE, NULL);

	strcpy(d.data, msg);
	d.len = data_len;

	// create
	pthread_t thread[2];
	if(pthread_create(&thread[0], NULL, thread_wait, NULL) != 0)
		goto failure;

	if(pthread_create(&thread[1], NULL, thread_run, NULL) != 0)
		goto failure;

	// wait
	for(int i=0; i<2; i++)
		if(pthread_join(thread[i], NULL) != 0)
			goto failure;	
	
	printf("%s - continue\n", __func__);

	// all ok
	free_data();
	return EXIT_SUCCESS;

// side effect: not too bad goto :)
failure:
	free_data();
	err(EXIT_FAILURE, NULL);
}

