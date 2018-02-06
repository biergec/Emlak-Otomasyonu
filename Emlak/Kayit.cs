using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class Kayit : Form
    {
        // Giriş ekranını kullanılamaz hale getirmek için enabled=false işlemleri
        public delegate void EnabledStatus();
        public event EnabledStatus EnableStatusChange;

        public Kayit()
        {   
            InitializeComponent();
        }

        private void Kayit_Load(object sender, EventArgs e)
        {

        }

        private void Kayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnableStatusChange();
        }

        private void button_kayit_Click(object sender, EventArgs e)
        {
            if (textBox_kullanici_adi.Text != "" && textBox_sifre.Text != "")
            {
                string yetkiDurumu = "false";
                if (checkBox_yetkilendirme.Checked == true)
                {
                    yetkiDurumu = "true";
                }
                KullaniciEkleme(yetkiDurumu);
            }
            else
                MessageBox.Show("Kullanıcı Adi ve Şifre Boş Olamaz");
        }

        //Kullanici var ise uyarı veriyor, yok ise yeni kullanıcı oluşturma işlemleri yapılıyor.
        private void KullaniciEkleme(string yetkiDurumu)
        {
            using (emlakDBEntities dbEmlakEntity = new emlakDBEntities())
            {
                Kullanici kullanici = dbEmlakEntity.Kullanicis.FirstOrDefault(x => x.kullaniciAd == textBox_kullanici_adi.Text);
                if (kullanici != null)
                {
                    // şifre yenileme ekranı şu an da yok!
                    MessageBox.Show("Böyle Bir Kullanıcı Mevcut Şifre Yenileme Yapmalısınız!");
                    return;
                }
                else
                {
                    try
                    {
                        Kullanici k = new Kullanici
                        {
                            kullaniciAd = textBox_kullanici_adi.Text,
                            kullaniciSifre = textBox_kullanici_adi.Text,
                            yetki = yetkiDurumu
                        };
                        dbEmlakEntity.Kullanicis.Add(k);
                        dbEmlakEntity.SaveChanges();

                        DialogResult result = MessageBox.Show("Kullanici Kayit İşlemi","Kayit Başarılı, Giriş Ekranına Dönmek İstiyor Musunuz?",MessageBoxButtons.YesNo);
                        if (result==DialogResult.Yes)
                        {
                            this.Close();
                        }
                        textBox_kullanici_adi.Text = ""; textBox_sifre.Text = "";
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
        }
    }
}

