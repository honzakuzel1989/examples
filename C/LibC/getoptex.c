
#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>
#include <err.h>
#include <string.h>
#include <getopt.h>

typedef struct 
{
	// -i ifile
	char *ifile;
	// -o [12]
	int out;
}TParams;

static void check_params(const int argc, const char **argv, TParams *params)
{
	// optarg - swich argument
	// opterr - disable (0)  or enable print error in case unknown switch
	// optind - the index in argv of first element that is not a option
	// optopt - store unknown option character (getopt return '?')
	// optstring - possible options (sorted, by convention)

	opterr = 0;
	
	int opt, counter = 1;
	while((opt = getopt(argc, (char **)argv, "i:o:t")) != -1)
	{
		switch(opt)
		{
			case 'o':
				counter+=2;
				params->out = atoi(optarg);
				break;
			case 'i':
				counter+=2;
				if(!(params->ifile = (char *)malloc(strlen(optarg) + 1)))
					exit(EXIT_FAILURE);
				strcpy(params->ifile, optarg);
				break;
			case '?':
				counter--;
				fprintf(stderr, "Fail app option (%c)\n", (char)optopt);
				break;
		}
	}

	if(counter != argc)
	{
		fprintf(stderr, "Bad options!\n");
		exit(EXIT_FAILURE);
	}	
}

int main(int argc, char **argv)
{
	if(argc != 5)
		errx(EXIT_FAILURE, "Wrong app options count!");

	TParams params;

	check_params((const int)argc, (const char **)argv, &params);

	printf("ifile: %s\n", params.ifile);
	printf("output: %d\n", params.out);

	free(params.ifile);

	return EXIT_SUCCESS;
}

