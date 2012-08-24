using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace MessengerServer
{
    public class ServerManager
    {
        SynchronousSocketListener server;
        Thread thServer;
        int mPort = 0;

        public event EventHandler BufferChanged;
        public ServerManager(int port)
        {
            mPort = port;
            server = new SynchronousSocketListener(mPort);
                
        }
        
        void Server_BufferChanged(object sender, EventArgs e)
        {
            this.BufferChanged(sender, new EventArgs());
        }

        public void DoRun()
        {
            server.BufferChanged += new EventHandler(Server_BufferChanged);
            thServer = new Thread(new ThreadStart(Start));
            thServer.Start();
            //this.BufferChanged(this, new EventArgs());
        }

        public void Start()
        {
            server.StartListening();
        }

        public string getBuffer()
        {
            return server.mBufferStr;
        }
    }

    public class SynchronousSocketListener
    {

        public event EventHandler BufferChanged;
        int mPort = 0;
        public string mBufferStr;
        public Hashtable mHtClientTable;
        private Object mClientTableLock = new Object();
        public Hashtable mHtLoginTable = null;  //로그인 사용자 Socket정보 테이블(key=id, value=Socket)
        
        public SynchronousSocketListener(int port)
        {
            mPort = port;
            //mBufferStr = "Waiting for a connection...";
        }
        public void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = new IPHostEntry();
            ipHostInfo.AddressList = new IPAddress[] { new IPAddress(new Byte[] { 127, 0, 0, 1 }) };
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1100);

            // Create a TCP/IP socket.
            Socket serverSoc = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                serverSoc.Bind(localEndPoint);
                serverSoc.Listen(10);
                mHtClientTable = new Hashtable();

                // Start listening for connections.
                while (true)
                {
                    Debug.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    this.BufferChanged(this, new EventArgs());
                    Socket soc = listener.Accept();
                    mHtClientTable.Add(soc.RemoteEndPoint.ToString(), soc);
                    Thread thClient = new Thread(new ParameterizedThreadStart(this.ReceiveMsg));
                    thClient.Start(soc);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            Debug.WriteLine("StartListening...");
            //Debug.Read();

        }

        public void addMsg(string msg)
        {
            mBufferStr = msg;
            this.BufferChanged(this, new EventArgs());
        }

        public void ReceiveMsg(object client)
        {
            Socket clientSoc = (Socket)client;

            // Incoming data from the client.
            string msg = null;
    
            // An incoming connection needs to be processed.
            while (true)
            {
                byte[] buffer = new byte[1024];
                int recv = 0;
                msg = "";
                //단일 메시지 수신
                while (true)
                {
                    recv = clientSoc.Receive(buffer);
                    if (recv == 0) break;
                    msg += Encoding.UTF8.GetString(buffer, 0, recv);
                }
                //메시지 수신 완료후 처리
                int mode = getMode(msg);

                addMsg("수신 메시지 : " + msg);

                ArrayList list = new ArrayList();
                list.Add(mode);
                list.Add(msg);
                list.Add(clientSoc);

                Thread msgThread = new Thread(new ParameterizedThreadStart(receiveReq));
                msgThread.Start(list);
            }
        }

        public void SendMsg(object client, string msg)
        {
            Socket clientSoc = (Socket)client;
            // Echo the data back to the client.
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            int retry = 0;
            int recv = 0;
            while (true)
            {
                recv = clientSoc.Send(buffer, SocketFlags.None);
                if (recv == buffer.Length) break;
                
                if (retry >= 3)
                {
                    throw new Exception("SendMsg Error :"+msg);
                }
                retry++;
            }
        }

        public void CloseClient(object client)
        {
            Socket clientSoc = (Socket)client;
            lock (mClientTableLock)
            {
                mHtClientTable.remove(clientSoc.RemoteEndPoint.ToString());
            }
            clientSoc.Shutdown(SocketShutdown.Both);
            clientSoc.Close();
        }


        public int getMode(string msg)
        {
            int mode = 0;
            string[] udata = null;
            try
            {
                msg = msg.Trim();
                if (msg.Contains("|"))
                {
                    udata = msg.Split('|');
                }
                mode = Convert.ToInt32(udata[0]);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("getMode() Exception : " + ex.ToString());
                mode = 10000;
            }
            return mode;
        }


        public void receiveReq(object Obj)
        {
            try
            {
                logWrite("receiveReq thread 시작!");
                Thread.Sleep(10);
                ArrayList List = (ArrayList)Obj;
                int mode = (int)List[0];
                string msg = (string)List[1];
                Socket clientSoc = null;
                if (List.Count > 2)
                {
                    clientSoc = (Socket)List[2];
                }
                string[] re = null;

                switch (mode)
                {
                    case 8://로그인
                        logWrite("case 8 로그인 요청");

                        re = msg.Split('|'); //msg 구성 : 코드번호|id|비밀번호|내선번호|ip주소
                        string clientId = re[1];
                        lock (mClientTableLock)
                        {
                            if (clientId != "")
                            {
                                mHtClientTable.Add(clientSoc.RemoteEndPoint.ToString(), clientSoc);
                                mHtLoginTable.Add(clientId, clientSoc);
                            }
                        }
                        //iep = new IPEndPoint(IPAddress.Parse(re[4]), 8883);
                        //Login(re, iep);
                        break;

                    case 0: //대화종료
                        break;

                    case 5: //파일 전송 메시지(5|파일명|파일크기|파일타임키|전송자id|수신자id;id;id...
                        re = msg.Split('|');
                        string[] filenameArray = re[1].Split('\\');
                        string filename = filenameArray[(filenameArray.Length - 1)];
                        int filesize = int.Parse(re[2]);

                        Hashtable fileinfotable = new Hashtable();
                        fileinfotable[re] = filename;

                        //파일 수신 스레드 시작
                        lock (filesock)
                        {
                            filesock = new UdpClient(filesender);
                            if (!ThreadList.ContainsKey(re[3] + re[4]) || ThreadList[re[3] + re[4]] == null) //같은 파일에 대한 전송 쓰레드가 시작되지 않았다면
                            {
                                Thread filereceiver = new Thread(new ParameterizedThreadStart(FileReceiver));
                                filereceiver.Start(fileinfotable);
                                ThreadList[re[3] + re[4]] = filereceiver;
                                SendMsg("Y|" + re[1] + "|" + re[3] + "|" + re[5], iep);  //re[5]==all 의 경우 전체에 대한 파일 전송
                            }
                        }
                        break;

                    case MsgMode.FILE_SND_SNR_REQ:  //case 23: 파일 전송 요청 (mode|전송자id|수신자id
                        //전송내용확인후 
                        re = msg.Split('|');
                        string senderId = re[1];
                        string recvId = re[2];
                        
                        //case MsgMode.FILE_SND_SNR_RES: //case 24: 전송요청 확인. 대기명령
                        string msgReturn = MsgMode.FILE_SND_SNR_RES + MsgFmt.DELIM+ MsgDetail.SNR_WAIT;
                        SendMsg(clientSoc, msgReturn);
                        
                        //MsgMode.FILE_LSN_SVR_REQ://case 25: 대기명령 to 수신자(listener생성요청) mode|전송자id|수신자id|
                        Socket soc = (Socket)mHtLoginTable[recvId];
                        if (soc != null) {
                            string msgStandby = MsgMode.FILE_LSN_SVR_REQ + MsgFmt.DELIM + senderId + MsgFmt.DELIM + recvId;
                            SendMsg(soc, msgStandby);
                        }
                        break;
                    case MsgMode.FILE_LSN_SVR_RES: //case 26: 오케응답 from 수신자(listener생성완료) mode|전송자id|수신자id|상태
                        re = msg.Split('|');
                        string senderId = re[1];
                        string recvId = re[2];
                        //MsgMode.FILE_STRT_SVR_REQ: //case 27: 파일전송명령 to 전송자. 수신자 없는 경우 서버전송->파일수신리스너 준비
                        
                        string msgReturn = MsgMode.FILE_STRT_SVR_REQ + MsgFmt.DELIM + senderId + MsgFmt.DELIM + recvId;
                        SendMsg(clientSoc, msgReturn);
                        break;
                    
                    case MsgMode.FILE_STRT_SVR_RES: //case 28: 전송명령확인 from 전송자. 프로세스끝,
                        re = msg.Split('|');
                        string senderId = re[1];
                        string recvId = re[2];
                        //logging
                        break;
                    case MsgMode.FILE_STRT_SNR_REQ: //case 29: 파일전송시작 from 전송자
                        re = msg.Split('|');
                        string senderId = re[1];
                        string recvId = re[2];
                        //logging
                        //파일수신 소켓이 처리할 내용
                        //MsgMode.FILE_STRT_SNR_RES: //case 29: 전송시작확인 from 수신자(서버 or 메신저)
                        break;
                    case MsgMode.FILE_STRT_END_REQ: //case 29: 파일전송종료 from 전송자
                        re = msg.Split('|');
                        string senderId = re[1];
                        string recvId = re[2];
                        //logging
                        //파일수신 소켓이 처리할 내용
                        //MsgMode.FILE_STRT_END_RES: //case 29: 전송종료확인 from 수신자(서버 or 메신저)
                        break;
                    default:

                        logWrite("잘못된 요청 코드 입니다. : " + mode.ToString());
                        break;
                }
            }
            catch (Exception exception)
            {
                logWrite(exception.ToString());
            }
        }

    }

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

}
