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
using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manav
{
    public partial class kasiyergiris : Form
    {
        kasalogin Kasalogin;
        MySql.Data.MySqlClient.MySqlConnection conn;
        //public kasiyergiris()
        //{
        //}

        //MySqlCommand cmd;
        //MySqlDataReader dr;

        public kasiyergiris(kasalogin gelenekran)
        {
            InitializeComponent();
            Kasalogin = gelenekran;
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
            urune();
        }
        public void urune()
        {
            try
            {
                listBox1.Items.Clear();
                string sql = "SELECT * FROM urun";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read() )
                {
                    //listBox1.Items.Add(rdr.GetString(0));
                    listBox1.Sorted = true;
                    listBox1.Items.Add("Barkod : " + rdr[2] + "   ~" + rdr[1] + "~   " + rdr[3] +
                         " ₺/kg   Adet: " + rdr[4] + "");

                }
                rdr.Close();
                
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {//urun eklemeye gider
            urunekle urunekle = new urunekle(this);
            urunekle.Show();
            this.Hide();
        }

        private void kasiyergiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Kasalogin.Show();
            //this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //anaekrana dönme
            Kasalogin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            urunsil urunsil = new urunsil(this);
            urunsil.Show();
            this.Hide();
        }

        private void kasiyergiris_Load(object sender, EventArgs e)
        {
            urune();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urunguncelle urunguncelle = new urunguncelle(this);
            urunguncelle.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //kasiyer ekleme / düzenleme yeri
            calisan calisan = new calisan(this);
            calisan.Show();
            this.Hide();
        }
    }
}
