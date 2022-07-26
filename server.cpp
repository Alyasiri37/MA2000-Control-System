
//**************** GENERAL HEADERS *****************
#include <cstdlib>
#include <winsock2.h>
#include <iostream>
using namespace std;
//**************  PCL-711b HEADERS *****************
#include <windows.h>
#include <windef.h>
#include <stdio.h>
#include <conio.h>
#include <cmath>
#include <driver.h>
//**************************************************
long   lDriverHandle;

//***************** DEFINITIONS ********************



//**************************************************

//*************** DEVICE FUNCTION DECLARATIONS *****
void ErrorHandler(DWORD dwErrCde);
void ErrorStop(long*, DWORD);





//************ Variables Section *****************//
	
	int noSamples = 100;
	bool connected;
	
	//******************** BUFFERS ***********************
	//******************** Receive Buffer ****************
	struct rcvBlock {
	float control;
	float roll_c;
	float yaw_c;
	float pitch_c;
	float elbow_c;
	float shoulder_c;
	float waist_c;
	
	float e0;
	float e1;
	float e2;
	float e3;
	float e4;
	float e5;
	unsigned m1brk:	1;
	unsigned m2brk:	1;
	unsigned m3brk:	1;
	unsigned m4brk:	1;
	unsigned m5brk:	1;
	unsigned m6brk:	1;
	unsigned null1:	1;
	unsigned null2:	1;

	} bufRCV;
	char *rcvBuf = (char *) &bufRCV;
	
	//******************* Send Buffer ********************
	struct sndBlock {
	float roll_p;
	float yaw_p;
	float pitch_p;
	float elbow_p;
	float shoulder_p;
	float waist_p;
		
	} bufSND;
	
	char *sndBuf = (char *) &bufSND;
	
	int rBytes, rv;
	
	//temp >> used for truncation 
	int temp;
	
	
