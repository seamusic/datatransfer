using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Daan.DataTransfer.Services;
using org.phprpc;

namespace Daan.DataTransfer.Web
{
    public partial class PullData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PHPRPC_Server server = new PHPRPC_Server();
            PullDataService pullDataService=new PullDataService();
            server.Add(pullDataService);
            server.Start();
        }
    }
}