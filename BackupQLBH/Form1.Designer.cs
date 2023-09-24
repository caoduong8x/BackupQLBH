namespace BackupQLBH
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSaoLuu = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkSendMail = new System.Windows.Forms.CheckBox();
            this.btnSelectDes = new System.Windows.Forms.Button();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSaoLuu);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblPercent);
            this.panel1.Controls.Add(this.btnSaoLuu);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.chkSendMail);
            this.panel1.Controls.Add(this.btnSelectDes);
            this.panel1.Controls.Add(this.txtDes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 197);
            this.panel1.TabIndex = 0;
            // 
            // lblSaoLuu
            // 
            this.lblSaoLuu.AutoSize = true;
            this.lblSaoLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaoLuu.ForeColor = System.Drawing.Color.Red;
            this.lblSaoLuu.Location = new System.Drawing.Point(179, 163);
            this.lblSaoLuu.Name = "lblSaoLuu";
            this.lblSaoLuu.Size = new System.Drawing.Size(264, 25);
            this.lblSaoLuu.TabIndex = 8;
            this.lblSaoLuu.Text = "Đang sao lưu dữ liệu.....";
            this.lblSaoLuu.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnClose.Image = global::BackupQLBH.Properties.Resources.Close_Window_24px;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(338, 123);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 36);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "   THOÁT";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblPercent.Location = new System.Drawing.Point(572, 72);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(0, 20);
            this.lblPercent.TabIndex = 9;
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnSaoLuu.Image = global::BackupQLBH.Properties.Resources.cloud_backup_restore_24px;
            this.btnSaoLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaoLuu.Location = new System.Drawing.Point(169, 123);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(116, 36);
            this.btnSaoLuu.TabIndex = 4;
            this.btnSaoLuu.Text = "SAO LƯU";
            this.btnSaoLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaoLuu.UseVisualStyleBackColor = true;
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(111, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 18);
            this.progressBar1.TabIndex = 6;
            // 
            // chkSendMail
            // 
            this.chkSendMail.AutoSize = true;
            this.chkSendMail.Checked = true;
            this.chkSendMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendMail.ForeColor = System.Drawing.Color.ForestGreen;
            this.chkSendMail.Location = new System.Drawing.Point(169, 97);
            this.chkSendMail.Name = "chkSendMail";
            this.chkSendMail.Size = new System.Drawing.Size(285, 24);
            this.chkSendMail.TabIndex = 5;
            this.chkSendMail.Text = "Gửi mail (caoduong.it8x@gmail.com)";
            this.chkSendMail.UseVisualStyleBackColor = true;
            // 
            // btnSelectDes
            // 
            this.btnSelectDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDes.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnSelectDes.Location = new System.Drawing.Point(577, 41);
            this.btnSelectDes.Name = "btnSelectDes";
            this.btnSelectDes.Size = new System.Drawing.Size(34, 26);
            this.btnSelectDes.TabIndex = 3;
            this.btnSelectDes.Text = "...";
            this.btnSelectDes.UseVisualStyleBackColor = true;
            this.btnSelectDes.Click += new System.EventHandler(this.btnSelectDes_Click);
            // 
            // txtDes
            // 
            this.txtDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDes.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtDes.Location = new System.Drawing.Point(111, 41);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(456, 26);
            this.txtDes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(208, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "SAO LƯU DỮ LIỆU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn nơi lưu:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 197);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAO LƯU DỮ LIỆU";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkSendMail;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.Button btnSelectDes;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSaoLuu;
        private System.Windows.Forms.Label lblPercent;
    }
}

