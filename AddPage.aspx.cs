using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace N01371157_FinalAssignment.sln
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // NOTHING TO HAPPEN ON PAGE_LOAD
        }

        protected void Add_Page(object sender, EventArgs e)
        {
            PAGESDB pages_db = new PAGESDB();

            HTTP_Page new_page = new HTTP_Page();

            new_page.Set_http_title(page_title.Text);
            new_page.Set_http_body(page_body.Text);
            new_page.Set_http_publish(page_publish.Checked);

            pages_db.AddPage(new_page);

            Response.Redirect("ListPages.aspx");

        } // END Add_Page
    }
}