
namespace AppAPI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLayAPI = new System.Windows.Forms.Button();
            this.txtmasite = new System.Windows.Forms.TextBox();
            this.txtngay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1432, 535);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnLayAPI
            // 
            this.btnLayAPI.Location = new System.Drawing.Point(12, 12);
            this.btnLayAPI.Name = "btnLayAPI";
            this.btnLayAPI.Size = new System.Drawing.Size(75, 23);
            this.btnLayAPI.TabIndex = 1;
            this.btnLayAPI.Text = "Lấy API";
            this.btnLayAPI.UseVisualStyleBackColor = true;
            this.btnLayAPI.Click += new System.EventHandler(this.btnLayAPI_Click);
            // 
            // txtmasite
            // 
            this.txtmasite.Location = new System.Drawing.Point(154, 14);
            this.txtmasite.Name = "txtmasite";
            this.txtmasite.Size = new System.Drawing.Size(100, 20);
            this.txtmasite.TabIndex = 2;
            this.txtmasite.Text = "1101";
            // 
            // txtngay
            // 
            this.txtngay.Location = new System.Drawing.Point(308, 14);
            this.txtngay.Name = "txtngay";
            this.txtngay.Size = new System.Drawing.Size(100, 20);
            this.txtngay.TabIndex = 3;
            this.txtngay.Text = "2024-04-25";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 588);
            this.Controls.Add(this.txtngay);
            this.Controls.Add(this.txtmasite);
            this.Controls.Add(this.btnLayAPI);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLayAPI;
        private System.Windows.Forms.TextBox txtmasite;
        private System.Windows.Forms.TextBox txtngay;
    }
}

