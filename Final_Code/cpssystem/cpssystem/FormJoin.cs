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
using System.Text.RegularExpressions;

namespace cpssystem
{
    public partial class FormJoin : Form
    {
        public FormJoin()
        {
            InitializeComponent();

            //콤보박스에 아이템 추가
            cmbPosition.Items.Add("사원");
            cmbPosition.Items.Add("선임");
            cmbPosition.Items.Add("책임");
            cmbPosition.Items.Add("사장");
            cmbDepartment.Items.Add("영업팀");
            cmbDepartment.Items.Add("개발팀");
            cmbDepartment.Items.Add("본부팀");
            cmbDepartment.Items.Add("설비팀");

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            client.Close();
            this.Close();
            
        }

        private void BtnJoinDB_Click(object sender, EventArgs e)
        {
            try
            {
                //회원가입 버튼 클릭시
                string sendJoin = null;//보낼 회원정보를 넣을 변수
                string recvJoin = null;//회원가입 성공여부를 받을 변수


                sendJoin += txtName.Text.ToString() + "/";
                sendJoin += txtPasswd.Text.ToString() + "/";

                if (cmbPosition.SelectedItem != null)
                {
                    sendJoin += cmbPosition.SelectedItem.ToString() + "/";


                }
                else
                {
                    MessageBox.Show("직책을 골라주세요");

                }
                if (cmbDepartment.SelectedItem != null)
                {
                    sendJoin += cmbDepartment.SelectedItem.ToString() + "/";

                }
                else
                {
                    MessageBox.Show("부서을 골라주세요");
                    return;
                }

                sendJoin += txtJobyear.Text.ToString();




                //입력한 회원정보를 보낸다.
                writer.WriteLine(sendJoin);

                //회원가입 성공여부에 대한 응답을 받는다.(성공시 사원번호 반환됨)
                recvJoin = reader.ReadLine();
                if (recvJoin == "성공")
                {
                    MessageBox.Show("가입성공");
                    recvJoin = reader.ReadLine();
                    MessageBox.Show("사원 번호 : " + recvJoin);

                    this.Close();
                }
                else if (recvJoin == "입사년도")
                {
                    MessageBox.Show("입사년도실패");

                }
                else if (recvJoin == "이름오류")
                {
                    MessageBox.Show("이름 실패");
                }
                else if (recvJoin == "이름(한글)")
                {
                    MessageBox.Show("한글(이름만)");
                }
            }
            catch
            {
                MessageBox.Show("서버와 연결이 끊어졌습니다. 다시 시도해주세요");
                this.Close();
            }
            
        }

        private void FormJoin_Load(object sender, EventArgs e)
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


                //회원가입시 sort 스트림처리.
                sortClient = new TcpClient();
                sortClient.Connect(FormLogin.ServerIPv4, int.Parse(FormLogin.ServerPort));

                sortStream = sortClient.GetStream();

                sortReader = new StreamReader(sortStream, encode);
                sortWriter = new StreamWriter(sortStream, encode) { AutoFlush = true };

                //회원 가입 시 ping 스트림
                pingClient = new TcpClient();
                pingClient.Connect(FormLogin.ServerIPv4, int.Parse(FormLogin.ServerPort));

                pingStream = pingClient.GetStream();

                pingReader = new StreamReader(pingStream, encode);
                pingWriter = new StreamWriter(pingStream, encode) { AutoFlush = true };




                //회원가입 할것이라는 신호를 서버로 보냄.
                string dataToSend = "회원가입";
                writer.WriteLine(dataToSend);

                //sort는 작동안해도 되는 신호를 보냄.
                sortWriter.WriteLine("회원가입");

                //ping은 작동안해도 되는 신호를 보냄.
                pingWriter.WriteLine("회원가입");
            }
            catch (Exception ex)
            {
                txtName.AppendText("연결 실패.");
                client.Close();
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

        private void CmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lblposition_Click(object sender, EventArgs e)
        {

        }

        private void Lbldepartments_Click(object sender, EventArgs e)
        {

        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Lblname_Click(object sender, EventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            Regex korea = new Regex("^[ㄱ-ㅎ가-힣]*$");
            Boolean ismatch = korea.IsMatch(txtName.Text);
            if (!ismatch)
            {
                MessageBox.Show("한글로만 입력해 주세요.");
                txtName.Text = null;
            }
        }

        private void FormJoin_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void TxtJobyear_TextChanged(object sender, EventArgs e)
        {

            Regex number = new Regex(@"^[0-9]*$");
            Boolean ismatch = number.IsMatch(txtJobyear.Text);
            if (!ismatch)
            {
                MessageBox.Show("숫자만 입력해 주세요.");
                txtJobyear.Text = null;
            }
        }

        private void TxtPasswd_TextChanged(object sender, EventArgs e)
        {
            Regex passwd = new Regex("^[ㄱ-ㅎ가-힣]*$");
            Boolean ismatch = passwd.IsMatch(txtPasswd.Text);
            if (ismatch)
            {
                MessageBox.Show("영어와 숫자로만 입력해 주세요.");
                txtPasswd.Text = null;
            }
        }

        private void TxtPasswdck_Leave(object sender, EventArgs e)
        {
            if (txtPasswd.Text != txtPasswdck.Text)
            {
                MessageBox.Show("패스워드 불일치");
                btnJoinDB.Visible = false;
                txtPasswd.Text = null;
                txtPasswdck.Text = null;
            }
            else
            {
                btnJoinDB.Visible = true;
            }
        }
    }
}
