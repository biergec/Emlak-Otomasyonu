namespace Emlak
{
    partial class SatilanKiralananEvler
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
            this.dataGridView_sorgulama = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_onizleme = new System.Windows.Forms.Button();
            this.button_yazdir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_ev_tercihi = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton_kiralik_ev = new System.Windows.Forms.RadioButton();
            this.radioButton_satilik_ev = new System.Windows.Forms.RadioButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sorgulama)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_ev_tercihi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_sorgulama
            // 
            this.dataGridView_sorgulama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sorgulama.Location = new System.Drawing.Point(6, 40);
            this.dataGridView_sorgulama.Name = "dataGridView_sorgulama";
            this.dataGridView_sorgulama.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_sorgulama.Size = new System.Drawing.Size(704, 302);
            this.dataGridView_sorgulama.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_onizleme);
            this.groupBox1.Controls.Add(this.button_yazdir);
            this.groupBox1.Controls.Add(this.dataGridView_sorgulama);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 438);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button_onizleme
            // 
            this.button_onizleme.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_onizleme.Location = new System.Drawing.Point(197, 348);
            this.button_onizleme.Name = "button_onizleme";
            this.button_onizleme.Size = new System.Drawing.Size(185, 84);
            this.button_onizleme.TabIndex = 5;
            this.button_onizleme.Text = "Yazdırma Önizleme";
            this.button_onizleme.UseVisualStyleBackColor = false;
            this.button_onizleme.Click += new System.EventHandler(this.button_onizleme_Click);
            // 
            // button_yazdir
            // 
            this.button_yazdir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_yazdir.Location = new System.Drawing.Point(6, 348);
            this.button_yazdir.Name = "button_yazdir";
            this.button_yazdir.Size = new System.Drawing.Size(185, 84);
            this.button_yazdir.TabIndex = 5;
            this.button_yazdir.Text = "Yazdir";
            this.button_yazdir.UseVisualStyleBackColor = false;
            this.button_yazdir.Click += new System.EventHandler(this.button_yazdir_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(702, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bilgilendirme";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_ev_tercihi
            // 
            this.groupBox_ev_tercihi.Controls.Add(this.button1);
            this.groupBox_ev_tercihi.Controls.Add(this.radioButton_kiralik_ev);
            this.groupBox_ev_tercihi.Controls.Add(this.radioButton_satilik_ev);
            this.groupBox_ev_tercihi.Location = new System.Drawing.Point(12, 9);
            this.groupBox_ev_tercihi.Name = "groupBox_ev_tercihi";
            this.groupBox_ev_tercihi.Size = new System.Drawing.Size(716, 76);
            this.groupBox_ev_tercihi.TabIndex = 15;
            this.groupBox_ev_tercihi.TabStop = false;
            this.groupBox_ev_tercihi.Text = "Ev Tercihi";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(230, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(480, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Sorgula";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton_kiralik_ev
            // 
            this.radioButton_kiralik_ev.AutoSize = true;
            this.radioButton_kiralik_ev.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton_kiralik_ev.Location = new System.Drawing.Point(126, 28);
            this.radioButton_kiralik_ev.Name = "radioButton_kiralik_ev";
            this.radioButton_kiralik_ev.Size = new System.Drawing.Size(88, 23);
            this.radioButton_kiralik_ev.TabIndex = 5;
            this.radioButton_kiralik_ev.Text = "Kiralik Ev";
            this.radioButton_kiralik_ev.UseVisualStyleBackColor = true;
            // 
            // radioButton_satilik_ev
            // 
            this.radioButton_satilik_ev.AutoSize = true;
            this.radioButton_satilik_ev.Checked = true;
            this.radioButton_satilik_ev.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton_satilik_ev.Location = new System.Drawing.Point(12, 28);
            this.radioButton_satilik_ev.Name = "radioButton_satilik_ev";
            this.radioButton_satilik_ev.Size = new System.Drawing.Size(84, 23);
            this.radioButton_satilik_ev.TabIndex = 5;
            this.radioButton_satilik_ev.TabStop = true;
            this.radioButton_satilik_ev.Text = "Satilik Ev";
            this.radioButton_satilik_ev.UseVisualStyleBackColor = true;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // SatilanKiralananEvler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 523);
            this.Controls.Add(this.groupBox_ev_tercihi);
            this.Controls.Add(this.groupBox1);
            this.Name = "SatilanKiralananEvler";
            this.Text = "Satilan, Kiralanan Evleri Sorgulama";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sorgulama)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox_ev_tercihi.ResumeLayout(false);
            this.groupBox_ev_tercihi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_sorgulama;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_onizleme;
        private System.Windows.Forms.Button button_yazdir;
        private System.Windows.Forms.GroupBox groupBox_ev_tercihi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton_kiralik_ev;
        private System.Windows.Forms.RadioButton radioButton_satilik_ev;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}