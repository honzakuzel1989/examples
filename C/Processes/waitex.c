
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <err.h>
#include <sys/types.h>
#include <sys/wait.h>

static void child()
{
	printf("%s start\n", __func__);
	sleep(2);
	printf("%s end\n", __func__);
}

int main(void)
{
	pid_t pid = fork();
	
	if(pid < 0)
		err(EXIT_FAILURE, NULL);
	else if(!pid)
		child();
	else
	{
		int stat;
		wait(&stat);
		
		int exst = WEXITSTATUS(stat);
		printf("exit status:%d\n", exst);

		printf("%s\n", __func__);
	}

	return EXIT_SUCCESS;
}

