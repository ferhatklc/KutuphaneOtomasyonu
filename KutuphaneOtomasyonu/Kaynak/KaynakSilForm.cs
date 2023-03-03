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
