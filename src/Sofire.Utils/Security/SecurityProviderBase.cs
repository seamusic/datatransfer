namespace Sofire.Security
{
    /// <summary>
    /// 表示加解密提供程序的基类。
    /// </summary>
    public abstract class SecurityProviderBase
    {
        #region Methods

        /// <summary>
        /// 给定密钥，解密数据。
        /// </summary>
        /// <param name="data">暗文。</param>
        /// <param name="key">解密的密钥。</param>
        /// <returns>返回解密后的明文。</returns>
        public abstract string Decrypt(string data, string key);

        /// <summary>
        /// 给定密钥，加密数据。
        /// </summary>
        /// <param name="data">明文。</param>
        /// <param name="key">加密的密钥。</param>
        /// <returns>返回加密后的暗文。</returns>
        public abstract string Encrypt(string data, string key);

        #endregion Methods
    }
}