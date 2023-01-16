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
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities.Collections;

namespace Manav
{
    public partial class urunguncelle : Form
    {
        kasiyergiris kasa;
        MySql.Data.MySqlClient.MySqlConnection conn;
        public urunguncelle(kasiyergiris kasa)
        {
            InitializeComponent();
            this.kasa = kasa;
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

                //listBox1.Items.Clear();

                string sql = "SELECT * FROM urun";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                listBox1.Sorted = true;
                listBox1.Items.Add("--->Barkod : " + rdr[2] + "<---  ~" + rdr[1] + "~   " + rdr[3] +
                    " ₺/kg   Adet: " + rdr[4] + "");

            }
                rdr.Close();
                
            }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "UPDATE `urun` SET`isim`= '" + textBox1.Text + "',`fiyat`= '" + textBox3.Text + "'," +
                    " `stok`= '" + textBox4.Text + "' WHERE `barkod`= '" + textBox2.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                urun();
                //conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // kasiyergiris kasiyer = new kasiyergiris(this);
            kasa.Show();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    MySqlCommand cmd = new MySqlCommand("SELECT * FROM urun where barkod like '"
            //        + textBox2.Text + "'", conn);
            //    MySqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {

            //        textBox1.Text = rdr[1].ToString();
            //        textBox2.Text = rdr[2].ToString(); ;
            //        textBox2.Text = rdr[3].ToString();
            //        textBox2.Text = rdr[4].ToString();

            //    }
            //    rdr.Close();
            //    conn.Close();

            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
