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
    public partial class PreForMem : Form
    {
        private YomanDB tblY;
        private StockPreDB tblStoP;
        private MemberDB tblM;
        public PreForMem(bool flag)
        {
            InitializeComponent();

            tblY = new YomanDB();
            tblStoP = new StockPreDB();
            tblM = new MemberDB();
            if (flag == true)
            {
                panel1.Visible = true;
                label1.Text = "מתנות שנקנו למשתתף";
            }
            else
            {
                label1.Text = " מתנות שנקנו לכל משתתף";
                panel1.Visible = false;
                dgDoch.DataSource = tblY.GetList().Select(x=> new {
                    משתתף = x.ThisMember().NameM,
                    מתנה = x.ThisPresent().TeurPre
                }).OrderBy(x=>x.משתתף).ToList();
            }
                 

        }

        private void PreForMem_Load(object sender, EventArgs e)
        {

        }

        private void btnIshur_Click(object sender, EventArgs e)
        {
            
            if (tblM.GetList().Find(x => x.NameM == txtName.Text) == null)
            {
                MessageBox.Show("אינך קיים במאגר המשתתפים, נסה להקיש את שמך שוב");
                txtName.Text = "";
                
            }
            else
                dgDoch.DataSource = tblY.GetList().Where(x => x.ThisMember().NameM == txtName.Text).Select(x => new
                {
                    משתתף = x.ThisMember().NameM,
                    מתנה = x.ThisPresent().TeurPre
                }).ToList();
           
        }
    }
}
