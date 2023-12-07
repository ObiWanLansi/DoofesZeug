using DoofesZeug.Tools.Crypt;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Crypt;

[TestClass]
public class TestAES
{
    private static readonly string CONTENT = "The quick brown fox jumps over a lazy dog.";

    private static readonly string SALT = "0xAFFE";

    private static readonly string PASSWORD = "JohnDoe74";


    [TestMethod]
    public void ExecuteAESTest()
    {
        string strCrypted = AES.Encrypt(CONTENT, PASSWORD, SALT);
        Assert.AreEqual("3+oC8tdgUmJe51OLjNndoFRkK/jLtI0CzYKZZiJ8c4TJfabHQ/c5edMBZxIIB/ooPndEjBeb88ixc5T6JRpRv6fq1cXAJAFeww2mKjrKUovT8cwauuTUhEU3O/D/lm1B", strCrypted);
        Assert.AreEqual(CONTENT, AES.Decrypt(strCrypted, PASSWORD, SALT));
    }
}
