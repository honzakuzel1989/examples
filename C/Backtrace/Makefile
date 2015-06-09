
CFLAGS=-W -Wall -std=c99 -pedantic -g
#important flag - make the function names available for program
BFLAGS=-rdynamic

.PHONY=all
all: backtrace

.PHONY=backtrace
backtrace: backtrace.c
	$(CC) $(CFLAGS) $(BFLAGS) backtrace.c -o backtrace

.PHONY=clean
clean:
	rm -f backtrace

