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
    public partial class KaynakListeForm : Form
    {
        public KaynakListeForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db= new KutuphaneOtomasyonuEntities();
        private void KaynakListeForm_Load(object sender, EventArgs e)
        {
            var kaynaklar=db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();

            //0. ve 4. kolonları görünmez yaptık 
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            //sütün isimlerini değiştirdik 
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar Adı";
            dataGridView1.Columns[3].HeaderText = "Kitap Sayfa Sayısı";
        }
    }
}
