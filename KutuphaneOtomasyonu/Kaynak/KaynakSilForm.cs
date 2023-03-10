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
    public partial class KaynakSilForm : Form
    {
        public KaynakSilForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db=new KutuphaneOtomasyonuEntities();
        private void KaynakSilForm_Load(object sender, EventArgs e)
        {
            var kaynaklar= db.Kaynaklar;
            dataGridView1.DataSource = kaynaklar.ToList();

            //0. ve 4. kolonları görünmez yaptık 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            //sütün isimlerini değiştirdik 
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Kitap Sayfa Sayısı";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16( dataGridView1.CurrentRow.Cells[0].Value);
            var silinenKaynak=db.Kaynaklar.Where(x=>x.kaynak_id==secilenId).FirstOrDefault();
            db.Kaynaklar.Remove(silinenKaynak);
            db.SaveChanges();

            var kaynaklar = db.Kaynaklar;
            dataGridView1.DataSource = kaynaklar.ToList();

        }
    }
}
