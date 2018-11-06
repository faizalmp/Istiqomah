using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Istiqomah
{
    public partial class Mutabaah_Page : Form
    {
        public Mutabaah_Page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = IstiqomahDatabase.accdb";
            try
            {
                dbconnection.Open();
                String Username = textBox2.Text.ToString();
                String Tanggal = textBox1.Text.ToString();
                String SholatFardhu = textBox9.Text.ToString();
                String SholatDhuha = textBox10.Text.ToString();
                String QiyamulLail = textBox8.Text.ToString();
                String Shaum = textBox7.Text.ToString();
                String Tilawah = textBox4.Text.ToString();
                String Hafalan = textBox5.Text.ToString();
                String Infaq = textBox3.Text.ToString();
                String Kajian = textBox6.Text.ToString();
                String dbquery = "INSERT into AmalanHarian(Username, Tanggal, SholatFardhu, SholatDhuha, QiyamulLail, Shaum, Tilawah, Hafalan, Infaq, Kajian) values ('" + Username + "', '" + Tanggal + "', '" + SholatFardhu + "', '" + SholatDhuha + "', '" + QiyamulLail + "', '" + Shaum + "', '" + Tilawah + "', '" + Hafalan + "', '" + Infaq + "', '" + Kajian + "')";                
                OleDbCommand storedata = new OleDbCommand(dbquery, dbconnection);
                storedata.ExecuteNonQuery();
                MessageBox.Show("Save Success!");
                Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                dbconnection.Close();
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mutabaah_Page_Load(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = IstiqomahDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "SELECT * from LoginLog";
                OleDbCommand searchdata = new OleDbCommand(query, dbconnection);
                searchdata.CommandType = CommandType.Text;
                OleDbDataReader reader = searchdata.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader["Username"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Save failed!");
            }
            finally
            {
                dbconnection.Close();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

