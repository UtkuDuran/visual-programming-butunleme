using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Manav
{
    internal class urunsql
    {
        
      MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=manav");
        public List<urun> uruns { get; set; }

        public urunsql()
        {
            uruns=new List<urun>(); 
            uruncek();  
        }

        private void uruncek()
        {
            conn.Open();
            string sql = "SELECT * FROM urun";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                urun sepet = new urun();
                sepet.Isim = dr[1].ToString();
                sepet.Barkod = dr[2].ToString();
                sepet.Fiyat = dr[3].ToString();
                sepet.Stok = dr[4].ToString();

                uruns.Add(sepet);
            }
            dr.Close();
            conn.Close();

        }
         

    }
}
