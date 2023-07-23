using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class GviaDB : GeneralDB
    {
        protected List<Gvia> list = new List<Gvia>();
        public GviaDB()
            : base("Gvia")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Gvia(dr));
            }
        }

        public List<Gvia> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Gvia Find(string code)
        {
            return this.GetList().Find(x => x.YearG.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            Gvia c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
        
        public void UpdateRow(Gvia c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Gvia c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
      
    }
}

