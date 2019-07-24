using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace cpssystem
{
    public partial class FormMain : Form
    {
        delegate void SetTextCallback(string text);

        public static string cmbStrCheck { get; set; }


        public FormMain()
        {
            InitializeComponent();
            //콤보박스에 아이템 추가
            cmbPositions.Items.Add("사원");
            cmbPositions.Items.Add("선임");
            cmbPositions.Items.Add("책임");
            cmbPositions.Items.Add("사장");
            cmbDepartments.Items.Add("영업팀");
            cmbDepartments.Items.Add("개발팀");
            cmbDepartments.Items.Add("본부팀");
            cmbDepartments.Items.Add("설비팀");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lblmessage3_Click(object sender, EventArgs e)
        {

        }

        private void Btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                // 메시지 전송 버튼 클릭시       /// 소켓 연결을 크게 두개 연결해야할것 같음.
                writer.WriteLine("전송/" + txtsendbox.Text.ToString());


                string q = reader.ReadLine();
                if (q == "성공")
                {
                    MessageBox.Show("전송 성공하였습니다.");
                }
                else
                {
                    MessageBox.Show("전송 실패하였습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버와 연결이 끊어졌습니다. 다시 로그인 해주세요.");
                this.Close();
            }
            
            
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                sublistbox.Items.Clear();

                string btnSignal = "검색";
                writer.WriteLine(btnSignal);

                string searchName = txtNames.Text.ToString();
                string searchPosition = cmbPositions.Text.ToString();
                string searchDepartment = cmbDepartments.Text.ToString();
                string revSearch = null;

                //입력한 검색정보 보냄
                writer.WriteLine(searchName);
                writer.WriteLine(searchPosition);
                writer.WriteLine(searchDepartment);

                //서버에서 listData 반환
                revSearch = reader.ReadLine();

                if (revSearch != null)
                {
                    // listData값 ]기호로 나눠서 구독 리스트박스에 띄움
                    string[] split = revSearch.Split(new String[] { "]" }, StringSplitOptions.None);
                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        sublistbox.Items.Add(split[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("서버와 연결이 끊어졌습니다. 다시 로그인 해주세요.");
                this.Close();
            }
            
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try

            {
                //LocalHost에 지정 포트로 TCP Connection을 생성하고 데이터를 송수신 하기
                //위한 스트림을 얻는다. 
                client = new TcpClient();
                client.Connect(FormLogin.ServerIPv4, int.Parse(FormLogin.ServerPort));

                stream = client.GetStream();

                reader = new StreamReader(stream, encode);
                writer = new StreamWriter(stream, encode)
                { AutoFlush = true };



                //sort 스트림
                sortClient = new TcpClient();
                sortClient.Connect(FormLogin.ServerIPv4, int.Parse(FormLogin.ServerPort));

                sortStream = sortClient.GetStream();

                sortReader = new StreamReader(sortStream, encode);
                sortWriter = new StreamWriter(sortStream, encode) { AutoFlush = true };

                
                //ping 스트림
                pingClient = new TcpClient();
                pingClient.Connect(FormLogin.ServerIPv4, int.Parse(FormLogin.ServerPort));

                pingStream = pingClient.GetStream();

                pingReader = new StreamReader(pingStream, encode);
                pingWriter = new StreamWriter(pingStream, encode) { AutoFlush = true };
                


                //로그인 할것이라는 신호를 서버로 보냄.
                string dataToSend = "로그인";

                

                writer.WriteLine(dataToSend);

                string sendLogin = "";//보낼 로그인 정보를 넣을 변수
                string recvLogin = null;//로그인 성공여부를 받을 변수

                sendLogin += FormLogin.id + "/";
                sendLogin += FormLogin.pw;

                //입력한 사원번호와 비번를 보낸다.
                writer.WriteLine(sendLogin);

                //로그인 성공여부에 대한 응답을 받는다.
                recvLogin = reader.ReadLine();


                if (recvLogin == "로그인 성공")
                {

                    MessageBox.Show(recvLogin);

                    txtsendbox.AppendText("로그인 한 사원번호 : "+ FormLogin.id);
                    btnsend.Visible = true;

                    string btnSignal = "로그인구독목록";
                    writer.WriteLine(btnSignal);
                    writer.WriteLine(FormLogin.id);
                    //서버에서 listData 반환
                    string revSearch = reader.ReadLine();

                    if (revSearch != null)
                    {
                        // listData값 ]기호로 나눠서 구독 리스트박스에 띄움
                        string[] split = revSearch.Split(new String[] { "]" }, StringSplitOptions.None);
                        for (int i = 0; i < split.Length - 1; i++)
                        {
                            subedlistbox.Items.Add(split[i]);

                        }
                    }

                    sortWriter.WriteLine(FormLogin.id);//로그인 성공시 sorter에 로그인 한 사원번호 보냄.

                    pingWriter.WriteLine("로그인");//로그인 성공시 pingging에 로그인신호를 보냄.

                    Thread t = new Thread(new ThreadStart(recvMessage));//쓰레드 실험
                    t.Start();


                    /*
                    Thread pingT = new Thread(new ThreadStart(pingging));//접속한 클라이언트를 쓰레드로 넘김.
                    pingT.Start();*/
                }
                else
                {
                    MessageBox.Show(recvLogin);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                txtpostbox.AppendText("연결 실패. 서버 or 통신설정을 확인하세요.");
                Console.WriteLine(ex.ToString());
                client.Close();
            }
        }

        public void socket_close()
        {
            if (stream != null)
            {
                client.Close();
                sortClient.Close();
                pingClient.Close();

                stream.Close();
                sortStream.Close();
                pingStream.Close();

                reader.Close();
                sortReader.Close();
                pingReader.Close();

                writer.Close();
                sortWriter.Close();
                pingWriter.Close();
            }
            
        }


        private void pingging()
        {
            try
            {
                while (true)
                {
                    //pingReader.ReadLine();
                    pingWriter.WriteLine("ping Test");
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                MessageBox.Show("서버와 연결이 끊어졌습니다. 접속 종료 후 다시 로그인 해주세요.");
            }
        }


        TcpClient client = null;
        NetworkStream stream = null;
        StreamReader reader = null;
        StreamWriter writer = null;
        Encoding encode = Encoding.GetEncoding("utf-8");

        TcpClient sortClient = null;
        NetworkStream sortStream = null;
        StreamWriter sortWriter = null;
        StreamReader sortReader = null;

        TcpClient pingClient = null;
        NetworkStream pingStream = null;
        StreamWriter pingWriter = null;
        StreamReader pingReader = null;

        private void Txtleavemessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtpostbox_TextChanged(object sender, EventArgs e)
        {

        }

        public void recvMessage()
        {
            try
            {
                papagoAPI transStr = new papagoAPI();

                sortWriter.WriteLine("부재메시지 가져와");
                
                string lastMs = sortReader.ReadLine();
                string[] split = lastMs.Split(new String[] { "/" }, StringSplitOptions.None);
                if (lastMs != "0")
                {
                    for(int i=0; i < split.Length; i++)
                    {
                        this.SetText_last(split[i]);
                    }
                }

                //sortWriter.WriteLine("메시지 가져와");
                while (true)
                {
                    //sortWriter.WriteLine("메시지 가져와");

                    string postMs = sortReader.ReadLine();

                    
                    if (FormMain.cmbStrCheck == "영어")
                    {
                        postMs = transStr.transStr(postMs,"en");
                    }
                    else if (FormMain.cmbStrCheck == "일본어")
                    {
                        postMs = transStr.transStr(postMs, "ja");
                    }
                    else if (FormMain.cmbStrCheck == "중국어(간체)")
                    {
                        postMs = transStr.transStr(postMs, "zh-CN");
                    }
                    else if (FormMain.cmbStrCheck == "중국어(번체)")
                    {
                        postMs = transStr.transStr(postMs, "zh-TW");
                    }


                    this.SetText(postMs);

                    Thread.Sleep(1000);
                }
            }
            catch(Exception e)
            {
                this.SetText("수신error");
            }    
        }

        private void SetText(string text)//invoke 기능으로 백그라운드 쓰레드에서의 UI 변경권한을 줌
        {
            try
            {
                if (this.txtpostbox.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txtpostbox.AppendText(text);
                    this.txtpostbox.AppendText("\r\n");
                }
            }
            catch
            {
                //예외상황 : 로그아웃 시 백업은 계속 돌아감.
            }
            
        }

        private void SetText_last(string text)//invoke 기능으로 백그라운드 쓰레드에서의 UI 변경권한을 줌
        {
            try
            {
                if (this.txtleavemessage.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText_last);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txtleavemessage.AppendText(text);
                    this.txtleavemessage.AppendText("\r\n");
                }
            }
            catch
            {
                //예외상황 : 로그아웃 시 백업은 계속 돌아감.
            }

        }



        public List<string> strArr = new List<string>();

        private void Btnsub_Click(object sender, EventArgs e)
        {
            // 구독 버튼 클릭시
            try
            {
                string btnSignal = "구독";
                writer.WriteLine(btnSignal); // 구독신호보내기

                int size = sublistbox.Items.Count; // 체크리스트박스 카운트
                string checklistData = ""; // 체크리스트 아이템 담을 변수 생성
                for (int i = 0; i < size; i++) // for문돌려서 아이템을 ]기호로 구분하여 합침
                {
                    if (sublistbox.GetItemChecked(i))
                    {
                        checklistData += sublistbox.Items[i] + "]";
                    }
                }

                writer.WriteLine(checklistData); // 체크리스트 아이템값 합친거 보내기

                string revSubscribe = reader.ReadLine();  // 구독되었는지 확인하는 변수

                if (revSubscribe != "")
                {
                    // listData값 ]기호로 나눠서 구독 리스트박스에 띄움
                    string[] split = revSubscribe.Split(new String[] { "]" }, StringSplitOptions.None);
                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        subedlistbox.Items.Add(split[i]);
                    }
                    MessageBox.Show("구독되었습니다");
                }
                else
                {
                    MessageBox.Show("이미 구독중인 항목이 있습니다. (구독 실패)");
                }
            }
            catch
            {
                MessageBox.Show("서버와 연결이 끊어졌습니다. 다시 로그인 해주세요.");
                this.Close();
            }
            
        }

        private void Btnserver_Click(object sender, EventArgs e)
        {
            socket_close();
            this.Close();
        }

        private void Btnsubcancle_Click(object sender, EventArgs e)
        {
            //구독취소버튼 누르면
            try
            {
                string btnSignal = "구독취소";
                writer.WriteLine(btnSignal); // 구독신호보내기

                int size = subedlistbox.Items.Count; // 체크리스트박스 카운트
                string checklistData = ""; // 체크리스트 아이템 담을 변수 생성
                for (int i = 0; i < size; i++) // for문돌려서 아이템을 ]기호로 구분하여 합침
                {
                    if (subedlistbox.GetItemChecked(i))
                    {
                        checklistData += subedlistbox.Items[i] + "]";
                    }
                }

                writer.WriteLine(checklistData); // 체크리스트 아이템값 합친거 보내기

                string revSubscribe = reader.ReadLine();  // 구독되었는지 확인하는 변수

                if (revSubscribe != null)
                {
                    // listData값 ]기호로 나눠서 구독 리스트박스에 띄움

                    subedlistbox.Items.Clear();
                    string[] split = revSubscribe.Split(new String[] { "]" }, StringSplitOptions.None);
                    for (int i = 0; i < split.Length - 1; i++)
                    {
                        subedlistbox.Items.Add(split[i]);
                    }
                    MessageBox.Show("구독취소되었습니다");
                }
                else
                {
                    MessageBox.Show("구독취소 실패");
                }
            }
            catch
            {
                MessageBox.Show("서버와 연결이 끊어졌습니다. 다시 로그인 해주세요.");
                this.Close();
            }
            
        }

        private void CmbStr_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void CmbStr_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FormMain.cmbStrCheck = cmbStr.SelectedItem.ToString();
        }

        private void Txtsendbox_MouseClick(object sender, MouseEventArgs e)
        {
            txtsendbox.Text = "";
        }
    }
}
