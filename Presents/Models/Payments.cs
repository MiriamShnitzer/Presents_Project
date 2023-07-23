using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Presents.DB;

namespace Presents.Models
{
   public class Payments
    {
        
              
        private int yearT;
        private double schum;
        private string payWay;
        private DateTime dateT;             


     public DataRow Dr { get; set; }
        public int KodTash { get; set; }
        public int KodM { get; set; }


        public Payments()
        {
        }

        public Payments(DataRow dr)
        {
            this.Dr = dr;
            this.KodTash = Convert.ToInt32(dr["kodTash"]);
            this.KodM = Convert.ToInt32(dr["kodM"]);
            this.yearT = Convert.ToInt32(dr["yearT"]);
            this.schum = Convert.ToDouble(dr["schum"]);
            this.payWay = dr["payWay"].ToString();
            this.dateT = Convert.ToDateTime(dr["dateT"].ToString());

        }
        
        public int YearT
        {
            get
            {
                return this.yearT;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.yearT = value;
                else
                    throw new Exception("השנה שהוקשה אינה תקינה");
            }
        }
        public double Schum
        {
            get
            {
                return this.schum;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.schum = value;
                else
                    throw new Exception("הסכום לתשלום אינו תקין");
            }
        }
        public DateTime DateT
        {
            get
            {
                return this.dateT;
            }
            set
            {
               
                    this.dateT = value;
               
            }
        }

        public string PayWay
        {
            get
            {
                return this.payWay;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.payWay = value;
                else
                    throw new Exception("אופן התשלום אינו תקין");
            }
        }

        public void PutInto()
        {
            Dr["kodTash"] = this.KodTash;
            Dr["kodM"] = this.KodM;
            Dr["yearT"] = this.yearT;
            Dr["schum"] = this.schum;
            Dr["dateT"] = this.dateT;
            Dr["payWay"] = this.payWay;
        }

        public Member ThisMember()
        {
            MemberDB tblk = new MemberDB();
            return tblk.GetList().First(x => x.KodM == this.KodM);
        }
        public Gvia ThisGvia()
        {
            GviaDB tblk = new GviaDB();
            return tblk.GetList().First(x => x.YearG == this.yearT);
        }

        public override string ToString()
        {
            return KodTash + "" + yearT + ""+schum+""+dateT;
        }





    }
}
