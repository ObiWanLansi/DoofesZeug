using System;

using DoofesZeug.Tools.Crypt;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Crypt
{
    [TestClass]
    public class TestSimpleHash
    {
        private static readonly string CONTENT = "The quick brown fox jumps over a lazy dog.";

        private static readonly string SALT = "0xAFFE";


        [TestMethod]
        public void ExecuteTestWithoutSalt()
        {
            Assert.AreEqual("8FCE54FAAD7E1B3A31D9A19FB1438B9E", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.MD5));
            Assert.AreEqual("302940176213954F686AAFFF183A652C5E71897F", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.SHA1));
            Assert.AreEqual("AA94AAE294AB894EEAF5751AD0A46B1B4E90B5E4F1E7C0F3759B504D3E809944", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.SHA256));
            Assert.AreEqual("05DD5EA91C40F281EB9A3A33091D73B19D98CCEA6CB3F55AD2FBC7398D5E8FFDA574CB604076EC4F8D18B868EC99A4FD57EAE4E835A1AEA3295CB67DE9927399", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.SHA512));
        }

        [TestMethod]
        public void ExecuteTestWithSalt()
        {
            Assert.AreEqual("B7A4E164AF72EEC2D3A5702425DD037A", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.MD5, SALT));
            Assert.AreEqual("F7DEA2E24757ED773D82450F605875390CD5E531", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.SHA1, SALT));
            Assert.AreEqual("DACAE8D8B9E582B24098B811AF9F3A95F3E9B75B77832D61E682A9B9446101FF", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.SHA256, SALT));
            Assert.AreEqual("D63F8F5E779EB52D6ED03BAE0745857DCF0202DF2D88E8324FBC5141979E9C8DBFA0468CD646DCBE3977FABEA1E438BB6CA0EDF40E5DE43D00A09039C5A6199C", SimpleHash.GetHash(CONTENT, SupportedHashAlgorithm.SHA512, SALT));
        }
    }
}
