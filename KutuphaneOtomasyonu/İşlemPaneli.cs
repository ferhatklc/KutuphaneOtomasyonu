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
            ekleKullanicibtn.Visible = false;
            güncelleKullanicibtn.Visible= false;
            silKullanicibtn.Visible = false;
            
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

            KullaniciListeForm kListeForm = new KullaniciListeForm();
            kListeForm.MdiParent = this;
            kListeForm.Show();
           
        }

        private void ekleKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciEkleForm ekleForm = new KullaniciEkleForm();  
            ekleForm.MdiParent = this;  
            ekleForm.Show();    
        }

        private void silKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciSilForm kSil= new KullaniciSilForm();  
            kSil.MdiParent = this;
            kSil.Show();
        }

        private void güncelleKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciGuncelleForm kGuncel = new KullaniciGuncelleForm();
            kGuncel.MdiParent = this;   
            kGuncel.Show();
        }
    }
}
