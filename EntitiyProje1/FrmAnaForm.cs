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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKategori fr = new FrmKategori();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun fru = new FrmUrun();
            fru.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmIstatistik fri = new FrmIstatistik();
            fri.Show();
        }
    }
}
