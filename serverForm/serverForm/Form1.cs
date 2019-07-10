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
    public partial class Form1 : Form
    {
        

        static byte[] Buffer { get; set; }
        static Socket sck;

        public Form1()
        {
            InitializeComponent();
        }

        public void TCPServer()
        {

            //-------------------------------------------------------------------------------------------------------------------------- 다른 방식.ㅁㄴㅇㄻㄴㅇㄹ

            // sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // sck.Bind(new IPEndPoint(IPAddress.Any, 7000));
            // sck.Listen(100);
            //
            // Socket accepted = sck.Accept();
            //
            // Buffer = new byte[accepted.SendBufferSize];
            // int bytesRead = accepted.Receive(Buffer);
            // byte[] formatted = new byte[bytesRead];
            // for (int i = 0; i < bytesRead; ++i)
            // {
            //     formatted[i] = Buffer[i];
            // }
            //
            // string strdata = Encoding.UTF8.GetString(formatted);
            //
            // textBox1.AppendText(strdata + "\r\n");
            // //Console.Write(strdata + "\r\n");
            // //Console.Read();
            //
            // accepted.Close();
            // sck.Close();

            //-------------------------------------------------------------------------asdfasdfasdfaaaSSSSSS

            TcpListener tcpListener = null;
            Socket joinSocket = null;
            Socket clientsocket = null;

            try
            {
                //IP주소를 나타내는 객체를 생성,TcpListener를 생성시 인자로 사용할려고
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                //TcpListener Class를 이용하여 클라이언트의 연결을 받아 들인다. 
                //tcpListener = new TcpListener(ipAd, 7000);
                //방화벽 실험
                tcpListener = new TcpListener(IPAddress.Any, 7000);
                tcpListener.Start();


                //Client의 접속이 올때 까지 Block 되는 부분, 대개 이부분을 Thread로 만들어 보내 버린다. 
                //백그라운드 Thread에 처리를 맡긴다. 
                while (true)
                {
                    clientsocket = tcpListener.AcceptSocket();

                    ClientListen cHandler = new ClientListen(clientsocket);
                    Thread t = new Thread(new ThreadStart(cHandler.chat));//접속한 클라이언트를 쓰레드로 넘김.
                    t.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                clientsocket.Close();
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("가동중");
            TCPServer();
            
        }
    }

    class ClientListen // 접속한 클라이언트 를 연결해주기위한 클레스.
    {
        int mem_num =0;
        Socket socket = null;
        NetworkStream stream = null;
        StreamReader reader = null;
        StreamWriter writer = null;


        public ClientListen(Socket socket) //접속한 클라이언트 소켓을 넣는 기능.
        {
            this.socket = socket;
        }



        public void chat() //각종 기능들 코딩할 공간.
        {
            string mem_num;//로그인 사원번호 받을 변수
            string firstQ;//최초신호받을 변수

            string streamStr;//실시간 메시지 받을 변수

            //클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다. 
            stream = new NetworkStream(socket);
            Encoding encode = Encoding.GetEncoding("utf-8");

            reader = new StreamReader(stream, encode);
            writer = new StreamWriter(stream, encode) { AutoFlush = true };
            

            try
            {
                //최초 신호 받아오기.
                firstQ = reader.ReadLine();

                if (firstQ == "회원가입")//회원가입을 한다는 신호가 왔을 경우
                {
                    makeMember_num mknum = new makeMember_num();//사원번호를 만들기위한 클레스 변수 선언.
                    TextDB joinDB = new TextDB();//회원가입 정보를 DB에 넣기위한 클레스 변수 선언.
                    memDB insertDB=new memDB(); 
                    //이름 비밀번호 직책 부서 입사년도 사원번호 세션 부재메시지 구독자

                    //가입할 회원 정보 받아옴.               //여기부터 오류남. 190705----------------------------------------------------------------------------------------------------
                    streamStr = reader.ReadLine();
                    //writer.WriteLine(streamStr);//정보 전송 디버깅 실험. (성공함)

                    string[] split = streamStr.Split(new String[] { "/" }, StringSplitOptions.None);// '/'를 기준으로 문자열을 나눠 배열에 저장함.

                    //split 디버깅 실험.(성공)
                    /*for(int i = 0; i < split.Length; i++)
                    {
                        streamStr += split[i];
                    }
                    writer.WriteLine(streamStr);
                    */

                    //정보 순서 : 이름,비밀번호,직책,부서,입사년도.
                    insertDB.mem_name = split[0];
                    insertDB.mem_password = split[1];
                    insertDB.mem_position = int.Parse(split[2]);
                    insertDB.mem_departmer = int.Parse(split[3]);
                    insertDB.mem_jobyear = int.Parse(split[4]);
                    insertDB.mem_number = mknum.mknum(insertDB.mem_jobyear.ToString(), insertDB.mem_departmer.ToString(), insertDB.mem_position.ToString());//사원번호 생성과 동시에 전달.

                    try//회원가입 성공
                    {
                        joinDB.insertJoin(insertDB);//회원가입 시도.
                        writer.WriteLine(insertDB.mem_number);
                    }
                    catch//회원가입 실패
                    {
                        writer.WriteLine("회원가입 실패 코드오류");
                    }

                    stream.Close();
                }
                else//로그인 했을경우
                {
                    mem_num = firstQ;
                    writer.WriteLine("로그인한 사원번호 : " + mem_num);
                }


                
                while (true)
                {
                    string str = reader.ReadLine(); //클라이언트한태 메시시 수신

                    /*  DB 연결실험.
                    TextDB testDB = new TextDB();
                    bool temp = testDB.selectName(str);
                    
                    if (temp)
                    {
                        writer.WriteLine("이름 존재함");
                    }
                    else
                    {
                        writer.WriteLine("이름 없음/연결 중지");
                        break;
                    }
                    */
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

}
