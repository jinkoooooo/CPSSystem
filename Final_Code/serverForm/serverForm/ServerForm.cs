using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;

namespace serverForm
{

    public partial class ServerForm : Form
    {
        delegate void SetTextCallback(string text);//invoke 기능시 사용.

        public static string SocketPort { get; set; }
        public static string DBPort { get; set; }
        public static string User { get; set; }
        public static string Schema { get; set; }
        public static string Passwd { get; set; }



        public ServerForm()
        {
            InitializeComponent();
        }

        Thread server = null;
        Thread serverlog = null;
        Thread t = null;
        Thread sortT = null;
        Thread pingT = null;


        public int ms_cnt = 0;//메시지DB 삭제를 위한 메시지전송 카운트.

        TcpListener tcpListener = null;

        public void TCPServer()
        {
            

            Socket clientsocket = null;
            Socket clientSortsocket = null;
            Socket pingSocket = null;

            MyVariables.end_flag = false;// 전체적인 흐름을 한번에 종료시키기 위한 플레그.


            MyVariables.mem_cnt = 0;



            try
            {
                //IP주소를 나타내는 객체를 생성,TcpListener를 생성시 인자로 사용할려고
                //IPAddress ipAd = IPAddress.Parse("127.0.0.1"); // 각자 개인작업 할때는 localhost로 바꿔서 코딩할것(다른파일포함).!필수!@@@@~!~!@!@!@!@!@!@

                //TcpListener Class를 이용하여 클라이언트의 연결을 받아 들인다. 
                tcpListener = new TcpListener(IPAddress.Any, int.Parse(ServerForm.SocketPort));
                tcpListener.Start();


                server = new Thread(new ThreadStart(count_mem));
                server.Start();

                serverlog = new Thread(new ThreadStart(logout_mem));//로그아웃 테스트!!!!!!!!!!!!!!!!
                serverlog.Start();


                //Client의 접속이 올때 까지 Block 되는 부분, 대개 이부분을 Thread로 만들어 보내 버린다. 
                //백그라운드 Thread에 처리를 맡긴다. 
                while (true)
                {

                    clientsocket = tcpListener.AcceptSocket();

                    clientSortsocket = tcpListener.AcceptSocket();

                    pingSocket = tcpListener.AcceptSocket();

                    if (MyVariables.end_flag)
                    {
                        break;//모든 흐름 종료하기위한 플레그
                    }

                    ClientListen cHandler = new ClientListen(clientsocket, clientSortsocket, pingSocket);

                    t = new Thread(new ThreadStart(cHandler.chat));//접속한 클라이언트를 쓰레드로 넘김.
                    t.Start();
                    sortT = new Thread(new ThreadStart(cHandler.sorter));//접속한 클라이언트를 쓰레드로 넘김.
                    sortT.Start();
                    pingT = new Thread(new ThreadStart(cHandler.pingging));//접속한 클라이언트를 쓰레드로 넘김.
                    pingT.Start();
                }
            }
            catch (Exception e)
            {
                if (btnServerStart.Visible == true)
                {
                    MessageBox.Show("서버를 종료합니다.");
                }
                else
                {
                    MessageBox.Show("서버 설정을 확인해 주세요.");
                }
            }


        }



        public void count_mem()
        {
            try
            {
                while (true)
                {
                    if (MyVariables.temp_number != null)
                    {

                        this.SetText(MyVariables.temp_number + " 님이 접속하였습니다.");
                        this.SetText("현재 접속자 수 : " + MyVariables.mem_cnt);

                        MyVariables.temp_number = null;
                    }

                    if (MyVariables.join_member != null)
                    {
                        this.SetText(MyVariables.join_member + " 님이 회원가입 하셨습니다.");
                        MyVariables.join_member = null;
                    }

                    if (MyVariables.end_flag)
                    {
                        break;//모든 흐름 종료하기위한 플레그
                    }
                }
            }
            catch
            {
                this.SetText("접속 오류");
            }
            
        }

