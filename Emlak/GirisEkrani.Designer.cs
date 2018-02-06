namespace Emlak
{
    partial class GirisEkrani
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
            this.button_girisYap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Kullanici_ad = new System.Windows.Forms.TextBox();
            this.textBox_kullanici_sifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Kayit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_girisYap
            // 
            this.button_girisYap.Location = new System.Drawing.Point(79, 94);
            this.button_girisYap.Name = "button_girisYap";
            this.button_girisYap.Size = new System.Drawing.Size(284, 88);
            this.button_girisYap.TabIndex = 0;
            this.button_girisYap.Text = "Giriş Yap";
            this.button_girisYap.UseVisualStyleBackColor = true;
            this.button_girisYap.Click += new System.EventHandler(this.button_girisYap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanici Ad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Kullanici_ad
            // 
            this.textBox_Kullanici_ad.Location = new System.Drawing.Point(155, 23);
            this.textBox_Kullanici_ad.Name = "textBox_Kullanici_ad";
            this.textBox_Kullanici_ad.Size = new System.Drawing.Size(208, 20);
            this.textBox_Kullanici_ad.TabIndex = 2;
            this.textBox_Kullanici_ad.Text = "ergec";
            this.textBox_Kullanici_ad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_kullanici_sifre
            // 
            this.textBox_kullanici_sifre.Location = new System.Drawing.Point(155, 55);
            this.textBox_kullanici_sifre.Name = "textBox_kullanici_sifre";
            this.textBox_kullanici_sifre.PasswordChar = '*';
            this.textBox_kullanici_sifre.Size = new System.Drawing.Size(208, 20);
            this.textBox_kullanici_sifre.TabIndex = 2;
            this.textBox_kullanici_sifre.Text = "ergec";
            this.textBox_kullanici_sifre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(101, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sifre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_Kayit
            // 
            this.button_Kayit.Location = new System.Drawing.Point(12, 94);
            this.button_Kayit.Name = "button_Kayit";
            this.button_Kayit.Size = new System.Drawing.Size(61, 88);
            this.button_Kayit.TabIndex = 0;
            this.button_Kayit.Text = "Kayit";
            this.button_Kayit.UseVisualStyleBackColor = true;
            this.button_Kayit.Click += new System.EventHandler(this.button_Kayit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 88);
            this.button1.TabIndex = 0;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(441, 202);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_kullanici_sifre);
            this.Controls.Add(this.textBox_Kullanici_ad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Kayit);
            this.Controls.Add(this.button_girisYap);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(457, 241);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(457, 241);
            this.Name = "GirisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoşgeldiniz! Giriş Ekranı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_girisYap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Kullanici_ad;
        private System.Windows.Forms.TextBox textBox_kullanici_sifre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Kayit;
        private System.Windows.Forms.Button button1;
    }
}

