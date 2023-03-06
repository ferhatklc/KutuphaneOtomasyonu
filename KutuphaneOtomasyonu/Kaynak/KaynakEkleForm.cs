using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kaynak
{
    public partial class KaynakEkleForm : Form
    {
        public KaynakEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db=new KutuphaneOtomasyonuEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Kaynaklar kaynaklar = new Kaynaklar();
            kaynaklar.kaynak_ad = adKaynaktxt.Text;
            kaynaklar.kaynak_yazar = yazarKaynaktxt.Text;
            kaynaklar.kaynak_sayfasayisi=Convert.ToInt16( comboBox1.Text);
            db.Kaynaklar.Add(kaynaklar);
            db.SaveChanges();

            var kliste = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kliste.ToList();


            //0. ve 4. kolonları görünmez yaptık 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            //sütün isimlerini değiştirdik 
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Kitap Sayfa Sayısı";



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KaynakEkleForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
