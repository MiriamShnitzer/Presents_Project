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
using Presents.GUI;

namespace Presents.GUI
{
    public partial class FrmDochSchum : Form
    {
        private PaymentsDB tblP;
        private YomanDB tblY;
        
        public FrmDochSchum()
        {
            InitializeComponent();
            tblP = new PaymentsDB();
            tblY = new YomanDB();
            double hachnasot = tblP.GetList().Sum(x => x.Schum);
            double hotzaot = tblY.GetList().Sum(x => x.ThisPresent().AlutP);
            txtDoch.Text = (hachnasot - hotzaot).ToString();
        }

        private void FrmDochSchum_Load(object sender, EventArgs e)
        {

        }
    }
}
