#!/usr/bin/env python

def exhandler(func):
	def inner(*args, **kwargs):
		try:
			print "executing method " + func.__name__
			ret = func(*args, **kwargs)
		except Exception as ex:
			print "failure (" + str(ex) + ")"
			raise
		else:
			print "success"
			return ret
	return inner

@exhandler
def l():
	return 10/10;

@exhandler
def m():
	return 10/0

def n():
	return 10/0

if __name__ == "__main__":
	print l()
	print m()
	print n()
	
