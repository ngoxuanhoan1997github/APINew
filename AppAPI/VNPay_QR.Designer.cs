
namespace AppAPI
{
    partial class VNPay_QR
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
            this.btnQRcode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbnganhang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtstk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbtemplate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txttentk = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtnoidung = new System.Windows.Forms.TextBox();
            this.txtsotien = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCreateQRVNPAY = new System.Windows.Forms.Button();
            this.btnCreateQRMOMO = new System.Windows.Forms.Button();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtngnhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQRcode
            // 
            this.btnQRcode.Location = new System.Drawing.Point(12, 20);
            this.btnQRcode.Name = "btnQRcode";
            this.btnQRcode.Size = new System.Drawing.Size(75, 23);
            this.btnQRcode.TabIndex = 0;
            this.btnQRcode.Text = "Create QR";
            this.btnQRcode.UseVisualStyleBackColor = true;
            this.btnQRcode.Click += new System.EventHandler(this.btnQRcode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngân Hàng";
            // 
            // cbbnganhang
            // 
            this.cbbnganhang.FormattingEnabled = true;
            this.cbbnganhang.Location = new System.Drawing.Point(246, 53);
            this.cbbnganhang.Name = "cbbnganhang";
            this.cbbnganhang.Size = new System.Drawing.Size(163, 21);
            this.cbbnganhang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "STK";
            // 
            // txtstk
            // 
            this.txtstk.Location = new System.Drawing.Point(246, 146);
            this.txtstk.Name = "txtstk";
            this.txtstk.Size = new System.Drawing.Size(133, 20);
            this.txtstk.TabIndex = 4;
            this.txtstk.Text = "02804433701";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Template";
            // 
            // cbbtemplate
            // 
            this.cbbtemplate.FormattingEnabled = true;
            this.cbbtemplate.Items.AddRange(new object[] {
            "compact",
            "compact2",
            "qr_only",
            "print"});
            this.cbbtemplate.Location = new System.Drawing.Point(246, 236);
            this.cbbtemplate.Name = "cbbtemplate";
            this.cbbtemplate.Size = new System.Drawing.Size(121, 21);
            this.cbbtemplate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số Tiền";
            // 
            // txttentk
            // 
            this.txttentk.Location = new System.Drawing.Point(246, 193);
            this.txttentk.Name = "txttentk";
            this.txttentk.Size = new System.Drawing.Size(133, 20);
            this.txttentk.TabIndex = 11;
            this.txttentk.Text = "NGO XUAN HOAN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tên TK";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nội Dung";
            // 
            // txtnoidung
            // 
            this.txtnoidung.Location = new System.Drawing.Point(246, 281);
            this.txtnoidung.Name = "txtnoidung";
            this.txtnoidung.Size = new System.Drawing.Size(133, 20);
            this.txtnoidung.TabIndex = 13;
            this.txtnoidung.Text = "Thu Nghiem";
            // 
            // txtsotien
            // 
            this.txtsotien.Location = new System.Drawing.Point(246, 100);
            this.txtsotien.Name = "txtsotien";
            this.txtsotien.Size = new System.Drawing.Size(168, 20);
            this.txtsotien.TabIndex = 14;
            this.txtsotien.Text = "10000";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(511, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(228, 242);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // btnCreateQRVNPAY
            // 
            this.btnCreateQRVNPAY.Location = new System.Drawing.Point(93, 20);
            this.btnCreateQRVNPAY.Name = "btnCreateQRVNPAY";
            this.btnCreateQRVNPAY.Size = new System.Drawing.Size(122, 23);
            this.btnCreateQRVNPAY.TabIndex = 17;
            this.btnCreateQRVNPAY.Text = "Create QR VNPAY";
            this.btnCreateQRVNPAY.UseVisualStyleBackColor = true;
            this.btnCreateQRVNPAY.Click += new System.EventHandler(this.btnCreateQRVNPAY_Click);
            // 
            // btnCreateQRMOMO
            // 
            this.btnCreateQRMOMO.Location = new System.Drawing.Point(511, 32);
            this.btnCreateQRMOMO.Name = "btnCreateQRMOMO";
            this.btnCreateQRMOMO.Size = new System.Drawing.Size(122, 23);
            this.btnCreateQRMOMO.TabIndex = 18;
            this.btnCreateQRMOMO.Text = "Create QR MoMo";
            this.btnCreateQRMOMO.UseVisualStyleBackColor = true;
            this.btnCreateQRMOMO.Click += new System.EventHandler(this.btnCreateQRMOMO_Click);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(761, 130);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(133, 20);
            this.txtemail.TabIndex = 22;
            this.txtemail.Text = "hoanngo1997@gmail.com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(758, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Email";
            // 
            // txtsdt
            // 
            this.txtsdt.Location = new System.Drawing.Point(761, 83);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(133, 20);
            this.txtsdt.TabIndex = 20;
            this.txtsdt.Text = "0334246837";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(758, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "SDT";
            // 
            // txttien
            // 
            this.txttien.Location = new System.Drawing.Point(761, 231);
            this.txttien.Name = "txttien";
            this.txttien.Size = new System.Drawing.Size(133, 20);
            this.txttien.TabIndex = 26;
            this.txttien.Text = "20000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(758, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Số tiền";
            // 
            // txtngnhan
            // 
            this.txtngnhan.Location = new System.Drawing.Point(761, 184);
            this.txtngnhan.Name = "txtngnhan";
            this.txtngnhan.Size = new System.Drawing.Size(133, 20);
            this.txtngnhan.TabIndex = 24;
            this.txtngnhan.Text = "Ngô Xuân Hoàn";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(758, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tên người nhận";
            // 
            // VNPay_QR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 573);
            this.Controls.Add(this.txttien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtngnhan);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtsdt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCreateQRMOMO);
            this.Controls.Add(this.btnCreateQRVNPAY);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtsotien);
            this.Controls.Add(this.txtnoidung);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttentk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbtemplate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtstk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbnganhang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQRcode);
            this.Name = "VNPay_QR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNPay_QR";
            this.Load += new System.EventHandler(this.VNPay_QR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQRcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbnganhang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtstk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbtemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txttentk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtnoidung;
        private System.Windows.Forms.TextBox txtsotien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCreateQRVNPAY;
        private System.Windows.Forms.Button btnCreateQRMOMO;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsdt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtngnhan;
        private System.Windows.Forms.Label label10;
    }
}