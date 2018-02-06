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
    public partial class MusteriEvSatis : Form
    {
        public string e_emlakNo { get; set; }
        public string e_ev_turu { get; set; }
        public string e_ev_alani { get; set; }
        public string e_oda_sayisi { get; set; }
        public string e_ev_durumu { get; set; }
        public string e_adres { get; set; }

        private void MusteriEvSatis_Load(object sender, EventArgs e)
        {
            try
            {
                if (e_emlakNo == "")
                {
                    MessageBox.Show("Emlak No Bulunamadı, Kapatılıyor.");
                    this.Close();
                }
                EvBilgileriYukleme();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void EvBilgileriYukleme()
        {
            textBox_e_emlak_no.Text = e_emlakNo;
            textBox_e_ev_turu.Text = e_ev_turu;
            textBox_e_toplam_alan.Text = e_ev_alani;
            textBox_e_oda_sayisi.Text = e_oda_sayisi;
            textBox_e_adres.Text = e_adres;
            textBox_e_durum.Text = e_ev_durumu;
        }

        public MusteriEvSatis()
        {
            InitializeComponent();
        }

        private void button_musteri_resim_yukleme_Click(object sender, EventArgs e)
        {
            ResimSec();
        }

        private void ResimSec()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Resim Seç";
            fd.Filter = "(*.jpg)|*.jpg | (*.png)|*.png";
            if (fd.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox_musteri_resim.Image = new Bitmap(fd.OpenFile());
            }
        }

        private void button_musteri_ev_satis_Click(object sender, EventArgs e)
        {
            if (textBox_m_tc.Text!="" && textBox_m_ad.Text != "" && textBox_m_soyad.Text != "" && textBox_m_telefon_no.Text != ""  && textBox_m_adres.Text != "")
            {
                try
                {
                    DialogResult result = MessageBox.Show("İşlemi Onaylıyor Musunuz?", "İşlem Onaylama", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int e_emlakNo_new = Convert.ToInt32(textBox_e_emlak_no.Text);
                        EvSatisYapMusteriTablosuEkleme(e_emlakNo_new);
                        EvSatisYapEvDurumuDegistirme(e_emlakNo_new);
                        MessageBox.Show("Kayit Başarılı.");
                        this.Close();
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.ToString());
                }
            }
            else
                MessageBox.Show("Lütfen Tüm Müşteri Bilgilerini Doldurunuz.");
        }

        private void EvSatisYapEvDurumuDegistirme(int e_emlakNo_new)
        {
            using (emlakDBEntities context=new emlakDBEntities())
            {
                var ev_durumu_degistir = context.Evs.Where(x => x.emlakNumarasi == e_emlakNo_new).First();

                ev_durumu_degistir.evDurumu = "pasif";
                context.SaveChanges();
            }
        }

        private void EvSatisYapMusteriTablosuEkleme(int e_emlakNo_textbox)
        {
            int tc_no = Convert.ToInt32(textBox_m_tc.Text);
            int tel_no = Convert.ToInt32(textBox_m_telefon_no.Text);
            using (emlakDBEntities context=new emlakDBEntities())
            {
                Musteri satis = context.Musteris.Add(new Musteri {
                    emlakNumarasi = e_emlakNo_textbox,
                    tc = tc_no,
                    ad = textBox_m_ad.Text,
                    soyad=textBox_m_soyad.Text,
                    telefonNo= tel_no,
                    mail=textBox_m_mail.Text,
                    adres=textBox_m_adres.Text
                });
                context.SaveChanges();
            }
            MessageBox.Show("Bilgiler Kaydedildi.");
        }

        private void textBox_m_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_m_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
             && !char.IsSeparator(e.KeyChar);
        }
    }
}
