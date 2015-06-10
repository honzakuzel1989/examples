
CC=gcc
CFLAGS=-std=gnu99 -pedantic -Wextra
PROGS=testcase

.PHONY=$(PROGS) all clean
all: $(PROGS)

testcase: testcase.c generic.h
	$(CC) $(CFLAGS) $^ -o $@

clean:
	rm -f $(PROGS)

