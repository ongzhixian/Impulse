# Filename: Makefile
# Description: The make file is to build up the crawler.
# Warning:  See how to use CFLAGS1 to build file.c
CC=gcc
CFLAGS= -Wall -pedantic -std=c99
SOURCES=./list.h ./list.c ./crawler.c ./crawler.h
CFILES=./list.c ./crawler.c

UTILDIR=../util/
UTILFLAG=-ltseutil
UTILLIB=$(UTILDIR)libtseutil.a
UTILC=$(UTILDIR)hash.c $(UTILDIR)html.c $(UTILDIR)file.c $(UTILDIR)dictionary.c
UTILH=$(UTILC:.c=.h)

crawler:$(SOURCES) $(UTILDIR)header.h $(UTILLIB)
        $(CC) $(CFLAGS) -o $@ $(CFILES) -L$(UTILDIR) $(UTILFLAG)

$(UTILLIB): $(UTILC) $(UTILH)
        cd $(UTILDIR); make;
