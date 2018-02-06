using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class EvEkleme : Form
    {
        public enum EvTur
        {
            Bilinmiyor,
            Daire,
            Bahçeli,
            Dubleks,
            Müstakil,
            Havuzlu,
            Apart
        }

        public EvTur evtur;

        public EvEkleme()
        {
            evtur = EvTur.Bilinmiyor;
            InitializeComponent();
        }

        private void EvEkleme_Load(object sender, EventArgs e)
        {
            groupBox_kiralik_ev_.Hide();
            groupBox_satilik_ev.Show();
            IlListYukleme();
            EvTurBelirleme();
        }

        private void EvTurBelirleme()
        {
            string[] evturleri =Enum.GetNames(typeof(EvTur));
            foreach (var item in evturleri)
            {
                comboBox_ev_turu.Items.Add(item);
            }
        }

        private void IlListYukleme()
        {
            try
            {
                using (emlakDBEntities context = new emlakDBEntities())
                {
                    var data = context.illers.Select(x => x.isim);
                    foreach (var item in data)
                    {
                        comboBox_il.Items.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void comboBox_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                var data = context.il_listeleme(comboBox_il.Text.ToString());
                //yeni ilçe seçildiğinde combobox temizleniyor.
                comboBox_ilce.Items.Clear();
                foreach (var item in data)
                {
                    comboBox_ilce.Items.Add(item);
                }
            }
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            if (comboBox_il.Text == "")
            {
                MessageBox.Show("Lütfen İl Seçimi Yapınız.");
                return;
            }
            else if (comboBox_ilce.Text == "")
            {
                MessageBox.Show("Lütfen İlçe Seçimi Yapınız.");
                return;
            }
            else if (textBox_adres.Text == "")
            {
                MessageBox.Show("Lütfen Adres Bilgilerini Giriniz.");
                return;
            }
            else if (radioButton_aktif.Checked == false && radioButton_pasif.Checked == false)
            {
                MessageBox.Show("Lütfen Ev Durumunu Aktif veya Pasi Yapınız");
                return;
            }
            else if (textBox_kat_numarasi.Text == "")
            {
                MessageBox.Show("Kat Numarası Boş Olamaz.");
                return;
            }
            else if (textBox_toplam_alan.Text == "" && Convert.ToInt32(textBox_toplam_alan.Text) > 0)
            {
                MessageBox.Show("Ev Toplam Alan Boş veya 0 Olamaz.");
                return;
            }
            else if (textBox_oda_sayisi.Text == "" && Convert.ToInt32(textBox_oda_sayisi.Text) > 0)
            {
                MessageBox.Show("Ev Oda Sayisi Boş veya 0 Olamaz.");
                return;
            }
            else if (comboBox_ev_turu.Text == "")
            {
                MessageBox.Show("Ev Türü Boş Olamaz.");
                return;
            }
            else if (textBox_ev_yasi.Text=="")
            {
                MessageBox.Show("Ev Yaşı Belirlemek İçin Yapım Tarihini Giriniz.");
                return;
            }
            else if (Convert.ToInt32(textBox_ev_yasi.Text)<=0)
            {
                MessageBox.Show("Ev Yaşı 0'dan Küçük Olamaz.");
                return;
            }
            else if (radioButton_kiralik_ev.Checked == false && radioButton_satilik_ev.Checked == false)
            {
                MessageBox.Show("Lütfen Ev Tercihini Yapınız");
                return;
            }
            else if (radioButton_kiralik_ev.Checked == true)
            {
                if (textBox_kiralikEv_kira.Text == "" || Convert.ToInt32(textBox_kiralikEv_kira.Text) < 0)
                {
                    MessageBox.Show("Lütfen Ev Kira Fiyatını Giriniz. Ev Kira Fiyatı 0'dan Küçük Olamaz");
                    return;
                }
                if (textBox_kiralikEv_depozito.Text == "" || Convert.ToInt32(textBox_kiralikEv_depozito.Text) < 0)
                {
                    MessageBox.Show("Lütfen Ev Depozito Fiyatını giriniz. Ev Depozito Fiyatı 0'dan Küçük Olamaz");
                    return;
                }
            }
            else if (radioButton_satilik_ev.Checked == true)
            {
                if (textBox_satilikEv_fiyat.Text == "" || Convert.ToInt32(textBox_satilikEv_fiyat.Text) < 0)
                {
                    MessageBox.Show("Lütfen Ev Fiyatını giriniz. Ev Fiyatı 0'dan Küçük Olamaz");
                    return;
                }
            }

            try
            {
                EvKayit();
                MessageBox.Show("Ev Bilgileri Başarılı Bir Şekilde Kaydedildi. \n Ev Emlak Kayıt Numarası : "+ kaydedilen_ev_emlak_no);
                this.Close();
                EvResimleriKlasoruAc(kaydedilen_ev_emlak_no);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void EvResimleriKlasoruAc(int kaydedilen_ev_emlak_no)
        {
            try
            {
                using (emlakDBEntities context=new emlakDBEntities())
                {
                    var directory_konum = context.ayarlars.ToList();
                    var directory_konum2 = directory_konum[0].resimKonum;

                    if (!Directory.Exists(directory_konum2.ToString()))
                        Directory.CreateDirectory(directory_konum2.ToString());

                    if (!Directory.Exists(directory_konum2.ToString() + kaydedilen_ev_emlak_no))
                        Directory.CreateDirectory(kaydedilen_ev_emlak_no.ToString());

                    Process.Start(directory_konum2.ToString() + kaydedilen_ev_emlak_no);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        public static int kaydedilen_ev_emlak_no;
        private void EvKayit()
        {
            kaydedilen_ev_emlak_no = 0;

            string evDurumBilgisi = "";
            if (radioButton_aktif.Checked == true)
                evDurumBilgisi = "aktif";
            else
                evDurumBilgisi = "pasif";

            using (emlakDBEntities context = new emlakDBEntities())
            {
                    Ev ev_emlakno_id=context.Evs.Add(new Ev {
                    il = comboBox_il.Text,
                    ilce = comboBox_ilce.Text,
                    semt = textBox_adres.Text,
                    katNumarasi = Convert.ToInt32(textBox_kat_numarasi.Text),
                    toplamEvAlani = Convert.ToInt32(textBox_toplam_alan.Text),
                    odaSayisi =Convert.ToInt32(textBox_oda_sayisi.Text),
                    evTuru = comboBox_ev_turu.Text,
                    yapimTarihi = Convert.ToDateTime(dateTimePicker_ev_yapim_tarihi.Text),
                    evDurumu = evDurumBilgisi});

                if (radioButton_satilik_ev.Checked == true)
                {
                    context.SatilikEvs.Add(new SatilikEv { fiyat=Convert.ToInt32(textBox_satilikEv_fiyat.Text), emlakNumarasi = ev_emlakno_id.emlakNumarasi});
                    context.SaveChanges();
                    kaydedilen_ev_emlak_no = ev_emlakno_id.emlakNumarasi;
                }
                else
                {
                    context.KiralikEvs.Add(new KiralikEv { kira = Convert.ToInt32(textBox_kiralikEv_kira.Text), emlakNumarasi = ev_emlakno_id.emlakNumarasi,depozito=Convert.ToInt32(textBox_kiralikEv_depozito.Text) });
                    context.SaveChanges();
                }
            }
        }

        private void radioButton_satilik_ev_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_kiralik_ev_.Hide();
            groupBox_satilik_ev.Show();
        }

        private void radioButton_kiralik_ev_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_satilik_ev.Hide();
            groupBox_kiralik_ev_.Show();
        }

        private void dateTimePicker_ev_yapim_tarihi_ValueChanged(object sender, EventArgs e)
        {
            EvYasHesaplama();
        }

        private void EvYasHesaplama()
        {
            TimeSpan ts;
            ts = DateTime.Now- Convert.ToDateTime(dateTimePicker_ev_yapim_tarihi.Text);
            textBox_ev_yasi.Text = ts.Days.ToString();
        }

        private void button_ev_resimleri_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ev Resimlerini Eklemek İçin Lütfen Öncelikle Ev'i Kayıt Edin. Daha Sonra Resimleri Koymanız Gereken Klasör Otomatik Olarak Açılacaktır.");
        }

        private void radioButton_kiralik_ev_CheckedChanged_1(object sender, EventArgs e)
        {
            groupBox_satilik_ev.Hide();
            groupBox_kiralik_ev_.Show();
        }

        private void textBox_adres_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
              && !char.IsSeparator(e.KeyChar);
        }

        private void textBox_kat_numarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
