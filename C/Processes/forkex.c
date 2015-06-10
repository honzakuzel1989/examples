
#include <unistd.h>
#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <sys/types.h>

const int sleep_max = 5;

int loops = 10;

int get_rand_num()
{
	return rand() % 5 + 1;
}

void parent()
{
	pid_t pid = getpid(), ppid = getppid();
	while(loops--)
	{
		sleep(get_rand_num());
		printf("%d I'm parent (pid = %d, ppid = %d)\n", loops, pid, ppid);
	}
}

void child()
{
	pid_t pid = getpid(), ppid = getppid();
	while(loops--)
	{
		sleep(get_rand_num());
		printf("%d I'm child (pid = %d, ppid = %d)\n", loops, pid, ppid);
	}
}

int main(void)
{
	srand(time(NULL));
	
	pid_t pid = fork();
	if(pid < 0)
		perror("fork()");
	else if(pid == 0)
		child();
	else
		parent();	

	return EXIT_SUCCESS;
}

