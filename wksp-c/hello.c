// hello.c
#include <stdio.h>
#include <string.h>
#include "comm\committee.h"

int main (int argc, char * argv[])
{
    printf("[PROGRAM START]\n");

    struct committee tradingCommittee;

    // strcpy(tradingCommittee.name, "FGA");
    // Use strcpy if name is char array (eg char name[32];)
    // printf("Committee: %s\n", tradingCommittee.name);
    
    // tradingCommittee.name = "Tradding";
    // printf("Committee: %s\n", tradingCommittee.name);

    // tradingCommittee.name = "Trading Committee";
    // printf("Committee: %s\n", tradingCommittee.name);

    printf("[PROGRAM END]\n");

    return 0;
}