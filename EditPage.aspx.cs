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
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGESDB pages_db = new PAGESDB();
            
            if(!Page.IsPostBack)
            {
                // POPULATE FIELDS:
                ShowPageInfo(pages_db);
            }

        } // END Page_Load

        protected void ShowPageInfo(PAGESDB pages_db)
        {
            bool valid = true;
            string pageid = Request.QueryString["page_id"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            
            // ATTEMPT TO GET PAGE RECORD:
            if (valid)
            {
                Dictionary<String, String> page_record = pages_db.FindPage(Int32.Parse(pageid));

                if (page_record.Count > 0)
                {
                    page_title.Text = page_record["page_title"];
                    page_body.Text = page_record["page_body"];
                }
                else
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                edit_page.InnerHtml = "There was an error finding that page.";
            }

        } // END ShowPageInfo


        protected void Update_Page(object sender, EventArgs e)
        {
            PAGESDB pages_db = new PAGESDB();

            bool valid = true;
            string pageid = Request.QueryString["page_id"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            if (valid)
            {
                HTTP_Page new_page = new HTTP_Page();
                new_page.Set_http_title(page_title.Text);
                new_page.Set_http_body(page_body.Text);
                new_page.Set_http_publish(page_publish.Checked);

                try
                {
                    pages_db.UpdatePage(Int32.Parse(pageid), new_page);
                    Response.Redirect("ShowPage.aspx?page_id=" + pageid);
                } // END TRY
                catch
                {
                    valid = false;
                } // END CATCH
            } 
            if (!valid)
            {
                edit_page.InnerHtml = "There was an error updating that page.";
            }

            ShowPageInfo(pages_db);
        } // END Update_Page

    }
}



