using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace N01371157_FinalAssignment.sln
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pages_db = new PAGESDB();
            ShowPageDetails(pages_db);

            // ASP BUTTON REDIRECT
            // SRC: https://stackoverflow.com/questions/23976683/asp-net-button-to-redirect-to-another-page

            edit_button.PostBackUrl = "~/EditPage.aspx?page_id=" + Request.QueryString["page_id"];

        } // END Page_Load

        protected void ShowPageDetails(PAGESDB pages_db)
        {
            bool valid = true;
            string pageid = Request.QueryString["page_id"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {
                Dictionary<String, String> page_record = pages_db.FindPage(Int32.Parse(pageid));

                if (page_record.Count > 0)
                {
                    title.InnerHtml = "for "+ page_record["page_title"];
                    page_title.InnerHtml = page_record["page_title"];
                    body_content.InnerHtml = page_record["page_body"];


                    page_published.InnerHtml = (page_record["page_published"] == "True") ? "Yes" : "No" ;
                    // SRC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
                    // Ternary conditional operator

                    string page_created = page_record["date_created"];
                    DateTime date_created_datetime = Convert.ToDateTime(page_created);
                    DateTime date_created_dateonly = date_created_datetime.Date;
                    date_created.InnerHtml = date_created_dateonly.ToString("d");
                    // SRC: HOW TO REMOVE TIME STAMP
                    // https://docs.microsoft.com/en-us/dotnet/api/system.datetime.date?redirectedfrom=MSDN&view=netframework-4.8#System_DateTime_Date

                }
                else
                {
                    valid = false;
                }
            }

            if (!valid)
            {
                page_details.InnerHtml = "There was an error finding that page.";
            }

        } // END ShowPageDetails

        // Delete_Page FUNCTION
        // SRC: CRUD Essentials - Christine Bittle
        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["page_id"];

            if (String.IsNullOrEmpty(pageid)) valid = false;

            PAGESDB pages_db = new PAGESDB();

            // DELETE PAGE FROM DB:
            if (valid)
            {
                pages_db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }

        } // END Delete_Page
    }
}