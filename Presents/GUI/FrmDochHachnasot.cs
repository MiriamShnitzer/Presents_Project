using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presents.Models;
using Presents.GUI;
using Presents.DB;


namespace Presents.GUI
{
    public partial class FrmDochHachnasot : Form
    {
        private PaymentsDB tblP;
        public FrmDochHachnasot()
        {
            InitializeComponent();
            tblP = new PaymentsDB();
            txtDoch.Text = tblP.GetList().Sum(x => x.Schum).ToString();
        }

        private void FrmDochHachnasot_Load(object sender, EventArgs e)
        {

        }
    }
}
