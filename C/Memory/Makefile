
CFLAGS=-rdynamic -std=c99 -pedantic -Wall -Wextra

.PHONY=all
all: alloc set

.PHONY=alloc
alloc: alloc.c
	$(CC) $(CFLAGS) alloc.c -o alloc

.PHONY=set
set: set.c
	$(CC) $(CFLAGS) set.c -o set

.PHONY=clean
clean:
	rm -f alloc set

