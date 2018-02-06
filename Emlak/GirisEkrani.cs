using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Emlak.Kayit;
using Microsoft.VisualBasic;

namespace Emlak
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        public void ThisEnabled()
        {
            this.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_girisYap_Click(object sender, EventArgs e)
        {
            if (textBox_Kullanici_ad.Text == "")
            {
                MessageBox.Show("Kullanıcı Ad Boş Olamaz");
                return;
            }
            else if (textBox_kullanici_sifre.Text=="")
            {
                MessageBox.Show("Kullanıcı Şifre Boş Olamaz");
                return;
            }

            if (UygulamaGirisYetkiKontrol())
            {
                AnaMenu x = new AnaMenu();
                x.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre Girdiniz");
        }

        private bool UygulamaGirisYetkiKontrol()
        {
            using (emlakDBEntities context=new emlakDBEntities())
            {
                Kullanici kDBKontrol = context.Kullanicis.Where(k => k.kullaniciAd == textBox_Kullanici_ad.Text).Where(k2 => k2.kullaniciSifre == textBox_kullanici_sifre.Text).FirstOrDefault<Kullanici>();
                if (kDBKontrol != null)
                    return true;
                // kullanıcı yok ise false geri döner
                return false;
            }
        }

        private void button_Kayit_Click(object sender, EventArgs e)
        {
            if (KayitButonuYetkiliKullanıcıKontrolü())
            {
                Kayit k = new Kayit();
                k.EnableStatusChange += new EnabledStatus(ThisEnabled);
                this.Enabled = false;
                k.Show();
            }else
                MessageBox.Show("Yetkisiz Kullanıcı");
        }

        private bool KayitButonuYetkiliKullanıcıKontrolü()
        {
            string sifreYetkiKontrolu = Interaction.InputBox("Yetki Kontrolü İçin Lütfen Şifreyi Giriniz","Yetkilendirme Kontrol");
            using (emlakDBEntities context = new emlakDBEntities())
            {
                Kullanici kDb = context.Kullanicis.Where(k => k.kullaniciAd=="Admin").Where(k=>k.kullaniciSifre==sifreYetkiKontrolu.ToString()).FirstOrDefault<Kullanici>();
                if (kDb!=null)
                    return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
