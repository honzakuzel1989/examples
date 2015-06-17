"""
	Contains functions to calculate
	circuit and content (returned
	like a pair) of a given element.
"""

# imports

# the best import style
import math
import sys
import inspect

# constants
# exception classes
# interface functions

def square(a):
	return 4*a, a*a

def rectangle(a, b):
	return 2 * (a+b), a*b

def triangle(a, b, c):
	# http://www.matematika.cz/obsah-trojuhelniku#heronuv-vzorec
	s = (a+b+c) / 2
	return a+b+c, math.sqrt(s * (s-a) * (s-b) * (s-c))

# classes
# internal functions & classes

def _print_content():
	# the best solution is to use inspect moudle
	functions = inspect.getmembers(sys.modules[__name__], inspect.isfunction)
	functions_names = [x for x,_ in functions]

	for f in functions_names:
		if f is "main" or f[0] is '_':
			continue
		else:
			print f

# main

def main():
	_print_content()
	return 0

if __name__ == '__main__':
	status = main()
	sys.exit(status)

