using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cpssystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //로그인 버튼 클릭시
            //실험
            FormMain frm = new FormMain();
            frm.Show();
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

        }
    }
}
