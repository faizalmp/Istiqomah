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
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
            this.Istiqomah.BalloonTipText = "Jangan lupa mengisi mutabaah mingguan";
            this.Istiqomah.BalloonTipTitle = "Reminder";
            this.Istiqomah.Visible = true;
            this.Istiqomah.ShowBalloonTip(3);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source = IstiqomahDatabase.accdb;";
            try
            {
                dbconnection.Open();
                String cmdText = "SELECT count(*)from Account where Username=" + "? and [Password]="+"?";
                OleDbCommand cmd = new OleDbCommand(cmdText, dbconnection);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                int result = (int)cmd.ExecuteScalar();
                if (result > 0)
                {
                    //MessageBox.Show("Login Successfull!");
                    String Username = textBox1.Text.ToString();
                    String myquery = "INSERT into LoginLog(Username)values('" + Username + "')";
                    OleDbCommand store = new OleDbCommand(myquery, dbconnection);
                    store.ExecuteNonQuery();
                    Hide();
                    Menu_Page MainMenu = new Menu_Page();
                    MainMenu.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
                
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register_Page RegisterPage = new Register_Page();

            RegisterPage.Show();
        }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
