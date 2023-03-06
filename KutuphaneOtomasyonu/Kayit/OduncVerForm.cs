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
    public partial class OduncVerForm : Form
    {
        public OduncVerForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db=new KutuphaneOtomasyonuEntities();
        private void OduncVerForm_Load(object sender, EventArgs e)
        {


            var kayitList = from kayit in db.Kayitlar select new { kayit.Ogrenciler.ogrenci_ad,kayit.Kaynaklar.kaynak_ad,kayit.aliş_tarih,kayit.son_tarih,kayit.durum }; 
            
            
            
          // var kayitList=db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();
          
            var kaynakList=db.Kaynaklar.ToList();  
            dataGridView2.DataSource = kaynakList.ToList();

            /*istenmeyen kolonları silme
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            kolon adları değiştirme
            dataGridView1.Columns[1].HeaderText = "Öğrenci";
            dataGridView1.Columns[2].HeaderText = "Kaynak Ad";
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arananSecilen=tcBultxt.Text;
            var kullaniciVarMi=db.Ogrenciler.Where(x=>x.ogrenci_tc==arananSecilen).FirstOrDefault();

            if (kullaniciVarMi != null)

                label2.Text = kullaniciVarMi.ogrenci_ad + " " + kullaniciVarMi.ogrenci_soyad;
            else
                label2.Text = "Böyle bir öğrenci yok";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string gelenAd=textBox1.Text;
            var bulununaKaynaklar=db.Kaynaklar.Where(x=>x.kaynak_ad.Contains(gelenAd)).ToList();
            dataGridView2.DataSource = bulununaKaynaklar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //öğrenciyi alma
            string secilenKişiTc=tcBultxt.Text;
            var secilenKişi=db.Ogrenciler.Where(x=>x.ogrenci_tc.Equals(secilenKişiTc)).FirstOrDefault();

            //kitabı alma
            int secilenKitapId =Convert.ToInt16( dataGridView2.CurrentRow.Cells[0].Value);   
            var secilenKitap= db.Kaynaklar.Where(x=>x.kaynak_id==secilenKitapId).FirstOrDefault();




            Kayitlar yeniKayit =new  Kayitlar();
            yeniKayit.kitap_id = secilenKitap.kaynak_id;
            yeniKayit.ogrenci_id = secilenKişi.ogrenci_id;
            yeniKayit.aliş_tarih = DateTime.Today;
            yeniKayit.son_tarih = DateTime.Today.AddDays(15);
            yeniKayit.durum = false;
            db.Kayitlar.Add(yeniKayit);
            db.SaveChanges();


            var kayitList = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitList.ToList();

        }


    }
}
