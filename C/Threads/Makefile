
CC=gcc
CFLAGS=-std=gnu99 -D_FORTIFY_SOURCE=2 -Wall -Wextra -O2 -march=native
LIBS=-lpthread

PROGS=threads cancel cleanup sigthread mutexex condex barrierex exitex #atomic

.PHONY=$(PROGS) all clean 

all:$(PROGS)

threads: threads.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

cancel: cancel.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

cleanup: cleanup.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

sigthread: sigthread.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

mutexex: mutexex.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

condex: condex.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

barrierex: barrierex.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

atomic: atomic.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS)

exitex: exitex.c
	$(CC) $(CFLAGS) $^ -o $@ $(LIBS) #-DMAINSTDRET

clean:
	rm -f $(PROGS)

