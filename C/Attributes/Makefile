
FLAGS=$(CFLAGS) -Wall -pedantic -Wextra -std=c99
PROGS=format noreturn const unused nonnull

.PHONY=all
all: $(PROGS)

.PHONY=format
format: format.c
	$(CC) $(FLAGS) $< -o $@
	
.PHONY=noreturn
noreturn: noreturn.c
	$(CC) $(FLAGS) $^ -o $@

.PHONY=const
const: const.c
	$(CC) $(FLAGS) $^ -o $@

.PHONY=unused
unused: unused.c
	$(CC) $(FLAGS) -DUNUSED $^ -o $@

.PHONY=nonnull
nonnull: nonnull.c
	$(CC) $(FLAGS) $^ -o $@

.PHONY=clean
clean:
	rm -rf $(PROGS)

