using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Daan.DataTransfer.DataCommon;
using Frameworks.DataTransfer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daan.DataTransfer.UnitTest
{
    /// <summary>
    /// DataTransferClientTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DataTransferClientTest
    {
        DataTransferClient client;
        public DataTransferClientTest()
        {
            client=new DataTransferClient();
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            var paramter = new DataParameter();
            paramter.Action = 1;

            string x = "hello, what can i do for you?";
            var crc = new CrcHash();
            var stream = StreamHeandler.StringToStream(x);
            var code = crc.GetHashCode(stream);
            paramter.CrcCode = code;
            paramter.DataString = x;

            var result = client.PushData(paramter);
            //
            // TODO: 在此处添加测试逻辑
            //
            //Assert.AreEqual(sb.ToString(), sb2);
        }

        [TestMethod]
        public void PullTest()
        {
            var client = new DataTransferClient();
            var paramter = new DataParameter();
            paramter.Action = 1;
            var result = client.PullData(paramter);
        }

        [TestMethod]
        public void PushTest()
        {
            for (int i = 0; i < 100000; i++)
            {
                PushMessage();
            }
        }

        private void PushMessage()
        {
            var paramter = new DataParameter();
            paramter.Action = 1;

            string x = "hello, what can i do for you?";
            var crc = new CrcHash();
            var stream = StreamHeandler.StringToStream(x);
            var code = crc.GetHashCode(stream);
            paramter.CrcCode = code;
            paramter.DataString = x;

            var result = client.PushData(paramter);
        }
    }
}
