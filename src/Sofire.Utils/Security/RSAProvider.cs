#if !SILVERLIGHT
namespace Sofire.Security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /*
     * “非对称加密”结合“对称加密”，是一种安全系数较高的加密方式。采用“非对称加密”方式来加密“对称加密”的密钥。
     * 因此“非对称加密”，最长明文长度为 117 位。
     */
    /// <summary>
    /// RSA 公钥私钥加解密提供程序( 非对称加密 )。
    /// <para>说明：提供“密钥加密”&lt; - &gt;“私钥解密”或“私钥加密”&lt; - &gt;“密钥解密”的服务。</para>
    /// </summary>
    public class RSAProvider : SecurityProviderBase
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="Sofire.Security.RSAProvider"/> 的新实例。
        /// </summary>
        public RSAProvider()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 创建密钥(公钥+私钥)以及公钥。
        /// </summary>
        /// <param name="key">密钥(公钥+私钥)。</param>
        /// <param name="publicKey">公钥。</param>
        public void CreateKey(out string key, out string publicKey)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                key = rsa.ToXmlString(true);
                publicKey = rsa.ToXmlString(false);
            }
        }

        /// <summary>
        /// 指定暗文以及以及密钥(公钥+私钥)或公钥进行数据加密。
        /// </summary>
        /// <param name="data">暗文。</param>
        /// <param name="key">密钥(公钥+私钥)或公钥。</param>
        /// <returns>返回解密后的明文。</returns>
        public override string Decrypt(string data, string key)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);
                return Encoding.UTF8.GetString(rsa.Decrypt(this.HexToBytes(data), false));
            }
        }

        /// <summary>
        /// 指定明文以及密钥(公钥+私钥)或公钥进行数据加密。
        /// </summary>
        /// <param name="data">明文。</param>
        /// <param name="key">密钥(公钥+私钥)或公钥。</param>
        /// <returns>返回加密后的暗文。</returns>
        public override string Encrypt(string data, string key)
        {
            if(data.Length > 117) throw new ArgumentOutOfRangeException("data", "RSA 算法加密长度最多不可超过 117 位。");

            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(key);

                byte[] bytResult = rsa.Encrypt(Encoding.UTF8.GetBytes(data), false);
                return this.ToHexString(bytResult);
            }
        }

        /// <summary>
        /// 指定一连串十六进制数字的字符串，返回转换后的字节数组。
        /// </summary>
        /// <param name="data">一连串十六进制数字的字符串形式。</param>
        /// <returns>返回一组字节。</returns>
        private byte[] HexToBytes(string data)
        {
            int l = data.Length / 2;
            string str;
            byte[] ret = new byte[l];
            for(int i = 0 ; i < l ; i++)
            {
                str = data.Substring(i * 2, 2);
                ret[i] = Convert.ToByte(str, 16);
            }
            return ret;
        }

        /// <summary>
        /// 指定字节数组，返回一连串十六进制数字的字符串形式。
        /// </summary>
        /// <param name="bytes">字节数组。</param>
        /// <returns>返回一个字符串，表示一连串十六进制数字的字符串形式。</returns>
        private string ToHexString(byte[] bytes)
        {
            if(bytes != null)
            {
                StringBuilder strBuilder = new StringBuilder();
                for(int i = 0 ; i < bytes.Length ; i++)
                {
                    strBuilder.Append(bytes[i].ToString("X2"));
                }
                return strBuilder.ToString();
            }
            return string.Empty;
        }

        #endregion Methods
    }
}
#endif