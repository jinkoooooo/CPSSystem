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

            //-------------------------------------------------------------------------------------------------------------------------- 다른 방식.

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

            //-------------------------------------------------------------------------

            TcpListener tcpListener = null;
            Socket joinSocket = null;
            Socket clientsocket = null;

            try
            {
                //IP주소를 나타내는 객체를 생성,TcpListener를 생성시 인자로 사용할려고
                IPAddress ipAd = IPAddress.Parse("127.0.0.1");

                //TcpListener Class를 이용하여 클라이언트의 연결을 받아 들인다. 
                tcpListener = new TcpListener(ipAd, 7000);
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
            string mem_num;
            //클라이언트의 데이터를 읽고, 쓰기 위한 스트림을 만든다. 
            stream = new NetworkStream(socket);
            Encoding encode = Encoding.GetEncoding("utf-8");

            reader = new StreamReader(stream, encode);
            writer = new StreamWriter(stream, encode) { AutoFlush = true };
            

            try
            {
                //로그인 접속 사원번호 받아오기
                mem_num = reader.ReadLine();//접속한 클라이언트의 사원번호 넣을 변수
                writer.WriteLine("로그인한 사원번호 : " + mem_num);
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
