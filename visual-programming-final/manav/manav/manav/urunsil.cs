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
    public partial class urunsil : Form

    {
        kasiyergiris kasaa;
        MySql.Data.MySqlClient.MySqlConnection conn;
        public urunsil(kasiyergiris kasaa)
        {
            InitializeComponent();
            this.kasaa = kasaa;
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
                    listBox1.Items.Add("--->Barkod : " + rdr[2] + "<---  ~" + rdr[1] + "~   " + rdr[3] +
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
        {
            try
            {
                string sql = "DELETE FROM `urun` WHERE `barkod`='" + textBox1.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                 cmd.ExecuteNonQuery();

                //while (rdr.Read())
                //{
                //    listBox1.Items.Remove(listBox1.SelectedItem);

                //}
                urun();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kasaa.Show();
            this.Close();
        }

        private void urunsil_Load(object sender, EventArgs e)
        {

        }
    }
}
