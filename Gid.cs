using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1_AIS
{
    public partial class Gid : Form
    {
        public Gid()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;
            pictureBox2.Visible = true;
            pictureBox2.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            pictureBox2.Visible = false;
            pictureBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form F1 = new Form1(false);
            this.Hide();
            F1.ShowDialog();
            this.Close();
        }
    }
}
