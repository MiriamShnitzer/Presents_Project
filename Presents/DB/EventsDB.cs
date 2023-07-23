using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class EventsDB : GeneralDB
    {
        protected List<Events> list = new List<Events>();
        public EventsDB()
            : base("Events")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Events(dr));
            }
        }

        public List<Events> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Events Find(string code)
        {
            return this.GetList().Find(x => x.KodE.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            Events c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
       
        public void UpdateRow(Events c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Events c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodE) + 1;
        }



    }
}

