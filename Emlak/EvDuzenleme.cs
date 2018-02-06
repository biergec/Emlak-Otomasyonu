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
    public partial class EvDuzenleme : Form
    {
        public string emlak_numarasi_form_aktarma { get; set; }

        public EvDuzenleme()
        {
            InitializeComponent();
        }

        public EvTur evtur;
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

        private void EvDuzenleme_Load(object sender, EventArgs e)
        {
            evtur = EvTur.Bilinmiyor;
            IlListYukleme();
            EvTurBelirleme();
            label_emlak_numarasi.Text = emlak_numarasi_form_aktarma;
            EvBilgileriIilkGirisYukleme(Convert.ToInt32(emlak_numarasi_form_aktarma));
            EvYasHesaplama();
        }
        private void EvTurBelirleme()
        {
            string[] evturleri = Enum.GetNames(typeof(EvTur));
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

        private void EvBilgileriIilkGirisYukleme(int emlak_numarasi_form_)
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                var ev_bilgileri_kayitli = context.Evs.Where(x => x.emlakNumarasi == emlak_numarasi_form_).First();
                comboBox_il.Text = ev_bilgileri_kayitli.il;
                comboBox_ilce.Text = ev_bilgileri_kayitli.ilce;
                textBox_adres.Text = ev_bilgileri_kayitli.semt;
                textBox_kat_numarasi.Text = ev_bilgileri_kayitli.katNumarasi.ToString();
                textBox_toplam_alan.Text = ev_bilgileri_kayitli.toplamEvAlani.ToString();
                textBox_oda_sayisi.Text = ev_bilgileri_kayitli.odaSayisi.ToString();
                comboBox_ev_turu.Text = ev_bilgileri_kayitli.evTuru;
                dateTimePicker_ev_yapim_tarihi.Value = ev_bilgileri_kayitli.yapimTarihi;

                string ev_durumu = ev_bilgileri_kayitli.evDurumu.Trim();
                if (ev_durumu == "aktif")
                    radioButton_aktif.Checked = true;
                else
                    radioButton_pasif.Checked = true;

                //Ev kiralik mi, kontrol, null dönerse satilik demek
                try
                {
                    var ev_kiralik_mi = context.KiralikEvs.Where(c => c.emlakNumarasi == emlak_numarasi_form_).First();
                    // Kiralik Ev İçin İşlemler
                    radioButton_kiralik_ev.Checked = true;
                    groupBox_satilik_ev.Hide();
                    groupBox_kiralik_ev_.Show();

                    textBox_kiralikEv_kira.Text = ev_kiralik_mi.kira.ToString();
                    textBox_kiralikEv_depozito.Text = ev_kiralik_mi.depozito.ToString();
                }
                catch (Exception)
                {
                    var ev_satilik_mi = context.SatilikEvs.Where(c => c.emlakNumarasi == emlak_numarasi_form_).First();

                    radioButton_satilik_ev.Checked = true;
                    groupBox_kiralik_ev_.Hide();
                    groupBox_satilik_ev.Show();

                    textBox_satilikEv_fiyat.Text = ev_satilik_mi.fiyat.ToString();
                }
            }
        }

        private void button_ev_bilgileri_update_Click(object sender, EventArgs e)
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
            else if (textBox_ev_yasi.Text == "")
            {
                MessageBox.Show("Ev Yaşı Belirlemek İçin Yapım Tarihini Giriniz.");
                return;
            }
            else if (Convert.ToInt32(textBox_ev_yasi.Text) <= 0)
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
                int emlak_no_update =Convert.ToInt32(label_emlak_numarasi.Text);
                EvUpdate(emlak_no_update);
                MessageBox.Show("Ev Bilgileri Başarılı Bir Şekilde Güncellendi.");
                this.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void EvUpdate(int emlak_no_update)
        {
            string evDurumBilgisi = "";
            if (radioButton_aktif.Checked == true)
                evDurumBilgisi = "aktif";
            else
                evDurumBilgisi = "pasif";

            using (emlakDBEntities context = new emlakDBEntities())
            {
                var ev_update_ev = context.Evs.Where(x=>x.emlakNumarasi==emlak_no_update).First();
                ev_update_ev.il = comboBox_il.Text;
                ev_update_ev.ilce = comboBox_ilce.Text;
                ev_update_ev.semt = textBox_adres.Text;
                ev_update_ev.katNumarasi = Convert.ToInt32(textBox_kat_numarasi.Text);
                ev_update_ev.toplamEvAlani = Convert.ToInt32(textBox_toplam_alan.Text);
                ev_update_ev.odaSayisi = Convert.ToInt32(textBox_oda_sayisi.Text);
                ev_update_ev.evTuru = comboBox_ev_turu.Text;
                ev_update_ev.yapimTarihi = Convert.ToDateTime(dateTimePicker_ev_yapim_tarihi.Text);
                ev_update_ev.evDurumu = evDurumBilgisi;

                if (radioButton_satilik_ev.Checked == true)
                {
                    var ev_update_Satilik_ev = context.SatilikEvs.Where(y => y.emlakNumarasi == emlak_no_update).First();
                    ev_update_Satilik_ev.fiyat = Convert.ToInt32(textBox_satilikEv_fiyat.Text);
                    context.SaveChanges();
                }
                else
                {
                    var ev_update_Kiralik_ev = context.KiralikEvs.Where(y => y.emlakNumarasi == emlak_no_update).First();
                    ev_update_Kiralik_ev.depozito = Convert.ToInt32(textBox_kiralikEv_depozito.Text);
                    ev_update_Kiralik_ev.kira = Convert.ToInt32(textBox_kiralikEv_kira.Text);
                    context.SaveChanges();
                }
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

        private void dateTimePicker_ev_yapim_tarihi_ValueChanged(object sender, EventArgs e)
        {
            EvYasHesaplama();
        }

        private void EvYasHesaplama()
        {
            TimeSpan ts;
            ts = DateTime.Now - Convert.ToDateTime(dateTimePicker_ev_yapim_tarihi.Text);
            textBox_ev_yasi.Text = ts.Days.ToString();
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

        private void button_ev_resimleri_Click(object sender, EventArgs e)
        {
            
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
