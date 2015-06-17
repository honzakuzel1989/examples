
OUTPUTADDR=mymathtest_coverage_html_output

.PHONY=test coverage all
all: test

test:
	python mymathtest.py

coverage:
	figleaf -i mymathtest.py
	mkdir -p $(OUTPUTADDR)
	figleaf2html -d $(OUTPUTADDR) .figleaf

