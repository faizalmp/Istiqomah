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
    public partial class ShowMutabaah_Page : Form
    {
        public ShowMutabaah_Page()
        {
            InitializeComponent();
            this.textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //OleDbConnection dbconnection = new OleDbConnection();
            //dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            //    @"Data source = IstiqomahDatabase.accdb";
            //try
            //{
            //    dbconnection.Open();
            //    textBox1 = sender as TextBox;
            //    String dbquery = "SELECT * from AmalanHarian";
            //    OleDbCommand predict = new OleDbCommand(dbquery, dbconnection);
            //    DataSet ds = new DataSet();
            //    OleDbDataAdapter adapter = new OleDbDataAdapter(predict);
            //    adapter.Fill(ds, "AmalanHarian");
            //    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //    this.textBox1.AutoCompleteCustomSource = collection;
            //}
            //catch(Exception error)
            //{

            //}
            //finally
            //{
            //    dbconnection.Close();
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source = IstiqomahDatabase.accdb";
            try
            {
                dbconnection.Open();
                String dbquery = "SELECT * from AmalanHarian WHERE Tanggal = '" + textBox1.Text.ToString() +"' and Username = '" + textBox2.Text.ToString() + "'";
                OleDbCommand searchdata = new OleDbCommand(dbquery, dbconnection);
                searchdata.CommandType = CommandType.Text;
                OleDbDataReader reader = searchdata.ExecuteReader();
                while (reader.Read())
                {
                    textBox9.Text = reader["SholatFardhu"].ToString();
                    textBox10.Text = reader["SholatDhuha"].ToString();
                    textBox11.Text = reader["QiyamulLail"].ToString();
                    textBox12.Text = reader["Shaum"].ToString();
                    textBox4.Text = reader["Tilawah"].ToString();
                    textBox5.Text = reader["Hafalan"].ToString();
                    textBox13.Text = reader["Infaq"].ToString();
                    textBox14.Text = reader["Kajian"].ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Load failed!" + error.Message);
            }
            finally
            {
                dbconnection.Close();
            }
        }

        private void ShowMutabaah_Page_Load(object sender, EventArgs e)
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "True")
            {
                textBox11.Text = "Ya";
            }
            if (textBox11.Text == "False")
            {
                textBox11.Text = "Tidak";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "True")
            {
                textBox10.Text = "Ya";
            }
            if (textBox10.Text == "False")
            {
                textBox10.Text = "Tidak";
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "True")
            {
                textBox9.Text = "Ya";
            }
            if (textBox9.Text == "False")
            {
                textBox9.Text = "Tidak";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconnection = new OleDbConnection();
            dbconnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source = IstiqomahDatabase.accdb";
            try
            {
                dbconnection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = dbconnection;
                String query = "SELECT top 10 * FROM AmalanHarian ORDER BY ID desc";
                cmd.CommandText = query;
                OleDbCommand get = new OleDbCommand(query, dbconnection);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    chart1.ChartAreas[0].AxisX.Maximum = 7;
                    chart2.ChartAreas[0].AxisX.Maximum = 7;
                    chart1.Series["Sholat Fardhu"].Points.AddXY(reader["Tanggal"].ToString(), reader["SholatFardhu"].ToString());
                    chart1.Series["Sholat Dhuha"].Points.AddXY(reader["Tanggal"].ToString(), reader["SholatDhuha"].ToString());
                    chart1.Series["Qiyamul Lail"].Points.AddXY(reader["Tanggal"].ToString(), reader["QiyamulLail"].ToString());
                    chart1.Series["Shaum Sunnah"].Points.AddXY(reader["Tanggal"].ToString(), reader["Shaum"].ToString());
                    chart1.Series["Tilawah"].Points.AddXY(reader["Tanggal"].ToString(), reader["Tilawah"].ToString());
                    chart1.Series["Hafalan"].Points.AddXY(reader["Tanggal"].ToString(), reader["Hafalan"].ToString());
                    chart2.Series["Infaq"].Points.AddXY(reader["Tanggal"].ToString(), reader["Infaq"].ToString());
                    chart1.Series["Kajian"].Points.AddXY(reader["Tanggal"].ToString(), reader["Kajian"].ToString());
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                dbconnection.Close();
            }

       }
    }
}

