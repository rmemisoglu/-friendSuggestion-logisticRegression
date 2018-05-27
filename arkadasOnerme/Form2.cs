using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arkadasOnerme
{
    public partial class Tablolar : MetroFramework.Forms.MetroForm
    {
        
        public Tablolar()
        {
            InitializeComponent();
        }
        arkadasOnerme oe2 = new arkadasOnerme();

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oe2.ogrenciProfils.ToList();
            dataGridView2.DataSource = oe2.ogrenciNetworks.ToList();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ekle = false;
            this.Hide();
            f1.Show();
        }
    }
}
