#include <errno.h>
#include <stdio.h>
#include <time.h>
#include <winsock2.h>

#pragma comment(lib,"ws2_32.lib") //Winsock Library

#define LOG_TO_CONSOLE 1
#define LOG_TO_FILE 1

enum LOG_LEVEL { DBG = 0, INF = 1, WRN = 2, ERR = 3, FTL = 4 };

// Function declarations
int initializeSocket(WSADATA * d);


// Function implementations
int initializeSocket(WSADATA * d)
{
    if (WSAStartup(MAKEWORD(2, 2), d)) {
        printf("Failed to initialize.\n");
        return -1;
    }
}

void initializeLog(FILE *fp)
{
    fp = fopen("./logs/main.log", "a");

}

// void log(FILE *fp, char * msg) 
// {
// }

// void logInfo(char * msg)
// {
//     char gmtTimeStr [20];
//     time_t systemTime;

//     time(&systemTime);
//     struct tm * gmtTime = gmtime(&systemTime);

//     strftime (gmtTimeStr, 20, "%Y-%m-%d %H:%M:%S", gmtTime);
//     printf ("[%s] - %s\n", gmtTimeStr, msg);
//  }

void logInfo(FILE * fp, char * msg)
{
    char gmtTimeStr [20];
    time_t systemTime;

    time(&systemTime);
    struct tm * gmtTime = gmtime(&systemTime);

    strftime (gmtTimeStr, 20, "%Y-%m-%d %H:%M:%S", gmtTime);

    if (LOG_TO_CONSOLE)
        printf ("[%s] - %s\n", gmtTimeStr, msg);
    if (LOG_TO_FILE)
        fprintf(fp, "[%s] - %s\n", gmtTimeStr, msg);
}

// main
int main (int argc, char* argv[])
{
    int errNum;
    FILE *fp;
    
    // CONSTANTS
    const char * logFilePath = "./logs/main.log";

    // Start program
    printf("[START PROGRAM]\n");

    fp = fopen(logFilePath, "a");

    if (fp == NULL) {
        printf("Error opening log file: [%s]\n", logFilePath);
        errNum = errno;
        fprintf(stderr, "Value of errno: %d\n", errno);
        perror("Error printed by perror");
        fprintf(stderr, "Error opening file: %s\n", strerror(errNum) );
    } else {
        
        logInfo(fp, "Jhe worl worls");

        fclose (fp);
    }

    // fp = fopen("./log2s/main.log", "a");
    // fprintf(fp, "This is testing for fprintf...\n");
    // fputs("This is testing for fputs...\n", fp);
    // fclose(fp);

    //log("Hello world")

    // WSADATA d; // structure contains information about the Windows Sockets implementation

    // initializeSocket(&d);

    // printf("Do stuff\n");
    
    // WSACleanup();

    printf("[END PROGRAM]\n");
	
	return 0;
}
