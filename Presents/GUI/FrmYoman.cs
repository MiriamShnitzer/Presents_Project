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
    public partial class FrmYoman : Form
    {
        private YomanDB tblJ;
        private Yoman jew;
        private bool flagAdd;
        private bool flagUpdate;
        private MemberDB tblM;
        private EventsDB tblE;
        private StockPreDB tblStoP;
        public FrmYoman()
        {
            InitializeComponent();
            btnFind.Visible = true;
            tblJ = new YomanDB();
            tblM = new MemberDB();
            tblE = new EventsDB();
            tblStoP = new StockPreDB();
            jew = tblJ.GetList().FirstOrDefault();
            flagUpdate = false;
            flagAdd = false;
            cbMem.DataSource = tblM.GetList().ToList();
            cbEvent.DataSource = tblE.GetList().ToList();
            cbPre.DataSource = tblStoP.GetList().ToList();
            NotPossible();
            btnFind.Visible = false;
            
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
            Possible();
            panel3.Visible = false;
            btnCanc.Visible = false;
            btnSgor.Visible = false;
        }
        private void Fill(Yoman jewllery)
        {
            if (tblJ.Size() > 0)
            {
                txtKodY.Text = jewllery.KodYoman.ToString();
                cbMem.SelectedItem = jewllery.ThisMember();
                cbMem.Text = jewllery.ThisMember().NameM;
                cbEvent.SelectedItem = jewllery.ThisEvents();
                cbEvent.Text = jewllery.ThisEvents().TeurE;
                dTimeE.Text = jewllery.dateE.ToString();
                cbPre.SelectedItem = jewllery.ThisPresent();
                cbPre.Text = jewllery.ThisPresent().TeurPre;
                txtChariga.Text = jewllery.Chariga.ToString();
                chkStatus.Checked = (jewllery.IsDone.Equals(true));

            }
            else
            {
                txtKodY.Text = "";
                cbMem.Text = "";
                cbPre.Text = "";
                cbEvent.Text = "";
                txtChariga.Text = "";
                dTimeE.Text = "";
                chkStatus.Checked = false;
            }
        }
        private void Possible()
        {
            btnSave.Visible = true;
            btnCancle.Visible = true;
            txtKodY.ReadOnly = true;
            cbMem.Enabled = true;
            dTimeE.Enabled = true;
            cbEvent.Enabled = true;                
            chkStatus.Enabled = true;
            cbPre.Enabled = true;
        }
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            btnSave.Visible = false;
            btnCancle.Visible = false;
            txtKodY.ReadOnly = true;
            cbMem.Enabled = false;
            cbEvent.Enabled = false;
            cbPre.Enabled = false;
            txtChariga.ReadOnly = true;
            dTimeE.Enabled = false;
            chkStatus.Enabled = false;
            btnCancle.Visible = false;
            btnSave.Visible = false;
        }
        private bool CreateFields(Yoman c)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                c.KodYoman = Convert.ToInt32(txtKodY.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtKodY, ex.Message);
                ok = false;
            }
            try
            {
                c.KodPre = ((StockPre)cbPre.SelectedItem).KodP;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbPre, ex.Message);
                ok = false;
            }

            try
            {
                c.Chariga = Convert.ToDouble(txtChariga.Text);
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtChariga, ex.Message);
                ok = false;
            }
            try
            {
                c.KodM = ((Member)cbMem.SelectedItem).KodM;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbMem, ex.Message);
                ok = false;
            }
            try
            {
                c.KodEvent = ((Events)cbEvent.SelectedItem).KodE;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cbEvent, ex.Message);
                ok = false;
            }
            try
            {
                c.dateE = dTimeE.Value ;
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(dTimeE, ex.Message);
                ok = false;
            }
            c.IsDone = (chkStatus.Checked == true);
            return ok;
        }
        private void clean()
        {
            txtKodY.Text = "";
            txtChariga.Text = "";
            cbMem.Text = "";
            cbPre.Text = "";
            cbEvent.Text = "";
            dTimeE.Text = "";
        }


        private void btnSave_Click(object sender, EventArgs e)// שמור
        {
            if (flagUpdate)
                if (CreateFields(jew))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן אירוע זה?", " אישור עדכון", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblJ.UpdateRow(jew);
                        Possible();
                        panel1.Visible = true;
                        panel3.Visible = false;
                        clean();
                    }
                    else
                        panel1.Visible = true;
                }
            if (flagAdd)
            {
                Yoman c = new Yoman();
                if (this.tblJ.Find(txtKodY.Text.ToString()) == null)
                {
                    if (CreateFields(c))
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף אירוע זה?", "אישור הוספה", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblJ.AddNew(c);
                            dgY.DataSource = tblJ.GetList().Select(x => new
                            {
                                קוד_יומן = x.KodYoman,
                                משתתף = x.ThisMember().NameM,
                                סוג_האירוע = x.ThisEvents().TeurE,
                                תאריך_האירוע = x.dateE,
                                מתנה = x.ThisPresent().TeurPre,
                                בוצע = x.IsDone,
                                גובה_חריגה = x.Chariga
                            }).ToList();
                            Possible();
                            panel1.Visible = true;
                            panel3.Visible = false;
                            clean();
                        }
                    }
                }
            }
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
            panel3.Visible = false;
            btnCanc.Visible = false;
        }

        
    

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Possible();
            panel1.Visible = false;
            string st = dgY.SelectedRows[0].Cells[0].Value.ToString();
            Yoman j = tblJ.Find(st);
            Fill(j);
            flagUpdate = true;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            panel1.Visible = true;
            panel3.Visible = false;
            btnFind.Visible = false;
            btnCanc.Visible = false;
            clean();
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
        }

        private void cbMem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Where(x=> x.ThisMember().NameM == cbMem.Text).Select(x => new
                 {
                     קוד_יומן = x.KodYoman,
                     משתתף = x.ThisMember().NameM,
                     סוג_האירוע = x.ThisEvents().TeurE,
                     תאריך_האירוע = Convert.ToDateTime(x.dateE),
                     מתנה = x.ThisPresent().TeurPre,
                     בוצע = x.IsDone,
                     גובה_חריגה = x.Chariga
                 }).ToList();
        }

        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Where(x => x.ThisEvents().TeurE == cbEvent.Text).Select(x => new
                 {
                     קוד_יומן = x.KodYoman,
                     משתתף = x.ThisMember().NameM,
                     סוג_האירוע = x.ThisEvents().TeurE,
                     תאריך_האירוע = x.dateE,
                     מתנה = x.ThisPresent().TeurPre,
                     בוצע = x.IsDone,
                     גובה_חריגה = x.Chariga
                 }).ToList();
        }

        private void dTimeE_ValueChanged(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Where(x => x.dateE == Convert.ToDateTime(dTimeE.Value)).Select(x => new
                 {
                     קוד_יומן = x.KodYoman,
                     משתתף = x.ThisMember().NameM,
                     סוג_האירוע = x.ThisEvents().TeurE,
                     תאריך_האירוע = x.dateE,
                     מתנה = x.ThisPresent().TeurPre,
                     בוצע = x.IsDone,
                     גובה_חריגה = x.Chariga
                 }).ToList();
        }

        

        private void txtChariga_TextChanged(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Where(x => x.Chariga.ToString().StartsWith(txtChariga.Text)).Select(x => new
                {
                    קוד_יומן = x.KodYoman,
                    משתתף = x.ThisMember().NameM,
                    סוג_האירוע = x.ThisEvents().TeurE,
                    תאריך_האירוע = x.dateE,
                    מתנה = x.ThisPresent().TeurPre,
                    בוצע = x.IsDone,
                    גובה_חריגה = x.Chariga
                }).ToList();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtKodY.Text = tblJ.GetNextKey().ToString();
            Possible();
            btnFind.Visible = true;
            panel1.Visible = false;
            btnCanc.Visible = true;
            flagAdd = true;
            cbMem.DataSource = tblM.GetList().ToList();
            cbEvent.DataSource = tblE.GetList().ToList();
            cbPre.DataSource = tblStoP.GetList().ToList();
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע =x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {                   
            panel1.Visible = false;
            panel3.Visible =false;
            btnFind.Visible = true;
            
            btnCanc.Visible = true;
            string st = dgY.SelectedRows[0].Cells[0].Value.ToString();
            jew = tblJ.Find(st);
            Fill(jew);
            flagUpdate = true;
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga

            }).ToList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSearchPre f = new FrmSearchPre((Member)cbMem.SelectedItem,cbEvent.SelectedItem.ToString(),this);
            f.Show();
        }
        public void ComeBack(StockPre qq,double x)
        {
            cbPre.SelectedItem = qq;
            cbPre.Text = qq.TeurPre;
            panel3.Visible = true;
            btnCanc.Visible = false;
            if (x < 0)
                txtChariga.Text = "0";
            else
                txtChariga.Text = x.ToString();
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            panel1.Visible = true;
            panel3.Visible = false;
            btnFind.Visible = false;
            clean();
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
            btnCanc.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = true;
            txtChariga.ReadOnly = false;
            btnSave.Visible = false;
            btnCancle.Visible = false;
            btnSgor.Visible = true;
        }

        private void btnSgor_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            txtChariga.ReadOnly = true;
            btnSgor.Visible = false;
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();

        }

        private void cbPre_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Where(x => x.ThisPresent().TeurPre == cbPre.Text).Select(x => new
                {
                    קוד_יומן = x.KodYoman,
                    משתתף = x.ThisMember().NameM,
                    סוג_האירוע = x.ThisEvents().TeurE,
                    תאריך_האירוע = x.dateE,
                    מתנה = x.ThisPresent().TeurPre,
                    בוצע = x.IsDone,
                    גובה_חריגה = x.Chariga
                }).ToList();
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Where(x => x.IsDone == chkStatus.Checked).Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dgY.DataSource = tblJ.GetList().Select(x => new
            {
                קוד_יומן = x.KodYoman,
                משתתף = x.ThisMember().NameM,
                סוג_האירוע = x.ThisEvents().TeurE,
                תאריך_האירוע = x.dateE,
                מתנה = x.ThisPresent().TeurPre,
                בוצע = x.IsDone,
                גובה_חריגה = x.Chariga
            }).ToList();
        }
    }
}
