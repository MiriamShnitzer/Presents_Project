using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Presents.Models
{
   public class Company
    {
        private string teurComp;
        public DataRow Dr { get; set; }
        public int KodComp { get; set; }
        public Company()
        {

        }

        public Company(DataRow dr)
        {
            this.Dr = dr;
            this.KodComp = Convert.ToInt32(dr["kodComp"]);
            this.teurComp = dr["teurComp"].ToString();
        }
        public string TeurComp
        {
            get
            {
                return this.teurComp;
            }
            set
            {
                this.TeurComp = value;
               
                  
            }
        }
        public void PutInto()
        {
            Dr["kodComp"] = this.KodComp;
            Dr["teurComp"] = this.teurComp;
        }
        public override string ToString()
        {
            return   teurComp+"" ;
        }
    }
}
