using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScisor
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if(s=="")
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("UserName Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form1 f = new Form1(textBox1.Text);
                f.Show();
                this.Hide();
            }
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
