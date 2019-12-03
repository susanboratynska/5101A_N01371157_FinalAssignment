using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace N01371157_FinalAssignment.sln
{
    public class PAGESDB
    {
        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "final_project"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString: USED TO CONNECT TO THE DATABASE
        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        // RETURNS RESULTSET = RETURNS A LIST OF DICTIONARIES
        // DICTIONARY: LIKE A LIST BUT WITH KEY:VALUE PAIRS (AKA: "ASSOCIATIVE ARRAYS")
        // WHEN YOU CALL List_Query IT IS EXPECTING A STRING PARAMETER - WHATEVER IS PASSED WILL BE STORED AS query WITHIN THIS FUNCITON
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString); //SQL CONNECTION CLASS

            // INPUT -> (string) SELECT QUERY 
            // e.g. "select * from pages";
            // OUTPUT -> (List<Dictionary<String,String>>) RESULT SET
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>(); //CREATED AN EMPTY RESULT SET; AN EMPTY ARRAY

            // IF ERRORS OCCURS IN try{}, THEN catch{} WILL EXECUTE

            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query" + query);
                // OPEN THE DATABASE CONNECTION
                Connect.Open();
                // GIVE THE CONNECTION A QUERY
                MySqlCommand cmd = new MySqlCommand(query, Connect); //TELLING MySqlComman WHICH DB TO USE WITH THE CONNECT VARIABLE
                // GRAB THE RESULT SET
                MySqlDataReader resultset = cmd.ExecuteReader();


                // FOR EVERY ROW IN THE RESULT SET (DICTIONARIES -- >LIST WITH KEY:VALUE PAIRS)
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>(); // EMPTY ROW 
                    // FOR EVERY COLUMN IN ITS ROW
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));
                    }

                    ResultSet.Add(Row);
                } // END ROW
                resultset.Close();

            } // END TRY

            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            } // END CATCH

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        } // END List_Query


        public Dictionary<String, String> FindPage(int id)
        {
            // UTILIZE THE CONNECTION STRING:
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            // CREATE BLANK PAGE:
            Dictionary<String, String> page = new Dictionary<string, string>();

            // GRAB PAGE DATA FROM DB:
            try
            {
                string query = "select * from pages where page_id = " + id;
                Debug.WriteLine("Connection Initialized...");

                // OPEN DB CONNECTION:
                Connect.Open();
                // RUN QUERY AGAINST DB:
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                // GRAB RESULT SET:
                MySqlDataReader resultset = cmd.ExecuteReader();

                // CREATE A LIST OF PAGE(S):
                List<Dictionary<String, String>> Pages = new List<Dictionary<String, String>>();
                
                // READ THROUGH RESULT SET:
                while (resultset.Read())
                {
                    // INFO TAHT WILL STORE A SINGLE PAGE:
                    Dictionary<String, String> Page = new Dictionary<String, String>();

                    // LOOK AT EACH COLUMN IN THE RESULT SET ROW, ADD THE COLUMN NAME (KEY) AND VALUE TO PAGE DICTIONARY:
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetName(i));
                        Debug.WriteLine("Attempting to transfer data of " + resultset.GetString(i));
                        Page.Add(resultset.GetName(i), resultset.GetString(i));
                    }
                    // ADD THE PAGE TO THE LIST OF PAGES:
                    Pages.Add(Page);
                } // END WHILE

                page = Pages[0]; // GET FIRST PAGE

            } // END TRY

            catch (Exception ex)
            {
                // IF ANYTHING GOES WRONG WITH TRY BLOCK, EXECUTE THE FOLLOWING:
                Debug.WriteLine("Something went wrong in the FindPage method");
                Debug.WriteLine(ex.ToString());
            } // END CATCH

            Connect.Close();
            Debug.WriteLine("Database connection terminated.");

            return page;
        } // END FindPage

        

        public void DeletePage(int pageid)
        {
            string remove_page = "DELETE FROM pages WHERE page_id = {0}";
            remove_page = String.Format(remove_page, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd_remove_page = new MySqlCommand(remove_page, Connect);

            try
            {
                Connect.Open();
                cmd_remove_page.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_remove_page);
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong with the DeletePage method.");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();

        } // END DeletePage


        public void UpdatePage (int pageid, HTTP_Page new_page)
        {
            // SRC: CRUD Essentials, Christine Bittle
            // PURPOSE: HOW TO EDIT PAGE
            // STRING FORMATTING:
            string query = "UPDATE pages set page_title='{0}', page_body='{1}', page_published={2} WHERE page_id={3}";
            query = String.Format(query, new_page.Get_http_title(), new_page.Get_http_body(), new_page.Get_http_publish(), pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);

            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            } // END TRY
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the UpdatePage method.");
                Debug.WriteLine(ex.ToString());
            } // END CATCH

            Connect.Close();

        } // END UpdatePage

        
        public void AddPage (HTTP_Page new_page)
        {
            string query = "INSERT INTO pages (page_title, page_body, page_published) VALUES ('{0}', '{1}', {2})";
            query = String.Format(query, new_page.Get_http_title(), new_page.Get_http_body(), new_page.Get_http_publish());

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);

            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddPage method.");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();

        } // END AddPage
            
    } // END OF PUBLIC CLASS
}