using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace Manav
{
    public partial class kasalogin : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public kasalogin()
        {
            InitializeComponent();
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = "server=127.0.0.1;uid=root;pwd=;database=manav";
                conn.Open();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string user = textBox1.Text;
            string pass = textBox2.Text;
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM kullanici WHERE isim='" + textBox1.Text + "'" +
                " AND sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı.");
                kasiyergiris kasiyergiris = new kasiyergiris(this);
                kasiyergiris.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
            }
            dr.Close();
            
    }

    private void button2_Click(object sender, EventArgs e)
        {
            anaekran anaekran = new anaekran();
            anaekran.Show();
            this.Hide();
        }
    }
}
