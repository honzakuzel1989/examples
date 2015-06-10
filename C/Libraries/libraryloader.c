
#include <stdlib.h>
#include <stdio.h>
#include <dlfcn.h>

// In case of error try export LD_LIBRARY_PATH environment variable with working directory
// eport LD_LIBRARY_PATH=.

void use(void (*f)(void))
{
	f();
}

int main(void)
{
	// Open
	void *handle = dlopen("library.so", RTLD_LAZY);
	if(!handle)
	{
		fprintf(stderr, "%s\n", dlerror());
		return EXIT_FAILURE;
	}
	
	// Clear
	dlerror();
	
	// Load
	void (*f)(void);
	// With cast warrning
	*(void **)(&f) = dlsym(handle, "sayHello");
	char *error = dlerror();
	if(error)
	{
		fprintf(stderr, "%s\n", dlerror());
		return EXIT_FAILURE;
	}
	
	// Use
	f();
	use(f);
	
	//  CLose
	dlclose(handle);
	return EXIT_FAILURE;
}
