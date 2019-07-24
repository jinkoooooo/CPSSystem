namespace cpssystem
{
    partial class FormMain
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
            this.lblmessage = new System.Windows.Forms.Label();
            this.lbllogotext = new System.Windows.Forms.Label();
            this.txtsendbox = new System.Windows.Forms.TextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.lblmessage2 = new System.Windows.Forms.Label();
            this.lblmessage3 = new System.Windows.Forms.Label();
            this.lblsubscribe = new System.Windows.Forms.Label();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.cmbPositions = new System.Windows.Forms.ComboBox();
            this.lbldepartments3 = new System.Windows.Forms.Label();
            this.lblposition2 = new System.Windows.Forms.Label();
            this.txtNames = new System.Windows.Forms.TextBox();
            this.lblname1 = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtpostbox = new System.Windows.Forms.TextBox();
            this.sublistbox = new System.Windows.Forms.CheckedListBox();
            this.subedlistbox = new System.Windows.Forms.CheckedListBox();
            this.lblsubedlist = new System.Windows.Forms.Label();
            this.btnsubcancle = new System.Windows.Forms.Button();
            this.btnsub = new System.Windows.Forms.Button();
            this.btnserver = new System.Windows.Forms.Button();
            this.txtleavemessage = new System.Windows.Forms.TextBox();
            this.cmbStr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblmessage.Location = new System.Drawing.Point(17, 86);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(100, 22);
            this.lblmessage.TabIndex = 0;
            this.lblmessage.Text = "메시지내용";
            // 
            // lbllogotext
            // 
            this.lbllogotext.AutoSize = true;
            this.lbllogotext.Font = new System.Drawing.Font("Rix정고딕 B", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbllogotext.Location = new System.Drawing.Point(363, 26);
            this.lbllogotext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllogotext.Name = "lbllogotext";
            this.lbllogotext.Size = new System.Drawing.Size(204, 35);
            this.lbllogotext.TabIndex = 16;
            this.lbllogotext.Text = "CPS SYSTEM";
            // 
            // txtsendbox
            // 
            this.txtsendbox.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.txtsendbox.Location = new System.Drawing.Point(123, 76);
            this.txtsendbox.Multiline = true;
            this.txtsendbox.Name = "txtsendbox";
            this.txtsendbox.Size = new System.Drawing.Size(654, 42);
            this.txtsendbox.TabIndex = 17;
            this.txtsendbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Txtsendbox_MouseClick);
            // 
            // btnsend
            // 
            this.btnsend.BackColor = System.Drawing.Color.White;
            this.btnsend.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.btnsend.Location = new System.Drawing.Point(794, 76);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(81, 42);
            this.btnsend.TabIndex = 18;
            this.btnsend.Text = "전송";
            this.btnsend.UseVisualStyleBackColor = false;
            this.btnsend.Visible = false;
            this.btnsend.Click += new System.EventHandler(this.Btnsend_Click);
            // 
            // lblmessage2
            // 
            this.lblmessage2.AutoSize = true;
            this.lblmessage2.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblmessage2.Location = new System.Drawing.Point(17, 134);
            this.lblmessage2.Name = "lblmessage2";
            this.lblmessage2.Size = new System.Drawing.Size(100, 22);
            this.lblmessage2.TabIndex = 19;
            this.lblmessage2.Text = "받은메시지";
            // 
            // lblmessage3
            // 
            this.lblmessage3.AutoSize = true;
            this.lblmessage3.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblmessage3.Location = new System.Drawing.Point(17, 390);
            this.lblmessage3.Name = "lblmessage3";
            this.lblmessage3.Size = new System.Drawing.Size(100, 22);
            this.lblmessage3.TabIndex = 21;
            this.lblmessage3.Text = "부재메시지";
            this.lblmessage3.Click += new System.EventHandler(this.Lblmessage3_Click);
            // 
            // lblsubscribe
            // 
            this.lblsubscribe.AutoSize = true;
            this.lblsubscribe.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblsubscribe.Location = new System.Drawing.Point(639, 134);
            this.lblsubscribe.Name = "lblsubscribe";
            this.lblsubscribe.Size = new System.Drawing.Size(82, 22);
            this.lblsubscribe.TabIndex = 23;
            this.lblsubscribe.Text = "구독하기";
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartments.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(697, 266);
            this.cmbDepartments.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(177, 30);
            this.cmbDepartments.TabIndex = 41;
            // 
            // cmbPositions
            // 
            this.cmbPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPositions.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPositions.FormattingEnabled = true;
            this.cmbPositions.Location = new System.Drawing.Point(697, 216);
            this.cmbPositions.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPositions.Name = "cmbPositions";
            this.cmbPositions.Size = new System.Drawing.Size(177, 30);
            this.cmbPositions.TabIndex = 40;
            // 
            // lbldepartments3
            // 
            this.lbldepartments3.AutoSize = true;
            this.lbldepartments3.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbldepartments3.Location = new System.Drawing.Point(643, 268);
            this.lbldepartments3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldepartments3.Name = "lbldepartments3";
            this.lbldepartments3.Size = new System.Drawing.Size(46, 22);
            this.lbldepartments3.TabIndex = 39;
            this.lbldepartments3.Text = "부서";
            // 
            // lblposition2
            // 
            this.lblposition2.AutoSize = true;
            this.lblposition2.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblposition2.Location = new System.Drawing.Point(643, 219);
            this.lblposition2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblposition2.Name = "lblposition2";
            this.lblposition2.Size = new System.Drawing.Size(46, 22);
            this.lblposition2.TabIndex = 38;
            this.lblposition2.Text = "직책";
            // 
            // txtNames
            // 
            this.txtNames.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNames.Location = new System.Drawing.Point(697, 168);
            this.txtNames.Margin = new System.Windows.Forms.Padding(4);
            this.txtNames.Name = "txtNames";
            this.txtNames.Size = new System.Drawing.Size(177, 29);
            this.txtNames.TabIndex = 37;
            // 
            // lblname1
            // 
            this.lblname1.AutoSize = true;
            this.lblname1.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblname1.Location = new System.Drawing.Point(643, 168);
            this.lblname1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname1.Name = "lblname1";
            this.lblname1.Size = new System.Drawing.Size(46, 22);
            this.lblname1.TabIndex = 36;
            this.lblname1.Text = "이름";
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.White;
            this.btnsearch.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.btnsearch.Location = new System.Drawing.Point(794, 404);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(81, 40);
            this.btnsearch.TabIndex = 42;
            this.btnsearch.Text = "검색";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.Btnsearch_Click);
            // 
            // txtpostbox
            // 
            this.txtpostbox.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.txtpostbox.Location = new System.Drawing.Point(21, 166);
            this.txtpostbox.Multiline = true;
            this.txtpostbox.Name = "txtpostbox";
            this.txtpostbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtpostbox.Size = new System.Drawing.Size(610, 184);
            this.txtpostbox.TabIndex = 20;
            this.txtpostbox.TextChanged += new System.EventHandler(this.Txtpostbox_TextChanged);
            // 
            // sublistbox
            // 
            this.sublistbox.Font = new System.Drawing.Font("Rix정고딕 B", 9F);
            this.sublistbox.FormattingEnabled = true;
            this.sublistbox.Location = new System.Drawing.Point(647, 315);
            this.sublistbox.Name = "sublistbox";
            this.sublistbox.Size = new System.Drawing.Size(227, 76);
            this.sublistbox.TabIndex = 43;
            // 
            // subedlistbox
            // 
            this.subedlistbox.Font = new System.Drawing.Font("Rix정고딕 B", 9F);
            this.subedlistbox.FormattingEnabled = true;
            this.subedlistbox.Location = new System.Drawing.Point(643, 488);
            this.subedlistbox.Name = "subedlistbox";
            this.subedlistbox.Size = new System.Drawing.Size(227, 76);
            this.subedlistbox.TabIndex = 44;
            // 
            // lblsubedlist
            // 
            this.lblsubedlist.AutoSize = true;
            this.lblsubedlist.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblsubedlist.Location = new System.Drawing.Point(639, 458);
            this.lblsubedlist.Name = "lblsubedlist";
            this.lblsubedlist.Size = new System.Drawing.Size(124, 22);
            this.lblsubedlist.TabIndex = 45;
            this.lblsubedlist.Text = "구독 목록보기";
            // 
            // btnsubcancle
            // 
            this.btnsubcancle.BackColor = System.Drawing.Color.White;
            this.btnsubcancle.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.btnsubcancle.Location = new System.Drawing.Point(763, 576);
            this.btnsubcancle.Name = "btnsubcancle";
            this.btnsubcancle.Size = new System.Drawing.Size(109, 39);
            this.btnsubcancle.TabIndex = 46;
            this.btnsubcancle.Text = "구독취소";
            this.btnsubcancle.UseVisualStyleBackColor = false;
            this.btnsubcancle.Click += new System.EventHandler(this.Btnsubcancle_Click);
            // 
            // btnsub
            // 
            this.btnsub.BackColor = System.Drawing.Color.White;
            this.btnsub.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.btnsub.Location = new System.Drawing.Point(697, 404);
            this.btnsub.Name = "btnsub";
            this.btnsub.Size = new System.Drawing.Size(81, 40);
            this.btnsub.TabIndex = 47;
            this.btnsub.Text = "구독";
            this.btnsub.UseVisualStyleBackColor = false;
            this.btnsub.Click += new System.EventHandler(this.Btnsub_Click);
            // 
            // btnserver
            // 
            this.btnserver.BackColor = System.Drawing.Color.White;
            this.btnserver.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.btnserver.Location = new System.Drawing.Point(767, 24);
            this.btnserver.Name = "btnserver";
            this.btnserver.Size = new System.Drawing.Size(109, 39);
            this.btnserver.TabIndex = 48;
            this.btnserver.Text = "접속종료";
            this.btnserver.UseVisualStyleBackColor = false;
            this.btnserver.Click += new System.EventHandler(this.Btnserver_Click);
            // 
            // txtleavemessage
            // 
            this.txtleavemessage.Font = new System.Drawing.Font("Rix정고딕 B", 10F);
            this.txtleavemessage.Location = new System.Drawing.Point(21, 429);
            this.txtleavemessage.Multiline = true;
            this.txtleavemessage.Name = "txtleavemessage";
            this.txtleavemessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtleavemessage.Size = new System.Drawing.Size(610, 184);
            this.txtleavemessage.TabIndex = 49;
            // 
            // cmbStr
            // 
            this.cmbStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStr.Font = new System.Drawing.Font("Rix정고딕 B", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbStr.FormattingEnabled = true;
            this.cmbStr.Items.AddRange(new object[] {
            "영어",
            "한글",
            "일본어",
            "중국어(간체)",
            "중국어(번체)"});
            this.cmbStr.Location = new System.Drawing.Point(123, 131);
            this.cmbStr.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStr.Name = "cmbStr";
            this.cmbStr.Size = new System.Drawing.Size(150, 30);
            this.cmbStr.TabIndex = 50;
            this.cmbStr.SelectionChangeCommitted += new System.EventHandler(this.CmbStr_SelectionChangeCommitted);
            this.cmbStr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CmbStr_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "(필터링 언어를 고르세요)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(897, 633);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStr);
            this.Controls.Add(this.txtleavemessage);
            this.Controls.Add(this.btnserver);
            this.Controls.Add(this.btnsub);
            this.Controls.Add(this.btnsubcancle);
            this.Controls.Add(this.lblsubedlist);
            this.Controls.Add(this.subedlistbox);
            this.Controls.Add(this.sublistbox);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.cmbDepartments);
            this.Controls.Add(this.cmbPositions);
            this.Controls.Add(this.lbldepartments3);
            this.Controls.Add(this.lblposition2);
            this.Controls.Add(this.txtNames);
            this.Controls.Add(this.lblname1);
            this.Controls.Add(this.lblsubscribe);
            this.Controls.Add(this.lblmessage3);
            this.Controls.Add(this.txtpostbox);
            this.Controls.Add(this.lblmessage2);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtsendbox);
            this.Controls.Add(this.lbllogotext);
            this.Controls.Add(this.lblmessage);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.Label lbllogotext;
        private System.Windows.Forms.TextBox txtsendbox;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Label lblmessage2;
        private System.Windows.Forms.Label lblmessage3;
        private System.Windows.Forms.Label lblsubscribe;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.ComboBox cmbPositions;
        private System.Windows.Forms.Label lbldepartments3;
        private System.Windows.Forms.Label lblposition2;
        private System.Windows.Forms.TextBox txtNames;
        private System.Windows.Forms.Label lblname1;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtpostbox;
        private System.Windows.Forms.CheckedListBox sublistbox;
        private System.Windows.Forms.CheckedListBox subedlistbox;
        private System.Windows.Forms.Label lblsubedlist;
        private System.Windows.Forms.Button btnsubcancle;
        private System.Windows.Forms.Button btnsub;
        private System.Windows.Forms.Button btnserver;
        private System.Windows.Forms.TextBox txtleavemessage;
        private System.Windows.Forms.ComboBox cmbStr;
        private System.Windows.Forms.Label label1;
    }
}