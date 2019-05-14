using RockPaperScisor.Properties;
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
    public partial class Form1 : Form
    {
        string pl="player"; 
        int player = 0, computer = 0, draw = 0;
        int s=0, m = 0, h = 0;
        //const string pl = "Player";
        const string cm = "Computer";
        const string dr = "Draw";
        const string ro = "Rock";
        const string pa = "Paper";
        const string sc = "Scissoor"; 
        Dictionary<int, Image> dict=new Dictionary<int, Image>();
        DataTable dt = new DataTable();
        public Form1(string s)
        {
            pl = s;
            //par = p;
            InitializeComponent();
            PlayerLabel.Text = pl;
            label4.Text = pl;

            dict.Add(1, Resources.rock);
            dict.Add(2, Resources.paper);
            dict.Add(3, Resources.scissors);

            dt.Columns.Add(pl);
            dt.Columns.Add("Computer");
            dt.Columns.Add("Winner");
            ScoreGrid.DataSource = dt;
            timer1.Start();
        }
        void msgshow(string s)
        {
            MessageBox.Show(s);
        }
        void addRaw(string p,string c,string w)
        {
            dt.Rows.Add(p, c, w);
        }
       void Generate_Move(int n)
        {
            string p = pl;
            p +=" Win!!!";
            string c = "Computer Win!!!";
            string d = "Match Draw!!!";
            Random rnd = new Random();
            int num = rnd.Next(1, 4);
            ComPic.Image = dict[num];
            if(n==1)
            {
                if (num == 1)
                {
                    draw++;
                    addRaw(ro, ro, dr);
                    msgshow(d);
                }
                else if (num == 2)
                {
                    computer++;
                    addRaw(ro, pa, cm);
                    msgshow(c);
                }
                else
                {
                    player++;
                    addRaw(ro, sc, pl);
                    msgshow(p);
                }

            }
            else if(n==2)
            {
                if (num == 1)
                {
                    player++;
                    addRaw(pa, ro, pl);
                    msgshow(p);
                }
                else if (num == 2)
                {
                    draw++;
                    addRaw(pa, pa, dr);
                    msgshow(d);
                }
                else
                {
                    computer++;
                    addRaw(pa, sc, cm);
                    msgshow(c);
                }
            }
            else if(n==3)
            {
                if (num == 1)
                {
                    computer++;
                    addRaw(sc, ro, cm);
                    msgshow(c);
                }
                else if (num == 2)
                {
                    player++;
                    addRaw(sc, pa, pl);
                    msgshow(p);
                }
                else
                {
                    draw++;
                    addRaw(sc, sc, dr);
                    msgshow(d);
                }
            }
            playerscore.Text = player.ToString();
            computerscore.Text = computer.ToString();
        }

        private void RockButton_Click(object sender, EventArgs e)
        {
            UsePic.Image = dict[1];
            Generate_Move(1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            if (player > computer)
            {
                s = pl;
                s += " Win!!! Computer Looser!!!\n";
            }
            else if (computer > player)
                s = "Computer Win!!! You Looser!!!\n";
            else
                s = "Drawn!!!\n";
            s += pl;
            s += " Score: ";
            s += player.ToString();
            s += "\nComputer Score: ";
            s += computer.ToString();
            s += "\nDrawn: ";
            s += draw.ToString();
            MessageBox.Show(s);
            this.Hide();
            Welcome f = new Welcome();
            f.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HelpForm h = new HelpForm(this);
            h.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s++;
            if (s == 60)
            {
                m++;
                s = 0;
            }
            if (m == 60)
            {
                m = 0;
                h++;
            }
            string sp = h.ToString();
            sp += ": ";
            if (m < 10)
                sp += "0";
            sp += m.ToString();
            sp += ": ";
            if (s < 10)
                sp += "0";
            sp += s.ToString();
            TimerBox.Text = sp;
        }

        private void PaperButton_Click(object sender, EventArgs e)
        {
            UsePic.Image = Resources.paper;
            Generate_Move(2);
        }

        private void ScissorButton_Click(object sender, EventArgs e)
        {
            UsePic.Image = Resources.scissors;
            Generate_Move(3);
        }
    }
}
