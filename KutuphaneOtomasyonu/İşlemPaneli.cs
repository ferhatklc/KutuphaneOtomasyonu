using KutuphaneOtomasyonu.Kayit;
using KutuphaneOtomasyonu.Kaynak;
using KutuphaneOtomasyonu.Kullanici;
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
    public partial class İşlemPaneli : Form
    {
        public İşlemPaneli()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities db =new KutuphaneOtomasyonuEntities();

        private void İşlemPaneli_Load(object sender, EventArgs e)
        {
            //kullanıcı butonu
            ekleKullanicibtn.Visible = false;
            güncelleKullanicibtn.Visible= false;
            silKullanicibtn.Visible = false;


            //kaynaklar butonu
            ekleKaynakbtn.Visible = false;
            guncelleKaynakbtn.Visible = false;
            silKaynakbtn.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ekleKullanicibtn.Visible == false)
            {
                ekleKullanicibtn.Visible = true;
                güncelleKullanicibtn.Visible = true;
                silKullanicibtn.Visible = true;
            }
            else {

                ekleKullanicibtn.Visible = false;
                güncelleKullanicibtn.Visible = false;
                silKullanicibtn.Visible = false;

            }

            OgrenciListeForm kListeForm = new OgrenciListeForm();
            kListeForm.MdiParent = this;
            kListeForm.Show();
           
        }

        private void ekleKullanicibtn_Click(object sender, EventArgs e)
        {
            OgrenciEkleForm ekleForm = new OgrenciEkleForm();  
            ekleForm.MdiParent = this;  
            ekleForm.Show();    
        }

        private void silKullanicibtn_Click(object sender, EventArgs e)
        {
            OgrenciSilForm kSil= new OgrenciSilForm();  
            kSil.MdiParent = this;
            kSil.Show();
        }

        private void güncelleKullanicibtn_Click(object sender, EventArgs e)
        {
            OgrenciGuncelleForm kGuncel = new OgrenciGuncelleForm();
            kGuncel.MdiParent = this;   
            kGuncel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ekleKaynakbtn.Visible == false)
            {

                ekleKaynakbtn.Visible = true;
                guncelleKaynakbtn.Visible = true;
                silKaynakbtn.Visible = true;
            }
            else
            {

                ekleKaynakbtn.Visible = false;
                guncelleKaynakbtn.Visible = false;
                silKaynakbtn.Visible = false;
            }
            KaynakListeForm kListe =new KaynakListeForm();
            kListe.MdiParent= this;
            kListe.Show();
        }

        private void ekleKaynakbtn_Click(object sender, EventArgs e)
        {
            KaynakEkleForm kaynakEkle =new KaynakEkleForm();
            kaynakEkle.MdiParent = this;    
            kaynakEkle.Show();
        }

        private void silKaynakbtn_Click(object sender, EventArgs e)
        {
            KaynakSilForm kaynakSil =new KaynakSilForm();
            kaynakSil.MdiParent = this;
            kaynakSil.Show();   
        }

        private void guncelleKaynakbtn_Click(object sender, EventArgs e)
        {
            KaynakGuncelleForm kGuncel= new KaynakGuncelleForm();
            kGuncel.MdiParent=this;
            kGuncel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OduncVerForm odunc= new OduncVerForm();
            odunc.MdiParent= this;
            odunc.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            GeriAlform geri =new GeriAlform();
            geri.MdiParent = this;
            geri.Show();

        }
    }
}
