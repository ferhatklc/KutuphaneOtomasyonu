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
    public partial class OgrenciEkleForm : Form
    {
        public OgrenciEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenciler kullanicilar = new Ogrenciler();
            kullanicilar.ogrenci_ad =kullaniciAdtxt.Text;
            kullanicilar.ogrenci_soyad = kullaniciSoyadtxt.Text;
            kullanicilar.ogrenci_tc= ogrencitctxt.Text;
            kullanicilar.ogrenci_sinif = Convert.ToInt16(comboBox1.Text);
            
            

            db.Ogrenciler.Add(kullanicilar);
            db.SaveChanges();
            Listele();
            
        }
        public void Listele()
        {

            var kullanicilar = db.Ogrenciler.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            
                       //0. ve 5. kolonları  görünmez yaptık
                       dataGridView1.Columns[0].Visible = false;
                       dataGridView1.Columns[5].Visible = false;


                       dataGridView1.Columns[1].HeaderText = "Öğrenci Adı";
                       dataGridView1.Columns[2].HeaderText = "Öğrenci Soyadı";
                       dataGridView1.Columns[3].HeaderText = "Öğrenci T.C'si";
                       dataGridView1.Columns[4].HeaderText = "Öğrenci Sınıfı";

                       
        }

        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void kullaniciAdtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
