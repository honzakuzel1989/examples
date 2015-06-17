#!/usr/bin/env python

def trace(func):
	def inner(*args):
		print "Arguments: " + str(args)
		return func(*args)
	return inner

@trace
def pow2(x):
	return x**2

@trace
def add(x, y):
	return x+y

@trace
def mprint(*msgs):
	for m in msgs:
		print m

if __name__ == "__main__":
	print pow2(2)
	print add(2, 2)
	mprint("Hello", "World", "Dude")

