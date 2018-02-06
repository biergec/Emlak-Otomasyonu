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
    public partial class SatilanKiralananEvler : Form
    {
        public SatilanKiralananEvler()
        {
            InitializeComponent();
        }

        public static string evDurumuSorgu = "", kiraDurumu = "";
        public void GenelRadioButonKontrolu()
        {
            if (radioButton_kiralik_ev.Checked == true)
                kiraDurumu = "kiralik";

            if (radioButton_satilik_ev.Checked == true)
                kiraDurumu = "satilik";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GenelRadioButonKontrolu();
                Sorgula();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void Sorgula()
        {
            using (emlakDBEntities context = new emlakDBEntities())
            {
                if (radioButton_kiralik_ev.Checked == true)
                {
                    var kisi_ev_sorgula_kiralik = (from x in context.Evs
                                                   join y in context.Musteris on x.emlakNumarasi equals y.emlakNumarasi
                                                   join z in context.KiralikEvs on y.emlakNumarasi equals z.emlakNumarasi
                                                   where x.evDurumu == "pasif"
                                                   select new
                                                   {
                                                       x.emlakNumarasi,
                                                       x.evTuru,
                                                       y.tc,
                                                       y.ad,
                                                       y.soyad,
                                                       y.telefonNo,
                                                       y.mail,
                                                       y.adres,
                                                       x.il,
                                                       x.ilce,
                                                       x.semt,
                                                       x.toplamEvAlani,
                                                       x.yapimTarihi,
                                                       x.odaSayisi,
                                                       z.depozito,
                                                       z.kira
                                                   }).ToList();
                    dataGridView_sorgulama.DataSource = kisi_ev_sorgula_kiralik;
                    DatagridviewIsimlendirme(kiraDurumu);
                }

                if (radioButton_satilik_ev.Checked == true)
                {
                    var kisi_ev_sorgula_satilik = (from x in context.Evs
                                                   join y in context.Musteris on x.emlakNumarasi equals y.emlakNumarasi
                                                   join z in context.SatilikEvs on y.emlakNumarasi equals z.emlakNumarasi
                                                   where x.evDurumu== "pasif"
                                                   select new
                                                   {
                                                       x.emlakNumarasi,
                                                       x.evTuru,
                                                       y.tc,
                                                       y.ad,
                                                       y.soyad,
                                                       y.telefonNo,
                                                       y.mail,
                                                       y.adres,
                                                       x.il,
                                                       x.ilce,
                                                       x.semt,
                                                       x.toplamEvAlani,
                                                       x.yapimTarihi,
                                                       x.odaSayisi,
                                                       z.fiyat,
                                                   }).ToList();
                    dataGridView_sorgulama.DataSource = kisi_ev_sorgula_satilik;
                    DatagridviewIsimlendirme(kiraDurumu);
                }
            }
        }

        private void DatagridviewIsimlendirme(string kiraDurumu)
        {
            if (kiraDurumu == "kiralik")
            {
                dataGridView_sorgulama.Columns[0].HeaderText = "Emlak Numarasi";
                dataGridView_sorgulama.Columns[1].HeaderText = "Ev Türü";
                dataGridView_sorgulama.Columns[2].HeaderText = "TC";
                dataGridView_sorgulama.Columns[3].HeaderText = "Ad";
                dataGridView_sorgulama.Columns[4].HeaderText = "Soyad";
                dataGridView_sorgulama.Columns[5].HeaderText = "Telen No";
                dataGridView_sorgulama.Columns[6].HeaderText = "Mail";
                dataGridView_sorgulama.Columns[7].HeaderText = "Adres";
                dataGridView_sorgulama.Columns[8].HeaderText = "İl";
                dataGridView_sorgulama.Columns[9].HeaderText = "İlçe";
                dataGridView_sorgulama.Columns[10].HeaderText = "Semt";
                dataGridView_sorgulama.Columns[11].HeaderText = "Toplam Ev Alani";
                dataGridView_sorgulama.Columns[12].HeaderText = "Yapim Tarihi";
                dataGridView_sorgulama.Columns[13].HeaderText = "Oda Sayisi";
                dataGridView_sorgulama.Columns[14].HeaderText = "Depozito";
                dataGridView_sorgulama.Columns[15].HeaderText = "Kira";
            }
            if (kiraDurumu == "satilik")
            {
                dataGridView_sorgulama.Columns[0].HeaderText = "Emlak Numarasi";
                dataGridView_sorgulama.Columns[1].HeaderText = "Ev Türü";
                dataGridView_sorgulama.Columns[2].HeaderText = "TC";
                dataGridView_sorgulama.Columns[3].HeaderText = "Ad";
                dataGridView_sorgulama.Columns[4].HeaderText = "Soyad";
                dataGridView_sorgulama.Columns[5].HeaderText = "Telen No";
                dataGridView_sorgulama.Columns[6].HeaderText = "Mail";
                dataGridView_sorgulama.Columns[7].HeaderText = "Adres";
                dataGridView_sorgulama.Columns[8].HeaderText = "İl";
                dataGridView_sorgulama.Columns[9].HeaderText = "İlçe";
                dataGridView_sorgulama.Columns[10].HeaderText = "Semt";
                dataGridView_sorgulama.Columns[11].HeaderText = "Toplam Ev Alani";
                dataGridView_sorgulama.Columns[12].HeaderText = "Yapim Tarihi";
                dataGridView_sorgulama.Columns[13].HeaderText = "Oda Sayisi";
                dataGridView_sorgulama.Columns[14].HeaderText = "Fiyat";
            }
        }

        //Yazdırma işlemi değişkenleri
        StringFormat strFormat;
        System.Collections.ArrayList arrColumnLefts = new System.Collections.ArrayList();
        System.Collections.ArrayList arrColumnWidths = new System.Collections.ArrayList();
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
                    foreach (DataGridViewColumn GridCol in dataGridView_sorgulama.Columns)
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

                while (iRow <= dataGridView_sorgulama.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView_sorgulama.Rows[iRow];

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

                            e.Graphics.DrawString("Kullanici ve Ev Bilgileri", new Font(dataGridView_sorgulama.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Kullanici ve Ev Bilgileri", new Font(dataGridView_sorgulama.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(dataGridView_sorgulama.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView_sorgulama.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Kullanici ve Ev Bilgileri", new Font(new Font(dataGridView_sorgulama.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView_sorgulama.Columns)
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

        private void button_yazdir_Click(object sender, EventArgs e)
        {
            if (dataGridView_sorgulama.ColumnCount > 0)
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

        private void button_onizleme_Click(object sender, EventArgs e)
        {
            if (dataGridView_sorgulama.ColumnCount > 0)
            {
                PrintPreviewDialog onizleme = new PrintPreviewDialog();
                onizleme.Document = printDocument1;
                onizleme.ShowDialog();
            }
            else
                MessageBox.Show("Lütfen Öncelikle Sorgulama Yapınız.");
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
                foreach (DataGridViewColumn dgvGridCol in dataGridView_sorgulama.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
