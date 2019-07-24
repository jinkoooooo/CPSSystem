using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cpssystem
{
    public partial class FormLogin : Form
    {

        public static string id { get; set; }
        public static string pw { get; set; }

        public static string ServerIPv4 { get; set; }
        public static string ServerPort { get; set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //로그인 버튼 클릭시
            FormLogin.id = txtid.Text.ToString();
            FormLogin.pw = txtpasswd.Text.ToString();

            FormMain frm = new FormMain();
            frm.Show();
            txtid.Clear();
            txtpasswd.Clear();
        }

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            //회원가입 버튼 클릭시
            FormJoin frm = new FormJoin();
            frm.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            FormLogin.ServerIPv4 = "localhost";
            FormLogin.ServerPort = "7000";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SocketEdit frm = new SocketEdit();
            frm.Show();
        }
    }
}
