using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class CompanyDB : GeneralDB
    {
        protected List<Company> list = new List<Company>();
        public CompanyDB()
            : base("Company")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Company(dr));
            }
        }

        public List<Company> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Company Find(string code)
        {
            return this.GetList().Find(x => x.KodComp.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            Company c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
        
        public void UpdateRow(Company c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Company c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodComp) + 1;
        }


    }
}

