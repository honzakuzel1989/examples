
NUM=1000
SORT=time

SCRIPT=toprofile.py
PROFILER=cProfile

.PHONY=run all profile graph
all: run

run:
	python $(SCRIPT) $(NUM)

profile:
	python -m $(PROFILER) -s $(SORT) $(SCRIPT) $(NUM)

graph:
	pycallgraph graphviz $(SCRIPT) $(NUM)
	eog pycallgraph.png

