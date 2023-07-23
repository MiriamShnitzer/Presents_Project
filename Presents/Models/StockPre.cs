using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Presents.DB;
namespace Presents.Models
{
  public  class StockPre
    {       
        private double alutP;
        private string teurPre;
        public bool Status { get; set; }

        public DataRow Dr { get; set; }
        public int KodP { get; set; }
        public int KodKind { get; set; }
        public int KodComp { get; set; }
        public StockPre()
        {
        }

        public StockPre(DataRow dr)
        {
            this.Dr = dr;
            this.KodP = Convert.ToInt32(dr["kodP"]);
            this.KodKind = Convert.ToInt32(dr["kodKind"]);
            this.KodComp = Convert.ToInt32(dr["kodComp"]);
            this.alutP = Convert.ToDouble(dr["alutP"]);
            this.teurPre = dr["teurPre"].ToString();
            if (dr["status"].Equals(true))
                this.Status = true;
            else
                this.Status = false;
        }
        public string TeurPre
        {
            get
            {
                return this.teurPre;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.teurPre = value;
                else
                    throw new Exception("שם המתנה אינו תקין");
            }
        }
        public double AlutP
        {
            get
            {
                return this.alutP;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.alutP = value;
                else
                    throw new Exception("עלות המתנה אינה תקינה");
            }
        }
        public void PutInto()
        {
            Dr["kodP"] = this.KodP;
            Dr["kodKind"] = this.KodKind;
            Dr["kodComp"] = this.KodComp;
            Dr["teurPre"] = this.teurPre;
            Dr["status"] = this.Status;
            Dr["alutP"] = this.alutP;                    
        }

        public PKinds ThisPKinds()
        {
            PKindsDB tblk = new PKindsDB();
            return tblk.GetList().First(x => x.KodK == this.KodKind);
        }
        public Company ThisComp()
        {
            CompanyDB tblk = new CompanyDB();
            return tblk.GetList().First(x => x.KodComp == this.KodComp);
        }
        public override string ToString()
        {
            return  teurPre + "" ;
        }


    }
}
