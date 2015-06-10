
#ifndef __HELPERH__
#define __HELPERH__

#include <pthread.h>

#define UNUSED \
	__attribute__((__unused__))

#define CREATE_TRHEADS(threads, num, func, ret) \
	do { \
		for(int i=0; i<num; i++) { \
			if((ret = pthread_create(&threads[i], NULL, func, NULL)) != 0) \
				break; \
		} \
	} while(0)

#define JOIN_THREADS(threads, num, ret) \
	do { \
		for(int i=0; i<num; i++) { \
			if((ret = pthread_join(threads[i], NULL)) != 0) \
				break; \
		} \
	} while(0)

#endif

