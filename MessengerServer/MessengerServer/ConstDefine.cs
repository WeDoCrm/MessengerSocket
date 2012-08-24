using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessengerServer
{
    class ConstDefine
    {
        public const string aaa = "";
    }

    class MsgMode
    {
        /** 
         * HEAD: CHAT, NOTI, LOG, MEMO, FILE */
        public const int CHAT_END = 0;              //case 0: //대화종료
        public const int NOTICE_LIST_REQ = 1;       //case 1: //공지사항 목록 요청(1|id)
        public const int LOG_FORCE_CLOSE = 2;       //case 2: //중복 로그인 상황에서 기존접속 끊기 선택한 경우
        public const int LOG_CHECK_STATUS = 3;      //case 3: //사용자 로그인 상태 체크요청(코드번호|id)
        public const int MEMO_SAVE  = 4;            //case 4: //메모 처리
        public const int NOTICE_SEND_REQ = 6;       //case 6: //공지사항 전달(6|메시지|발신자id | n 또는 e | noticetime | 제목)  n : 일반공지 , e : 긴급공지
        public const int MEMO_UNREAD_REQ = 7;       //case 7: //안읽은 메모 요청
        public const int LOG_IN = 8;                //case 8: //로그인
        public const int LOG_OUT =9;                //case 9: //로그아웃             
        public const int NOTICE_UNREAD_REQ = 11;    //case 11: //안읽은 공지 요청(11|id)
        //public const int NOTICE_SEND_REQ = 13;      //case 13: //보낸 공지 리스트 요청
        public const int NOTICE_DEL_READ_REQ = 14;  //case 14: //읽은 정보 삭제 요청(14|seqnum)
        public const int NOTICE_DEL_ADM_REQ = 15;   //case 15: //관리자 공지 삭제(15|seqnum;seqnum;seqnum;...)
        public const int CHAT_SEND_MSG = 16;        //case 16: //채팅메시지 전달(16|Formkey|id/id/..|발신자name|메시지 ) 구분자 : |(pipe) 
        public const int LOG_SEND_NEW_LIST = 17;    //case 17: //추가한 상담원 리스트 기존 대화자에게 전송 (17|formkey|id/id/...|name|receiverID)
        public const int CHAT_FORM_CLOSE   = 18;    //case 18: //2명 이상과 대화중 폼을 닫은 경우(q|Formkey|id|receiverID) 
        public const int MEMO_SEND_REQ     = 19;    //case 19: //쪽지 전송요청(m|recName|recID|content|senderID);
        public const int LOG_SEND_STATUS   = 20;    //case 20: //상태변경 알림(20|senderid|상태값)
        public const int NOTICE_SEND_CHECK = 21;    //case 21: //공지 읽음 확인 메시지(21 | receiverid | notice id | sender id)
        public const int LOG_SEND_CUSTOMER = 22;    //case 22: //고객정보 전달시도(22&ani&senderID&receiverID)

        public const int FILE_RCV   = 5;            //case 5: //파일 전송 메시지(5|파일명|파일크기|파일타임키|전송자id|수신자id;id;id...
        public const int FILE_UNRCV_REQ = 10;       //case 10: //안받은 파일 요청
        public const int FILE_SEND_REQ = 12;        //case 12: //파일 전송 요청


        public const int FILE_SND_SNR_REQ  = 23;    //case 23: 파일 전송 요청
        public const int FILE_SND_SNR_RES  = 24;    //case 24: 전송요청 확인. 대기명령
        public const int FILE_LSN_SVR_REQ  = 25;    //case 25: 대기명령 to 수신자(listener생성요청)
        public const int FILE_LSN_SVR_RES  = 26;    //case 26: 오케응답 from 수신자(listener생성완료)./' |`1
        public const int FILE_STRT_SVR_REQ = 27;    //case 27: 파일전송명령 to 전송자. 수신자 없는 경우 서버전송->파일수신리스너 준비
        public const int FILE_STRT_SVR_RES = 28;    //case 28: 전송명령확인 from 전송자. 프로세스끝,
        public const int FILE_STRT_SNR_REQ = 29;    //case 29: 파일전송시작 from 전송자
        public const int FILE_STRT_SNR_RES = 30;    //case 29: 전송시작확인 from 수신자(서버 or 메신저)
        public const int FILE_STRT_END_REQ = 31;    //case 29: 파일전송종료 from 전송자
        public const int FILE_STRT_END_RES = 32;    //case 29: 전송종료확인 from 수신자(서버 or 메신저)

        
        public const int FILE_LISTEN_RES = 24;      //case 24: 오케응답 from 수신자(listener생성완료)
        
        //public const int FILE_LISTEN_RES = 24;      //case 24: 오케응답 from 수신자(listener생성완료)
        public const int FILE_SEND_TO_SENDER = 25;
        /* 
         * 1. 파일 전송 요청
         *  1-0. 요청확인, 전송자에 대기명령
         *  1-1. 파일 수신자 확인
         *  1-2. 대기명령 to 수신자(listener생성요청)
         *  1-3. 수신자 없는 경우 에러리턴
         * 2. 오케응답 from 수신자(listener생성완료)
         *   -- 파일수신명령완료 수신자와의 작업 끝!)
         * 3. 파일전송명령 to 전송자
         * 4. 파일전송시작 from 전송자 (전송자와의 작업 끝!) 
         */

    }

    class MsgFmt
    {
        public const string DELIM = "|";
    }

    class MsgDetail
    {
        public const string SNR_WAIT = "SNR_WAIT";
        public const string RCV_FILE_LSN = "FILE_LSN";
        public const string FROM_TO = "F|{0}|T{1}";
    }

}
