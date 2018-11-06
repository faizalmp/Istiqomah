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
    public partial class Register_Page : Form
    {
        public Register_Page()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Please fill the First Name");
            }
            else if (textBox2.TextLength == 0)
            {
                MessageBox.Show("Please fill the Last Name");
            }
            else if (textBox3.TextLength == 0)
            {
                MessageBox.Show("Please fill the E-Mail");
            }
            else if (textBox4.TextLength == 0)
            {
                MessageBox.Show("Please fill the Username");
            }
            else if (textBox5.TextLength == 0)
            {
                MessageBox.Show("Please fill the Password");
            }
            else if (textBox6.TextLength == 0)
            {
                MessageBox.Show("Please Re-Type the Password!");
            }
            else if (textBox5.TextLength < 8)
            {
                MessageBox.Show("Your Password is less than 8 character");
            }
            else if (textBox6.Text != textBox5.Text)
            {
                MessageBox.Show("Please Re-Type the Password");
            }
            
            else
            {
                OleDbConnection dbconnection = new OleDbConnection();
                dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                    @"Data source = IstiqomahDatabase.accdb";
                try
                {
                    dbconnection.Open();
                    String FirstName = textBox1.Text.ToString();
                    String LastName = textBox2.Text.ToString();
                    String Email = textBox3.Text.ToString();
                    String Username = textBox4.Text.ToString();
                    String Password = textBox5.Text.ToString();
                    String dbquery = "INSERT into Account(FirstName, LastName, Email, Username, [Password]) values ('"+FirstName+ "', '" + LastName + "', '" + Email + "', '" + Username + "', '" + Password + "')";
                    OleDbCommand storedata = new OleDbCommand(dbquery, dbconnection);
                    storedata.ExecuteNonQuery();
                    MessageBox.Show("Registration complete!");
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Registration failed!");
                }
                finally
                {
                    dbconnection.Close();
                }
            }

        }

        private void Register_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
