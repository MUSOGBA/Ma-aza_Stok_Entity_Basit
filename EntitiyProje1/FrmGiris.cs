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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            DbEntityUrunEntities db = new DbEntityUrunEntities();
            var sorgu = from x in db.Tbl_Admin where x.Kullanici == TxtKadi.Text && x.Sifre == TxtSifre.Text select x;

            if (sorgu.Any())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Girdiğiniz Bilgiler Yanlış Lütfen Kontrol Edip Tekrar Giriş Yapın","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
