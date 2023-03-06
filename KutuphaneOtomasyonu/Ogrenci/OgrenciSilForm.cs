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
    public partial class OgrenciSilForm : Form
    {
        public OgrenciSilForm()
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
        private void KullaniciSilForm_Load(object sender, EventArgs e)
        {
           Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId =Convert.ToInt16 (dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici =db.Ogrenciler.Where(x=>x.ogrenci_id==secilenId).FirstOrDefault();
            db.Ogrenciler.Remove(kullanici);
            db.SaveChanges();
            Listele();
        }
    }
}
