using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N01371157_FinalAssignment.sln
{
    public class HTTP_Page
    {
        private string http_title;
        private string http_body;
        private bool http_publish;


        // GET:
        public string Get_http_title()
        {
            return http_title;
        }

        public string Get_http_body()
        {
            return http_body;
        }

        public bool Get_http_publish()
        {
            return http_publish;
        }

        // SET:

        public void Set_http_title(string value)
        {
            http_title = value;
        }

        public void Set_http_body(string value)
        {
            http_body = value;
        }

        public void Set_http_publish(bool value)
        {
            http_publish = value;
        }
    }
}