namespace serverForm
{
    partial class ServerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.btnSEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(151, 153);
            this.txtServer.Multiline = true;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(464, 159);
            this.txtServer.TabIndex = 0;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(335, 116);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(0, 18);
            this.lblServer.TabIndex = 1;
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(204, 73);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(117, 42);
            this.btnServerStart.TabIndex = 2;
            this.btnServerStart.Text = "서버가동";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.TabIndex = 3;
            // 
            // btnServerStop
            // 
            this.btnServerStop.Location = new System.Drawing.Point(452, 73);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(115, 41);
            this.btnServerStop.TabIndex = 4;
            this.btnServerStop.Text = "서버중지";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Visible = false;
            this.btnServerStop.Click += new System.EventHandler(this.BtnServerStop_Click);
            // 
            // btnSEdit
            // 
            this.btnSEdit.Location = new System.Drawing.Point(295, 342);
            this.btnSEdit.Name = "btnSEdit";
            this.btnSEdit.Size = new System.Drawing.Size(183, 68);
            this.btnSEdit.TabIndex = 5;
            this.btnSEdit.Text = "서버 설정";
            this.btnSEdit.UseVisualStyleBackColor = true;
            this.btnSEdit.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnSEdit);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnServerStart);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Button btnSEdit;
    }
}

