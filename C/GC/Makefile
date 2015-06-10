
CC=gcc
CFLAGS=-pedantic -Wall -Wextra -O0 -W -std=c99
PROGS=ex1 ex2

.PHONY=all clean $(PROGS)
all: $(PROGS)

ex1: ex1.c
	$(CC) $(CFLAGS) $^ -o $@ -lgc

ex2: ex2.c
	$(CC) $(CFLAGS) $^ -o $@ -lgc

clean:
	rm -f $(PROGS)

