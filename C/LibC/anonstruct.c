
extern void exit(int);
extern int printf(char *, ...);

int main(void)
{
	struct {int i; double d; char c;} s;
	
	s.i = 1;
	s.d = 1.1;
	s.c = '1';

	printf("s.i=%d\ns.d=%f\ns.c=%c\n",s.i, s.d, s.c);

	return 0;
}

