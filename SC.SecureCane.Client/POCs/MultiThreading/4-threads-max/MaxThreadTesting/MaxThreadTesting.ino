#include <Thread.h>
#include <ThreadController.h>

int ledPin = 13;

// ThreadController that will controll all threads
ThreadController controll = ThreadController();

//1 Thread
Thread myThread = Thread();
//2 Thread
Thread hisThread = Thread();
//3 Thread
Thread herThread = Thread();
//4 Thread
Thread yourThread = Thread();
//5 Thread
Thread ourThread = Thread();
//ThreadController, that will be added to controll
ThreadController groupOfThreads = ThreadController();

// callback for myThread
void myCallback(){
	Serial.print("callback for Thread 1 : ");
	Serial.println(millis());
}

// callback for hisThread
void hisCallback(){
	Serial.print("callback for Thread 2 : ");
	Serial.println(millis());
}


// callback for herThread
void herCallback(){
	Serial.print("callback for Thread 3 : ");
	Serial.println(millis());
}

// callback for yourThread
void yourCallback(){
	Serial.print("callback for Thread 4 : ");
	Serial.println(millis());
}

// callback for ourThread
void ourCallback(){
	Serial.print("callback for Thread 5 : ");
	Serial.println(millis());
}

void setup(){
	Serial.begin(9600);

	// Configure myThread
	myThread.onRun(myCallback);
	myThread.setInterval(5000);

	// Configure hisThread
	hisThread.onRun(hisCallback);
	hisThread.setInterval(5000);
	
	// Configure herThread
	herThread.onRun(herCallback);
	herThread.setInterval(5000);

	// Configure yourThread
	herThread.onRun(yourCallback);
	herThread.setInterval(5000);

	// Configure yourThread
	herThread.onRun(ourCallback);
	herThread.setInterval(5000);

	// Adds myThread to the controll
	controll.add(&myThread);

	// Adds hisThread and blinkLedThread to groupOfThreads
	groupOfThreads.add(&hisThread);
	groupOfThreads.add(&herThread);
	groupOfThreads.add(&yourThread);

	// Add groupOfThreads to controll
	controll.add(&groupOfThreads);
	
}

void loop(){
	// run ThreadController
	// this will check every thread inside ThreadController,
	// if it should run. If yes, he will run it;
	controll.run();

	// Rest of code
	float h = 3.1415;
	h/=2;
}