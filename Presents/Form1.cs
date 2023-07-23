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
    public partial class Form1 : Form
    {
        private bool flagManager;
        private bool flagSec;
        private bool flagMem;
        public Form1()
        {
            InitializeComponent();           
            panel1.Visible = true;
            panel2.Visible = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            flagManager = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            flagSec = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            flagMem = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            errorProvider1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flagManager)
                if (txtTz.Text == "031468473")
                {
                    Form2 f = new Form2("מנהל");
                    f.Show();
                    this.Hide();
                }
            if (flagSec)
                if (txtTz.Text == "031468473")
                {
                    Form2 f = new Form2("מזכירה");
                    f.Show();
                    this.Hide();
                }
            if(flagMem)                
                {
                    Form2 f = new Form2("משתתף");
                    f.Show();
                    this.Hide();
                }


        }
    }
}
