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
            //다시작성하기 버튼 클릭시
            txtName.Text = "";
            txtPasswdj.Text = "";
            txtPasswdck.Text = "";
            cmbPosition.Text = "";
            cmbDepartment.Text = "";
            txtJobyear.Text = "";


        }

        private void BtnJoinDB_Click(object sender, EventArgs e)
        {
            //회원가입 버튼 클릭시
            FormJoinSucess frm = new FormJoinSucess();
            frm.Show();
            this.Close();
               
        }

        private void FormJoin_Load(object sender, EventArgs e)
        {

        }

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

        }
    }
}
