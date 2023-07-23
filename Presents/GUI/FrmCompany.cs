using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presents.Models;
using Presents.DB;

namespace Presents.GUI
{
    public partial class FrmCompany : Form
    {
        //private Company comp;
        private CompanyDB tblComp;
       
        public FrmCompany()
        {
            InitializeComponent();
            tblComp = new CompanyDB();
            dgSug.DataSource = tblComp.GetList();
            dgSug.DataSource = tblComp.GetList().Select(x => new { קוד = x.KodComp, שם = x.TeurComp }).ToList();
            panel1.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtKod.Text = tblComp.GetNextKey().ToString();
            txtsug.Text = "";
            Possible();
            txtsug.Select();
           
        }

        private void Possible()
        {
            panel1.Visible = true;
            btnNew.Visible = false;          
            txtsug.ReadOnly = false;
        }

        private void NotPossible()
        {
            panel1.Visible = false;
            btnNew.Visible = true;
           
        }
       
       
            private bool CreateFields(Company k)
        {
            bool ok = true;
            errorProvider1.Clear();
            k.KodComp = Convert.ToInt32(txtKod.Text);
            try
            {
                k.TeurComp = txtsug.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtsug, ex.Message);
                ok = false;
            }
            return ok;

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            NotPossible();
            errorProvider1.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Company k = new Company();
            if (tblComp.GetList().Exists(x => x.TeurComp == this.txtsug.Text))
            {
                MessageBox.Show("חברה זו כבר קיימת במאגר", "שגיאת הוספה", MessageBoxButtons.OK);
                txtsug.Text = "";
            }
            else

                if (CreateFields(k))
            {
                DialogResult r = MessageBox.Show("האם להוסיף חברה זו?", "אישור הוספה",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    tblComp.AddNew(k);
                    dgSug.DataSource = tblComp.GetList().Select(x => new
                    { קוד = x.KodComp, תאור = x.TeurComp }).ToList();
                    NotPossible();
                }
            }
        }
    }


}

