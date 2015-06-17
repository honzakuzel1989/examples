
SCRIPT=tograph.py
GRAPHER=pycallgraph

.PHONY=all run graph

all: run

run:
	python $(SCRIPT)

graph:
	$(GRAPHER) graphviz -- $(SCRIPT)
	eog $(GRAPHER).png

