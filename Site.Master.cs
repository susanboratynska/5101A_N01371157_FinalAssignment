using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N01371157_FinalAssignment.sln
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            nav_menu.InnerHtml = ""; 

            string query = "select * from pages";
            nav_menu.InnerHtml += "<ul class=\"nav navbar-nav\">";

            // DISPLAY CONTENT IN MENU:
            var pages_db = new PAGESDB();
            List<Dictionary<String, String>> results = pages_db.List_Query(query);
            foreach (Dictionary<String, String> row in results)
            {
                nav_menu.InnerHtml += "<li><a href=\"ShowPage.aspx?page_id=" +row["page_id"] + "\">" + row["page_title"] + "</a></li>";
            }

            nav_menu.InnerHtml += "</ul>";
        }
    }
}