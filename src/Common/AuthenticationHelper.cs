using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daan.DataTransfer.DataCommon
{
    public class AuthenticationHelper
    {
        /// <summary>
        /// 创建校验头
        /// </summary>
        public static bool CreateServiceHeader(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            var ccs = new Spring.Threading.CallContextStorage();
            WebServiceHeader ash = (WebServiceHeader)ccs.GetData("authenticationHeader") ?? new WebServiceHeader();

            ash.Name = name;
            ash.Password = password;
            ccs.SetData("authenticationHeader", ash);

            return true;
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <returns></returns>
        public static bool AuthServiceHeader()
        {
            return true;
            WebServiceHeader ash = null;

            // WebService environment
            if (System.Web.HttpContext.Current != null &&
                System.Web.HttpContext.Current.Items.Contains("AuthenticationSoapHeader"))
            {
                ash = (WebServiceHeader)System.Web.HttpContext.Current.Items["AuthenticationSoapHeader"];
            }
            else
            {
                // Local environment
                var ccs = new Spring.Threading.HybridContextStorage();
                ash = (WebServiceHeader)ccs.GetData("authenticationHeader");
            }

            // no Authentication Header
            if (ash == null)
            {
                ash = new WebServiceHeader();
                ash.Name = "unknown";
                ash.Password = String.Empty;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
