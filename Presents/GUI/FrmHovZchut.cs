using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presents.DB;
using Presents.Models;
using Presents.GUI;

namespace Presents.GUI
{
    public partial class FrmHovZchut : Form
    {
        private GviaDB tblG;
        private PaymentsDB tblP;
        private MemberDB tblM;
        private YomanDB tblY;

        private static double hOrZ;
        public FrmHovZchut(bool flag)
        {
            InitializeComponent();
            tblG = new GviaDB();
            tblM = new MemberDB();
            tblP = new PaymentsDB();
            tblY = new YomanDB();
            if(flag)
            {
                panel1.Visible = true;
                label1.Text = "החוב/ היתרה שלך";
                dgDoch.Visible = false;
                panel2.Visible = false;
            }

            else
            {
                label1.Text = " דוח חובות/ זכויות";
                panel1.Visible = false;
                dgDoch.Visible = true;
                panel2.Visible = false;

            }
            
            double gvia = tblG.GetList().Sum(x => x.SchumG);
            double charigot = tblY.GetList().Where(y => y.ThisMember().NameM == txtName.Text).Sum(z => z.Chariga);

            dgDoch.DataSource = tblM.GetList().Select(x => new
                {
                    משתתף = x.NameM,

                    חוב_או_יתרה = tblP.GetList().Where(p => p.KodM == x.KodM).Sum(p => p.Schum) - gvia-charigot
                }).ToList();


               
        }
        public FrmHovZchut(bool flag,int kod)
        {
            InitializeComponent();
            tblG = new GviaDB();
            tblM = new MemberDB();
            tblP = new PaymentsDB();
            tblY = new YomanDB();
            panel1.Visible = false;
            string s = tblM.GetList().First(y => y.KodM == kod).NameM;
            label1.Text = "החוב/ היתרה של: "+s;
            txtName.Text = tblP.GetList().First(y => y.ThisMember().KodM == kod).ThisMember().NameM;
            
            dgDoch.Visible = false;
            panel2.Visible = true;
            double gvia = tblG.GetList().Sum(r => r.SchumG);
            double charigot = tblY.GetList().Where(y => y.ThisMember().NameM == txtName.Text).Sum(z => z.Chariga);
            double x = tblP.GetList().Where(y => y.ThisMember().KodM == kod).Sum(y => y.Schum) - gvia-charigot;
            txtDoch.Text = x.ToString();
        }

        private void btnIshur_Click(object sender, EventArgs e)
        {
            if (tblM.GetList().Find(x => x.NameM == txtName.Text) == null)
            {
                MessageBox.Show("אינך קיים במאגר המשתתפים, נסה להקיש את שמך שוב");
                txtName.Text = "";
            }
            else
            {
                panel2.Visible = true;
                double gvia = tblG.GetList().Sum(r => r.SchumG);
                double charigot = tblY.GetList().Where(y => y.ThisMember().NameM == txtName.Text).Sum(z => z.Chariga);
                double x = tblP.GetList().Where(y => y.ThisMember().NameM == txtName.Text).Sum(y => y.Schum) - gvia-charigot;
                txtDoch.Text = x.ToString();
                
            }

        }

        private void FrmHovZchut_Load(object sender, EventArgs e)
        {

        }
    }
}

