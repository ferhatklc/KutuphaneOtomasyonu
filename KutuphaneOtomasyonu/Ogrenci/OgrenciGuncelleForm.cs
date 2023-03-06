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
    public partial class OgrenciGuncelleForm : Form
    {
        public OgrenciGuncelleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
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
        private void KullaniciGuncelleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            kullaniciAdtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kullaniciSoyadtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ogrencitctxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16( dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici =db.Ogrenciler.Where(x=>x.ogrenci_id==secilenId).FirstOrDefault();
            kullanici.ogrenci_ad = kullaniciAdtxt.Text;
            kullanici.ogrenci_soyad = kullaniciSoyadtxt.Text;
            kullanici.ogrenci_sinif = Convert.ToInt16(comboBox1.Text);
            kullanici.ogrenci_tc = ogrencitctxt.Text;



            db.SaveChanges();
            Listele();
        }
        
    }
}
