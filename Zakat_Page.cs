using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Istiqomah
{
    public partial class Zakat_Page : Form
    {
        public Zakat_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uangTeks = textBox1.Text.ToString();
            string tabunganTeks = textBox2.Text.ToString();
            string emasTeks = textBox3.Text.ToString();
            string propertiTeks = textBox4.Text.ToString();
            string lainTeks = textBox5.Text.ToString();
            string hargaT = textBox7.Text.ToString();
            if (textBox1.Text.Length == 0) uangTeks = "0";
            if (textBox2.Text.Length == 0) tabunganTeks = "0";
            if (textBox3.Text.Length == 0) emasTeks = "0";
            if (textBox4.Text.Length == 0) propertiTeks = "0";
            if (textBox5.Text.Length == 0) lainTeks = "0";
            if (textBox7.Text.Length == 0) hargaT = "500000";
            double harga = Int64.Parse(hargaT);
            double uang = Int64.Parse(uangTeks);
            double tabungan = Int64.Parse(tabunganTeks);
            double emas = Int64.Parse(emasTeks);
            emas = emas * harga;
            if (emas >= 85 * harga)
            {
                emas = emas * 0.025;
            }
            else emas = 0;
            double properti = Int64.Parse(propertiTeks);
            double lain = Int64.Parse(lainTeks);
            double zakatTotal = (emas + ((uang + properti + lain + tabungan) * 0.025));
            textBox6.Text = (zakatTotal.ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
