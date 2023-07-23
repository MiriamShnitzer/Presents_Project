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
    public partial class FrmMember : Form
    {
        private Member client;
        private MemberDB tblClient;
        private bool flagAdd;
        private bool flagUpdate;
        


        public FrmMember()
        {
            InitializeComponent();
            tblClient = new MemberDB();
            client = tblClient.GetList().FirstOrDefault();
            flagUpdate = false;
            flagAdd = false;
            NotPossible();
            dgMem.DataSource = tblClient.GetList().Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status

            }).ToList();
            //Fill(client);

        }
        public FrmMember(bool add) : this()
        {
            
            txtKod.ReadOnly = false;
            txtKod.Text = "";
            txtName.Text = "";
            txtAddr.Text = "";
            txtPel.Text = "";
            cbTafkid.Text = "";
            chkStatus.Checked = true;
            btnUpdate.Visible = false;
            panel1.Visible = true;
            Possible();

        }
        public FrmMember(Member c, bool up) : this()
        {
            btnUpdate.Visible = true;
            panel1.Visible = false;
            this.client = c;
            flagUpdate = up;
            Fill(c);
            if (flagUpdate)
                Possible();
        }
        

        
        private void Fill(Member client)
        {
            if(tblClient.Size()>0)
            {
                txtKod.Text = client.KodM.ToString();
                txtName.Text = client.NameM.ToString();
                txtAddr.Text = client.Address.ToString();
                cbTafkid.SelectedItem = client.Tafkid.ToString();
                cbTafkid.Text= client.Tafkid.ToString();
                txtPel.Text = client.PelM.ToString();
                chkStatus.Checked = (client.Status.Equals(true));

            }
            else
            {
                txtKod.Text = "";
                txtName.Text = "";
                txtAddr.Text = "";
                txtPel.Text = "";
                cbTafkid.Text = "";
                chkStatus.Checked = false;
            }
        }
       


        private void btnUpdate_Click(object sender, EventArgs e)// עדכן
        {
            panel2.Visible = false;
            btnCancle.Visible = true;
            btnSave.Visible = true;
            string st = dgMem.SelectedRows[0].Cells[0].Value.ToString();
            client = tblClient.Find(st);
            Fill(client);
            flagUpdate = true;           
            dgMem.DataSource = tblClient.GetList().Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status

            }).ToList();
        }
        private void Possible()
        {
            panel1.Visible = true;
            btnSave.Visible = true;
            btnCancle.Visible = true;
            
        }
        private void NotPossible()
        {
            flagAdd = false;
            flagUpdate = false;
            btnSave.Visible = false;
            btnCancle.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)// שמור
        {
            if(flagUpdate)
                if(CreateFields(client))
                {
                    DialogResult r = MessageBox.Show("האם לעדכן משתתף זה?", " אישור עדכון", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if(r==DialogResult.Yes)
                    {
                        tblClient.UpdateRow(client);
                        NotPossible();
                        dgMem.DataSource = tblClient.GetList().Select(x => new
                        {
                            קוד = x.KodM,
                            שם = x.NameM,
                            כתובת = x.Address,
                            פלאפון = x.PelM,
                            תפקיד = x.Tafkid,
                            פעיל = x.Status
                        }).ToList();
                    }
                }
            if(flagAdd)
            {
                Member c = new Member();
                if(tblClient.Find(txtName.Text)==null&& tblClient.Find(txtPel.Text) == null&& 
                   tblClient.Find(txtAddr.Text) == null&& tblClient.Find(cbTafkid.Text) == null)
                {
                    if(CreateFields(c))
                    {
                        DialogResult r = MessageBox.Show("האם להוסיף משתתף זה?", "אישור הוספה", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if(r==DialogResult.Yes)
                        {
                            tblClient.AddNew(c);
                           
                            dgMem.DataSource = tblClient.GetList().Select(x => new
                            {
                                קוד = x.KodM,
                                שם = x.NameM,
                                כתובת = x.Address,
                                פלאפון = x.PelM,
                                תפקיד = x.Tafkid,
                                פעיל = x.Status
                            }).ToList();
                            NotPossible();
                            clean();
                            panel2.Visible = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("משתתף זה כבר קיים");
                }
                
            }
            panel2.Visible = true;
            clean();
            dgMem.DataSource = tblClient.GetList().Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
            NotPossible();
            clean();
            panel2.Visible = true;
        }

        private bool CreateFields(Member c)
        {
            bool ok = true;
            errorProvider1.Clear();
            try
            {
                c.KodM = Convert.ToInt32( txtKod.Text);
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txtKod, ex.Message);
                ok = false;
            }
            try
            {
                c.NameM = txtName.Text;
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txtName, ex.Message);
                ok = false;
            }
            try
            {
                c.Address = txtAddr.Text;
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txtAddr, ex.Message);
                ok = false;
            }
            try
            {
                c.PelM = txtPel.Text;
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txtPel, ex.Message);
                ok = false;
            }
            try
            {
                c.Tafkid = cbTafkid.SelectedItem.ToString();
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(cbTafkid, ex.Message);
                ok = false;
            }
            c.Status = (chkStatus.Checked == true);
            return ok;
        }

        private void btnCancle_Click(object sender, EventArgs e)// בטל
        {
            NotPossible();
            errorProvider1.Clear();
            clean();
            panel2.Visible = true;
            dgMem.DataSource = tblClient.GetList().Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }
        private void clean()
        {
            txtKod.Text = "";
            txtAddr.Text = "";
            txtKod.Text = "";
            txtName.Text = "";
            txtPel.Text = "";
            cbTafkid.Text = "";
        }
         
        private void btnNew_Click(object sender, EventArgs e)// חדש
        {
            flagAdd = true;
            txtKod.Text = tblClient.GetNextKey().ToString();
            txtAddr.Text = "";
            
            txtName.Text = "";
            txtPel.Text = "";
            cbTafkid.Text = "";
            Possible();
            panel2.Visible = false;
            panel1.Visible = true;
           
        }

        private void btnDel_Click(object sender, EventArgs e)// מחק
        {
          
            DialogResult r = MessageBox.Show("האם למחוק לקוח זה?", "אישור מחיקה", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                string st = dgMem.SelectedRows[0].Cells[0].Value.ToString();
                tblClient.DeleteStatus(st);
                dgMem.DataSource = tblClient.GetList().Select(x => new
                {
                    קוד = x.KodM,
                    שם = x.NameM,
                    כתובת = x.Address,
                    פלאפון = x.PelM,
                    תפקיד = x.Tafkid,
                    פעיל = x.Status
                }).ToList();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)// שינוי בשם
        {
            dgMem.DataSource = tblClient.GetList().Where(x => x.NameM.StartsWith(txtName.Text) && x.Address.StartsWith(txtAddr.Text) &&
            x.PelM.StartsWith(txtPel.Text) && x.Tafkid.StartsWith(cbTafkid.Text)).Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }

        private void txtAddr_TextChanged(object sender, EventArgs e)// שינוי בכתובת
        {
            dgMem.DataSource = tblClient.GetList().Where(x => x.NameM.StartsWith(txtName.Text) && x.Address.StartsWith(txtAddr.Text) &&
            x.PelM.StartsWith(txtPel.Text) && x.Tafkid.StartsWith(cbTafkid.Text)).Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }

        private void txtPel_TextChanged(object sender, EventArgs e)// שינוי בפלאפון
        {
            dgMem.DataSource = tblClient.GetList().Where(x => x.NameM.StartsWith(txtName.Text) && x.Address.StartsWith(txtAddr.Text) &&
            x.PelM.StartsWith(txtPel.Text) && x.Tafkid.StartsWith(cbTafkid.Text)).Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }

        private void txtTafkid_TextChanged(object sender, EventArgs e)// שינוי בתפקיד
        {
            dgMem.DataSource = tblClient.GetList().Where(x => x.NameM.StartsWith(txtName.Text) && x.Address.StartsWith(txtAddr.Text) &&
            x.PelM.StartsWith(txtPel.Text) && x.Tafkid.StartsWith(cbTafkid.Text)).Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)// שינוי בסטטוס
        {
            dgMem.DataSource = tblClient.GetList().Where(x => x.NameM.StartsWith(txtName.Text) && x.Address.StartsWith(txtAddr.Text) &&
            x.PelM.StartsWith(txtPel.Text) && x.Tafkid.StartsWith(cbTafkid.Text) && chkStatus.Checked == x.Status).Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }

        private void cbTafkid_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgMem.DataSource = tblClient.GetList().Where(x => x.Tafkid==(cbTafkid.Text)|| x.Tafkid.StartsWith  (cbTafkid.Text)).Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgMem.DataSource = tblClient.GetList().Select(x => new
            {
                קוד = x.KodM,
                שם = x.NameM,
                כתובת = x.Address,
                פלאפון = x.PelM,
                תפקיד = x.Tafkid,
                פעיל = x.Status
            }).ToList();
        }
    }
}
