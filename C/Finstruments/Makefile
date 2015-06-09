
CFLAGS=-std=c99 -Wall -g -Wextra -pedantic -finstrument-functions -rdynamic

all: finstruments

finstruments: finstruments.c
	$(CC) $(CFLAGS) finstruments.c -o finstruments

clean:
	rm -f finstruments

