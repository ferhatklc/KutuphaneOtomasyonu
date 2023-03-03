using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class Form1 : Form
    {
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void personelGirisbtn_Click(object sender, EventArgs e)
        {

            string gelenAd = adGiristxt.Text;
            string gelenSifre = sifreGiristxt.Text;

            var personel = db.Personeller.Where(x => x.personel_ad.Equals(gelenAd) && x.personel_sifre.Equals(gelenSifre)).FirstOrDefault();


            if (personel == null)
            {


                MessageBox.Show("Kullanıcı adı veya şifre yanlış");

            }
            else {
                MessageBox.Show("Giriş Başarılı ");


                İşlemPaneli panel = new İşlemPaneli();
                panel.Show();
                this.Hide();

            }

        }
    }
}
