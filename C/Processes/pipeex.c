
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <err.h>
#include <string.h>

#include <sys/types.h>
#include <sys/wait.h>

int main(void)
{
	// the array of filedescriptors (read [0], write [1])
	int pipefd[2];
	char buf;

	if (pipe(pipefd) < 0)
		err(EXIT_FAILURE, NULL);

	pid_t cpid = fork();
	if (cpid < 0)
		err(EXIT_FAILURE, NULL);

	if (!cpid) 
	{
		close(pipefd[1]);
		
		while (read(pipefd[0], &buf, 1))
			write(STDOUT_FILENO, &buf, 1);

		puts("");
		close(pipefd[0]);

		_exit(EXIT_SUCCESS);
	}
	else 
	{
		char *msg = "Hello!";
		int len = strlen(msg);

		close(pipefd[0]);
		write(pipefd[1], msg, len);
		close(pipefd[1]);
		
		wait(NULL);
		
		exit(EXIT_SUCCESS);
	}	
}

