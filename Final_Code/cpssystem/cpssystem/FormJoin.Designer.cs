namespace cpssystem
{
    partial class FormJoin
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnJoinDB = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.txtJobyear = new System.Windows.Forms.TextBox();
            this.lbljobyear = new System.Windows.Forms.Label();
            this.lbldepartments = new System.Windows.Forms.Label();
            this.lblposition = new System.Windows.Forms.Label();
            this.txtPasswdck = new System.Windows.Forms.TextBox();
            this.lblpasswdck = new System.Windows.Forms.Label();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.lblpasswd = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReset.Location = new System.Drawing.Point(88, 484);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 44);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "가입취소";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnJoinDB
            // 
            this.btnJoinDB.BackColor = System.Drawing.Color.White;
            this.btnJoinDB.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJoinDB.Location = new System.Drawing.Point(265, 484);
            this.btnJoinDB.Name = "btnJoinDB";
            this.btnJoinDB.Size = new System.Drawing.Size(130, 44);
            this.btnJoinDB.TabIndex = 36;
            this.btnJoinDB.Text = "회원가입";
            this.btnJoinDB.UseVisualStyleBackColor = false;
            this.btnJoinDB.Click += new System.EventHandler(this.BtnJoinDB_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(196, 360);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(240, 30);
            this.cmbDepartment.TabIndex = 35;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.CmbDepartment_SelectedIndexChanged);
            // 
            // cmbPosition
            // 
            this.cmbPosition.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(196, 298);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(240, 30);
            this.cmbPosition.TabIndex = 34;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.CmbPosition_SelectedIndexChanged);
            // 
            // txtJobyear
            // 
            this.txtJobyear.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtJobyear.Location = new System.Drawing.Point(196, 418);
            this.txtJobyear.Margin = new System.Windows.Forms.Padding(4);
            this.txtJobyear.Name = "txtJobyear";
            this.txtJobyear.Size = new System.Drawing.Size(240, 29);
            this.txtJobyear.TabIndex = 33;
            // 
            // lbljobyear
            // 
            this.lbljobyear.AutoSize = true;
            this.lbljobyear.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbljobyear.Location = new System.Drawing.Point(46, 422);
            this.lbljobyear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbljobyear.Name = "lbljobyear";
            this.lbljobyear.Size = new System.Drawing.Size(82, 22);
            this.lbljobyear.TabIndex = 32;
            this.lbljobyear.Text = "입사년도";
            // 
            // lbldepartments
            // 
            this.lbldepartments.AutoSize = true;
            this.lbldepartments.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbldepartments.Location = new System.Drawing.Point(46, 360);
            this.lbldepartments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldepartments.Name = "lbldepartments";
            this.lbldepartments.Size = new System.Drawing.Size(46, 22);
            this.lbldepartments.TabIndex = 31;
            this.lbldepartments.Text = "부서";
            this.lbldepartments.Click += new System.EventHandler(this.Lbldepartments_Click);
            // 
            // lblposition
            // 
            this.lblposition.AutoSize = true;
            this.lblposition.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblposition.Location = new System.Drawing.Point(46, 298);
            this.lblposition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblposition.Name = "lblposition";
            this.lblposition.Size = new System.Drawing.Size(46, 22);
            this.lblposition.TabIndex = 30;
            this.lblposition.Text = "직책";
            this.lblposition.Click += new System.EventHandler(this.Lblposition_Click);
            // 
            // txtPasswdck
            // 
            this.txtPasswdck.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPasswdck.Location = new System.Drawing.Point(196, 233);
            this.txtPasswdck.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswdck.Name = "txtPasswdck";
            this.txtPasswdck.Size = new System.Drawing.Size(240, 29);
            this.txtPasswdck.TabIndex = 29;
            this.txtPasswdck.Leave += new System.EventHandler(this.TxtPasswdck_Leave);
            // 
            // lblpasswdck
            // 
            this.lblpasswdck.AutoSize = true;
            this.lblpasswdck.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblpasswdck.Location = new System.Drawing.Point(46, 237);
            this.lblpasswdck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpasswdck.Name = "lblpasswdck";
            this.lblpasswdck.Size = new System.Drawing.Size(118, 22);
            this.lblpasswdck.TabIndex = 28;
            this.lblpasswdck.Text = "비밀번호확인";
            // 
            // txtPasswd
            // 
            this.txtPasswd.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPasswd.Location = new System.Drawing.Point(196, 171);
            this.txtPasswd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(240, 29);
            this.txtPasswd.TabIndex = 27;
            // 
            // lblpasswd
            // 
            this.lblpasswd.AutoSize = true;
            this.lblpasswd.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblpasswd.Location = new System.Drawing.Point(46, 175);
            this.lblpasswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpasswd.Name = "lblpasswd";
            this.lblpasswd.Size = new System.Drawing.Size(82, 22);
            this.lblpasswd.TabIndex = 26;
            this.lblpasswd.Text = "비밀번호";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(196, 110);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 29);
            this.txtName.TabIndex = 25;
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblname.Location = new System.Drawing.Point(46, 114);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(46, 22);
            this.lblname.TabIndex = 24;
            this.lblname.Text = "이름";
            this.lblname.Click += new System.EventHandler(this.Lblname_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rix정고딕 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(209, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 23;
            this.label2.Text = "회원가입";
            // 
            // FormJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(497, 563);
            this.ControlBox = false;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnJoinDB);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.txtJobyear);
            this.Controls.Add(this.lbljobyear);
            this.Controls.Add(this.lbldepartments);
            this.Controls.Add(this.lblposition);
            this.Controls.Add(this.txtPasswdck);
            this.Controls.Add(this.lblpasswdck);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.lblpasswd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.label2);
            this.Name = "FormJoin";
            this.Text = "FormJoin";
            this.Load += new System.EventHandler(this.FormJoin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnJoinDB;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.TextBox txtJobyear;
        private System.Windows.Forms.Label lbljobyear;
        private System.Windows.Forms.Label lbldepartments;
        private System.Windows.Forms.Label lblposition;
        private System.Windows.Forms.TextBox txtPasswdck;
        private System.Windows.Forms.Label lblpasswdck;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Label lblpasswd;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label2;
    }
}