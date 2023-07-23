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
    public partial class FrmEvents : Form
    {
       
            private EventsDB tblEvents;
            private Events eve;
            private bool flagAdd;
            private bool flagUpdate;
            private EventsDB tblK;
            public FrmEvents()
            {
                InitializeComponent();

                tblEvents = new EventsDB();
                tblK = new EventsDB();
                eve = tblEvents.GetList().FirstOrDefault();
                flagUpdate = false;
                flagAdd = false;
                
                NotPossible();
                dgKinds.DataSource = tblEvents.GetList().Select(x => new
                {
                    קוד_אירוע = x.KodE,
                    סוג_אירוע = x.TeurE,                  
                    תעריף = x.Taarif,
                    
                }).ToList();
                Possible();
                btnSave.Visible = false;
                btnCancle.Visible = false;
            }

            private void Fill(Events events)
            {
                if (tblEvents.Size() > 0)
                {
                    txtkod.Text = events.KodE.ToString();                                    
                    txtteur.Text = events.TeurE.ToString();                  
                    txttaarif.Text = events.Taarif.ToString();
                   

                }
                else
                {
                    txtkod.Text = "";                   
                    txtteur.Text = "";                  
                    txttaarif.Text = "";
                   
                }
            }
            private void Possible()
            {
                btnSave.Visible = true;
                btnCancle.Visible = true;           
                txtkod.ReadOnly = true;              
                txtteur.ReadOnly = false;              
                txttaarif.ReadOnly = false;
               
            }
            private void NotPossible()
            {
                flagAdd = false;
                flagUpdate = false;
                btnSave.Visible = false;
                btnCancle.Visible = false;
                txtkod.ReadOnly = true;              
                txttaarif.ReadOnly = true;
                txtteur.ReadOnly = true;              
                btnCancle.Visible = false;
                btnSave.Visible = false;
            }
            private bool CreateFields(Events c)
            {
                bool ok = true;
                errorProvider1.Clear();
                try
                {
                    c.KodE = Convert.ToInt32(txtkod.Text);

                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtkod, ex.Message);
                    ok = false;
                }
                try
                {
                    c.TeurE = txtteur.Text;
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txtteur, ex.Message);
                    ok = false;
                }
               
                
                try
                {
                    c.Taarif = Convert.ToDouble(txttaarif.Text);
                }
                catch (Exception ex)
                {
                    errorProvider1.SetError(txttaarif, ex.Message);
                    ok = false;
                }
            return ok;
               
            }

        private void btnNew_Click_1(object sender, EventArgs e)// חדש
        {
            txtkod.Text = tblEvents.GetNextKey().ToString();
            Possible();
            flagAdd = true;
            dgKinds.DataSource = tblEvents.GetList().Select(x => new
            {
                קוד_אירוע = x.KodE,
                סוג_אירוע = x.TeurE,
                תעריף = x.Taarif,

            }).ToList();
        }


        private void btnUpdate_Click_1(object sender, EventArgs e)// עדכן
        {
            Possible();
            txtteur.ReadOnly = true;
            string st = dgKinds.SelectedRows[0].Cells[0].Value.ToString();
            eve = tblEvents.Find(st);
            Fill(eve);
            flagUpdate = true;
            btnNew.Visible = false;
            btnUpdate.Visible = false;
            dgKinds.DataSource = tblEvents.GetList().Select(x => new
            {
                קוד_אירוע = x.KodE,
                סוג_אירוע = x.TeurE,
                תעריף = x.Taarif,

            }).ToList();
        }

        //private void txtkod_TextChanged(object sender, EventArgs e)// שינוי בקוד אירוע
        //{
        //    dgKinds.DataSource = tblK.GetList().Where(x => x.KodE.ToString().StartsWith(txtkod.Text) && x.TeurE.StartsWith(txtteur.Text)
        //            && x.Taarif.ToString().StartsWith(txttaarif.Text)).Select(x => new
        //            {
        //                קוד_סוג_אירוע = x.KodE,
        //                סוג_אירוע = x.TeurE,
        //                תעריף = x.Taarif,
        //            }).ToList();
        //}


        private void txtteur_TextChanged_1(object sender, EventArgs e)// שינוי בסוג אירוע
        {
            dgKinds.DataSource = tblK.GetList().Where(x =>  x.TeurE.StartsWith(txtteur.Text)
                && x.Taarif.ToString().StartsWith(txttaarif.Text)).Select(x => new
                {
                    קוד_סוג_אירוע = x.KodE,
                    סוג_אירוע = x.TeurE,
                    תעריף = x.Taarif,
                }).ToList();
        }



        private void txttaarif_TextChanged(object sender, EventArgs e)// שינוי בתעריף
        {
            dgKinds.DataSource = tblK.GetList().Where(x =>  x.TeurE.StartsWith(txtteur.Text)
                     && x.Taarif.ToString().StartsWith(txttaarif.Text)).Select(x => new
                     {
                         קוד_תכשיט = x.KodE,
                         שם_תכשיט = x.TeurE,
                         מחיר = x.Taarif,
                     }).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)// שמור
        {
            if (flagUpdate)
                if (CreateFields(eve))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן סוג אירוע זה?", " אישור עדכון", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (r == DialogResult.Yes)
                    {
                        tblK.UpdateRow(eve);
                        Possible();
                        panel1.Visible = true;
                        btnSave.Visible = false;
                        btnCancle.Visible = false;
                        clean();
                        errorProvider1.Clear();
                    }
                }
            if (flagAdd)
            {
                Events c = new Events();
                if (this.tblK.Find(txtkod.Text.ToString()) == null)
                {
                    if (CreateFields(c))
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף סוג אירוע זה?", "אישור הוספה", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            tblK.AddNew(c);
                            dgKinds.DataSource = tblK.GetList().Select(x => new
                            {
                                קוד_תכשיט = x.KodE,
                                שם_תכשיט = x.TeurE,
                                מחיר = x.Taarif,
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
            btnUpdate.Visible = true;
            btnNew.Visible = true;

        }

        private void btnCancle_Click(object sender, EventArgs e)// בטל
        {
            errorProvider1.Clear();
            clean();
            panel1.Visible = true;
            btnCancle.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnNew.Visible = true;
        }
      
            private void clean()
            {
                txtkod.Text = "";
                txttaarif.Text = "";               
                txtteur.Text = "";
            }

       
    }  
}
