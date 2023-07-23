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
using Presents.Data;

namespace Presents.Gui
{
    public partial class FrmStockPre : Form
    {
        private StockPreDB tblJ;
        private StockPre jew;
        private bool flagAdd;
        private bool flagUpdate;
        private PKindsDB tblK;
        private CompanyDB tblComp;
        public FrmStockPre()
        {
            InitializeComponent();

            tblJ = new StockPreDB();
            tblK = new PKindsDB();
            tblComp = new CompanyDB();
            jew = tblJ.GetList().FirstOrDefault();
            flagUpdate = false;
            flagAdd = false;
            cbsog.DataSource = tblK.GetList().ToList();

            cbComp.DataSource = tblComp.GetList().ToList();
            NotPossible();
            dgJ.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_מתנה = x.TeurPre,
                סוג_מתנה = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
            Possible();
            btnSave.Visible = false;
            btnCancle.Visible = false;
        }

        private void Fill(StockPre jewllery)
        {
            if (tblJ.Size() > 0)
            {
                txtKodP.Text = jewllery.KodP.ToString();
                cbsog.SelectedItem = jewllery.ThisPKinds();
                cbsog.Text = jewllery.ThisPKinds().TeurK;
                txtTeur.Text = jewllery.TeurPre.ToString();
                cbComp.SelectedItem = jewllery.ThisComp();
                cbComp.Text = jewllery.ThisComp().TeurComp;
                txtPriceOne.Text = jewllery.AlutP.ToString();
                chkStatus.Checked = (jewllery.Status.Equals(true));

            }
            else
            {
                txtKodP.Text = "";
                cbsog.Text = "";
                txtTeur.Text = "";
                cbComp.Text = "";
                txtPriceOne.Text = "";
                chkStatus.Checked = false;
            }
        }
        private void Possible()
        {
            btnSave.Visible = true;
            btnCancle.Visible = true;
            txtKodP.ReadOnly = true;
            cbsog.Enabled = true;
            txtTeur.ReadOnly = false;
            cbComp.Enabled = true;
            txtPriceOne.ReadOnly = false;
            chkStatus.Enabled = true;
        }
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            btnSave.Visible = false;
            btnCancle.Visible = false;
            txtKodP.ReadOnly = true;
            cbsog.Enabled = false;
            cbComp.Enabled = false;
            txtPriceOne.ReadOnly = true;
            txtTeur.ReadOnly = true;
            chkStatus.Enabled = false;
            btnCancle.Visible = false;
            btnSave.Visible = false;
        }
        private bool CreateFields(StockPre c)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                c.KodP = Convert.ToInt32(txtKodP.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtKodP, ex.Message);
                ok = false;
            }
            try
            {
                c.TeurPre = txtTeur.Text;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtTeur, ex.Message);
                ok = false;
            }

            try
            {
                c.AlutP = Convert.ToDouble(txtPriceOne.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtPriceOne, ex.Message);
                ok = false;
            }
            try
            {

                c.KodKind = ((PKinds)cbsog.SelectedItem).KodK;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbsog, ex.Message);
                ok = false;
            }
            try
            {
                c.KodComp = ((Company)cbComp.SelectedItem).KodComp;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbComp, ex.Message);
                ok = false;
            }
            c.Status = (chkStatus.Checked == true);
            return ok;
        }

        private void btnNew_Click(object sender, EventArgs e)// חדש
        {
            txtKodP.Text = tblJ.GetNextKey().ToString();
            cbsog.DataSource = tblK.GetList().ToList();
            cbComp.DataSource = tblComp.GetList().ToList();
            Possible();
            panel1.Visible = false;
            flagAdd = true;
            flagUpdate = false;
            dgJ.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }



        private void btnUpdate_Click(object sender, EventArgs e)// עדכן
        {
            Possible();
            panel1.Visible = false;
            string st = dgJ.SelectedRows[0].Cells[0].Value.ToString();
            jew = tblJ.Find(st);
            Fill(jew);
            flagUpdate = true;
            flagAdd = false;


        }



        private void cbsog_SelectedIndexChanged(object sender, EventArgs e)// שינוי בסוג תכשיט
        {
            dgJ.DataSource = tblJ.GetList().Where(x => x.ThisPKinds().TeurK == cbsog.Text).Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }
        private void cbComp_SelectedIndexChanged(object sender, EventArgs e)//שינוי בחברה
        {
            dgJ.DataSource = tblJ.GetList().Where(x => x.ThisComp().TeurComp == cbComp.Text).Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }

        private void txtTeur_TextChanged(object sender, EventArgs e)// שינוי בשם מתנה
        {
            dgJ.DataSource = tblJ.GetList().Where(x => x.TeurPre.StartsWith(txtTeur.Text)).Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }



        private void txtPriceOne_TextChanged(object sender, EventArgs e)// שינוי בעלות
        {
            dgJ.DataSource = tblJ.GetList().Where(x => x.AlutP.ToString().StartsWith(txtPriceOne.Text)).Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }


        private void btnSave_Click_1(object sender, EventArgs e)// שמור
        {
            if (flagUpdate)
                if (CreateFields(jew))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן מתנה זו?", " אישור עדכון", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblJ.UpdateRow(jew);
                        Possible();
                        dgJ.DataSource = tblJ.GetList().Select(x => new
                        {
                            קוד_מתנה = x.KodP,
                            תיאור_המתנה = x.TeurPre,
                            סוג = x.ThisPKinds().TeurK,
                            חברה = x.ThisComp().TeurComp,
                            עלות = x.AlutP,
                            זמין = x.Status
                        }).ToList();
                        panel1.Visible = true;
                        btnSave.Visible = false;
                        btnCancle.Visible = false;
                        clean();
                    }
                }
            if (flagAdd)
            {
                StockPre c = new StockPre();
                if (this.tblJ.Find(txtKodP.Text.ToString()) == null)
                {
                    if (CreateFields(c))
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף מתנה זו?", "אישור הוספה", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblJ.AddNew(c);
                            dgJ.DataSource = tblJ.GetList().Select(x => new
                            {
                                קוד_מתנה = x.KodP,
                                תיאור_המתנה = x.TeurPre,
                                סוג = x.ThisPKinds().TeurK,
                                חברה = x.ThisComp().TeurComp,
                                עלות = x.AlutP,
                                זמין = x.Status
                            }).ToList();
                            Possible();
                            panel1.Visible = true;
                            btnSave.Visible = false;
                            btnCancle.Visible = false;
                            clean();
                        }
                    }
                }
            }
            dgJ.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();

        }

        private void btnCancle_Click_1(object sender, EventArgs e)// בטל
        {
            clean();
            errorProvider1.Clear();
            panel1.Visible = true;
            btnCancle.Visible = false;
            btnSave.Visible = false;
            dgJ.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();

        }


        private void clean()
        {
            txtKodP.Text = "";
            txtPriceOne.Text = "";
            cbComp.Text = "";
            cbsog.Text = "";
            txtTeur.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)// מחק
        {
            DialogResult r = MessageBox.Show("האם למחוק מתנה זו?", "אישור מחיקה", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                string st = dgJ.SelectedRows[0].Cells[0].Value.ToString();
                tblJ.DeleteStatus(st);
                dgJ.DataSource = tblJ.GetList().Select(x => new
                {
                    קוד_מתנה = x.KodP,
                    תיאור_המתנה = x.TeurPre,
                    סוג = x.ThisPKinds().TeurK,
                    חברה = x.ThisComp().TeurComp,
                    עלות = x.AlutP,
                    זמין = x.Status
                }).ToList();

            }
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            dgJ.DataSource = tblJ.GetList().Where(x => chkStatus.Checked == x.Status).Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgJ.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_מתנה = x.KodP,
                תיאור_המתנה = x.TeurPre,
                סוג = x.ThisPKinds().TeurK,
                חברה = x.ThisComp().TeurComp,
                עלות = x.AlutP,
                זמין = x.Status
            }).ToList();
        }
    }


    
}
