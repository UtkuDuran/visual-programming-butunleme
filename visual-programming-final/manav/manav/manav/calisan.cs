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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manav
{
    public partial class calisan : Form
    {
        kasiyergiris panel;
        MySql.Data.MySqlClient.MySqlConnection conn;
        public calisan(kasiyergiris panel)
        {
            this.panel = panel;
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
            isci();
            this.panel = panel;
        }
        public void isci()
        {
            try
            {
                listBox1.Items.Clear();
                string user = "SELECT * FROM `kullanici`";
                MySqlCommand cmd = new MySqlCommand(user, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listBox1.Sorted = true;
                    listBox1.Items.Add("İD: "+rdr[0]+"  User : " + rdr[1] +
                        "   Password: " + rdr[2]);

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
                {   //kullanici ekleme
                    string sql = "INSERT INTO `kullanici`(`isim`, `sifre`)" +
                    "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    //textBox1.Text = "";
                    //textBox2.Text = "";
                    isci();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {   //kullanici silme
                string sql = "DELETE FROM `kullanici` WHERE `id`='" + textBox3.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                isci();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel.Show();
            this.Close();
        }
    }
}
