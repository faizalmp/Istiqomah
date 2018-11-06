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
    public partial class Menu_Page : Form
    {
        public Menu_Page()
        {
            InitializeComponent();
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source = IstiqomahDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "SELECT * from GenerateHadist ORDER BY rnd(-(100000*ID)*Time())";
                OleDbCommand store = new OleDbCommand(query, dbconnection);
                OleDbDataReader reader = store.ExecuteReader();
                while (reader.Read())
                {
                    richTextBox1.Text = reader["HadistHarian"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Hadist tidak ada");
            }
            finally
            {
                dbconnection.Close();
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Mutabaah_Page MainMenu = new Mutabaah_Page();
            MainMenu.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowMutabaah_Page LihatMutabaah = new ShowMutabaah_Page();
            LihatMutabaah.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source = IstiqomahDatabase.accdb";
            try
            {
                dbconnection.Open();
                String query = "DELETE * from LoginLog";
                OleDbCommand delete = new OleDbCommand(query, dbconnection);
                delete.ExecuteNonQuery();

                //MessageBox.Show("Logout Successfull!");
            }
            catch (Exception error)
            {
                MessageBox.Show("Logout failed!" + error.Message);
            }
            finally
            {
                dbconnection.Close();
            }
            Close();
            Home_Page HomePage = new Home_Page();
            HomePage.Show();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Menu_Page_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Zakat_Page hitungZakat = new Zakat_Page();
            hitungZakat.Show();
        }
    }
}
