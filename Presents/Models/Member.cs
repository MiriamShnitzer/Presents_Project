using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Presents.Models
{
    public class Member
    {
       
        private string nameM;        
        private string address;
        private string pelM;
        private string tafkid;
        private bool status;

        public DataRow Dr { get; set; }
        public int KodM { get; set; }
        public bool Status { get; set; }
        public Member()
        {
        }

        public Member(DataRow dr)
        {
            this.Dr = dr;
            this.KodM = Convert.ToInt32( dr["kodM"]);
            this.nameM = dr["nameM"].ToString();
            this.address = dr["address"].ToString();
            this.pelM = dr["pelM"].ToString();
            this.tafkid = dr["tafkid"].ToString();
            if (dr["status"].Equals(true))
                this.Status = true;
            else
                this.Status = false;
        }
        public string NameM
        {
            get
            {
                return this.nameM;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.nameM = value;
                else
                    throw new Exception("שם המשתתף אינו תקין");
            }
        }
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.address = value;
                else
                    throw new Exception("הכתובת אינה תקינה");
            }
        }
        public string PelM
        {
            get
            {
                return this.pelM;
            }
            set
            {
                if (ValidateUtil.IsCellPhone(value))
                    this.pelM = value;
                else
                    throw new Exception("הפלאפון אינו תקין");
            }
        }
        
        public string Tafkid
        {
            get
            {
                return this.tafkid;
            }
            set
            {
                if (ValidateUtil.IsHebrew(value))
                    this.tafkid = value;
                else
                    throw new Exception("תפקיד המשתתף שהוקש אינו תקין");
            }
        }

        public void PutInto()
        {
            Dr["kodM"] = this.KodM;
            Dr["nameM"] = this.nameM;
            Dr["address"] = this.address;
            Dr["pelM"] = this.pelM;
            Dr["tafkid"] = this.tafkid;
            Dr["status"] = this.Status;
        }

        public override string ToString()
        {
            return nameM+"";
        }
    }
}
