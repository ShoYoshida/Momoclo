using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Momoclo.Util;
using Momoclo.DAO;
using Momoclo.View;

namespace Momoclo.Service
{
    public class MomocloRequest
    {
        public int id { get; set; }
        public string color { get; set; }
        public string name { get; set; }
        public string birth { get; set; }
        public string bloodtype { get; set; }
        public string birthplace { get; set; }
        public string height { get; set; }
        public string oper { get; set; }

        public MomocloRequest()
        {
            System.Diagnostics.Debug.WriteLine("Call");
        }
    }

    /// <summary>
    /// MomocloHandler の概要の説明
    /// </summary>
    public class MomocloHandler : IHttpHandler
    {
        private const string ADD = "add";
        private const string EDIT = "edit";
        private const string DEL = "del";
        HttpContext context;
        MomocloRequest req = new MomocloRequest();

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;

            if (context.Request.HttpMethod == "GET")
            {
                System.Diagnostics.Debug.WriteLine("GET");

            }
            else if (context.Request.HttpMethod == "POST")
            {
                System.Diagnostics.Debug.WriteLine("POST");
                
                string id = context.Request.Form["id"];
                req.id = int.Parse(Utility.NullToZero(id));       
                
                req.color = context.Request.Form["color"];
                req.name = context.Request.Form["name"];
                req.birth = context.Request.Form["birth"];
                req.bloodtype = context.Request.Form["bloodtype"];
                req.birthplace = context.Request.Form["birthplace"];
                req.height = context.Request.Form["height"];
                req.oper = context.Request.Form["oper"];


                System.Diagnostics.Debug.WriteLine(req.oper);

            }

            switch (req.oper) 
            {
                case ADD:
                    Save();
                    Load();
                    break;
                case EDIT:
                    Save();
                    Load();
                    break;
                case DEL:
                    Remove();
                    break;
                default:

                    break;
            }

            Load();

        }

        private void Load()
        {
            context.Response.ContentType = "text/plain";

            //List<Member> members = new List<Member>();
            //members.Add(new Member("Green", "有安杏果"));
            //members.Add(new Member("Pink", "佐々木彩夏"));
            //members.Add(new Member("Red", "百田夏菜子"));
            //members.Add(new Member("Yellow", "玉井詩織"));
            //members.Add(new Member("Purple", "高城れに"));


            var s = new System.Web.Script.Serialization.JavaScriptSerializer();

            //context.Response.Write(s.Serialize(members.ToArray()));
            MomocloDAO dao = new MomocloDAO();
            MemberView[] members = dao.Select();
            context.Response.Write(s.Serialize(members));
            context.Response.End();
        }

        private void Save()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                MomocloDAO dao = new MomocloDAO();
                dao.Save(req);
                transaction.Complete();
            }
        }

        private void Remove()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                MomocloDAO dao = new MomocloDAO();
                dao.Remove(req);
                transaction.Complete();
            }
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


}