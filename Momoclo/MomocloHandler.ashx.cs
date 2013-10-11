using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Momoclo
{
    /// <summary>
    /// MomocloHandler の概要の説明
    /// </summary>
    public class MomocloHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.HttpMethod == "GET")
            {
                System.Diagnostics.Debug.WriteLine("GET");

            }
            else if (context.Request.HttpMethod == "POST")
            {
                System.Diagnostics.Debug.WriteLine("POST");
                string color = context.Request.Form["color"];
                string name = context.Request.Form["name"];
                string birth = context.Request.Form["birth"];
                string bloodtype = context.Request.Form["bloodtype"];
                string oper = context.Request.Form["oper"];

                System.Diagnostics.Debug.WriteLine(oper);

            }


            List<Member> members = new List<Member>();
            members.Add(new Member("Green", "有安杏果"));
            members.Add(new Member("Pink", "佐々木彩夏"));
            members.Add(new Member("Red", "百田夏菜子"));
            members.Add(new Member("Yellow", "玉井詩織"));
            members.Add(new Member("Purple", "高城れに"));


            var s = new System.Web.Script.Serialization.JavaScriptSerializer();

            context.Response.Write(s.Serialize(members.ToArray()));
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Member
    {
        public string color { get; set; }
        public string name { get; set; }

        public Member(string color, string name)
        {
            this.color = color;
            this.name = name;
        }
    }
}