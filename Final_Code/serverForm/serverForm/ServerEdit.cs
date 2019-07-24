using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serverForm
{
    public partial class ServerEdit : Form
    {
        public ServerEdit()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ServerForm.SocketPort = txtSPort.Text.ToString();
            ServerForm.DBPort = txtDBPort.Text.ToString();
            ServerForm.User = txtUser.Text.ToString();
            ServerForm.Schema = txtSchema.Text.ToString();
            ServerForm.Passwd = txtPassword.Text.ToString();

            this.Close();
        }

        private void ServerEdit_Load(object sender, EventArgs e)
        {
            txtSPort.Text = ServerForm.SocketPort;
            txtDBPort.Text = ServerForm.DBPort;
            txtUser.Text = ServerForm.User;
            txtSchema.Text = ServerForm.Schema;
            txtPassword.Text = ServerForm.Passwd;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