        public void logout_mem()
        {
            while (true)
            {
                if (MyVariables.logout_number != null)
                {
                    try
                    {
                        this.SetText(MyVariables.logout_number + " 님이 로그아웃 하였습니다.");
                        this.SetText("현재 접속자 수 : " + MyVariables.mem_cnt);
                    }
                    catch
                    {
                        this.SetText("접속 오류");
                    }
                    MyVariables.logout_number = null;
                }

                if (MyVariables.end_flag)
                {
                    break;//모든 흐름 종료하기위한 플레그
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //서버 설정 기본값
            SocketPort = "7000";
            DBPort = "3306";
            User = "root";
            Schema = "testbase";
            Passwd = "inhatc";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            btnSEdit.Enabled = false;
            lblServer.Text = "서버 가동중";
            btnServerStart.Visible = false;
            btnServerStop.Visible = true;
            

            Thread server = new Thread(new ThreadStart(TCPServer));//접속한 클라이언트를 쓰레드로 넘김.
            server.Start();
            

        }


        public void SetText(string text)//invoke 기능으로 백그라운드 쓰레드에서의 UI 변경권한을 줌
        {
            try
            {
                if (this.txtServer.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txtServer.AppendText(text);
                    this.txtServer.AppendText("\r\n");
                }
            }
            catch
            {
                //예외상황 : 로그아웃 시 백업은 계속 돌아감.
            }

        }

        private void BtnServerStop_Click(object sender, EventArgs e)
        {
            try
            {
                btnServerStart.Visible = true;

                MyVariables.end_flag = true;
                lblServer.Text = "서버 중지됨";
                if (tcpListener != null)
                {
                    tcpListener.Stop();
                }


                btnServerStop.Visible = false;


                server.Abort();
                serverlog.Abort();
                if (t != null)
                {
                    t.Abort();
                }

                if (sortT != null)
                {
                    sortT.Abort();
                }

                if (pingT != null)
                {
                    pingT.Abort();
                }
            }
            catch
            {
                MessageBox.Show("서버가 종료 됩니다.");
            }


            

            this.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            ServerEdit frm = new ServerEdit();
            frm.Show();
        }
    }


    public static class MyVariables
    {
        public static int mem_cnt { get; set; }//현재 접속자 수 카운트변수

        public static string temp_number { get; set; }//접속회원 넘버를 잠깐 넣기위한 변수.

        public static string join_member { get; set; }

        public static string logout_number { get; set; }

        public static bool end_flag { get; set; }
    }




    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------




    class ClientListen // 접속한 클라이언트 를 연결해주기위한 클레스.
    {
        public string mem_num { get; set; }//로그인 사원번호 받을 변수

        
        Socket socket = null;

        NetworkStream stream = null;
        StreamReader reader = null;
        StreamWriter writer = null;

        //sort 실험
        Socket sortSocket = null;
        NetworkStream sortStream = null;
        StreamReader sortReader = null;
        StreamWriter sortWriter = null;

        //ping 실험
        Socket pingSocket = null;
        NetworkStream pingStream = null;
        StreamReader pingReader = null;
        StreamWriter pingWriter = null;
        

        public void socket_close(string socketName)
        {
            switch (socketName)
            {
                case "socket":
                    socket.Close();
                    sortSocket.Close();
                    pingSocket.Close();

                    stream.Close();
                    reader.Close();
                    writer.Close();
                    break;

                case "sortSocket":
                    socket.Close();
                    sortSocket.Close();
                    pingSocket.Close();

                    sortStream.Close();
                    sortReader.Close();
                    sortWriter.Close();
                    break;

                case "pingSocket":
                    socket.Close();
                    sortSocket.Close();
                    pingSocket.Close();

                    pingStream.Close();
                    pingReader.Close();
                    pingWriter.Close();
                    break;
            }
        }


        public ClientListen(Socket a, Socket b, Socket c)
        {
            this.socket = a;
            this.sortSocket = b;
            this.pingSocket = c;
        }

        public ClientListen(Socket a, Socket b)
        {
            this.socket = a;
            this.sortSocket = b;

        }

        public ClientListen(int i, Socket socket) //접속한 클라이언트 소켓을 넣는 기능.
        {
            if (i == 1)
            {
                this.socket = socket;
            }
            else if (i == 2)
            {
                this.sortSocket = socket;//실험.(성공)
            }
            else if (i == 3)
            {
                this.pingSocket = socket;
            }

        }

        public void pingging()
        {


            //클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다. 
            pingStream = new NetworkStream(pingSocket); ///오류남.
            Encoding encode = Encoding.GetEncoding("utf-8");

            pingReader = new StreamReader(pingStream, encode);
            pingWriter = new StreamWriter(pingStream, encode) { AutoFlush = true };

            try
            {
                string firstQ = pingReader.ReadLine();

                if (firstQ != "회원가입")
                {
                    while (true)
                    {
                        pingWriter.WriteLine("ping Test");
                        Thread.Sleep(1000);

                        if (MyVariables.end_flag)
                        {
                            break;//모든 흐름 종료하기위한 플레그
                        }
                    }
                    socket_close("pingSocket");
                }       
            }
            catch
            {
                MyVariables.logout_number = mem_num;
                MyVariables.mem_cnt--;
                socket_close("pingSocket");
            }
        }


        public void chat() //각종 기능들 코딩할 공간.--------------------------------------------------------------------------------
        {
            bool joinQ = false;//회원가입시 플레그

            MessageDB msDB = new MessageDB();


            string firstQ;//최초신호받을 변수
            //MessageDB msDB=new MessageDB();
            string streamStr;//실시간 메시지 받을 변수

            
            //클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다. 
            stream = new NetworkStream(socket);
            Encoding encode = Encoding.GetEncoding("utf-8");

            reader = new StreamReader(stream, encode);
            writer = new StreamWriter(stream, encode) { AutoFlush = true };
            

            try
            {
                while (true)
                {
                    //최초 신호 받아오기.
                    firstQ = reader.ReadLine();

                    if (firstQ == "회원가입")//회원가입을 한다는 신호가 왔을 경우
                    {
                        makeMember_num mknum = new makeMember_num();//사원번호를 만들기위한 클레스 변수 선언.
                        mapperDB joinDB = new mapperDB();//회원가입 정보를 DB에 넣기위한 클레스 변수 선언.
                        memDB insertDB = new memDB();
                        //이름 비밀번호 직책 부서 입사년도 사원번호 세션 부재메시지 구독자

                        while (true)
                        {
                            streamStr = reader.ReadLine();


                            string[] split = streamStr.Split(new String[] { "/" }, StringSplitOptions.None);// '/'를 기준으로 문자열을 나눠 배열에 저장함.

                            if (split[0] == "")
                            {
                                writer.WriteLine("이름오류");
                                //처리
                                continue;
                            }
                            else
                            {
                                insertDB.mem_name = split[0];

                                if (split[1] == "")
                                {
                                    writer.WriteLine("비밀번호를 넣어주세요");
                                    continue;

                                }
                                else
                                {
                                    insertDB.mem_password = split[1];

                                    if (split[2] == "")
                                    {
                                        writer.WriteLine("직책을 넣어주세요");
                                        //처리
                                        continue;
                                    }
                                    else
                                    {
                                        insertDB.mem_position = split[2];

                                        if (split[3] == "")
                                        {
                                            writer.WriteLine("부서을 넣어주세요");
                                            //처리
                                            continue;
                                        }
                                        else
                                        {
                                            insertDB.mem_department = split[3];

                                            if (split[4] == "")
                                            {
                                                writer.WriteLine("입사년도");
                                                //처리
                                                continue;
                                            }
                                            else
                                            {
                                                insertDB.mem_jobyear = int.Parse(split[4]);
                                                insertDB.mem_number = mknum.mknum(insertDB.mem_jobyear.ToString(), insertDB.mem_department.ToString(), insertDB.mem_position.ToString());//사원번호 생성과 동시에 전달.

                                                try//회원가입 성공
                                                {
                                                    joinDB.insertJoin(insertDB);//회원가입 시도.
                                                    writer.WriteLine("성공");
                                                    writer.WriteLine(insertDB.mem_number);
                                                    MyVariables.join_member = insertDB.mem_name+"("+insertDB.mem_number+")";
                                                }
                                                catch//회원가입 실패
                                                {
                                                    writer.WriteLine("회원가입 실패 코드오류");
                                                }

                                                stream.Close();
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }


                        //stream.Close();
                        socket_close("socket");//실험
                        joinQ = true;
                    }
                    else if (firstQ == "로그인")
                    { //로그인 한다는 신호가 왔을 경우


                        memDB selectDB = new memDB();
                        mapperDB login = new mapperDB();// 로그인 정보를 DB에서 가져오기 위한 클레스 변수 선언.

                        //로그인 할 정보를 받아옴
                        streamStr = reader.ReadLine();

                        // '/'이거 기준으로 스플릿. selectDB.사원번호 / 비번 <= 가져온거 집어넣기
                        string[] split = streamStr.Split(new String[] { "/" }, StringSplitOptions.None);

                        selectDB.mem_number = split[0];
                        selectDB.mem_password = split[1];

                        try//로그인 성공
                        {
                            bool log_check = login.selectlogin(selectDB);//id 존재 유무 확인.
                            if (log_check)
                            {
                                writer.WriteLine("로그인 성공");
                                mem_num = split[0];
                                msDB.mem_num = mem_num;

                                MyVariables.temp_number = mem_num;//현재 접속한 사람.
                                MyVariables.mem_cnt++; //접속자 수 +1

                                break;
                            }
                            else
                            {
                                writer.WriteLine("다시 시도");
                                firstQ = reader.ReadLine();
                            }
                        }
                        catch//로그인 오류
                        {
                            writer.WriteLine("로그인 실패 코드오류");
                        }
                        //writer.WriteLine("로그인 완료");
                    }

                    if (MyVariables.end_flag)
                    {
                        break;//모든 흐름 종료하기위한 플레그
                    }
                }


                //-------------------------------------여기까지함.스트림을 크게 한개 더연결해야 할듯하다.(성공)


                while (true) //로그인 후 지속적인 stream 기능을 구현할 공간.//검색기능, 전송기능, 구독기능 등등
                {
                    if (MyVariables.end_flag)
                    {
                        break;//모든 흐름 종료하기위한 플레그
                    }

                    if (joinQ)
                    {
                        break;
                    }


                    string str = reader.ReadLine(); //클라이언트한태 메시시 수신
                    string[] split = str.Split(new String[] { "/" }, StringSplitOptions.None);
                    //0: 신호 , 1: 메시지 내용

                    if (split[0] == "전송")
                    {

                        msDB.insertMessage(split[1]);//전송받은 내용을 사원번호, 시간, 내용, 구독자수 로 구성하여 repository DB에넣음.
                        writer.WriteLine("성공");

                    }
                    else if (str == "검색")
                    {

                        List<string> getsublist = new List<string>();
                        string listData = "";

                        //검색기능
                        mapperDB searchDB = new mapperDB();//회원가입 정보를 DB에 넣기위한 클레스 변수 선언.


                        // 입력값 받아옴
                        string getName = reader.ReadLine();
                        string getPosition = reader.ReadLine();
                        string getDeaprtment = reader.ReadLine();

                        try
                        {
                            // 검색함수 돌려서 나온값 넣기
                            getsublist = searchDB.selectSearchName(getName, getPosition, getDeaprtment);
                            for (int i = 0; i < getsublist.Count; i++)
                            {
                                listData += getsublist[i];
                                // listData라는 변수에 리스트값을 다 더해서 넣어버림
                            }
                            writer.WriteLine(listData);
                            // listData 클라이언트쪽으로 반환
                        }
                        catch
                        {
                            writer.WriteLine("실패 코드오류");
                        }

                    }
                    else if (str == "구독취소")
                    {
                        string getCheckData = "";
                        string getMemNumber = mem_num;
                        List<string> sucessCheck = new List<string>();
                        string listData = "";
                        mapperDB subDB = new mapperDB();
                        memDB selectDB = new memDB();
                        getCheckData = reader.ReadLine();
                        try
                        {
                            sucessCheck = subDB.Findthendelete(getCheckData, getMemNumber);
                            for (int i = 0; i < sucessCheck.Count; i++)
                            {
                                listData += sucessCheck[i];
                                // listData라는 변수에 리스트값을 다 더해서 넣어버림
                            }
                            writer.WriteLine(listData);
                            // listData 클라이언트쪽으로 반환
                        }
                        catch
                        {
                            writer.WriteLine("실패 코드오류");
                        }
                    }
                    else if (str == "구독")
                    {
                        string getCheckData = "";
                        string getMemNumber = mem_num;
                        List<string> sucessCheck = new List<string>();
                        string listData = "";
                        mapperDB subDB = new mapperDB();
                        memDB selectDB = new memDB();
                        getCheckData = reader.ReadLine();
                        try
                        {
                            sucessCheck = subDB.insertSub(getCheckData, getMemNumber);
                            for (int i = 0; i < sucessCheck.Count; i++)
                            {
                                listData += sucessCheck[i];
                                // listData라는 변수에 리스트값을 다 더해서 넣어버림
                            }
                            writer.WriteLine(listData);
                            // listData 클라이언트쪽으로 반환
                        }
                        catch
                        {
                            writer.WriteLine("");
                        }
                    }

                    else if (str == "로그인구독목록")
                    {
                        string getNumber = reader.ReadLine();
                        string listData = "";
                        mapperDB putDataToListDB = new mapperDB();
                        List<string> getsubedlist = new List<string>();
                        try
                        {
                            getsubedlist = putDataToListDB.LoadFormPutData(getNumber);
                            for (int i = 0; i < getsubedlist.Count; i++)
                            {
                                listData += getsubedlist[i];
                                // listData라는 변수에 리스트값을 다 더해서 넣어버림
                            }
                            writer.WriteLine(listData);
                            // listData 클라이언트쪽으로 반환
                        }
                        catch
                        {
                            writer.WriteLine("실패 코드오류");
                        }
                    }
                    else
                    {
                        writer.WriteLine("실패");//테스트 디버깅
                    }
                }
                socket_close("socket");
            }
            catch (Exception e)
            {
                socket_close("socket");
            }
        }

        public void sorter()//실험(성공)
        {

            try
            {
                sortStream = new NetworkStream(sortSocket);
                Encoding encode = Encoding.GetEncoding("utf-8");

                sortReader = new StreamReader(sortStream, encode);
                sortWriter = new StreamWriter(sortStream, encode) { AutoFlush = true };

                string num = sortReader.ReadLine();


                mem_num = num;

                MessageDB msDB = new MessageDB();
                msDB.mem_num = mem_num;
                //msDB.mem_num = MyVariables.mem_num;//불러올 메시지 사원번호


                string sortQ = sortReader.ReadLine();
                while (true)//솔팅 성공.!(회원 세션 구현해야함.)
                {
                    if (MyVariables.end_flag)
                    {
                        break;//모든 흐름 종료하기위한 플레그
                    }

                    if (num == "회원가입")//회원가입시 sorter 기능 중지.
                    {
                        break;
                    }
                    if(sortQ== "부재메시지 가져와")
                    {
                        //부재메시지 보냄.
                        //부재메시지 보냄.
                        //부재메시지 보냄.
                        if (msDB.searchMessage())
                        {
                            List<string> dataMs = msDB.readMessage();
                            string lastMs = "";
                            for (int i = 0; i < dataMs.Count; i++)
                            {
                                lastMs += dataMs[i]+"/";//메시지 수신
                            }

                            sortWriter.WriteLine(lastMs);//부재메시지묶음 보냄.

                            msDB.deleteMessage();
                            sortQ = "이제 메시지 가져와";
                        }
                        else
                        {
                            sortQ = "이제 메시지 가져와";
                            string lastNull = "0";
                            sortWriter.WriteLine(lastNull);
                        }
                    }
                    else//아니면 그냥 메시지 확인 루트 돌림.
                    {

                        bool check = msDB.searchMessage();
                        if (check)
                        {
                            List<string> dataMs = msDB.readMessage();

                            for (int i = 0; i < dataMs.Count; i++)
                            {
                                sortWriter.WriteLine(dataMs[i]);//메시지 수신
                            }
                            msDB.deleteMessage();
                            Thread.Sleep(1000);
                        }
                    }
                }
                socket_close("sortSocket");
            }
            catch (Exception e)
            {
                //MyVariables.logout_number = mem_num;
                //MyVariables.mem_cnt--;
                socket_close("sortSocket");

            }
        }
    }

}
