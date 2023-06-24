using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodlu_Satis_Programi
{
    public partial class fUrunGrubuEkle : Form
    {
        public fUrunGrubuEkle()
        {
            InitializeComponent();
        }
        BarkodDbEntities db = new BarkodDbEntities();
        private void fUrunGrubuEkle_Load(object sender, EventArgs e)
        {
            GrupDoldur();
        }

        private void bStandart1_Click(object sender, EventArgs e)
        {
            if (txtUrunGrubuAdi.Text!="")
            {
                UrunGrup ug = new UrunGrup();
                ug.UrunGrupAd = txtUrunGrubuAdi.Text;
                db.UrunGrup.Add(ug);
                db.SaveChanges();
                GrupDoldur();
                txtUrunGrubuAdi.Clear();
                MessageBox.Show("Ürün Grubu Eklendi...");

                fUrunGiris f = (fUrunGiris)Application.OpenForms["fUrunGiris"];

                if (f!=null)
                {
                    f.GrupDoldur();
                }
             
            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyiniz");
            }
            
        }
        private void GrupDoldur()
        {
            listUrunGrup.DisplayMember = "UrunGrupAd";
            listUrunGrup.ValueMember = "Id";
            listUrunGrup.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            int grupid = Convert.ToInt32(listUrunGrup.SelectedValue.ToString());
            string grupad = listUrunGrup.Text;
            DialogResult onay = MessageBox.Show(grupad+" grubunu silmek istiyor musunuz ?","Silme İşlemi",MessageBoxButtons.YesNo);
            if (onay==DialogResult.Yes)
            {
                var grup = db.UrunGrup.FirstOrDefault(x => x.Id == grupid);
                db.UrunGrup.Remove(grup);
                db.SaveChanges();
                GrupDoldur();
                txtUrunGrubuAdi.Focus();
                MessageBox.Show(grupad+" ürün grubu silindi.");
                fUrunGiris f = (fUrunGiris)Application.OpenForms["fUrunGiris"];
                f.GrupDoldur();
            }
        }
    }
}
