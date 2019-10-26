using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Daan.DataTransfer.Client;
using Daan.DataTransfer.DataCommon;
using Frameworks.DataTransfer;

namespace Client
{
    static class Program
    {
        static decimal i = 0;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogHelper.Debug(typeof(Program), "程序开始");
            for (int i = 0; i < 10; i++)
            {
                DateTime dateTime1 = DateTime.Now;
                PushMessage();
                //PullMessage();
                var t = DateTime.Now - dateTime1;
                Console.WriteLine(string.Format("第{0}个花费时间为{1}毫秒", i, t.Milliseconds));
            }

            Console.ReadKey();
        }

        private static void PullMessage()
        {
            var client = new PullDataClient();
            client.ActionId = 1;
            client.Synchronous = true;
            client.RetryTimes = 10;
            var x = "tt";
            var result = client.PullData<string, string>(x);
        }

        private static void PushMessage()
        {
            var client = new PushDataClient();
            client.ActionId = 1;
            client.Synchronous = true;
            //var text = File.ReadAllText(@"c:\20120704.log");
            var text = "x";
            var result = client.PushData<string, string>(text);
        }
    }
}
