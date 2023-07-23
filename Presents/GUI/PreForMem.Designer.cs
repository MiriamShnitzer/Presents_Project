namespace Presents.GUI
{
    partial class PreForMem
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnIshur = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgDoch)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(732, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "מתנות שקיבל משתתף";
            // 
            // dgDoch
            // 
            this.dgDoch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDoch.Location = new System.Drawing.Point(302, 280);
            this.dgDoch.Name = "dgDoch";
            this.dgDoch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgDoch.Size = new System.Drawing.Size(475, 276);
            this.dgDoch.TabIndex = 1;
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(38, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(156, 20);
            this.txtName.TabIndex = 3;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIshur);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(360, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 143);
            this.panel1.TabIndex = 71;
            // 
            // PreForMem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1077, 636);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgDoch);
            this.Controls.Add(this.label1);
            this.Name = "PreForMem";
            this.Text = "PreForMem";
            this.Load += new System.EventHandler(this.PreForMem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDoch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgDoch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnIshur;
        private System.Windows.Forms.Panel panel1;
    }
}