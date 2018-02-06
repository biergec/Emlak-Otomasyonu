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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button_Ev_Ekleme_Click(object sender, EventArgs e)
        {
            SingletonClassEvEkleme.MainMenuEvEkleme().Show();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {

        }

        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Kapatmak İstediğinize Emin Misiniz?", "Kapattığınız Taktirde Uygulamadan Çıkacaksınız!", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            else
                return;
        }

        private void button_Ev_Sorgulama_Click(object sender, EventArgs e)
        {
            SingletonClassEvSorgulamaListeleme.SorgulamaEkraniAc().Show();
        }

        private void button_Satilan_kiralanan_evler_Click(object sender, EventArgs e)
        {
            SinglethonClassMusteriSorgu.SorgulamaEkraniAc().Show();
        }
    }
}
