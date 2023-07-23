namespace Presents.GUI
{
    partial class FrmYoman
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgY = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.cbMem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKodY = new System.Windows.Forms.TextBox();
            this.txtChariga = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dTimeE = new System.Windows.Forms.DateTimePicker();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnFind = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbPre = new System.Windows.Forms.ComboBox();
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnSgor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgY)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgY
            // 
            this.dgY.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgY.Location = new System.Drawing.Point(470, 114);
            this.dgY.Name = "dgY";
            this.dgY.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgY.Size = new System.Drawing.Size(726, 333);
            this.dgY.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(316, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(528, 79);
            this.label1.TabIndex = 54;
            this.label1.Text = "יומן מעקב אירועים";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbEvent);
            this.panel2.Controls.Add(this.cbMem);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtKodY);
            this.panel2.Location = new System.Drawing.Point(38, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 150);
            this.panel2.TabIndex = 61;
            // 
            // cbEvent
            // 
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Location = new System.Drawing.Point(9, 113);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(160, 21);
            this.cbEvent.TabIndex = 60;
            this.cbEvent.SelectedIndexChanged += new System.EventHandler(this.cbEvent_SelectedIndexChanged);
            // 
            // cbMem
            // 
            this.cbMem.FormattingEnabled = true;
            this.cbMem.Location = new System.Drawing.Point(9, 70);
            this.cbMem.Name = "cbMem";
            this.cbMem.Size = new System.Drawing.Size(160, 21);
            this.cbMem.TabIndex = 56;
            this.cbMem.SelectedIndexChanged += new System.EventHandler(this.cbMem_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(240, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 51;
            this.label3.Text = "משתתף";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(223, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "סוג אירוע";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(173, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 18);
            this.label6.TabIndex = 49;
            this.label6.Text = "קוד יומן אירועים";
            // 
            // txtKodY
            // 
            this.txtKodY.Location = new System.Drawing.Point(9, 23);
            this.txtKodY.Name = "txtKodY";
            this.txtKodY.Size = new System.Drawing.Size(160, 20);
            this.txtKodY.TabIndex = 46;
            // 
            // txtChariga
            // 
            this.txtChariga.Location = new System.Drawing.Point(9, 107);
            this.txtChariga.Name = "txtChariga";
            this.txtChariga.ReadOnly = true;
            this.txtChariga.Size = new System.Drawing.Size(160, 20);
            this.txtChariga.TabIndex = 64;
            this.txtChariga.TextChanged += new System.EventHandler(this.txtChariga_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(211, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "גובה חריגה";
            // 
            // dTimeE
            // 
            this.dTimeE.Location = new System.Drawing.Point(9, 18);
            this.dTimeE.Name = "dTimeE";
            this.dTimeE.Size = new System.Drawing.Size(160, 20);
            this.dTimeE.TabIndex = 61;
            this.dTimeE.ValueChanged += new System.EventHandler(this.dTimeE_ValueChanged);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.LightGray;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCancle.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancle.Location = new System.Drawing.Point(52, 189);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(97, 48);
            this.btnCancle.TabIndex = 59;
            this.btnCancle.Text = "בטל";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSave.ForeColor = System.Drawing.Color.Maroon;
            this.btnSave.Location = new System.Drawing.Point(176, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 48);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "שמור";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(255, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 53;
            this.label5.Text = "מתנה";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(201, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 52;
            this.label4.Text = "תאריך אירוע";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkStatus.Location = new System.Drawing.Point(134, 149);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(166, 22);
            this.chkStatus.TabIndex = 44;
            this.chkStatus.Text = "                   ?בוצע\r\n";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Location = new System.Drawing.Point(562, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 85);
            this.panel1.TabIndex = 62;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSearch.ForeColor = System.Drawing.Color.Maroon;
            this.btnSearch.Location = new System.Drawing.Point(3, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 55);
            this.btnSearch.TabIndex = 43;
            this.btnSearch.Text = "חפש";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnNew.ForeColor = System.Drawing.Color.Maroon;
            this.btnNew.Location = new System.Drawing.Point(271, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 55);
            this.btnNew.TabIndex = 42;
            this.btnNew.Text = "חדש";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightGray;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Maroon;
            this.btnUpdate.Location = new System.Drawing.Point(137, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 55);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "עדכן";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.LightGray;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnFind.ForeColor = System.Drawing.Color.Maroon;
            this.btnFind.Location = new System.Drawing.Point(122, 280);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(123, 58);
            this.btnFind.TabIndex = 43;
            this.btnFind.Text = "מציאת מתנה מתאימה";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbPre);
            this.panel3.Controls.Add(this.dTimeE);
            this.panel3.Controls.Add(this.txtChariga);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnCancle);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.chkStatus);
            this.panel3.Location = new System.Drawing.Point(38, 355);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 249);
            this.panel3.TabIndex = 63;
            // 
            // cbPre
            // 
            this.cbPre.Enabled = false;
            this.cbPre.FormattingEnabled = true;
            this.cbPre.Location = new System.Drawing.Point(9, 63);
            this.cbPre.Name = "cbPre";
            this.cbPre.Size = new System.Drawing.Size(160, 21);
            this.cbPre.TabIndex = 65;
            this.cbPre.SelectedIndexChanged += new System.EventHandler(this.cbPre_SelectedIndexChanged_1);
            // 
            // btnCanc
            // 
            this.btnCanc.BackColor = System.Drawing.Color.LightGray;
            this.btnCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnCanc.ForeColor = System.Drawing.Color.Maroon;
            this.btnCanc.Location = new System.Drawing.Point(385, 544);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(97, 48);
            this.btnCanc.TabIndex = 64;
            this.btnCanc.Text = "בטל";
            this.btnCanc.UseVisualStyleBackColor = false;
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnSgor
            // 
            this.btnSgor.BackColor = System.Drawing.Color.LightGray;
            this.btnSgor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSgor.ForeColor = System.Drawing.Color.Maroon;
            this.btnSgor.Location = new System.Drawing.Point(133, 610);
            this.btnSgor.Name = "btnSgor";
            this.btnSgor.Size = new System.Drawing.Size(97, 48);
            this.btnSgor.TabIndex = 65;
            this.btnSgor.Text = "סגור חיפוש";
            this.btnSgor.UseVisualStyleBackColor = false;
            this.btnSgor.Click += new System.EventHandler(this.btnSgor_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(400, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 55);
            this.button1.TabIndex = 44;
            this.button1.Text = "רענן";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FrmYoman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1226, 674);
            this.Controls.Add(this.btnSgor);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgY);
            this.Name = "FrmYoman";
            this.Text = "FrmYoman";
            ((System.ComponentModel.ISupportInitialize)(this.dgY)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dTimeE;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbMem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKodY;
        private System.Windows.Forms.TextBox txtChariga;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbPre;
        private System.Windows.Forms.Button btnCanc;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSgor;
        private System.Windows.Forms.Button button1;
    }
}