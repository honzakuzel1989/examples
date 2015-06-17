#!/usr/bin/env python

def trace(func):
	def inner():
		print ">> inp"
		func()
		print ">> out"
	return inner

def hello():
	print "Hello!"

@trace
def cao():
	print "Cao"

if __name__ == "__main__":
	decorated = trace(hello)
	decorated()
	cao()

