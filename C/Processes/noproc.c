
#include <stdio.h>
#include <sys/sysinfo.h>

int main(void)
{
	printf("This system has %d processors configured and %d processors available.\n",
		get_nprocs_conf(), 
		get_nprocs());
	
	return 0;
}

