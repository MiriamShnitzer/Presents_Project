using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class PKindsDB : GeneralDB
    {
        protected List<PKinds> list = new List<PKinds>();
        public PKindsDB()
            : base("PKinds")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new PKinds(dr));
            }
        }

        public List<PKinds> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public PKinds Find(string code)
        {
            return this.GetList().Find(x => x.KodK.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            PKinds c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
       
        public void UpdateRow(PKinds c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(PKinds c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodK) + 1;
        }


    }
}

