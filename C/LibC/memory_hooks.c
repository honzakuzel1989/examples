
/*
 * Sources:
 * http://www.gnu.org/software/libc/manual/html_node/Hooks-for-Malloc.html
 * http://lists.gnu.org/archive/html/bug-hurd/2011-11/msg00022.html
 */

/* Prototypes for __malloc_hook, __free_hook */
#include <malloc.h>
#include <stdio.h>

#ifndef __MALLOC_HOOK_VOLATILE
#	define __MALLOC_HOOK_VOLATILE
#endif

#define __unused __attribute__((__unused__))

/* Prototypes for our hooks */
static void my_init_hook(void);
static void *my_malloc_hook(size_t, const void *);
static void my_free_hook(void *, const void *);
static void *my_realloc_hook(void *, size_t, const void *);

/* Override initializing hook from the C library */
void (*__MALLOC_HOOK_VOLATILE __malloc_initialize_hook)(void) = my_init_hook;

/* Variables to save original hooks */
static void *(*old_malloc_hook)(size_t, const void *);
static void (*old_free_hook)(void *, const void *);
static void *(*old_realloc_hook)(void *, size_t, const void *);

static void my_init_hook(void)
{
	old_malloc_hook = __malloc_hook;
	old_free_hook = __free_hook;
	old_realloc_hook = __realloc_hook;
	__malloc_hook = my_malloc_hook;
	__free_hook = my_free_hook;
	__realloc_hook = my_realloc_hook;
}

static void *my_malloc_hook(size_t size, const void *caller __unused)
{
	void *result;

	/* Restore all old hooks */
	__malloc_hook = old_malloc_hook;
	__free_hook = old_free_hook;
	__realloc_hook = old_realloc_hook;

	/* Call recursively */
	result = malloc(size);

	/* Save underlying hooks */
	old_malloc_hook = __malloc_hook;
	old_free_hook = __free_hook;
	old_realloc_hook = __realloc_hook;

	/* Printf might call malloc, protect it */
	printf("malloc (%u bytes) returns %p\n", (unsigned) size, result);

	/* Restore our own hooks */
	__malloc_hook = my_malloc_hook;
	__free_hook = my_free_hook;
	__realloc_hook = my_realloc_hook;

	return result;
}

static void my_free_hook(void *ptr, const void *caller __unused)
{
	/* Restore all old hooks */
	__malloc_hook = old_malloc_hook;
	__free_hook = old_free_hook;
	__realloc_hook = old_realloc_hook;

	/* Call recursively */
	free(ptr);

	/* Save underlying hooks */
	old_malloc_hook = __malloc_hook;
	old_free_hook = __free_hook;
	old_realloc_hook = __realloc_hook;

	/* Printf might call malloc, protect it */
	printf("freed pointer %p\n", ptr);

	/* Restore our own hooks */
	__malloc_hook = my_malloc_hook;
	__free_hook = my_free_hook;
	__realloc_hook = my_realloc_hook;
}

static void *my_realloc_hook(void *ptr, size_t size, const void *caller __unused)
{
	void *result;

	/* Restore all old hooks */
	__malloc_hook = old_malloc_hook;
	__free_hook = old_free_hook;
	__realloc_hook = old_realloc_hook;

	/* Call recursively */
	result = realloc(ptr, size);

	/* Save underlying hooks */
	old_malloc_hook = __malloc_hook;
	old_free_hook = __free_hook;
	old_realloc_hook = __realloc_hook;

	/* Printf might call malloc, protect it */
	printf("realloc (%p %u bytes) returns %p\n", ptr, (unsigned) size, result);

	/* Restore our own hooks */
	__malloc_hook = my_malloc_hook;
	__free_hook = my_free_hook;
	__realloc_hook = my_realloc_hook;

	return result;
}

int main(void)
{
	int *i = malloc(10 * sizeof(int));
	if(i) free(i);

	char *ch = realloc(NULL, 100 * sizeof *ch);
	if(ch) free(ch);

	return 0;
}

