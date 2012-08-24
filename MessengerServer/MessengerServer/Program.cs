/****************************** Module Header ******************************\ 
* Module Name:  Program.cs 
* Project:      CSSocketServer 
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
#region Using Directive
using System;
using System.Text;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
#endregion 

namespace MessengerServer
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
