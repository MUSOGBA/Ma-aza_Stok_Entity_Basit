using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitiyProje1
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        { 
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.Tbl_Kategori.AD,
                                            x.DURUM
                                        }
                                        ).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun u = new Tbl_Urun();
            u.URUNAD = TxtUrunAdi.Text;
            u.MARKA = TxtMarka.Text;
            u.STOK =short.Parse( TxtStok.Text);
            u.FIYAT =decimal.Parse( TxtFiyat.Text);
            u.DURUM = true;
            u.KATEGORI = int.Parse(CmbKategori.Text);
            db.Tbl_Urun.Add(u);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunId.Text);
            var ktgr = db.Tbl_Urun.Find(x);
            db.Tbl_Urun.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtUrunId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtUrunAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            CmbKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunId.Text);
            var ktgr = db.Tbl_Urun.Find(x);
            ktgr.URUNAD = TxtUrunAdi.Text;
            ktgr.MARKA = TxtMarka.Text;
            ktgr.STOK = short.Parse(TxtStok.Text);
            ktgr.FIYAT =decimal.Parse( TxtFiyat.Text);
            ktgr.DURUM = true;
            ktgr.KATEGORI = int.Parse(CmbKategori.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategori
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                              ).ToList();
            CmbKategori.DisplayMember = "AD";
            CmbKategori.ValueMember = "ID";
            CmbKategori.DataSource = kategoriler;
        }
    }
}
