using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Daan.DataTransfer.DataCommon;
using org.phprpc;

namespace Daan.DataTransfer.Web
{
    class ServerTest
    {
        public string BeginXX(string parameter)
        {
            return parameter;
        }

        public String Hi(String name)
        {
            return "Hello " + name;
        }
        public static List<int> Sort(List<int> list)
        {
            list.Sort();
            return list;
        }
    }  

    public partial class Server : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var server = new PHPRPC_Server();
            server.Add("Hi", new ServerTest());
            server.Add("BeginXX", new ServerTest());
            server.Add("Sort", typeof(ServerTest));
            server.Start(); 
        }
    }
}