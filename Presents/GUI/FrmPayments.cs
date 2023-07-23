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
    public partial class FrmPayments : Form
    {
        private PaymentsDB tblP;
        private Payments pay;
        private bool flagAdd;
        private bool flagUpdate;
        private MemberDB tblM;
        private GviaDB tblG;
        
        public FrmPayments()
        {
            InitializeComponent();

            tblP = new PaymentsDB();
            tblM = new MemberDB();
            tblG = new GviaDB();
            pay = tblP.GetList().FirstOrDefault();
            flagUpdate = false;
            flagAdd = false;
            panel3.Visible = false;
            cbKodM.DataSource = tblM.GetList().ToList();
            cbYearT.DataSource = tblG.GetList().ToList();/////.Select(x => new { x.YearG }).ToList();
            cbYearT.Text = DateTime.Today.Year.ToString();
            cbPay.Text = "מזומן";
            NotPossible();
            dgTash.DataSource = tblP.GetList().Select(x => new
            {
                קוד_תשלום = x.KodTash,               
                משתתף = x.ThisMember().NameM,
                שנה= x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
            Possible();
            btnSave.Visible = false;
            btnCancle.Visible = false;
        }
        private void Possible()
        {
            btnSave.Visible = true;
            btnCancle.Visible = true;
            txtKodTash.ReadOnly = true;
            cbKodM.Enabled = true;
            cbYearT.Enabled = true;          
            txtSchum.ReadOnly = false;
            dtDate.Enabled = true;
            cbPay.Enabled = true;
            
        }
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            btnSave.Visible = false;
            btnCancle.Visible = false;
            txtKodTash.ReadOnly = true;
            cbKodM.Enabled = false;           
            cbYearT.Enabled = false;
            txtSchum.ReadOnly = true;
            dtDate.Enabled = false;
            cbPay.Enabled = false;
            btnCancle.Visible = false;
            btnSave.Visible = false;
        }
        private void Fill(Payments jewllery)
        {
            if (tblP.Size() > 0)
            {
                txtKodTash.Text = jewllery.KodTash.ToString();
                cbKodM.SelectedItem = jewllery.ThisMember();
                cbKodM.Text = jewllery.ThisMember().NameM;
                cbYearT.SelectedItem = jewllery.YearT.ToString();
                txtSchum.Text = jewllery.Schum.ToString();
                dtDate.Text = jewllery.DateT.ToString();
                cbPay.SelectedItem = jewllery.PayWay.ToString();


            }
            else
            {
                txtKodTash.Text = "";
                cbKodM.Text = "";
                cbYearT.Text = "";
                txtSchum.Text = "";
                dtDate.Text = "";
                cbPay.Text = "";
            }
        }
        private bool CreateFields(Payments c)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                c.KodTash = Convert.ToInt32(txtKodTash.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtKodTash, ex.Message);
                ok = false;
            }
            try
            {
                c.KodM = ((Member)(cbKodM.SelectedItem)).KodM;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbKodM, ex.Message);
                ok = false;
            }

            try
            {
                if (tblG.GetList().Exists(x => x.YearG == Convert.ToInt32(cbYearT.Text)) == true)
                    c.YearT = ((Gvia)(cbYearT.SelectedItem)).YearG;
                else
                    throw new Exception("עבור השנה שהקשת עדיין לא נקבע תעריף הגבייה, ביכולתך לשלם עבור השנה הזו ויתרתך תשמר");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbYearT, ex.Message);
                ok = false;
            }
            try
            {
                c.Schum = Convert.ToInt32(txtSchum.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtSchum, ex.Message);
                ok = false;
            }
            try
            {
                c.DateT = dtDate.Value ;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(dtDate, ex.Message);
                ok = false;
            }
            try
            {
                c.PayWay = cbPay.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbPay, ex.Message);
                ok = false;
            }

            return ok;
        }
        private void clean()
        {
            txtKodTash.Text = "";
            cbKodM.Text = "";
            txtSchum.Text = "";
            cbYearT.Text = "";
            cbPay.Text = "";
            dtDate.Value = DateTime.Today;
         
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            txtKodTash.Text = tblP.GetNextKey().ToString();
            cbKodM.DataSource = tblM.GetList().ToList();          
            Possible();
            panel1.Visible = false;
            flagAdd = true;
            flagUpdate = false;
            dgTash.DataSource = tblP.GetList().Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Possible();
            panel1.Visible = false;
            string st = dgTash.SelectedRows[0].Cells[0].Value.ToString();            
            pay = tblP.Find(st);
            Fill(pay);
            flagUpdate = true;
            flagAdd = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flagUpdate)
                if (CreateFields(pay))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן תשלום זה?", " אישור עדכון", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblP.UpdateRow(pay);
                        Possible();
                        dgTash.DataSource = tblP.GetList().Select(x => new
                        {
                            קוד_תשלום = x.KodTash,
                            משתתף = x.ThisMember().NameM,
                            שנה = x.YearT,
                            סכום_לתשלום = x.Schum,
                            תאריך = x.DateT,
                            אופן_התשלום = x.PayWay
                        }).ToList();
                        panel1.Visible = true;
                        btnSave.Visible = false;
                        btnCancle.Visible = false;
                        clean();
                    }
                }
            if (flagAdd)
            {
                Payments c = new Payments();
                if (this.tblP.Find(txtKodTash.Text.ToString()) == null)
                {
                    if (CreateFields(c))
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף תשלום זה?", "אישור הוספה", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblP.AddNew(c);
                            dgTash.DataSource = tblP.GetList().Select(x => new
                            {
                                קוד_תשלום = x.KodTash,
                                משתתף = x.ThisMember().NameM,
                                שנה = x.YearT,
                                סכום_לתשלום = x.Schum,
                                תאריך = x.DateT,
                                אופן_התשלום = x.PayWay
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
            dgTash.DataSource = tblP.GetList().Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
            cbKodM.DataSource = tblM.GetList().ToList();
            cbYearT.Text = DateTime.Today.Year.ToString();
            cbPay.Text = "מזומן";


        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            clean();
            errorProvider1.Clear();
            panel1.Visible = true;
            btnCancle.Visible = false;
            btnSave.Visible = false;
            dgTash.DataSource = tblP.GetList().Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
            cbKodM.DataSource = tblM.GetList().ToList();
            cbYearT.Text = DateTime.Today.Year.ToString();
            cbPay.Text = "מזומן";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgSikum.Visible = true;
            btnAdd.Visible = false;
            
            var y = tblP.GetList().Select(x => new { x.YearT }).Distinct().ToList();
            var m = tblM.GetList();
            
            foreach (var i in y)
            {            
                dgSikum.DataSource = tblM.GetList().Select(x => new
                {                  
                    קוד_משתתף = x.KodM,
                    משתתף = x.NameM,
                    שנה = i.YearT,                    
                    סך_התשלום_לשנה_זו = tblP.GetList().Where(p =>p.YearT == i.YearT && p.KodM==x.KodM).Sum(p =>p.Schum)
                }).ToList();
                
                panel3.Visible = true;

            }
        }




        private void btnSgor_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            btnAdd.Visible = true;
        }

        private void cbKodM_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgTash.DataSource = tblP.GetList().Where(x => x.ThisMember().NameM == cbKodM.Text).Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
        }

        private void cbYearT_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgTash.DataSource = tblP.GetList().Where(x => x.YearT == Convert.ToInt32(cbYearT.Text)).Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
        }

        private void txtSchum_TextChanged(object sender, EventArgs e)
        {
            if (txtSchum.Text != "")
            {
                dgTash.DataSource = tblP.GetList().Where(x => x.Schum.ToString().StartsWith(txtSchum.Text)).Select(x => new
                {
                    קוד_תשלום = x.KodTash,
                    משתתף = x.ThisMember().NameM,
                    שנה = x.YearT,
                    סכום_לתשלום = x.Schum,
                    תאריך = x.DateT,
                    אופן_התשלום = x.PayWay
                }).ToList();
            }
        }
        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            dgTash.DataSource = tblP.GetList().Where(x => x.DateT == Convert.ToDateTime(dtDate.Value)).Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
        }

        private void cbPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgTash.DataSource = tblP.GetList().Where(x => x.PayWay == cbPay.Text).Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();

        }

       

        private void dgSikum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string t = dgSikum.SelectedRows[0].Cells[0].Value.ToString();
            Member m= tblM.Find(t);
            int ko = m.KodM;
            FrmHovZchut f = new FrmHovZchut(true,ko);
            f.Show();
        }

        private void dgSikum_Click(object sender, EventArgs e)
        {
            string t = dgSikum.SelectedRows[0].Cells[0].Value.ToString();
            Member m = tblM.Find(t);
            int ko = m.KodM;
            FrmHovZchut f = new FrmHovZchut(true, ko);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgTash.DataSource = tblP.GetList().Select(x => new
            {
                קוד_תשלום = x.KodTash,
                משתתף = x.ThisMember().NameM,
                שנה = x.YearT,
                סכום_לתשלום = x.Schum,
                תאריך = x.DateT,
                אופן_התשלום = x.PayWay
            }).ToList();
        }
    }
}
