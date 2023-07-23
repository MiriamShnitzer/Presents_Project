using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presents.Gui;
using Presents.GUI;


namespace Presents
{
    public partial class Form2 : Form
    {
        public Form2(string st)
        {
            InitializeComponent();
            if (st == "מנהל")
            {
                panelMana.Visible = true;
                panelSec.Visible = false;
                panel1.Visible = false;
            }
            if (st == "מזכירה")
            {
                panelSec.Visible = true;
                panelMana.Visible = false;
                panel1.Visible = false;
            }
            if (st=="משתתף")
            {
                panel1.Visible = true;
                panelSec.Visible = false;
                panelMana.Visible = false;
            }
            //if (DateTime.Today.Month == 1 && DateTime.Today.Day == 1)
            //    button14.Visible = true;
            //else
            //    button14.Visible = false;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCompany f = new FrmCompany();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPKinds f = new FrmPKinds();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmEvents f = new FrmEvents();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmGvia f = new FrmGvia();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           FrmMember f = new FrmMember();
            f.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmStockPre f = new FrmStockPre();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmYoman f = new FrmYoman();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmPayments f = new FrmPayments();
            f.Show();
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            FrmDochSchum f = new FrmDochSchum();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PreForMem f = new PreForMem(true);
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PreForMem f = new PreForMem(false);
            f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FrmYearlyDoch f = new FrmYearlyDoch();
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PreForMem f = new PreForMem(false);
            f.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FrmDochHachnasot f = new FrmDochHachnasot();
            f.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
           FrmHovZchut f = new FrmHovZchut(false);
            f.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FrmHovZchut f = new FrmHovZchut(true);
            f.Show();
        }
    }
}
