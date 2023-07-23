using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Presents.Models
{
   public class Events
    {
        private string teurE;
        private double taarif;
        public int KodE { get; set; }
        public DataRow Dr { get; set; }
        public Events()
        {

        }
        public Events(DataRow dr)
        {
            this.Dr = dr;
            this.KodE = Convert.ToInt32(dr["kodE"]);
            this.teurE = (dr["teurE"]).ToString();
            this.taarif = Convert.ToInt32(dr["taarif"]);
        }
        public double Taarif
        {
            get
            {
                return this.taarif;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.taarif = value;
                else
                    throw new Exception("התעריף שהוקש אינו תקין");
            }
        }
        public string TeurE
        {
            get
            {
                return this.teurE;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.teurE = value;
                else
                    throw new Exception("תיאור האירוע אינו תקין");
            }
        }
        public void PutInto()
        {
            Dr["kodE"] = this.KodE;
            Dr["teurE"] = this.teurE;
            Dr["taarif"] = this.taarif;
        }
        public override string ToString()
        {
            return  teurE+"";
        }
    }
}
