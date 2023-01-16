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
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities.Collections;

namespace Manav
{
    public partial class urunekle : Form
    {
        kasiyergiris kasiyergiris1;
        MySql.Data.MySqlClient.MySqlConnection conn;
        public urunekle(kasiyergiris kasiyergiris1)
        {
            InitializeComponent();
            this.kasiyergiris1 = kasiyergiris1;
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
            urun();
        }
        public void urun()
        {
            try
            {
                listBox1.Items.Clear();
                string sql = "SELECT * FROM urun";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listBox1.Sorted = true;
                    listBox1.Items.Add("Barkod : "+rdr[2] + "   ~" + rdr[1] + "~   " + rdr[3] +
                        " ₺/kg   Adet: " + rdr[4] + "");

                }
                rdr.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {   //kasaiyere gitme
            //kasiyergiris kasiyergiris =  new kasiyergiris();
            kasiyergiris1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //urun ekleme yeri
            string sql = "INSERT INTO `urun`(`isim`, `barkod`, `fiyat`, `stok`) " +
                "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            urun();
           
        }

        private void urunekle_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
