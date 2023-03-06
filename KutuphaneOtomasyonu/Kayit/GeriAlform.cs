using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu.Kayit
{
    public partial class GeriAlform : Form
    {
        public GeriAlform()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db=new KutuphaneOtomasyonuEntities();
        private void GeriAlform_Load(object sender, EventArgs e)
        {

           

            var kayitlar= db.Kayitlar.Where(x=>x.durum==false).ToList();
           
            dataGridView1.DataSource = kayitlar.ToList();
            dataGridView1.Columns[6].Visible= false;
            dataGridView1.Columns[7].Visible= false;
           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seçilenKayitId =Convert.ToInt16( dataGridView1.CurrentRow.Cells[0].Value);
            var kayit =db.Kayitlar.Where(x=>x.kayit_id==seçilenKayitId).FirstOrDefault();
            kayit.durum = true;

            db.SaveChanges();

            var kayitlar = db.Kayitlar.Where(x => x.durum == false).ToList();
            dataGridView1.DataSource = kayitlar.ToList();
            
        }
    }
}
