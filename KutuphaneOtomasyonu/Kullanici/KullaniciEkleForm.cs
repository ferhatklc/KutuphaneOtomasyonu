using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kullanici
{
    public partial class KullaniciEkleForm : Form
    {
        public KullaniciEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Kullanicilar kullanicilar = new Kullanicilar();
            kullanicilar.kullanici_ad =kullaniciAdtxt.Text;
            kullanicilar.kullanici_soyad=kullaniciSoyadtxt.Text;
            kullanicilar.kullanici_sinif = Convert.ToInt16(comboBox1.Text);
            

            db.Kullanicilar.Add(kullanicilar);
            db.SaveChanges();
            Listele();
            
        }
        public void Listele()
        {

            var kullanicilar = db.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
        }

        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
