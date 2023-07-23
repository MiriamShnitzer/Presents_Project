using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class StockPreDB : GeneralDB
    {
        protected List<StockPre> list = new List<StockPre>();
        public StockPreDB()
            : base("StockPre")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new StockPre(dr));
            }
        }

        public List<StockPre> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public StockPre Find(string code)
        {
            return this.GetList().Find(x => x.KodP.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            StockPre c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(string code)
        {
            StockPre c = this.Find(code);
            if (c != null)
            {
                c.Status = false;
                this.UpdateRow(c);
            }
        }
        public void UpdateRow(StockPre c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(StockPre c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodP) + 1;
        }


    }
}

