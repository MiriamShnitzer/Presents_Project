using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class PaymentsDB : GeneralDB
    {
        protected List<Payments> list = new List<Payments>();
        public PaymentsDB()
            : base("Payments")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Payments(dr));
            }
        }

        public List<Payments> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Payments Find(string code)
        {
            return this.GetList().Find(x => x.KodTash.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            Payments c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
      
        public void UpdateRow(Payments c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Payments c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodTash) + 1;
        }

    }
}

