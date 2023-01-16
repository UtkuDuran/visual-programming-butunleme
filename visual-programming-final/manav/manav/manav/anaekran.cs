using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manav
{
    public partial class anaekran : Form
    {
        public anaekran()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteri musteri = new musteri();
            musteri.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
             kasalogin kasalogin = new kasalogin();
            kasalogin.Show();
            this.Hide();
        }

        private void anaekran_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
        }
    }
}
