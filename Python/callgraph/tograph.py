
def one():
	print("one")
	two()

def two():
	print("two")
	three()
	four()

def three():
	print("three")
	four()
	five()
	six()

def four():
	print("four")
	five()
	six()
	seven()
	eight()

def five():
	print("five")
	pass

def six():
	print("six")
	pass

def seven():
	print("seven")

def eight():
	print("eight")

if __name__ == "__main__":
	one()
	two()
	three()
	four()
	five()
	six()
	seven()
	eight()

