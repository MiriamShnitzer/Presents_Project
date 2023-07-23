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
    public partial class FrmPKinds : Form
    {
        //private PKinds PKinds;
        private PKindsDB tblPK;
        public FrmPKinds()
        {
            InitializeComponent();
            tblPK = new PKindsDB();
            dgSug.DataSource = tblPK.GetList();
            dgSug.DataSource = tblPK.GetList().Select(x => new { קוד = x.KodK,סוג_מתנה = x.TeurK }).ToList();
            panel1.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtKod.Text = tblPK.GetNextKey().ToString();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            PKinds k = new PKinds();
            if (tblPK.GetList().Exists(x => x.TeurK == this.txtsug.Text))
            {
                MessageBox.Show("סוג מתנה זה כבר קיים", "שגיאת הוספה", MessageBoxButtons.OK);
                txtsug.Text = "";
            }
            else

                if (CreateFields(k))
            {
                DialogResult r = MessageBox.Show("האם להוסיף סוג מתנה זה?", "אישור הוספה",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    tblPK.AddNew(k);
                    dgSug.DataSource = tblPK.GetList().Select(x => new
                    { קוד = x.KodK, סוג_מתנה = x.TeurK }).ToList();
                    NotPossible();
                }
            }

        }
        private bool CreateFields(PKinds k)
        {
            bool ok = true;
            errorProvider1.Clear();
            k.KodK = Convert.ToInt32(txtKod.Text);
            try
            {
                k.TeurK = txtsug.Text;
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

       


    }
}
