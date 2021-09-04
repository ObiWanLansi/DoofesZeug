using DoofesZeug.Tools.Crypt;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Crypt
{
    [TestClass]
    public class TestTDES
    {
        private static readonly string CONTENT = "The quick brown fox jumps over a lazy dog.";

        private static readonly string SALT = "0xAFFE";

        private static readonly string PASSWORD = "JohnDoe74";


        [TestMethod]
        public void ExecuteTDES()
        {
            string strCrypted = TDES.Encrypt(CONTENT, PASSWORD, SALT);
            Assert.AreEqual("9pofFEqyRkqeXhXoXnIZyGjHcs/JVUZZ94jCrLN46OLKY01aFkw5j/rSRI0evPRwQyBmCOQXTfOx3G1VE/IIK3efQnPLEYHNNx2DWKakHlSQKkOjAAwjIw==", strCrypted);
            Assert.AreEqual(CONTENT, TDES.Decrypt(strCrypted, PASSWORD, SALT));
        }
    }
}
