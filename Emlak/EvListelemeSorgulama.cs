using System;
using System.Collections;
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
    public partial class EvListelemeSorgulama : Form
    {
        public EvListelemeSorgulama()
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

        private void EvListelemeSorgulama_Load(object sender, EventArgs e)
        {
            evtur = EvTur.Bilinmiyor;
            IlListYukleme();
            EvTurBelirleme();
            panel_sorgulama_ekrani.Hide();
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

        //il ilçeye göre sorgulama
        private void button_ev_adres_bilgi_sorgula_Click(object sender, EventArgs e)
        {
            GenelRadioButonKontrolu();

            if (comboBox_il.Text != "" && comboBox_ilce.Text=="")
            {
                AdresBilgisiIleSorgulamaIlSadece(evDurumuSorgu,kiraDurumu);
                panel_sorgulama_ekrani.Show();
            }
          
            if (comboBox_il.Text != "" && comboBox_ilce.Text != "")
            {
                AdresBilgisiIleSorgulamaIlIlce(evDurumuSorgu, kiraDurumu);
                panel_sorgulama_ekrani.Show();
            }
        }


        private void DatagridviewIsimlendirme(string kiraDurumu)
        {
            if (kiraDurumu=="kiralik")
            {
                dataGridView_sorgulama_sonuc.Columns[0].HeaderText = "Emlak Numarasi";
                dataGridView_sorgulama_sonuc.Columns[1].HeaderText = "Ev Türü";
                dataGridView_sorgulama_sonuc.Columns[2].HeaderText = "İl";
                dataGridView_sorgulama_sonuc.Columns[3].HeaderText = "İlçe";
                dataGridView_sorgulama_sonuc.Columns[4].HeaderText = "Semt";
                dataGridView_sorgulama_sonuc.Columns[5].HeaderText = "Oda Sayisi";
                dataGridView_sorgulama_sonuc.Columns[6].HeaderText = "Toplam Ev Alani";
                dataGridView_sorgulama_sonuc.Columns[7].HeaderText = "Yapim Tarihi";
                dataGridView_sorgulama_sonuc.Columns[8].HeaderText = "Depozito";
                dataGridView_sorgulama_sonuc.Columns[9].HeaderText = "Kira";
            }
            if (kiraDurumu == "satilik")
            {
                dataGridView_sorgulama_sonuc.Columns[0].HeaderText = "Emlak Numarasi";
                dataGridView_sorgulama_sonuc.Columns[1].HeaderText = "Ev Türü";
                dataGridView_sorgulama_sonuc.Columns[2].HeaderText = "İl";
                dataGridView_sorgulama_sonuc.Columns[3].HeaderText = "İlçe";
                dataGridView_sorgulama_sonuc.Columns[4].HeaderText = "Semt";
                dataGridView_sorgulama_sonuc.Columns[5].HeaderText = "Oda Sayisi";
                dataGridView_sorgulama_sonuc.Columns[6].HeaderText = "Toplam Ev Alani";
                dataGridView_sorgulama_sonuc.Columns[7].HeaderText = "Yapim Tarihi";
                dataGridView_sorgulama_sonuc.Columns[8].HeaderText = "Fiyat";
            }
        }

        private void AdresBilgisiIleSorgulamaIlSadece(string evDurumuSorgu,string kiraDurumu)
        {
            try
            {
                using (emlakDBEntities context = new emlakDBEntities())
                {
                    if (kiraDurumu == "kiralik")
                    {
                        var sorguKiralik = (from f in context.Evs
                                            join c in context.KiralikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                            where f.il == comboBox_il.Text && f.evDurumu == evDurumuSorgu
                                            select new
                                            {
                                                f.emlakNumarasi,
                                                f.evTuru,
                                                f.il,
                                                f.ilce,
                                                f.semt,
                                                f.odaSayisi,
                                                f.toplamEvAlani,
                                                f.yapimTarihi,
                                                f.KiralikEv.depozito,
                                                f.KiralikEv.kira
                                            }).ToList();
                        panel_sorgulama_ekrani.Show();
                        dataGridView_sorgulama_sonuc.DataSource = sorguKiralik;
                        DatagridviewIsimlendirme(kiraDurumu);
                    }

                    if (kiraDurumu == "satilik")
                    {
                        var sorgusatilik = (from f in context.Evs
                                            join c in context.SatilikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                            where f.il == comboBox_il.Text && f.evDurumu == evDurumuSorgu
                                            select new
                                            {
                                                f.emlakNumarasi,
                                                f.evTuru,
                                                f.il,
                                                f.ilce,
                                                f.semt,
                                                f.odaSayisi,
                                                f.toplamEvAlani,
                                                f.yapimTarihi,
                                                f.SatilikEv.fiyat
                                            } ).ToList();
                        panel_sorgulama_ekrani.Show();
                        dataGridView_sorgulama_sonuc.DataSource = sorgusatilik;
                        DatagridviewIsimlendirme(kiraDurumu);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void AdresBilgisiIleSorgulamaIlIlce(string evDurumuSorgu,string kiraDurumu)
        {
            try
            {
                using (emlakDBEntities context = new emlakDBEntities())
                {
                    if (kiraDurumu == "kiralik")
                    {
                        var sorguKiralik = (from f in context.Evs
                                            join c in context.KiralikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                            where f.il == comboBox_il.Text && f.evDurumu == evDurumuSorgu && f.ilce == comboBox_ilce.Text
                                            select new
                                            {
                                                f.emlakNumarasi,
                                                f.evTuru,
                                                f.il,
                                                f.ilce,
                                                f.semt,
                                                f.odaSayisi,
                                                f.toplamEvAlani,
                                                f.yapimTarihi,
                                                f.KiralikEv.depozito,
                                                f.KiralikEv.kira
                                            }
                                                    ).ToList();
                        panel_sorgulama_ekrani.Show();
                        dataGridView_sorgulama_sonuc.DataSource = sorguKiralik;
                        DatagridviewIsimlendirme(kiraDurumu);
                    }

                    if (kiraDurumu == "satilik")
                    {
                        var sorgusatilik = (from f in context.Evs
                                            join c in context.SatilikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                            where f.il == comboBox_il.Text && f.evDurumu == evDurumuSorgu && f.ilce == comboBox_ilce.Text
                                            select new
                                            {
                                                f.emlakNumarasi,
                                                f.evTuru,
                                                f.il,
                                                f.ilce,
                                                f.semt,
                                                f.odaSayisi,
                                                f.toplamEvAlani,
                                                f.yapimTarihi,
                                                f.SatilikEv.fiyat
                                            }
                               ).ToList();
                        panel_sorgulama_ekrani.Show();
                        dataGridView_sorgulama_sonuc.DataSource = sorgusatilik;
                        DatagridviewIsimlendirme(kiraDurumu);
                    }
                }
            }
            catch (Exception)
            {

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

        public static string evDurumuSorgu = "", kiraDurumu = "";
        public void GenelRadioButonKontrolu()
        {
            if (radioButton_aktif.Checked == true)
                evDurumuSorgu = "aktif";

            if (radioButton_pasif.Checked == true)
                evDurumuSorgu = "pasif";

            if (radioButton_kiralik_ev.Checked == true)
                kiraDurumu = "kiralik";

            if (radioButton_satilik_ev.Checked == true)
                kiraDurumu = "satilik";
        }

        private void button_ev_durum_bilgisi_sorgula_Click(object sender, EventArgs e)
        {
            try
            {
                GenelRadioButonKontrolu();
                EvDurumBilgisineGoreSorgula(kiraDurumu, evDurumuSorgu);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void EvDurumBilgisineGoreSorgula(string kiraDurumu, string evDurumuSorgu)
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                if (kiraDurumu == "kiralik")
                {
                    var sorguKiralik = (from f in context.Evs
                                        join c in context.KiralikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                        where f.evDurumu == evDurumuSorgu
                                        select new
                                        {
                                            f.emlakNumarasi,
                                            f.evTuru,
                                            f.il,
                                            f.ilce,
                                            f.semt,
                                            f.odaSayisi,
                                            f.toplamEvAlani,
                                            f.yapimTarihi,
                                            f.KiralikEv.depozito,
                                            f.KiralikEv.kira
                                        }).ToList();
                    panel_sorgulama_ekrani.Show();
                    dataGridView_sorgulama_sonuc.DataSource = sorguKiralik;
                    DatagridviewIsimlendirme(kiraDurumu);
                }

                if (kiraDurumu == "satilik")
                {
                    var sorgusatilik = (from f in context.Evs
                                        join c in context.SatilikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                        where f.evDurumu == evDurumuSorgu
                                        select new
                                        {
                                            f.emlakNumarasi,
                                            f.evTuru,
                                            f.il,
                                            f.ilce,
                                            f.semt,
                                            f.odaSayisi,
                                            f.toplamEvAlani,
                                            f.yapimTarihi,
                                            f.SatilikEv.fiyat
                                        }).ToList();
                    panel_sorgulama_ekrani.Show();
                    dataGridView_sorgulama_sonuc.DataSource = sorgusatilik;
                    DatagridviewIsimlendirme(kiraDurumu);
                }
            }
        }

        private void button_genelEvVilgileri_sorgula_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_oda_sayisi.Text != "" && textBox_toplam_alan.Text != "" && comboBox_ev_turu.Text != "")
                {
                    GenelRadioButonKontrolu();
                    GenelEvBilgilerineGoreSorgulama(kiraDurumu, evDurumuSorgu);
                }
                else
                    MessageBox.Show("Lütfen Genel Ev Bilgileri Alanı Kriterler İle Doldurunuz");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void GenelEvBilgilerineGoreSorgulama(string kiraDurumu, string evDurumuSorgu)
        {
            int t_ev_alan=0, t_oda_sayisi = 0;
            string t_ev_turu = "";
            if (textBox_toplam_alan.Text!="")
                t_ev_alan = Convert.ToInt32(textBox_toplam_alan.Text);
            if(textBox_oda_sayisi.Text!="")
                t_oda_sayisi = Convert.ToInt32(textBox_oda_sayisi.Text);
            if(comboBox_ev_turu.Text!="")
                t_ev_turu = comboBox_ev_turu.Text;

            using (emlakDBEntities context = new emlakDBEntities())
            {
                if (kiraDurumu == "kiralik")
                {
                    if (textBox_oda_sayisi.Text != "" && textBox_toplam_alan.Text != "" && comboBox_ev_turu.Text != "")
                    {
                        var sorguKiralik = (from f in context.Evs
                                            join c in context.SatilikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                            where f.evDurumu == evDurumuSorgu && f.toplamEvAlani >= t_ev_alan && f.odaSayisi >= t_oda_sayisi && f.evTuru == t_ev_turu
                                            select new
                                            {
                                                f.emlakNumarasi,
                                                f.evTuru,
                                                f.il,
                                                f.ilce,
                                                f.semt,
                                                f.odaSayisi,
                                                f.toplamEvAlani,
                                                f.yapimTarihi,
                                                f.KiralikEv.depozito,
                                                f.KiralikEv.kira
                                            }).ToList();
                        panel_sorgulama_ekrani.Show();
                        dataGridView_sorgulama_sonuc.DataSource = sorguKiralik;
                    }
                }

                if (kiraDurumu == "satilik")
                {
                    var sorgusatilik = (from f in context.Evs
                                        join c in context.SatilikEvs on f.emlakNumarasi equals c.emlakNumarasi
                                        where f.evDurumu == evDurumuSorgu && f.toplamEvAlani >= t_ev_alan && f.odaSayisi >= t_oda_sayisi  && f.evTuru== t_ev_turu
                                        select new
                                        {
                                            f.emlakNumarasi,
                                            f.evTuru,
                                            f.il,
                                            f.ilce,
                                            f.semt,
                                            f.odaSayisi,
                                            f.toplamEvAlani,
                                            f.yapimTarihi,
                                            f.SatilikEv.fiyat
                                        }
                            ).ToList();
                    panel_sorgulama_ekrani.Show();
                    dataGridView_sorgulama_sonuc.DataSource = sorgusatilik;
                }
            }
        }

        //Yazdırma işlemi değişkenleri
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView_sorgulama_sonuc.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;


                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= dataGridView_sorgulama_sonuc.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView_sorgulama_sonuc.Rows[iRow];

                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            e.Graphics.DrawString("Ev Bilgileri", new Font(dataGridView_sorgulama_sonuc.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Ev Bilgileri", new Font(dataGridView_sorgulama_sonuc.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(dataGridView_sorgulama_sonuc.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView_sorgulama_sonuc.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Ev Bilgileri", new Font(new Font(dataGridView_sorgulama_sonuc.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView_sorgulama_sonuc.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;

                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }

                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }


                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView_sorgulama_sonuc.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Yazdir_Click(object sender, EventArgs e)
        {
            if (dataGridView_sorgulama_sonuc.ColumnCount > 0)
            {
                PrintDialog yazdir = new PrintDialog();
                yazdir.Document = printDocument1;
                yazdir.UseEXDialog = true;
                if (yazdir.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
            }
            else
                MessageBox.Show("Lütfen Öncelikle Sorgulama Yapınız.");
        }

        private void button_duzenle_Click(object sender, EventArgs e)
        {
            string seciliSatir = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["emlakNumarasi"].Value.ToString();
            if (seciliSatir != null)
            {
                EvDuzenleme e_duzenleme = new EvDuzenleme();
                e_duzenleme.emlak_numarasi_form_aktarma = seciliSatir;
                e_duzenleme.Show();
            }
            else
                MessageBox.Show("Lütfen Bir Sonuç Seçiniz");
        }

        private void button_ev_silme_Click(object sender, EventArgs e)
        {
            try
            {
                EvSilmeİslemleri();
                
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void EvSilmeİslemleri()
        {
            string seciliSatir_emlak_no = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["emlakNumarasi"].Value.ToString();
            if (seciliSatir_emlak_no != null)
            {
                int emlak_no_convert = Convert.ToInt32(seciliSatir_emlak_no);
                DialogResult result = MessageBox.Show("Seçili Evi Silmek İstediğinize Emin Misiniz?", "Ev Silme İşlemi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (emlakDBEntities context = new emlakDBEntities())
                    {
                        var ev_silme = context.Evs.Where(x => x.emlakNumarasi == emlak_no_convert).First();
                        context.Evs.Remove(ev_silme);

                        try
                        {
                            // Kiralik Ev İçin İşlemler
                            var ev_kiralik_mi = context.KiralikEvs.Where(c => c.emlakNumarasi == emlak_no_convert).First();
                            context.KiralikEvs.Remove(ev_kiralik_mi);
                            context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            var ev_satilik_mi = context.SatilikEvs.Where(c => c.emlakNumarasi == emlak_no_convert).First();
                            context.SatilikEvs.Remove(ev_satilik_mi);
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Ev Başarılı Bir Şekilde Silindi, Lütfen Tekrar Sorgulama Yapınız");
                    dataGridView_sorgulama_sonuc.Columns.Clear();
                }
            }
            else
                MessageBox.Show("Lütfen Bir Sonuç Seçiniz");
        }

        private void button_satis_Click(object sender, EventArgs e)
        {
            try
            {
                EvSatisIslemleri();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString()); ;
            }
        }

        private void EvSatisIslemleri()
        {
            string seciliSatir_emlak_no = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["emlakNumarasi"].Value.ToString();
            if (seciliSatir_emlak_no != null)
            {
                MusteriEvSatis m_satis = new MusteriEvSatis();
                m_satis.e_emlakNo = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["emlakNumarasi"].Value.ToString();
                m_satis.e_ev_turu = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["evTuru"].Value.ToString();
                m_satis.e_ev_alani = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["toplamEvAlani"].Value.ToString();
                m_satis.e_oda_sayisi = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["odaSayisi"].Value.ToString();
                string adres_genel = dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["il"].Value.ToString() + " / " + dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["ilce"].Value.ToString() + " / " + dataGridView_sorgulama_sonuc.SelectedRows[0].Cells["semt"].Value.ToString();
                m_satis.e_adres = adres_genel;

                emlakDBEntities context = new emlakDBEntities();
                int s_emlak_no = Convert.ToInt32(seciliSatir_emlak_no);
                try
                {
                    // Kiralik Ev İçin İşlemler
                    var ev_kiralik_mi = context.KiralikEvs.Where(c => c.emlakNumarasi == s_emlak_no).First();
                    m_satis.e_ev_durumu = "Kiralik Ev";
                }
                catch (Exception)
                {
                    m_satis.e_ev_durumu = "Satilik Ev";
                }

                m_satis.Show();
            }
        }

        private void textBox_toplam_alan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button_onizleme_Click(object sender, EventArgs e)
        {
            if (dataGridView_sorgulama_sonuc.ColumnCount > 0)
            {
                PrintPreviewDialog onizleme = new PrintPreviewDialog();
                onizleme.Document = printDocument1;
                onizleme.ShowDialog();
            }
            else
                MessageBox.Show("Lütfen Öncelikle Sorgulama Yapınız.");
        }

    }
}
