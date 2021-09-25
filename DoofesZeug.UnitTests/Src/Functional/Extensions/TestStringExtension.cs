using DoofesZeug.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Extensions
{
    [TestClass]
    public class TestStringExtension
    {
        [TestMethod]
        public void ExecuteStringExtensionTest()
        {
            Assert.IsFalse("Hanswurst".ContainsControlCharacters());
            Assert.IsTrue("Hans\twurst".ContainsControlCharacters());

            Assert.IsTrue("Hans wurst".ContainsNonLetterCharacters());
            Assert.IsTrue("Hans\twurst".ContainsNonLetterCharacters());
            Assert.IsTrue("Hanswurst.".ContainsNonLetterCharacters());
            Assert.IsTrue("Hans1wurst".ContainsNonLetterCharacters());
            Assert.IsFalse("Hanswurst".ContainsNonLetterCharacters());


            Assert.AreEqual("Arthur Dent", "\"Arthur Dent\"".RemoveQuotation());
            Assert.AreEqual("A ...", "Arthur Dent".Shorten(5));
            Assert.AreEqual("tneD ruhtrA", "Arthur Dent".Reverse());

            Assert.AreEqual("ARTHUR DENT", "Arthur Dent".Upper());
            Assert.AreEqual("arthur dent", "Arthur Dent".Lower());
            Assert.AreEqual("Arthur Dent", "arthur dent".Capitalize());
            Assert.AreEqual("Arthur dent", "arthur dent".CapitalizeOnlyFirstLetter());

            Assert.IsTrue("Arthur Dent".EqualsIgnoreCase("ARTHUR DENT"));
        }
    }
}
