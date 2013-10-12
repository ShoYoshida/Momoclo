using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Momoclo.Common;
using Momoclo.Service;
using Momoclo.View;
using Momoclo.Util;

namespace Momoclo.DAO
{


    public class MomocloDAO : DBUtil
    {
        public MemberView[] Select() 
        {
            var rs = from mem in this.MContainer.Members
                     select mem;

            List<MemberView> members = new List<MemberView>();
            foreach (Member member in rs)
            {
                MemberView view = new MemberView();
                view.id = member.ID;
                view.color = member.Color;
                view.name = member.Name;
                view.birth = member.Birth;
                view.bloodtype = getBloodtype(member.Bloodtype);
                view.birthplace = member.Birthplace;
                view.height = member.Height.ToString();
                members.Add(view);
            }

            return members.ToArray();

        }

        public void Save(MomocloRequest req)
        {

            if (req.id > 0)
            {
                var rs = from mem in this.MContainer.Members
                         where mem.ID == req.id
                         select mem;

                Member oldRec = rs.Single();

                oldRec.Color = req.color;
                oldRec.Name = req.name;
                oldRec.Birth = req.birth;
                oldRec.Bloodtype = req.bloodtype;
                oldRec.Birthplace = req.birthplace;
                oldRec.Height = Utility.NullorValue(req.height);
            }
            else 
            {
                Member member = new Member();
                member.Color = req.color;
                member.Name = req.name;
                member.Birth = req.birth;
                member.Bloodtype = req.bloodtype;
                member.Birthplace = req.birthplace;
                member.Height = Utility.NullorValue(req.height);

                this.MContainer.Members.AddObject(member);            
            }

            this.MContainer.SaveChanges();

        }

        public void Remove(MomocloRequest req)
        {
            var rs = from mem in this.MContainer.Members
                     where mem.ID == req.id
                     select mem;

            this.MContainer.Members.DeleteObject(rs.Single());

            this.MContainer.SaveChanges();
      
        }




        private string getBloodtype(string s) 
        {
            switch(s){
                case "0":
                    return "A";
                case "1":
                    return "B";
                case "2":
                    return "AB";
                case "3":
                    return "O";
                default :
                    return null;
            }

        }
    }
}