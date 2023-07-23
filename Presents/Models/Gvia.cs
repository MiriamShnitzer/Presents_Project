using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Presents.Models
{
    public class Gvia
    {
        private int yearG;
        private double schumG;
        public DataRow Dr { get; set; }

        public Gvia(DataRow dr)
        {
            this.Dr = dr;
            this.yearG = Convert.ToInt32(dr["yearG"]);
            this.schumG = Convert.ToDouble(dr["schumG"]);
        }
        public Gvia()
        {

        }

        public int YearG
        {
            get
            {
                return this.yearG;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.yearG = value;
                else
                    throw new Exception("השנה שהוקשה אינה תקינה");
            }
        }
        public double SchumG
        {
            get
            {
                return this.schumG;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.schumG = value;
                else
                    throw new Exception("סכום הגבייה אינו תקין");
            }
        }
        public void PutInto()
        {
            Dr["yearG"] = this.yearG;
            Dr["schumG"] = this.schumG;
        }
        public override string ToString()
        {
            return yearG.ToString();///////+ ""+schumG ;
        }
    }
}
