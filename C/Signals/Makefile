
CFLAGS=-Wall -W -pedantic -Wextra #-std=c11
CC=gcc
PROGS=catchsignal sigactionex siginfoex sigprocmaskex

.PHONY=all clean $(PROGS)

all: $(PROGS)

catchsignal: catchsignal.c
	$(CC) $(CFLAGS) $^ -o $@

sigactionex: sigactionex.c
	$(CC) $(CFLAGS) $^ -o $@

siginfoex: siginfoex.c
	$(CC) $(CFLAGS) $^ -o $@

sigprocmaskex: sigprocmaskex.c
	$(CC) $(CFLAGS) $^ -o $@

clean:
	rm -f $(PROGS)

