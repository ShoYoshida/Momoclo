using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Momoclo
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bool PC = false;
            bool HOME = true;
            bool FOOD = false;
            bool BOOK = true;
            //MenuItem homeMenu = NavigationMenu.FindItem(@"ホーム&キッチン・ペット");

            //if (homeMenu != null)
            //{
            //    homeMenu.ChildItems.RemoveAt(1);
            //}



            if (!PC) 
            {
                MenuItem pc = NavigationMenu.FindItem(@"パソコン・オフィス用品");
                if (pc != null) 
                { 
                    NavigationMenu.Items.Remove(pc); 
                }
                
            }
            MenuItem home = NavigationMenu.FindItem(@"ホーム&キッチン・ペット");
            if (!HOME) 
            {            
                NavigationMenu.Items.Remove(home);
                if (home != null)
                {
                    NavigationMenu.Items.Remove(home);
                }
            }

            MenuItem homeSubMenu = NavigationMenu.FindItem(@"ホーム&キッチン・ペット/インテリア・家具・寝具");

            if (homeSubMenu != null)
            {
                home.ChildItems.Remove(homeSubMenu);
            }



            if (!FOOD)
            {
                MenuItem food = NavigationMenu.FindItem(@"食品&飲料");
                NavigationMenu.Items.Remove(food);
                if (food != null)
                {
                    NavigationMenu.Items.Remove(food);
                }
            }
            if (!BOOK)
            {
                MenuItem book = NavigationMenu.FindItem(@"本・コミック・雑誌");
                NavigationMenu.Items.Remove(book);
                if (book != null)
                {
                    NavigationMenu.Items.Remove(book);
                }
            }           
        }
    }
}
