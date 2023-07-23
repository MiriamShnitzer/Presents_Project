namespace Presents.GUI
{
    partial class FrmHovZchut
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgDoch = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIshur = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDoch)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1087, 77);
            this.label1.TabIndex = 2;
            this.label1.Text = "             דוח חובות/ זכויות            ";
            // 
            // dgDoch
            // 
            this.dgDoch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDoch.Location = new System.Drawing.Point(316, 343);
            this.dgDoch.Name = "dgDoch";
            this.dgDoch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgDoch.Size = new System.Drawing.Size(527, 330);
            this.dgDoch.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIshur);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(408, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 139);
            this.panel1.TabIndex = 72;
            // 
            // btnIshur
            // 
            this.btnIshur.BackColor = System.Drawing.Color.LightGray;
            this.btnIshur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnIshur.ForeColor = System.Drawing.Color.Maroon;
            this.btnIshur.Location = new System.Drawing.Point(139, 78);
            this.btnIshur.Name = "btnIshur";
            this.btnIshur.Size = new System.Drawing.Size(100, 56);
            this.btnIshur.TabIndex = 70;
            this.btnIshur.Text = "אישור";
            this.btnIshur.UseVisualStyleBackColor = false;
            this.btnIshur.Click += new System.EventHandler(this.btnIshur_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(38, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(156, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(200, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "הקש את שמך כאן";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDoch);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(224, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(729, 51);
            this.panel2.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(109, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 37);
            this.label3.TabIndex = 9;
            this.label3.Text = "ש\"ח";
            // 
            // txtDoch
            // 
            this.txtDoch.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDoch.Location = new System.Drawing.Point(203, 3);
            this.txtDoch.Name = "txtDoch";
            this.txtDoch.ReadOnly = true;
            this.txtDoch.Size = new System.Drawing.Size(125, 44);
            this.txtDoch.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(334, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(387, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = ":חובך/ יתרתך מסתכמת ב";
            // 
            // FrmHovZchut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1226, 685);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgDoch);
            this.Controls.Add(this.label1);
            this.Name = "FrmHovZchut";
            this.Text = "FrmHovZchut";
            this.Load += new System.EventHandler(this.FrmHovZchut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDoch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDoch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIshur;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDoch;
        private System.Windows.Forms.Label label4;
    }
}