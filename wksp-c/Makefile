########################################

# Usage:
# make        # compile all binary
# make clean  # remove ALL binaries and objects

########################################
# Variables

CC := gcc
CFLAGS :=
CPPFLAGS :=

########################################
# Targets

# all:
# 	Write-Host "HELLO WORLD"

# Define a pattern rule that compiles every .c file into a .o file
%.o : %.c
	$(CC) -c $(CFLAGS) $(CPPFLAGS) $< -o $@

.FAKE:

hello: .FAKE
	${CC} hello.c -o hello

hey: one two
	# Outputs "hey", since this is the first target
	echo $@ #

	# Outputs all prerequisites newer than the target "one two"
	echo $?

	# Outputs all prerequisites "one two"
	echo $^

	echo "hey"

one:
	@echo "do one"

two:
	@echo "do two"


########################################
# Example targets

# .DEFAULT_GOAL := generate

# .PHONY: all say_hello generate clean

# all: say_hello generate

# say_hello:
# 	echo "Hello World"

# generate:
# 	@echo "Creating empty text files..."
# 	touch file-{1..10}.txt

# clean:
# 	@echo "Cleaning up..."
# 	rm *.txt