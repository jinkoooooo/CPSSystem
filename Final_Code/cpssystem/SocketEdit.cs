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
    public partial class SocketEdit : Form
    {
        public SocketEdit()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtIPv4.Text == "" && txtPort.Text == "")
            {
                MessageBox.Show("IPv4 번호와 port 번호를 입력하세요.");
                return;
            }
            else if (txtIPv4.Text == "")
            {
                MessageBox.Show("IPv4 번호를 입력하세요.");
                return;
            }
            else if (txtPort.Text == "")
            {
                MessageBox.Show("Port 번호를 입력하세요.!!");
                return;
            }
            MessageBox.Show("적용 되었습니다.");
            FormLogin.ServerIPv4 = txtIPv4.Text.ToString();
            FormLogin.ServerPort = txtPort.Text.ToString();

            this.Close();
        }

        private void SocketEdit_Load(object sender, EventArgs e)
        {
            txtIPv4.Text = FormLogin.ServerIPv4;
            txtPort.Text = FormLogin.ServerPort;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
