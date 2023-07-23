using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Presents.DB;



namespace Presents.Models
{
   public class Yoman
    {
        private double chariga;
        public DateTime dateE;
        public bool IsDone { get; set; }

        public DataRow Dr { get; set; }
        public int KodYoman { get; set; }
        public int KodM { get; set; }
        public int KodEvent { get; set; }
        public int KodPre { get; set; }
        public Yoman()
        {
        }

        public Yoman(DataRow dr)
        {
            this.Dr = dr;
            this.KodYoman = Convert.ToInt32(dr["kodYoman"]);
            this.KodM = Convert.ToInt32(dr["kodM"]);
            this.KodEvent = Convert.ToInt32(dr["kodEvent"]);
            this.dateE = Convert.ToDateTime(dr["dateE"].ToString());
            this.KodPre = Convert.ToInt32(dr["kodPre"]);
            this.chariga = Convert.ToDouble(dr["chariga"]);

            if (dr["IsDone"].Equals(true))
                this.IsDone = true;
            else
                this.IsDone = false;
        }
        public double Chariga
        {
            get
            {
                return this.chariga;
            }
            set
            {
                if (ValidateUtil.IsNum(value.ToString()))
                    this.chariga = value;
                else
                    throw new Exception("החריגה שהוקשה אינה תקינה");
            }
        }
        
        public void PutInto()
        {
            Dr["kodYoman"] = this.KodYoman;
            Dr["kodM"] = this.KodM;
            Dr["kodEvent"] = this.KodEvent;
            Dr["kodPre"] = this.KodPre;
            Dr["dateE"] = this.dateE;
            Dr["isDone"] = this.IsDone;
            Dr["chariga"] = this.chariga;
        }

        public Events ThisEvents()
        {
            EventsDB tblk = new EventsDB();
            return tblk.GetList().First(x => x.KodE == this.KodEvent);
        }

        public Member ThisMember()
        {
            MemberDB tblk = new MemberDB();
            return tblk.GetList().First(x => x.KodM == this.KodM);
        } 

        public StockPre ThisPresent()
        {
            StockPreDB tblk = new StockPreDB();
            return tblk.GetList().First(x => x.KodP == this.KodPre);
        }
        public override string ToString()
        {
            return KodYoman + "" + dateE + "" +chariga;
        }
    }
}


