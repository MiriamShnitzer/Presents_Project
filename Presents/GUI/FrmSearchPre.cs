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

namespace Presents.GUI
{
    public partial class FrmSearchPre : Form
    {
       
        public object qq;
        private EventsDB tblE;
        private YomanDB tblY;
        private StockPreDB tblStoP;
        private FrmYoman ff;
        public FrmSearchPre(Member member, string eve,FrmYoman f)
        {
            InitializeComponent();

            

            panel1.Visible = false;
            tblE = new EventsDB();
            tblY = new YomanDB();
            tblStoP = new StockPreDB();
            cbPre.DataSource = tblStoP.GetList().Where(x=> x.Status==true).ToList();
            txtMem.Text = member.NameM;           
            txtEve.Text = eve.ToString();
            ff = f;
            dgMatanot.DataSource = tblY.GetList().Where(x => x.ThisMember().NameM == txtMem.Text).Select(x => new
            {
                משתתף = x.ThisMember().NameM,
                מתנה = x.ThisPresent().TeurPre
            }).ToList();

        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            bool flagChariga = false;
            bool flagMem = false;
            if(cbPre.Text=="סכום כסף")
            {
                panel1.Visible = true;
            }
            DialogResult r = new DialogResult();
            Events ev = tblE.GetList().First(x => x.TeurE == txtEve.Text);
            StockPre sp = tblStoP.GetList().First(x => x.TeurPre == cbPre.SelectedItem.ToString());
            if (sp.AlutP > ev.Taarif)
                flagChariga = true;

            if (tblY.GetList().Find(x => x.ThisMember().NameM == txtMem.Text && x.ThisPresent().TeurPre == cbPre.SelectedItem.ToString())
                != null)
                flagMem = true;
            if (flagMem&&!flagChariga)
            {
                r = MessageBox.Show("משתתף זה כבר קיבל בעבר מתנה זו. האם תרצה בכל זאת לבחור במתנה זו?", "אישור בחירה", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                    cbPre.Text = "";
                else
                {
                    double x = sp.AlutP - ev.Taarif;
                    ff.ComeBack((StockPre)(cbPre.SelectedItem), x);
                    this.Hide();
                }

            }

            if (flagChariga&&!flagMem)
            {
                r = MessageBox.Show("עלות המתנה שבחרת גבוהה מן התעריף לאירוע. האם תרצה בכל זאת לבחור במתנה זו?", "אישור בחירה", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                    cbPre.Text = "";
                else
                {
                    double x = sp.AlutP - ev.Taarif;
                    ff.ComeBack((StockPre)(cbPre.SelectedItem), x);
                    this.Hide();
                }


            }
            if (flagChariga && flagMem)
            {
                r = MessageBox.Show("משתתף זה כבר קיבל בעבר מתנה זו. האם תרצה בכל זאת לבחור במתנה זו?", "אישור בחירה", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                    cbPre.Text = "";
                else
                {
                    r = MessageBox.Show("עלות המתנה שבחרת גבוהה מן התעריף לאירוע. האם תרצה בכל זאת לבחור במתנה זו?", "אישור בחירה", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.No)
                        cbPre.Text = "";
                    else
                    {
                        double z = sp.AlutP - ev.Taarif;
                        ff.ComeBack((StockPre)(cbPre.SelectedItem), z);
                        this.Hide();
                    }
                    
                }
            }
            if (!flagChariga&&!flagMem)
            {
               double x = sp.AlutP - ev.Taarif;
               ff.ComeBack((StockPre)(cbPre.SelectedItem), x);
               this.Hide();                
            }
        }       
    }
}

