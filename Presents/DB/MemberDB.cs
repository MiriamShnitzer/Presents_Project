using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Presents.Models;
using Presents.DB;

namespace Presents.DB
{
    class MemberDB : GeneralDB
    {
        protected List<Member> list = new List<Member>();
        public MemberDB()
            : base("Member")
        {
        }
        private void DataTableToList()
        {
            foreach (DataRow dr in table.Rows)
            {
                list.Add(new Member(dr));
            }
        }

        public List<Member> GetList()
        {
            list.Clear();
            DataTableToList();
            return list;
        }
        public Member Find(string code)
        {
            return this.GetList().Find(x => x.KodM.ToString() == code);
        }
        public void DeleteRow(string code)
        {
            Member c = this.Find(code);
            if (c != null)
            {

                c.Dr.Delete();
                this.Update();
            }
        }
        public void DeleteStatus(string code)
        {
            Member c = this.Find(code);
            if (c != null)
            {
                c.Status = false;
                this.UpdateRow(c);
            }
        }
        public void UpdateRow(Member c)
        {
            c.PutInto();
            this.Update();
        }
        public void AddNew(Member c)
        {
            c.Dr = table.NewRow();
            c.PutInto();
            this.Add(c.Dr);
        }
        public int GetNextKey()
        {
            if (this.Size() == 0)
                return 1;
            return this.GetList().Max(x => x.KodM) + 1;
        }

    }
}

