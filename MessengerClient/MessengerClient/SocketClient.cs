/****************************** Module Header ******************************\ 
* Module Name:  Program.cs 
* Project:      CSSocketClient 
* Copyright (c) Microsoft Corporation. 
*  
* Sockets are an application programming interface(API) in an operating system 
* used for in inter-process communication. Sockets constitute a mechanism for 
* delivering incoming data packets to the appropriate application process or 
* thread, based on a combination of local and remote IP addresses and port 
* numbers. Each socket is mapped by the operational system to a communicating 
* application process or thread. 
* 
* 
* .NET supplies a Socket class which implements the Berkeley sockets interface. 
* It provides a rich set of methods and properties for network communications.  
* Socket class allows you to perform both synchronous and asynchronous data 
* transfer using any of the communication protocols listed in the ProtocolType 
* enumeration. It supplies the following types of socket: 
* 
* Stream: Supports reliable, two-way, connection-based byte streams without  
* the duplication of data and without preservation of boundaries. 
* 
* Dgram:Supports datagrams, which are connectionless, unreliable messages of 
* a fixed (typically small) maximum length.  
* 
* Raw: Supports access to the underlying transport protocol.Using the  
* SocketTypeRaw, you can communicate using protocols like Internet Control  
* Message Protocol (Icmp) and Internet Group Management Protocol (Igmp).  
* 
* Rdm: Supports connectionless, message-oriented, reliably delivered messages,  
* and preserves message boundaries in data.  
* 
* Seqpacket:Provides connection-oriented and reliable two-way transfer of  
* ordered byte streams across a network. 
* 
* Unknown:Specifies an unknown Socket type. 
*  
* This source is subject to the Microsoft Public License. 
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL. 
* All other rights reserved. 
*  
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,  
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED  
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
\***************************************************************************/
#region Using directives
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
#endregion 

namespace MessengerClient
{
    // State object for receiving data from remote device.
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class SynchronousSocketClient
    {
        const int SOC_SUC_CODE = 1;
        const int SOC_ERR_CODE = -1;

        // Data buffer for incoming data.
        byte[] bytes = new byte[1024];
        Socket mSender = null;
        IPEndPoint remoteEP = null;

        public SynchronousSocketClient()
        {

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(HostOrIP);//Dns.Resolve("host.contoso.com");
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                mSender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


        public int Connect()
        {
            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                mSender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    mSender.RemoteEndPoint.ToString());
                return SOC_SUC_CODE;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
            return SOC_ERR_CODE;
        }

        public int Send(string msg)
        {                // Encode the data string into a byte array.
            byte[] byteMsg = Encoding.ASCII.GetBytes("This is a test<EOF>");
            return Send(byteMsg);
        }

        public int Send(byte[] msg)
        {
            try
            {
                // Send the data through the socket.
                int bytesSent = mSender.Send(msg);
                return bytesSent;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
            return SOC_ERR_CODE;
        }

        public int Receive(byte[] byteStr)
        {
            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                // Receive the response from the remote device.
                int bytesRec = mSender.Receive(byteStr);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(byteStr, 0, bytesRec));
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
            return SOC_ERR_CODE;
        }

        public string ReadLine()
        {
            string line = null;
            while (true)
            {
                byte[] bytes = new byte[1024];
                int bytesRec = Receive(bytes);
                line += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (line.IndexOf("") > -1) break;
            }
            return line;
        }

        public int Close()
        {
            try
            {
               // Release the socket.
                mSender.Shutdown(SocketShutdown.Both);
                mSender.Close();
                return SOC_SUC_CODE;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
            return SOC_ERR_CODE;
        }

    }

    public class SocStreamClient
    {
        System.Net.Sockets.TcpClient mClientSocket = null;
        NetworkStream mServerStream = null;
        string readData = null;
        string mIpAddress = "";
        int mPort = 0;

        public SocStreamClient(string ipAddress, int port)
        {
            mIpAddress = ipAddress;
            mPort = port;
            mClientSocket = new System.Net.Sockets.TcpClient();
            mServerStream = default(NetworkStream);
        }

        public void Connect()
        {
            readData = "Conected to Chat Server ...";
            mClientSocket.Connect(mIpAddress, mPort);
            mServerStream = mClientSocket.GetStream();
        }

        public void Write(string input)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(input);
            Write(outStream);
        }

        public void Write(byte[] inputByte) {
            mServerStream.Write(inputByte, 0, inputByte.Length);
            mServerStream.Flush();
        }


        public void Read()
        {
            while (true)
            {
                mServerStream = mClientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = mClientSocket.ReceiveBufferSize;
                mServerStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
            }
        }

        public void Close() {
            mServerStream.Close();
            mClientSocket.Close();
        }

    }

    public class TcpClientManager {

        SynchronousSocketClient mSocClient;
        //SocStreamClient         mstreamClient;
        public TcpClientManager() 
        {
            mSocClient = new SynchronousSocketClient();
            m
        }

        public void Connect()
        {
        }

        public void Send(string msg)
        {
        }

        public void Send(

        
    }

    public class SocketClient
    {
        public SocketClient()
        {
        }

        // The port number for the remote device.
        private const int port = 11000;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;

        public void StartClient()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());//Dns.Resolve("host.contoso.com");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.
                Send(client, "This is a test<EOF>");
                sendDone.WaitOne();

                // Receive the response from the remote device.
                Receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.
                Console.WriteLine("Response received : {0}", response);

                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
