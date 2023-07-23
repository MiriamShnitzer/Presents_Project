namespace Presents.GUI
{
    partial class FrmYearlyDoch
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 44.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(375, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "דוח הוצאות שנתי";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(552, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = ":בשנה החולפת הוצאות הקופה הסתכמו ב";
            // 
            // txtDoch
            // 
            this.txtDoch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtDoch.Location = new System.Drawing.Point(403, 239);
            this.txtDoch.Name = "txtDoch";
            this.txtDoch.Size = new System.Drawing.Size(125, 31);
            this.txtDoch.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(329, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "ש\"ח";
            // 
            // FrmYearlyDoch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1109, 581);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDoch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmYearlyDoch";
            this.Text = "FrmYearlyDoch";
            this.Load += new System.EventHandler(this.FrmYearlyDoch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDoch;
        private System.Windows.Forms.Label label3;
    }
}