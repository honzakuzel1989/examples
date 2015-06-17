#!/usr/bin/env python

def logger(func):
	def inner(*args, **kwargs):
		print "before method " + func.__name__
		ret = func(*args, **kwargs)
		print "after method " + func.__name__
		return ret
	return inner

@logger
def say_hello():
	print "hello"
	return "hello"

@logger
def say_hi():
	print "hi"

if __name__ == "__main__":
	hello = say_hello()
	print hello
	say_hi()
	
