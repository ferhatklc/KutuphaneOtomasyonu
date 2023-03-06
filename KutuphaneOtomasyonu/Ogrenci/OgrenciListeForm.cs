using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class OgrenciListeForm : Form
    {
        public OgrenciListeForm()
        {
            InitializeComponent();
        }
        public void Listele() {
             
            KutuphaneOtomasyonuEntities db = new KutuphaneOtomasyonuEntities();
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
        private void KullaniciListeForm_Load(object sender, EventArgs e)
        {
            Listele(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
