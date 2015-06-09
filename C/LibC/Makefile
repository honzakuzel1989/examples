
CFLAGS=-Wall -W -pedantic -Wextra -std=c99
PROGS=stdargex atexitex sort search macros argc env mainreturn mallperturb fsattack errnoex errorlist \
	nonlocaljump assertex stddefex timeex 2darray getoptex anonstruct loop

.PHONY=all clean $(PROGS)

all: $(PROGS)

stdarg: stdargex.c
	$(CC) $(CFLAGS) stdargex.c -o stdargex

atexit: atexitex.c
	$(CC) $(CFLAGS) atexitex.c -o atexitex

sort: sort.c
	$(CC) $(CFLAGS) sort.c -o sort

search: search.c
	$(CC) $(CFLAGS) search.c -o search -lm

macros: macros.c
	$(CC) $(CFLAGS) $^ -o $@

argc: argc.c
	$(CC) $(CFLAGS) $^ -o $@

env: env.c
	$(CC) $(CFLAGS) $^ -o $@

mainreturn: mainreturn.c
	$(CC) $(CFLAGS) $^ -o $@

mallperturb: mallperturb.c
	$(CC) $(CFLAGS) $^ -o $@

fsattack: fsattack.c
	$(CC) $(CFLAGS) $^ -o $@

errnoex: errnoex.c
	$(CC) $(CFLAGS) $^ -o $@

errorlist: errorlist.c
	$(CC) $(CFLAGS) $^ -o $@

nonlocaljump: nonlocaljump.c
	$(CC) $(CFLAGS) $^ -o $@

assertex: assertex.c
	$(CC) $(CFLAGS) $^ -o $@

stddefex: stddefex.c
	$(CC) $(CFLAGS) $^ -o $@

timeex: timeex.c
	$(CC) $(CFLAGS) $^ -o $@

array: array.c
	$(CC) $(CFLAGS) $^ -o $@

getoptex: getoptex.c
	$(CC) $(CFLAGS) $^ -o $@

anonstruct: anonstruct.c
	$(CC) $(CFLAGS) $^ -o $@

loop: loop.c
	$(CC) $(CFLAGS) $^ -o $@

clean:
	rm -f $(PROGS)

