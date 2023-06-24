using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barkodlu_Satis_Programi
{
    public partial class fAyarlar : Form
    {
        public fAyarlar()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            tadsoyad.Clear();
            ttelefon.Clear();
            teposta.Clear();
            tkullaniciad.Clear();
            tsifre.Clear();
            tsifretekrar.Clear();
            chsatisekrani.Checked = false;
            chraporekrani.Checked = false;
            chstok.Checked = false;
            churungiris.Checked = false;
            chayarlar.Checked = false;
            chfiyatguncelle.Checked = false;
            chyedekleme.Checked = false;

        }
        private void bkaydet_Click(object sender, EventArgs e)
        {
            if (bkaydet.Text == "Kaydet")
            {
                if (tadsoyad.Text != "" && ttelefon.Text != "" && tkullaniciad.Text != "" && tsifre.Text != "" && tsifretekrar.Text != "")
                {
                    if (tsifre.Text == tsifretekrar.Text)
                    {
                        try
                        {
                            using (var db = new BarkodDbEntities())
                            {
                                if (!db.Kullanici.Any(x => x.KullaniciAd == tkullaniciad.Text))
                                {
                                    Kullanici k = new Kullanici();
                                    k.AdSoyad = tadsoyad.Text;
                                    k.Telefon = ttelefon.Text;
                                    k.Eposta = teposta.Text;
                                    k.KullaniciAd = tkullaniciad.Text.Trim();
                                    k.Sifre = tsifre.Text;
                                    k.Satis = chsatisekrani.Checked;
                                    k.Rapor = chraporekrani.Checked;
                                    k.Stok = chstok.Checked;
                                    k.UrunGiris = churungiris.Checked;
                                    k.Ayarlar = chayarlar.Checked;
                                    k.FiyatGuncelle = chfiyatguncelle.Checked;
                                    k.Yedekleme = chyedekleme.Checked;
                                    db.Kullanici.Add(k);
                                    db.SaveChanges();
                                    Doldur();
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Bu Kullanıcı Zaten Kayıtlı.");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata Oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Doldurun..");
                }
            }
            else if (bkaydet.Text == "Düzenle/Kaydet")
            {
                if (tadsoyad.Text != "" && ttelefon.Text != "" && tkullaniciad.Text != "" && tsifre.Text != "" && tsifretekrar.Text != "")
                {
                    if (tsifre.Text == tsifretekrar.Text)
                    {
                        int id = Convert.ToInt32(lKullaniciid.Text);
                        using (var db = new BarkodDbEntities())
                        {
                            var guncelle = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = tadsoyad.Text;
                            guncelle.Telefon = ttelefon.Text;
                            guncelle.Eposta = teposta.Text;
                            guncelle.KullaniciAd = tkullaniciad.Text.Trim();
                            guncelle.Sifre = tsifre.Text;
                            guncelle.Satis = chsatisekrani.Checked;
                            guncelle.Rapor = chraporekrani.Checked;
                            guncelle.Stok = chstok.Checked;
                            guncelle.UrunGiris = churungiris.Checked;
                            guncelle.Ayarlar = chayarlar.Checked;
                            guncelle.FiyatGuncelle = chfiyatguncelle.Checked;
                            guncelle.Yedekleme = chyedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme Yapılmıştır");
                            bkaydet.Text = "Kaydet";
                            Temizle();
                            Doldur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Doldurun..");
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridListeKullanici.Rows.Count > 0)
            {
                int id = Convert.ToInt32(gridListeKullanici.CurrentRow.Cells["Id"].Value.ToString());
                lKullaniciid.Text = id.ToString();
                using (var db = new BarkodDbEntities())
                {
                    var getir = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                    tadsoyad.Text = getir.AdSoyad;
                    ttelefon.Text = getir.Telefon;
                    teposta.Text = getir.Eposta;
                    tkullaniciad.Text = getir.KullaniciAd;
                    tsifre.Text = getir.Sifre;
                    tsifretekrar.Text = getir.Sifre;
                    chsatisekrani.Checked = (bool)getir.Satis;
                    chraporekrani.Checked = (bool)getir.Rapor;
                    chstok.Checked = (bool)getir.Stok;
                    churungiris.Checked = (bool)getir.UrunGiris;
                    chayarlar.Checked = (bool)getir.Ayarlar;
                    chfiyatguncelle.Checked = (bool)getir.Ayarlar;
                    chyedekleme.Checked = (bool)getir.Yedekleme;
                    bkaydet.Text = "Düzenle/Kaydet";
                    Doldur();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Seçiniz");
            }
        }

        private void fAyarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Doldur();
            Cursor.Current = Cursors.Default;
        }
        private void Doldur()
        {
            using (var db = new BarkodDbEntities())
            {
                if (db.Kullanici.Any())
                {
                gridListeKullanici.DataSource = db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();
                }
                Islemler.SabitVarsayılan();
                var yazici = db.Sabit.FirstOrDefault();
                chYazmaDurumu.Checked = (bool)yazici.Yazici;

                var sabitler = db.Sabit.FirstOrDefault();
                tKartKomisyon.Text = sabitler.KartKomisyon.ToString();

                tisyeriadsoyad.Text = sabitler.AdSoyad;
                tisyeriunvan.Text = sabitler.Unvan;
                tisyeriadres.Text = sabitler.Adres;
                tisyeritelefon.Text = sabitler.Adres;
                tisyerieposta.Text = sabitler.Eposta;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridListeKullanici.Rows.Count > 0)
            {
                using (var db = new BarkodDbEntities())
                {
                    int id = Convert.ToInt32(gridListeKullanici.CurrentRow.Cells["Id"].Value.ToString());
                    string adsoyad = gridListeKullanici.CurrentRow.Cells["AdSoyad"].Value.ToString();
                    string kullaniciad = gridListeKullanici.CurrentRow.Cells["KullaniciAd"].Value.ToString();
                    DialogResult onay = MessageBox.Show(adsoyad + " kullanıcısını silmek istiyor musunuz ?", "Kullanıcı Silme İşlemi", MessageBoxButtons.YesNo);
                    if (onay == DialogResult.Yes)
                    {
                        var kullanici = db.Kullanici.Find(id);
                        db.Kullanici.Remove(kullanici);
                        db.SaveChanges();

                    }
                    MessageBox.Show("Kullanıcı Silinmiştir");
                    Islemler.GridDuzenle(gridListeKullanici);
                    Doldur();
                }
            }
        }

        private void chYazmaDurumu_CheckedChanged(object sender, EventArgs e)
        {
            using (var db=new BarkodDbEntities())
            {
                if (chYazmaDurumu.Checked)
                {
                    Islemler.SabitVarsayılan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu Aktif";
                }
                else
                {
                    Islemler.SabitVarsayılan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu Pasif";
                }
            }
        }

        private void bStandart1_Click(object sender, EventArgs e)
        {
            if (tKartKomisyon.Text != "")
            {
                using (var db = new BarkodDbEntities())
                {
                    var sabit = db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(tKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart Komisyon Ayarlandı");
                }
            }
            else
            {
                MessageBox.Show("Kart Komisyon bilgisini giriniz");
            }
        }

        private void bisyerikaydet_Click(object sender, EventArgs e)
        {
            if (tisyeriadsoyad.Text!="" && tisyeriunvan.Text!="" && tisyeriadres.Text!="" && tisyeritelefon.Text!="" && tisyerieposta.Text!="")
            {
                using (var db = new BarkodDbEntities()) 
                {
                    var isyeri = db.Sabit.FirstOrDefault();
                    isyeri.AdSoyad = tisyeriadsoyad.Text;
                    isyeri.Unvan = tisyeriunvan.Text;
                    isyeri.Adres = tisyeriadres.Text;
                    isyeri.Telefon = tisyeritelefon.Text;
                    isyeri.Eposta = tisyerieposta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri bilgileri kaydedilmiştir");
                    var yeni = db.Sabit.FirstOrDefault();
                    tisyeriadsoyad.Text = yeni.AdSoyad;
                    tisyeriunvan.Text = yeni.Unvan;
                    tisyeriadres.Text = yeni.Adres;
                    tisyeritelefon.Text = yeni.Telefon;
                    tisyerieposta.Text = yeni.Eposta;
                }
            }
        }

        private void bYedektenYükle_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\ProgramRestore.exe");
            Application.Exit();
        }
    }
}