void main(void)
{
//*************** PCL VARIABLE DECLARATIONS ********
    DWORD  dwErrCde;
    ULONG  lDevNum=000 ;
     
    USHORT usChan=0,outChan=0;	
	USHORT usGain=0;
    float  voltBuf,fVoltage[6],fOutValue[6];
	PT_AIVoltageIn ptAIVoltageIn;
    PT_AIConfig ptAIConfig;
	PT_AOVoltageOut tAOVoltageOut;
	ptAIVoltageIn.voltage=&voltBuf;
	

//**************************************************


//*************** NETWORK VARIABLES AND SOCKECT INIT SECTION*****************
   WSADATA              wsaData;
   SOCKET               ListeningSocket;
   SOCKET               NewConnection;
   SOCKADDR_IN          ServerAddr;
   SOCKADDR_IN          ClientAddr;
   int                  Port = 10000;
   
   // Initialize Winsock version 2.2

   WSAStartup(MAKEWORD(2,2), &wsaData);
   
      // Create a new socket to listen for client connections.
 
      ListeningSocket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	  
      // Set up a SOCKADDR_IN structure that will tell bind that we
      // want to listen for connections on all interfaces using port
      // 5150. Notice how we convert the Port variable from host byte
      // order to network byte order.
	  
      ServerAddr.sin_family = AF_INET;
      ServerAddr.sin_port = htons(Port);    
      ServerAddr.sin_addr.s_addr = htonl(INADDR_ANY);
	  
      // Associate the address information with the socket using bind.
	  
      bind(ListeningSocket, (SOCKADDR *)&ServerAddr, 
      sizeof(ServerAddr));

   // Listen for client connections. We used a backlog of 5, which
   // is normal for many applications.
	
	int ClientAddrLen=sizeof(ClientAddr);
	
      listen(ListeningSocket, 1); 

   // Accept a new connection when one arrives.

      NewConnection = accept(ListeningSocket, (SOCKADDR *) 
                          &ClientAddr,&ClientAddrLen);
		connected = true;
		cout << " CONNECTED "<< endl;
	//*************** Step 1: Open device *************
    dwErrCde = DRV_DeviceOpen(lDevNum, &lDriverHandle); 
	
	cout << " DEVICE OPEN \t" <<  lDriverHandle << endl;

    if (dwErrCde != SUCCESS)
    {
        ErrorHandler(dwErrCde);
        printf("Program terminated!\n");

        printf("Press any key to exit....");
        getch();
        exit(1) ;
    }
	//*************************************************
	// *********** Activate Brakes ************
    DWORD lPortStart = 0;			// for digital output
    DWORD lPortCount = 2;			// for digital output
	BYTE * pBufData = new BYTE[ lPortCount ];
	pBufData[ 0 ] = 0x00;
	pBufData[ 1 ] = 0x80;
	
	dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
	    if (dwErrCde != SUCCESS)
    {
        ErrorHandler(dwErrCde);
        printf("Program terminated!\n");

        printf("Press any key to exit....");
        getch() ;
        exit(1) ;
    }
		cout << " AdxDioWriteDoPorts \t" <<  lDriverHandle << endl;
	cout << " Brakes On " << endl;
	//*************************************************
	//Step 2: Config device
	//Analog IN
    ptAIConfig.DasChan = usChan;
    ptAIConfig.DasGain = usGain;
	
	//Analog OUT
	tAOVoltageOut.chan = outChan;
    dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
    if (dwErrCde != SUCCESS)
    {
        ErrorStop(&lDriverHandle, dwErrCde);
        return;
    }
	//*************************************************
	
	// Step 3: prepare data aquisition
    ptAIVoltageIn.chan = usChan;              // input channel
    ptAIVoltageIn.gain = usGain;              // gain code: refer to manual for voltage range
    ptAIVoltageIn.TrigMode = 0;               // 0: internal trigger, 1: external trigger
    //ptAIVoltageIn.voltage = &fVoltage;        // Voltage retrieved
	//int noSamples = 50;				          // number of samples

	
	
	
	
	
   //****************************************************************
   // At this point you can do two things with these sockets. Wait
   // for more connections by calling accept again on ListeningSocket
   // and start sending or receiving data on NewConnection. We will
   // describe how to send and receive data later in the chapter.
   //***************************************************************
	
	//recv(NewConnection, rcvBuf , sizeof(bufRCV), 0);
	
	
	
   float tempVolt=0;
    while (connected)
            {

                //cout << " while (connected) " << endl;

                    // Start basic data transfer to check for control command
                   // while (bufRCV.control == 0)
                    //{


                        //check start variable
						//Connected, waiting for the client to start the control command.
						recv(NewConnection, rcvBuf , sizeof(bufRCV), 0);
						//bufRCV.control = ntohl(bufRCV.control);
                        //cout << bufRCV.control<<endl;
                        // Release H/W lock
						
						//
						// Set the analog output position to float
						//
						pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
						
						dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
								{
									ErrorHandler(dwErrCde);
									printf("Program terminated!\n");

									printf("Press any key to exit....");
									getch() ;
									exit(1) ;
								}
								//*************** Last edit
							fVoltage[0]=0;
							fVoltage[1]=0;
							fVoltage[2]=0;
							fVoltage[3]=0;
							fVoltage[4]=0;
							fVoltage[5]=0;
                        while (bufRCV.control == 1)
                        {
							
							 //cout << bufRCV.control<<endl;
							 //Sleep(1000);
							/// We need to transmit data first
							//----------------------------------------------
                            //step 4 :  Perform Data acquisition here, 
                            
							
						/*	for (USHORT j = 0; j < 6; j++)
							{	
								
								ptAIVoltageIn.chan = j;
								tempVolt=0.0;
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[j]=tempVolt/(float) noSamples;
								
								
								
							}
							*/	
							//cout << bufRCV.m6brk;
							//Sleep(2000); 
							//**************************************************
							// Convert voltages to doubles to ensure integrity
							bufSND.roll_p		=  fVoltage[0];
							bufSND.yaw_p		=  fVoltage[1];
							bufSND.pitch_p		=  fVoltage[2];
							bufSND.elbow_p		=  fVoltage[3];
							bufSND.shoulder_p	=  fVoltage[4];
							bufSND.waist_p		=  fVoltage[5];
														
							//**************************************************
						    

                            send(NewConnection, sndBuf, sizeof(bufSND), 0);
							//cout << "data sent "<<endl;
                            //**************************************************
							//Sleep(2000);
							
							//*************** Extract data from the buffer *****

							recv(NewConnection, rcvBuf , sizeof(bufRCV), 0);

							
						
													
								
								
						    //*************************************************
                            // ***************** ANALOG DE-MULTIPLEXING *****************
							// This section de multiplexes the analog speeds for the motors
							// 
							// Get the voltages from the buffer,
								fOutValue[0] = bufRCV.roll_c;
								fOutValue[1] = bufRCV.yaw_c;
								fOutValue[2] = bufRCV.pitch_c;
								fOutValue[3] = bufRCV.elbow_c;
								fOutValue[4] = bufRCV.shoulder_c;
								fOutValue[5] = bufRCV.waist_c;

							for (int i = 0; i<6; i++)
								 {
									fOutValue[i]=fabs(fOutValue[i]);
									if ( fOutValue[i] > 4)
										fOutValue[i]=4;
								 }
									
													
													 //
                            // Set the output of the plant with the output of the controller
                            
							// Set the directional bytes
							// At first the braking is aktivated on byte 1,, I know there is a typo here
							
							
							
							
							
							// We can shorten the time by neglecting the idle motors
							// from the multiplex procedure, the D/O buffer should be done !!
							// otherwise the analog out will swing to the wrong port.
							// ******************* MOTOR 1 ***********************
								
							//********** MOTOR 1 *************
															
								if ( !bufRCV.m1brk )
								
								{
								 //************* last edit comrade
								ptAIVoltageIn.chan = 0;
								tempVolt=0.0;
								dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									}
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[0]=tempVolt/(float) noSamples;
								
								bufSND.roll_p		=  fVoltage[0];
								
								
								
								pBufData[ 0 ] = pBufData[ 0 ] & 0xFC;
								
								if (bufRCV.e0 < 0)
											{
											pBufData[ 0 ] = pBufData[ 0 ] | 0x02;
											}
								else if (bufRCV.e0 > 0)
											{
												pBufData[ 0 ] = pBufData[ 0 ] | 0x01;
								
											}
											
									// Analog Out		
									tAOVoltageOut.OutputValue = fabs(fOutValue[0]);
									if (tAOVoltageOut.OutputValue > 4) tAOVoltageOut.OutputValue = 4;
									dwErrCde = DRV_AOVoltageOut(lDriverHandle, &tAOVoltageOut);
									Sleep(1);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										printf("Press any key to exit....");
										getch();
										return;
									}
									
								//
								// SEND Direction + Speed
								//
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								pBufData[ 1 ] = pBufData[ 1 ] | 0x10;
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}
								
								//
								//Set the output on the float pin
								//
									
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}	
								}
								else {pBufData[ 0 ] = pBufData[ 0 ] & 0xFC;}
								// ******************************************
								
								// ******************* MOTOR 2 ***********************
								 							
								if ( !bufRCV.m2brk )
							{
								{
								
								ptAIVoltageIn.chan = 1;
								tempVolt=0.0;
								dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									}
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[1]=tempVolt/(float) noSamples;
								
								bufSND.yaw_p		=  fVoltage[1];
								
								pBufData[ 0 ] = pBufData[ 0 ] & 0xF3;
								
								if (bufRCV.e1 < 0)
											{
											pBufData[ 0 ] = pBufData[ 0 ] | 0x08;
											}
								else if (bufRCV.e1 > 0)
											{
												pBufData[ 0 ] = pBufData[ 0 ] | 0x04;
								
											}
											
									// Analog Out		
									tAOVoltageOut.OutputValue = fabs(fOutValue[1]);
									if (tAOVoltageOut.OutputValue > 4) tAOVoltageOut.OutputValue = 4;
									dwErrCde = DRV_AOVoltageOut(lDriverHandle, &tAOVoltageOut);
									Sleep(1);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										printf("Press any key to exit....");
										getch();
										return;
									}
									
								//
								// SEND Direction + Speed
								//
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								pBufData[ 1 ] = pBufData[ 1 ] | 0x20;
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}
								
								//
								//Set the output on the float pin
								//
									
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}	
								  }
								
								}
								else {pBufData[ 0 ] = pBufData[ 0 ] & 0xF3;}
								//*************************************************
								
								// ******************* MOTOR 3 ***********************
															
								if ( !bufRCV.m3brk )
								
								{
								
								ptAIVoltageIn.chan = 2;
								tempVolt=0.0;
								dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									}
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[2]=tempVolt/(float) noSamples;
								
								bufSND.pitch_p		=  fVoltage[2];
								
								
								
								pBufData[ 0 ] = pBufData[ 0 ] & 0xCF;
								
								if (bufRCV.e2 < 0)
											{
											pBufData[ 0 ] = pBufData[ 0 ] | 0x20;
											}
								else if (bufRCV.e2 > 0)
											{
												pBufData[ 0 ] = pBufData[ 0 ] | 0x10;
								
											}
											
									// Analog Out		
									tAOVoltageOut.OutputValue = fabs(fOutValue[2]);
									if (tAOVoltageOut.OutputValue > 4) tAOVoltageOut.OutputValue = 4;
									dwErrCde = DRV_AOVoltageOut(lDriverHandle, &tAOVoltageOut);
									Sleep(1);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										printf("Press any key to exit....");
										getch();
										return;
									}
									
								//
								// SEND Direction + Speed
								//
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								pBufData[ 1 ] = pBufData[ 1 ] | 0x30;
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}
								
								//
								//Set the output on the frloat pin
								//
									
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}	
								
								
								}
								else{pBufData[ 0 ] = pBufData[ 0 ] & 0xCF;}								
								//*************************************************
								
								// ******************* MOTOR 4 ***********************
								 							
								if ( !bufRCV.m4brk )
							
								{
								
								ptAIVoltageIn.chan = 3;
								tempVolt=0.0;
								dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									}
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[3]=tempVolt/(float) noSamples;
								bufSND.elbow_p		=  fVoltage[3];
								
								
								pBufData[ 0 ] = pBufData[ 0 ] & 0x3F;
								
								if (bufRCV.e3 < 0)
											{
											pBufData[ 0 ] = pBufData[ 0 ] | 0x80;
											}
								else if (bufRCV.e3 > 0)
											{
												pBufData[ 0 ] = pBufData[ 0 ] | 0x40;
								
											}
											
									// Analog Out		
									tAOVoltageOut.OutputValue = fabs(fOutValue[3]);
									if (tAOVoltageOut.OutputValue > 4) tAOVoltageOut.OutputValue = 4;
									dwErrCde = DRV_AOVoltageOut(lDriverHandle, &tAOVoltageOut);
									Sleep(1);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										printf("Press any key to exit....");
										getch();
										return;
									}
									
								//
								// SEND Direction + Speed
								//
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								pBufData[ 1 ] = pBufData[ 1 ] | 0x40;
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}
								
								//
								//Set the output on the frloat pin
								//
									
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}	
								}
								else {pBufData[ 0 ] = pBufData[ 0 ] & 0x3F;}
								//*************************************************

								
								// ******************* MOTOR 5 ***********************
								 							
								if ( !bufRCV.m5brk )
							
								{
								
								ptAIVoltageIn.chan = 4;
								tempVolt=0.0;
								dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									}
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[4]=tempVolt/(float) noSamples;
								
								bufSND.shoulder_p	=  fVoltage[4];
								
								pBufData[ 1 ] = pBufData[ 1 ] & 0xFC;
								
								if (bufRCV.e4 < 0)
											{
											pBufData[ 1 ] = pBufData[ 1 ] | 0x02;
											}
								else if (bufRCV.e4 > 0)
											{
												pBufData[ 1 ] = pBufData[ 1 ] | 0x01;
								
											}
											
									// Analog Out		
									tAOVoltageOut.OutputValue = fabs(fOutValue[4]);
									if (tAOVoltageOut.OutputValue > 4) tAOVoltageOut.OutputValue = 4;
									dwErrCde = DRV_AOVoltageOut(lDriverHandle, &tAOVoltageOut);
									Sleep(1);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										printf("Press any key to exit....");
										getch();
										return;
									}
									
								//
								// SEND Direction + Speed
								//
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								pBufData[ 1 ] = pBufData[ 1 ] | 0x50;
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}
								
								//
								//Set the output on the frloat pin
								//
									
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}	
								}
								else {pBufData[ 1 ] = pBufData[ 1 ] & 0xFC;}
								//*************************************************
								
								
								// ******************* MOTOR 6 ***********************
								
								 							
								if ( !bufRCV.m6brk )
							
							
								{
								
								ptAIVoltageIn.chan = 5;
								tempVolt=0.0;
								dwErrCde = DRV_AIConfig(lDriverHandle, &ptAIConfig);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									}
								for (int i = 0; i < noSamples; i++)
								{
									
									
								   dwErrCde = DRV_AIVoltageIn(lDriverHandle, &ptAIVoltageIn);
								   
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										return;
									} 
									
									//ptAIVoltageIn.voltage=&voltBuf;
									tempVolt+=voltBuf;
									//cout << voltBuf<<endl;
								//	cout << ptAIVoltageIn.chan << endl;
									

								}
								 //Take the average and truncate 
								fVoltage[5]=tempVolt/(float) noSamples;
								
								bufSND.waist_p		=  fVoltage[5];
								
								
								pBufData[ 1 ] = pBufData[ 1 ] & 0xF3;
								
								if (bufRCV.e5 < 0)
											{
											pBufData[ 1 ] = pBufData[ 1 ] | 0x08;
											}
								else if (bufRCV.e5 > 0)
											{
												pBufData[ 1 ] = pBufData[ 1 ] | 0x04;
								
											}
											
									// Analog Out		
									tAOVoltageOut.OutputValue = fabs(fOutValue[5]);
									if (tAOVoltageOut.OutputValue > 4) tAOVoltageOut.OutputValue = 4;
									dwErrCde = DRV_AOVoltageOut(lDriverHandle, &tAOVoltageOut);
									Sleep(1);
									if (dwErrCde != SUCCESS)
									{
										ErrorStop(&lDriverHandle, dwErrCde);
										printf("Press any key to exit....");
										getch();
										return;
									}
									
								//
								// SEND Direction + Speed
								//
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								pBufData[ 1 ] = pBufData[ 1 ] | 0x60;
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}
								
								//
								//Set the output on the frloat pin
								//
									
								pBufData[ 1 ] = pBufData[ 1 ] & 0x8f;
								
								dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
									if (dwErrCde != SUCCESS)
										{
											ErrorHandler(dwErrCde);
											printf("Program terminated!\n");
											printf("Press any key to exit....");
											getch() ;
											exit(1) ;
										}	
								}
								else {pBufData[ 1 ] = pBufData[ 1 ] & 0xF3;}
										
							//*************************************************
							

                           
                        }
						// *********** Activate Brakes ************
			
							pBufData[ 0 ] = 0x00;
							pBufData[ 1 ] = 0x80;
							
							dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
								if (dwErrCde != SUCCESS)
							{
								ErrorHandler(dwErrCde);
								printf("Program terminated!\n");

								printf("Press any key to exit....");
								getch() ;
								exit(1) ;
							}
							
							//break;
							
							if (bufRCV.control==-1)
								{
								  WSACleanup();
								  connected =false;
								  break;
								}
							
            }
            
			
			// *********** Activate Brakes ************
			
			pBufData[ 0 ] = 0x00;
			pBufData[ 1 ] = 0x80;
			
			dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
				if (dwErrCde != SUCCESS)
			{
				ErrorHandler(dwErrCde);
				printf("Program terminated!\n");

				printf("Press any key to exit....");
				getch() ;
				exit(1) ;
			}
			
   //****************************************************************
      // Step 5: Close device
    dwErrCde = DRV_DeviceClose(&lDriverHandle);
	if (dwErrCde != SUCCESS)
    {
        ErrorStop(&lDriverHandle, dwErrCde);
        return;
    }
	  
	  
	  closesocket(NewConnection);
      closesocket(ListeningSocket);

   // When your application is finished handling the connections, 
   // call WSACleanup.
