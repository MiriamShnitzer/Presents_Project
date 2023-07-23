using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class YomanDB : GeneralDB
    {
        protected List<Yoman> list = new List<Yoman>();
        public YomanDB()
            : base("Yoman")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Yoman(dr));
            }
        }

        public List<Yoman> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Yoman Find(string code)
        {
            return this.GetList().Find(x => x.KodYoman.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            Yoman c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
        
        public void UpdateRow(Yoman c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Yoman c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodYoman) + 1;
        }


    }
}

