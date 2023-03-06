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
    public partial class KaynakGuncelleForm : Form
    {
        public KaynakGuncelleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db=new KutuphaneOtomasyonuEntities();
        private void KaynakGuncelleForm_Load(object sender, EventArgs e)
        {
            var kaynaklar= db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();

            //0. ve 4. kolonları görünmez yaptık 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            //sütün isimlerini değiştirdik 
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Kitap Sayfa Sayısı";

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            adKaynaktxt.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            yazarKaynaktxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString() ;
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int  seçilenKaynak = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var guncellenecekKaynak  = db.Kaynaklar.Where(x=>x.kaynak_id==seçilenKaynak).FirstOrDefault();
            guncellenecekKaynak.kaynak_ad = adKaynaktxt.Text;
            guncellenecekKaynak.kaynak_yazar = yazarKaynaktxt.Text;
            guncellenecekKaynak.kaynak_sayfasayisi= Convert.ToInt16( comboBox1.Text);
            db.SaveChanges();

            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();
        }
    }
}
