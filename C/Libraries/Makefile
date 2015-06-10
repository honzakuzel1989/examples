
PROGS=Main MainStatic MainDynamic
all:$(PROGS) 

CC=gcc
CPP=g++
CFLAGS=-std=c99 -O0 -Wall -W -pedantic -Wextra -g
AR=ar
ARFLAGS=crs

C.o: C.h C.c
	$(CC) -c C.c -o C.o

Main: Main.c C.o
	$(CC) $(CFLAGS) Main.c C.o -o Main

Cstatic: C.o
	$(AR) $(ARFLAGS) libctest.a C.o

Cdynamic: C.o Cdynamic
	$(CC) -shared -o libctest.so C.o

MainStatic: Main.c Cstatic
	$(CC) $(CFLAGS) -static Main.c -L. -lctest -o MainStatic

MainDynamic: Main.c
	$(CC) Main.c -o MainDynamic -L. -lctest

clean:
	rm -f -- *.exe *.a *.so *.o $(PROGS)

pack:
	zip examp.zip *.c *.h Makefile

