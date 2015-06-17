
import sys

def loop(x):
	y = 0
	for i in range(x):
		y += 1
	return y

def run(x):
	y = 0
	for i in range(x):
		y += loop(x)
	return y

if __name__ == '__main__':
	try:
		print(run(int(sys.argv[1])))
	except:
		print("Usage: " + sys.argv[0] + " n, where n -> n! loops")

