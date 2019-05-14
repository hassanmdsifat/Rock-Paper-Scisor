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
    public partial class HelpForm : Form
    {
        Form1 par;
        public HelpForm(Form1 f)
        {
            par = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.par.Show();
            this.Hide();
        }

        private void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
