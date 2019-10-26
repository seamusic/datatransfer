﻿using System;
using Daan.DataTransfer.DataCommon;
using Spring.Context.Support;

namespace Daan.DataTransfer.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
           // var ctx = ContextRegistry.GetContext() as WebApplicationContext;
            // 在应用程序启动时运行的代码
            log4net.Config.XmlConfigurator.Configure();
            LogHelper.Info(GetType(), "程序开始启动");
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

    }
}
