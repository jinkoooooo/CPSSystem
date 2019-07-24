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

namespace cpssystem
{
    public partial class FormMain : Form
    {
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
            // 메시지 전송 버튼 클릭시
            SendTCP(txtsendbox.Text.ToString());
        }

        private void Btnsearch_Click(object sender, EventArgs e)
        {
            // 구독할 사람 검색 버튼 클릭시
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
                client.Connect("localhost", 7000);
                stream = client.GetStream();


                reader = new StreamReader(stream, encode);
                writer = new StreamWriter(stream, encode)
                { AutoFlush = true };

                //로그인한 사원번호 서버로 보냄.
                string dataToSend = "123";

                writer.WriteLine(dataToSend);
                string dataFrom = reader.ReadLine();
                txtsendbox.AppendText("연결되었습니다. 메시지를 입력하세요.");
                txtpostbox.AppendText(dataFrom);
                btnsend.Visible = true;
            }
            catch (Exception ex)
            {
                txtpostbox.AppendText("연결 실패.");
                Console.WriteLine(ex.ToString());
                client.Close();
            }
        }

        TcpClient client = null;
        NetworkStream stream = null;
        StreamReader reader = null;
        StreamWriter writer = null;
        Encoding encode = Encoding.GetEncoding("utf-8");

        public void SendTCP(String text)
        {
            try
            {
                string dataToSend = text;

                writer.WriteLine(dataToSend);
                String str = reader.ReadLine();
                //Console.WriteLine(str);
                txtpostbox.AppendText(str);
                if (str == "이름 없음/연결 중지")
                {
                    btnsend.Visible = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                client.Close();
            }
        }


    }
}
