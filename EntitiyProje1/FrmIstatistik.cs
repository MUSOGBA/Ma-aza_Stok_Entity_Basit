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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {

            label2.Text = db.Tbl_Kategori.Count().ToString();
            label3.Text = db.Tbl_Urun.Count().ToString();
            label5.Text = db.Tbl_Musteri.Count(x => x.DURUM == true).ToString();
            label7.Text = db.Tbl_Musteri.Count(x => x.DURUM == false).ToString();
            label9.Text = db.Tbl_Urun.Count(x => x.KATEGORI == 1).ToString();
            label11.Text = db.Tbl_Urun.Sum(x => x.STOK).ToString();
            label13.Text =(from x in db.Tbl_Urun orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label15.Text = (from x in db.Tbl_Urun orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            label17.Text = (from x in db.Tbl_Musteri select x.SEHIR).Distinct().Count().ToString();
            label19.Text = db.Tbl_Satıs.Sum(x => x.FIYAT).ToString();
            label21.Text = db.markasıra().FirstOrDefault();
            label23.Text = db.marka1().FirstOrDefault();

        }
    }
}
