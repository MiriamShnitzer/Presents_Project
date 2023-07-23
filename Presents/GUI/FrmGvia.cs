using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presents.DB;
using Presents.Models;


namespace Presents.Gui
{
    public partial class FrmGvia : Form
    {
        private Gvia k;
        private GviaDB tblGvia;
        Boolean flagNew;
        Boolean flagCharig;
        public FrmGvia()
        {
            InitializeComponent();
            tblGvia = new GviaDB();
            dgSug.DataSource = tblGvia.GetList();
            dgSug.DataSource = tblGvia.GetList().Select(x => new { שנת_גבייה = x.YearG, סכום_לגבייה = x.SchumG }).ToList();
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int y = tblGvia.GetList().Max(x => x.YearG);
            if (DateTime.Today.Day <5  && DateTime.Today.Month <5&& DateTime.Today.Year==y+1) 
           
            {
                txtYear.Text = (DateTime.Today.Year ).ToString();
                txtSum.Text = "";
                Possible();
                txtSum.Select();
                flagNew = true;
            }
            else
                MessageBox.Show("קביעת תעריף לגבייה חדשה ניתנת רק בתחילת שנה");
        }

        private void Possible()
        {
            panel1.Visible = true;
            panel2.Visible = false;
            btnNew.Visible = false;
            btnCharig.Visible = false;
            txtSum.ReadOnly = false;
        }

        private void NotPossible()
        {
            panel1.Visible = false;
            btnNew.Visible = true;
            btnCharig.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult r;
            Gvia k1 = new Gvia();
            if (flagNew)
            {
                if (tblGvia.GetList().Exists(x => x.YearG.ToString() == this.txtYear.Text))
                {

                    MessageBox.Show("כבר נקבעה גבייה לשנה זו", "שגיאת הוספה", MessageBoxButtons.OK);
                    txtSum.Text = "";
                    txtYear.Text = "";
                    panel1.Visible = false;
                    btnNew.Visible = true;
                    btnCharig.Visible = true;
                    
                }
                else

              if (CreateFields(k1))
                {
                    r = MessageBox.Show("האם לקבוע פרטי גבייה זו?", "אישור הוספה",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblGvia.AddNew(k1);
                        dgSug.DataSource = tblGvia.GetList().Select(x => new
                        { שנת_גבייה = x.YearG, סכום_לגבייה = x.SchumG }).ToList();
                        NotPossible();
                    }
                }
            }
            else
                if (flagCharig)
                if (CreateFields(k))
                {

                    r = MessageBox.Show("האם לקבוע גבייה חריגה?", " אישור עדכון", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        k.SchumG = Convert.ToInt32(txtSum.Text) + Convert.ToInt32(txtCharig.Text);
                        tblGvia.UpdateRow(k);
                        Possible();
                        panel1.Visible = false;
                        btnCharig.Visible = true;
                        btnNew.Visible = true;
                        clean();
                    }
                    dgSug.DataSource = tblGvia.GetList().Select(x => new
                    { שנת_גבייה = x.YearG, סכום_לגבייה = x.SchumG }).ToList();
                }
        }

            private void clean()
            {
               txtYear.Text = "";
                txtSum.Text = "";
               txtCharig.Text = "";
            }

        
        private bool CreateFields(Gvia k)
        {
            bool ok=true;
            errorProvider1.Clear();
            //k.YearG = Convert.ToInt32(txtYear.Text);
            try
            {
                k.YearG = Convert.ToInt32( txtYear.Text);            
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txtSum, ex.Message);
                ok = false;
            }
            try
            {
                k.SchumG = Convert.ToInt32(txtSum.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtSum, ex.Message);
                ok = false;
            }
            return ok;

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            NotPossible();
            errorProvider1.Clear();
            clean();
        }

        private void button1_Click(object sender, EventArgs e)// גבייה חריגה
        {
            panel3.Visible = true;
            btnNew.Visible = false;
            btnCharig.Visible = false;
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txttz.Text) == 031468473)
            {
                panel3.Visible = false;
                txttz.Text = "";
                Possible();
                panel2.Visible = true;
                flagCharig = true;
                flagNew = false;
                int y = tblGvia.GetList().Max(x => x.YearG);
                if (y != DateTime.Today.Year || DateTime.Today.Month > 9 /*|| DateTime.Today.Month < 12*/)
                {
                    panel1.Visible = false;
                    btnNew.Visible = true;
                    btnCharig.Visible = true;
                    MessageBox.Show("עדיין לא נקבעה גבייה לשנה זו, ולכן לא ניתן לבצע גבייה חריגה");
                    txtSum.Text = "";
                    txtYear.Text = "";


                }

                else
                {
                    txtYear.Text = y.ToString();
                    k = tblGvia.GetList().Find(x => x.YearG == y);
                    txtSum.Text = k.SchumG.ToString();
                    txtYear.ReadOnly = true;
                    txtSum.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("תעודת הזהות אינה תקינה, נסה שוב");
                txttz.Text = "";

            }
        }
    }
}