if (bufRCV.control==-1)
	{
      WSACleanup();
	  connected =false;
	}
}
//*******************************************************************
//***************** FUNCTION DECLARATION ****************************



/**********************************************************************
 * Function: ErrorHandler
 *           Show the error message for the corresponding error code
 * input:    dwErrCde, IN, Error code
 * return:   none
 **********************************************************************/
void ErrorHandler(DWORD dwErrCde)
{
    char szErrMsg[180];

    DRV_GetErrorMessage(dwErrCde, szErrMsg);
    printf("\nError(%d): %s\n", dwErrCde & 0xffff, szErrMsg);
}//ErrorHandler

/**********************************************************************
 * Function:   ErrorStop
 *             Release all resource and terminate program if error occurs 
 * Paramaters: pDrvHandle, IN/OUT, pointer to Driver handle
 *             dwErrCde, IN, Error code.
 * return:     none             
 **********************************************************************/
void ErrorStop(long *pDrvHandle, DWORD dwErrCde)
{
    //Error message 
    ErrorHandler(dwErrCde);
    printf("Program terminated!\n");
    
    //Close device & brake b4 it;
	// *********** Activate Brakes ************
			DWORD lPortStart = 0;			// for digital output
			DWORD lPortCount = 2;			// for digital output
			BYTE * pBufData = new BYTE[ lPortCount ];
			pBufData[ 0 ] = 0x00;
			pBufData[ 1 ] = 0x80;
			
			dwErrCde = AdxDioWriteDoPorts( lDriverHandle, lPortStart, lPortCount, pBufData );
				if (dwErrCde != SUCCESS)
			{
				ErrorHandler(dwErrCde);
				printf("Program terminated!\n");

				printf("Press any key to exit....");
				getch() ;
				exit(1) ;
			}
			
    DRV_DeviceClose(pDrvHandle);
	if(connected==true)
    WSACleanup();
	connected =false;
    printf("Press any key to exit....");
    getch();
    exit(1);
}//ErrorStop












