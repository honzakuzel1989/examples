#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

const int numOfThreads = 2;

// required for init routine and for pthread_once call
static pthread_once_t once_control = PTHREAD_ONCE_INIT;

typedef struct
{
	int id;
	int retval;
} pthread_t_data;

// init routine is called only once
void init_routine(void)
{
	puts(__func__);
}

void *start_fun(void *arg)
{
	pthread_once(&once_control, init_routine);

	pthread_t_data *data = (pthread_t_data *)arg;
	
	printf("Hello from thread %d.\n", data->id);

	data->retval = data->id * 10;

	/*
	The new thread terminates in one of the following ways:

   * It  calls  pthread_exit(3),  specifying  an exit status value that is
     available  to  another  thread  in  the  same  process   that   calls
     pthread_join(3).

   * It  returns  from  start_routine().   This  is  equivalent to calling
     pthread_exit(3) with the value supplied in the return statement.

   * It is canceled (see pthread_cancel(3)).

   * Any of the threads in the process calls exit(3), or the  main  thread
     performs  a  return  from main().  This causes the termination of all
     threads in the process.
	*/
	
	// http://stackoverflow.com/questions/3844678/pthread-exit-vs-return

	// sometimes memory leaks!
	//pthread_exit((void *)data);
	
	// without memory leaks!
	return (void *)data;
}

int main(void)
{
	pthread_t threads[numOfThreads];
	pthread_t_data threads_data[numOfThreads];

	for(int i=0; i<numOfThreads; i++) {
		threads_data[i].id = i;
		// pthread_attr_t == implicit attributec (sizeof stack, planning policy, ..)
		if(pthread_create(&threads[i], NULL, start_fun, (void *)&threads_data[i]) != 0)
			fprintf(stderr, "Thread %d failed to create.\n", i);
		else
			printf("Thread %d successfully created with id %d.\n", i, i);
	}

	puts("");

	// waiting for threads one by one
	pthread_t_data *retdata;
	for(int i=0; i<numOfThreads; i++) {
		if(pthread_join(threads[i], (void **)&retdata) != 0)
			fprintf(stderr, "Thread %d failed to join.\n", i);
		else
			printf("Thread %d succcessfully joined with return value %d.\n", i, retdata->retval);
	}
		

	return EXIT_SUCCESS;
}

