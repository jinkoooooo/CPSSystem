namespace cpssystem
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtpasswd = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblpasswd1 = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.btnSEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rix정고딕 B", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(174, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "CPS SYSTEM";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.Location = new System.Drawing.Point(134, 290);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(105, 37);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.White;
            this.btnJoin.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJoin.Location = new System.Drawing.Point(288, 290);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(105, 37);
            this.btnJoin.TabIndex = 13;
            this.btnJoin.Text = "회원가입";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.BtnJoin_Click);
            // 
            // txtpasswd
            // 
            this.txtpasswd.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtpasswd.Location = new System.Drawing.Point(198, 219);
            this.txtpasswd.Margin = new System.Windows.Forms.Padding(4);
            this.txtpasswd.Name = "txtpasswd";
            this.txtpasswd.Size = new System.Drawing.Size(249, 32);
            this.txtpasswd.TabIndex = 12;
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtid.Location = new System.Drawing.Point(198, 151);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(249, 32);
            this.txtid.TabIndex = 11;
            // 
            // lblpasswd1
            // 
            this.lblpasswd1.AutoSize = true;
            this.lblpasswd1.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblpasswd1.Location = new System.Drawing.Point(60, 224);
            this.lblpasswd1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpasswd1.Name = "lblpasswd1";
            this.lblpasswd1.Size = new System.Drawing.Size(92, 25);
            this.lblpasswd1.TabIndex = 10;
            this.lblpasswd1.Text = "비밀번호";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblid.Location = new System.Drawing.Point(60, 155);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(92, 25);
            this.lblid.TabIndex = 9;
            this.lblid.Text = "사원번호";
            // 
            // btnSEdit
            // 
            this.btnSEdit.Location = new System.Drawing.Point(13, 13);
            this.btnSEdit.Name = "btnSEdit";
            this.btnSEdit.Size = new System.Drawing.Size(112, 31);
            this.btnSEdit.TabIndex = 16;
            this.btnSEdit.Text = "통신설정";
            this.btnSEdit.UseVisualStyleBackColor = true;
            this.btnSEdit.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(520, 385);
            this.Controls.Add(this.btnSEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtpasswd);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lblpasswd1);
            this.Controls.Add(this.lblid);
            this.Font = new System.Drawing.Font("Rix정고딕 B", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtpasswd;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lblpasswd1;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Button btnSEdit;
    }
}