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
    public partial class fUrunGiris : Form
    {
        public fUrunGiris()
        {
            InitializeComponent();
        }
        BarkodDbEntities db = new BarkodDbEntities();
        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = txtBarkod.Text.Trim();
                if (db.Urun.Any(a => a.Barkod == barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    txtUrunAdi.Text = urun.UrunAd;
                    txtAciklama.Text = urun.Aciklama;
                    cmbUrunGrubu.Text = urun.UrunGrup;
                    txtAlisFiyati.Text = urun.AlisFiyat.ToString();
                    txtSatisFiyati.Text = urun.SatisFiyat.ToString();
                    txtMiktar.Text = urun.Miktar.ToString();
                    txtKdvOrani.Text = urun.KdvOrani.ToString();
                }
                else
                {
                    MessageBox.Show("Ürün kayıtlı değil,kaydedebilirsiniz");
                }
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (txtBarkod.Text != "" && txtUrunAdi.Text != "" && cmbUrunGrubu.Text != "" && txtAlisFiyati.Text != "" && txtSatisFiyati.Text != "" && txtKdvOrani.Text != "" && txtMiktar.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == txtBarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == txtBarkod.Text).SingleOrDefault();
                    guncelle.Barkod = txtBarkod.Text;
                    guncelle.UrunAd = txtUrunAdi.Text;
                    guncelle.Aciklama = txtAciklama.Text;
                    guncelle.UrunGrup = cmbUrunGrubu.Text;
                    guncelle.AlisFiyat = Convert.ToDouble(txtAlisFiyati.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(txtSatisFiyati.Text);
                    guncelle.KdvOrani = Convert.ToInt32(txtKdvOrani.Text);
                    guncelle.KdvTutari = Math.Round(Islemler.DoubleYap(txtSatisFiyati.Text) * Convert.ToInt32(txtKdvOrani.Text) / 100, 2);
                    guncelle.Miktar += Convert.ToDouble(txtMiktar.Text);
                    guncelle.Birim = "Adet";
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lkullanici.Text;
                    db.SaveChanges();
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = txtBarkod.Text;
                    urun.UrunAd = txtUrunAdi.Text;
                    urun.Aciklama = txtAciklama.Text;
                    urun.UrunGrup = cmbUrunGrubu.Text;
                    urun.AlisFiyat = Convert.ToDouble(txtAlisFiyati.Text);
                    urun.SatisFiyat = Convert.ToDouble(txtSatisFiyati.Text);
                    urun.KdvOrani = Convert.ToInt32(txtKdvOrani.Text);
                    urun.KdvTutari = Math.Round(Islemler.DoubleYap(txtSatisFiyati.Text) * Convert.ToInt32(txtKdvOrani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(txtMiktar.Text);
                    urun.Birim = "Adet";
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lkullanici.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    if (txtBarkod.Text.Length == 8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }

                    
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                }
                Islemler.StokHareket(txtBarkod.Text, txtUrunAdi.Text, "Adet", Convert.ToDouble(txtMiktar.Text), cmbUrunGrubu.Text, lkullanici.Text);
                Temizle();
            }
            else
            {
                MessageBox.Show("Bilgi Girişlerini Kontrol Ediniz...");
                txtBarkod.Focus();
            }
        }

        private void txtUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAra.Text.Length >= 2)
            {
                string urunad = txtUrunAra.Text;
                gridUrunler.DataSource = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                Islemler.GridDuzenle(gridUrunler);
            }
        }

        private void biptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            txtBarkod.Clear();
            txtUrunAdi.Clear();
            txtAciklama.Clear();
            txtAlisFiyati.Text = "0";
            txtSatisFiyati.Text = "0";
            txtMiktar.Text = "0";
            txtKdvOrani.Text = "8";
            txtBarkod.Focus();
        }

        private void fUrunGiris_Load(object sender, EventArgs e)
        {
            txtUrunSayisi.Text = db.Urun.Count().ToString();
            gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
            Islemler.GridDuzenle(gridUrunler);
            GrupDoldur();
        }
        public void GrupDoldur()
        {
            cmbUrunGrubu.DisplayMember = "UrunGrupAd";
            cmbUrunGrubu.ValueMember = "Id";
            cmbUrunGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }
        private void bUrunGrubuEkle_Click(object sender, EventArgs e)
        {
            fUrunGrubuEkle f = new fUrunGrubuEkle();
            f.ShowDialog();
        }

        private void bBarkodOluştur_Click(object sender, EventArgs e)
        {
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8 - karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            txtBarkod.Text = olusanbarkod;
            txtUrunAdi.Focus();
        }

        private void txtSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count>0)
            {
                int urunid = Convert.ToInt32(gridUrunler.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunad = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunad + " ürününü silmek istiyor musunuz ?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urun.Find(urunid);
                    db.Urun.Remove(urun);
                    db.SaveChanges();
                    var hizliurun = db.HizliUrun.Where(x => x.Barkod == barkod).SingleOrDefault();
                    hizliurun.Barkod = "-";
                    hizliurun.UrunAd = "-";
                    hizliurun.Fiyat = 0;
                    db.SaveChanges();
                    MessageBox.Show("Ürün Silinmiştir..");
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                    txtBarkod.Focus();
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count>0)
            {
                txtBarkod.Text = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                txtUrunAdi.Text = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                txtAciklama.Text = gridUrunler.CurrentRow.Cells["Aciklama"].Value.ToString();
                cmbUrunGrubu.Text= gridUrunler.CurrentRow.Cells["UrunGrup"].Value.ToString();
                txtAlisFiyati.Text= gridUrunler.CurrentRow.Cells["AlisFiyat"].Value.ToString();
                txtSatisFiyati.Text= gridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                txtMiktar.Text= gridUrunler.CurrentRow.Cells["Miktar"].Value.ToString();
                string birim= gridUrunler.CurrentRow.Cells["Birim"].Value.ToString();
            }
        }

        private void bRaporAl_Click(object sender, EventArgs e)
        {
            
        }
    }
}
