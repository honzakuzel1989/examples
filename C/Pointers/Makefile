
CFLAGS=-std=c99 -Wall -pedantic -Wextra -W
PROGS=funcptr funcarray funcs

.PHONY=all clean $(PROGS)

all: $(PROGS)

funcptr: funcptr.c
	$(CC) $(CFLAGS) $^ -o $@

funcarray: funcarray.c
	$(CC) $(CFLAGS) $^ -lm -o $@

func: funcs.c
	$(CC) $(CFLAGS) $^ -o $@

clean:
	rm -f $(PROGS)

