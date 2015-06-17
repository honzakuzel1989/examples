"""
	Tests for mymath module.
"""

# imports

import unittest
import mymath

# constants
# exception classes

class TestMyMathFunctions(unittest.TestCase):

	def test_square(self):
		self.assertTrue(mymath.square(10), (40, 100))

	def test_rectangle(self):
		self.assertTrue(mymath.rectangle(2, 4), (12, 8))

	def test_triangle(self):
		self.assertTrue(mymath.triangle(3, 3, 3), (9, 2.0))

# interface functions
# classes
# internal functions & classes

if __name__ == '__main__':
	unittest.main()

