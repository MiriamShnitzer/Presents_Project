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
    public partial class FrmYearlyDoch : Form
    {
        private YomanDB tblY;
        public FrmYearlyDoch()
        {
            InitializeComponent();
            tblY = new YomanDB();
            txtDoch.Text = tblY.GetList().Where(x=>x.dateE.Year==DateTime.Today.Year-1). Sum(x => x.ThisPresent().AlutP).ToString();
        }

        private void FrmYearlyDoch_Load(object sender, EventArgs e)
        {

        }
    }
}
