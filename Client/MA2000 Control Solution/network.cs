using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
namespace MA2000_Control_Solution
{
    class network
    {
        
        //***************************
        //       Send Buffer        *  
        //***************************
        public static float control;
        public static float roll_c;
        public static float yaw_c;
        public static float pitch_c;
        public static float elbow_c;
        public static float shoulder_c;
        public static float waist_c;

        public static float e0;
        public static float e1;
        public static float e2;
        public static float e3;
        public static float e4;
        public static float e5;

        public static BitArray brakeBit = new BitArray(8);


        //***************************


        //***************************
        //      Receive Buffer      *  
        //***************************

        public static float roll_p;
        public static float yaw_p;
        public static float pitch_p;
        public static float elbow_p;
        public static float shoulder_p;
        public static float waist_p;

        //***************************

        //***************************
        // Declarations
        //***************************
        private static MemoryStream buffer = new MemoryStream();

        private static byte[] sndBuffer = new byte[256];
        private static byte[] rcvBuffer = new byte[256];
        public static byte[] bControl,bRoll_c,bYaw_c,bPitch_c,bElbow_c,bShoulder_c,bWaist_c= new byte[4];
        public static byte[] bE0, bE1, bE2, bE3, bE4, bE5 = new byte[4];
        public static byte brakeByte = new byte();

        // Socket & Endpoint Declarations
        // **************************
        
          static IPEndPoint ipep ;
          static Socket server;
        //***************************


        public static void net_init(string ip, int port)
        {

             ipep = new IPEndPoint( IPAddress.Parse(ip), port);
             server =new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
        }

        public static void connect()
        {
            try
            {
                server.Connect(ipep);
                Form1.Instance.log("Connected to server at "+ ipep.Address.ToString()+":" +ipep.Port.ToString());
                classStatus.connected = true;
            }
            catch (SocketException e)
            {
                // Write log shit here
                Form1.Instance.log("Unable to connect to server.");
                Form1.Instance.log(e.ToString());
                classStatus.connected = false;
                return;
            }


        }

        public static void send()
        {
            sndBuffer = new byte[256];
            buffer.Position = 0;
            // The first thing to be done is constructing
            // the buffer...
            bControl        = BitConverter.GetBytes(control);
            bRoll_c         = BitConverter.GetBytes(roll_c);
            bYaw_c          = BitConverter.GetBytes(yaw_c);
            bPitch_c        = BitConverter.GetBytes(pitch_c);
            bElbow_c        = BitConverter.GetBytes(elbow_c);
            bShoulder_c     = BitConverter.GetBytes(shoulder_c);
            bWaist_c        = BitConverter.GetBytes(waist_c);

            bE0             = BitConverter.GetBytes(e0);
            bE1             = BitConverter.GetBytes(e1);
            bE2             = BitConverter.GetBytes(e2);
            bE3             = BitConverter.GetBytes(e3);
            bE4             = BitConverter.GetBytes(e4);
            bE5             = BitConverter.GetBytes(e5);
            brakeByte       = bit2byte(brakeBit);

            buffer.Write(bControl, 0, 4);
            buffer.Write(bRoll_c, 0, 4);
            buffer.Write(bYaw_c, 0, 4);
            buffer.Write(bPitch_c, 0, 4);
            buffer.Write(bElbow_c, 0, 4);
            buffer.Write(bShoulder_c, 0, 4);
            buffer.Write(bWaist_c, 0, 4);

            buffer.Write(bE0, 0, 4);
            buffer.Write(bE1, 0, 4);
            buffer.Write(bE2, 0, 4);
            buffer.Write(bE3, 0, 4);
            buffer.Write(bE4, 0, 4);
            buffer.Write(bE5, 0, 4);
            buffer.WriteByte(brakeByte);

            sndBuffer = buffer.ToArray();
            server.Send(sndBuffer);
        }

        public static void receive()
        {
            // Receive and extract data to the receive buffer
            rcvBuffer = new byte[256];
            server.Receive(rcvBuffer);

            roll_p      = BitConverter.ToSingle(rcvBuffer, 0);
            yaw_p       = BitConverter.ToSingle(rcvBuffer, 4);
            pitch_p     = BitConverter.ToSingle(rcvBuffer, 8);
            elbow_p     = BitConverter.ToSingle(rcvBuffer, 12);
            shoulder_p  = BitConverter.ToSingle(rcvBuffer, 16);
            waist_p     = BitConverter.ToSingle(rcvBuffer, 20);

           
        }

        public static void disconnect()
        {
            classStatus.connected = false;
            
            server.Disconnect(true);

        }

        // BitArray to byte conversion

        static byte bit2byte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("Bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }
    }
}
