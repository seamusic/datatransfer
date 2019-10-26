using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Daan.DataTransfer.DataCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daan.DataTransfer.UnitTest
{
    /// <summary>
    /// DataCommonTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DataCommonTest
    {
        public DataCommonTest()
        {
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
        public void Base64ConvertTest()
        {
            var testTest = "hello";
            var bs = System.Text.Encoding.Default.GetBytes(testTest);
            var stream = new MemoryStream(bs);
            var actual = Base64Convert.ToBase64(stream);

            var expected = Base64Convert.FrmBase64(actual);

            var test2 = System.Text.Encoding.Default.GetString(expected.ToArray());

            Assert.AreEqual(testTest, test2);
        }

        [TestMethod]
        public void SerializationTest()
        {
            var list = new List<string>();
            list.Add("hello");
            list.Add("fine");
            list.Add("love");

            var obj = Serialization.Serialize(list);
            var obj2 = Serialization.DeSerialize<List<string>>(obj);

            Assert.AreEqual(list[2], obj2[2]);
        }

        [TestMethod]
        public void StreamHeandlerTest()
        {
            var text1 = @"hello
who";

            var stream = StreamHeandler.StringToStream(text1);
            var zipStream = ZipCompress.Compress(stream);
            var base64 = Base64Convert.ToBase64(zipStream);
            var txt1 = StreamHeandler.StreamToString(base64);

            var txt2 = txt1;

            var base642 = StreamHeandler.StringToStream(txt2);
            var unZipStream = Base64Convert.FrmBase64(base642);
            var steam2 = ZipCompress.UnCompress(unZipStream);
            var text2 = StreamHeandler.StreamToString(steam2);

            Assert.AreEqual(text1, text2);
        }

        [TestMethod]
        public void StreamHeandlerTest2()
        {
            var text1 = @"hello
who";

            var stream = StreamHeandler.StringToStream(text1);
            var zipStream = ZipCompress.Compress(stream);
            var base64 = Base64Convert.ToBase64(zipStream);
            var txt1 = StreamHeandler.StreamToString(base64);

            var txt2 = txt1;

            var base642 = StreamHeandler.StringToStream(txt2);
            var unZipStream = Base64Convert.FrmBase64(base642);
            var steam2 = ZipCompress.UnCompress(unZipStream);
            var text2 = StreamHeandler.StreamToString(steam2);

            Assert.AreEqual(text1, text2);
        }

        [TestMethod]
        public void ZipCompressTest()
        {

            var test = @"hellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohello
hellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohellohello";
            var sb = new StringBuilder(test);

            var stream = StreamHeandler.StringToStream(sb.ToString());
            var zipStream = ZipCompress.Compress(stream);
            var unZipStream = ZipCompress.UnCompress(zipStream);
            var sb2 = StreamHeandler.StreamToString(stream);

            Assert.AreEqual(sb.ToString(), sb2);
        }

        [TestMethod]
        public void CrcTest()
        {
            var testTest = "hello";
            var stream = StreamHeandler.StringToStream(testTest);

            CrcHash crcHash = new CrcHash();
            var crccode = crcHash.GetHashCode(stream);
            crcHash.Hash(stream, crccode);
            Assert.AreEqual(crcHash.Hash(stream, crccode), true);
        }


        [TestMethod]
        public void DataProcessFactoryTest()
        {
            var factory = new DataProcessFactory();
            var info = new DataInfo();
            info.ActionId = 1;
            info.DataId = "sss";
            info.SpliteCount = 10;

            var bytes = factory.ProcessToString(info);

            var info2 = factory.ProcessToObject<DataInfo>(bytes);

            Assert.AreEqual(info.DataId, info2.DataId);

        }

        [TestMethod]
        public void DataProcessFactoryBase64Test()
        {
            string txt = "x";
            var b = new Base64Convert();
            var bb = StringByteConver.ToByte(txt);
            var code = b.Process(bb);
            var code2 = b.DeProcess(code);

            var txt1 = StringByteConver.ToString(bb);
            var txt2 = StringByteConver.ToString(code2);
            Assert.AreEqual(txt1, txt2);
        }

        [TestMethod]
        public void DataProcessFactoryStringByteConverTest()
        {
            var txt = "hello";
            var bytes = StringByteConver.ToByte(txt);
            var txt2 = StringByteConver.ToString(bytes);

            Assert.AreEqual(txt, txt2);
        }

        [TestMethod]
        public void DataProcessFactoryCheckDataSegment()
        {
            var factory = new DataProcessFactory();
            var se = factory.BuildDataSegment(0, "1", 1000, 1, "H4sIAAAAAAAEAONnZGBgqAAAyMMqIwYAAAA=");
            var x = factory.CheckDataSegment(se);
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void DataProcessFactoryCheckStringProcess()
        {
            var factory = new DataProcessFactory();
            var txt = "x";
            var ptxt = factory.ProcessToString(txt);
            var dtxt = factory.ProcessToObject<string>(ptxt);
            Assert.AreEqual(txt, dtxt);
        }

        [TestMethod]
        public void DataProcessFactoryByteProcess()
        {
            var factory = new DataProcessFactory();
            var txt = "halkfjklsdfjowjflskdfjlsfjls";
            var bytes = StringByteConver.ToByte(txt);
            var ptxt = factory.Process(bytes);
            var dtxt = factory.DeProcess(ptxt);
            var result = StringByteConver.ToString(dtxt);
            Assert.AreEqual(txt, result);
        }
    }
}
