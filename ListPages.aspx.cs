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
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            pages_result.InnerHtml = "";

            string searchkey = "";
      


            if (Page.IsPostBack)
            {
                searchkey = page_search.Text;
            }

            string query = "select * from pages";

            if (searchkey != "")
            {
                query += " WHERE LOWER(page_title) LIKE '%" + searchkey + "%'";
                query += " OR LOWER(page_body) LIKE '%" + searchkey + "%'";
                query += " OR date_created LIKE '%" + searchkey + "%'";
            }

            // DISPLAY CONTENT IN TABLE:
            var pages_db = new PAGESDB();
            List<Dictionary<String, String>> results = pages_db.List_Query(query);
            foreach (Dictionary<String, String> row in results)
            {
                TableRow table_row = new TableRow();

                TableCell table_cell = new TableCell
                {
                    Text = "<a href=\"ShowPage.aspx?page_id=" + row["page_id"] + "\">" + row["page_title"] + "</a>"
                };
                table_row.Cells.Add(table_cell);

                TableCell table_cell2 = new TableCell
                {
                    Text = row["page_body"]
                };
                table_row.Cells.Add(table_cell2);

                string page_pub = "";

                if(row["page_published"] == "True")
                {
                    page_pub = "Yes";
                }
                else
                {
                    page_pub = "No";
                }


                TableCell table_cell3 = new TableCell
                 {
                    Text = page_pub
                };
                table_row.Cells.Add(table_cell3);

                // REMOVE TIMESTAMP IN date_created:
                string date_created = row["date_created"];
                DateTime date_created_datetime = Convert.ToDateTime(date_created);
                DateTime date_created_dateonly = date_created_datetime.Date;
                // SRC: HOW TO REMOVE TIME STAMP
                // https://docs.microsoft.com/en-us/dotnet/api/system.datetime.date?redirectedfrom=MSDN&view=netframework-4.8#System_DateTime_Date


                TableCell table_cell4 = new TableCell
                {
                    Text = date_created_dateonly.ToString("d")
                };
                table_row.Cells.Add(table_cell4);

                // ADD ROW TO TABLE:
                list_pages_table.Rows.Add(table_row);



            } // END OF FOREACH LOOP


        }
    }
}