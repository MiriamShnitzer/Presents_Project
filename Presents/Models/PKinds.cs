using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Presents.Models
{
   public class PKinds
    {

        private string teurK;
        public DataRow Dr { get; set; }
        public int KodK { get; set; }
        public PKinds()
        {

        }

        public PKinds(DataRow dr)
        {
            this.Dr = dr;
            this.KodK = Convert.ToInt32(dr["kodK"]);
            this.teurK = dr["teurK"].ToString();
        }
        public string TeurK
        {
            get
            {
                return this.teurK;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.teurK = value;
                else
                    throw new Exception("שם סוג המתנה אינו תקין");
            }
        }
        public void PutInto()
        {
            Dr["kodK"] = this.KodK;
            Dr["teurK"] = this.teurK;
        }
        

        public override string ToString()
        {
            return teurK + "";
        }

       
    }
}
