
CFLAGS=-Wall -W -pedantic -Wextra -std=c99
CC=gcc

PROGS=forkex waitex pipeex noproc

.PHONY=all clean $(PROGS)

all: $(PROGS)

forkex: forkex.c
	$(CC) $(CFLAGS) $^ -o $@

waitex: waitex.c
	$(CC) $(CFLAGS) $^ -o $@

pipeex: pipeex.c
	$(CC) $(CFLAGS) $^ -o $@

noproc: noproc.c
	$(CC) $(CFLAGS) $^ -o $@

clean:
	rm -f $(PROGS)

