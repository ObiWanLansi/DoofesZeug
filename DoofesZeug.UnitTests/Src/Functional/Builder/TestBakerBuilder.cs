using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestBakerBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Baker baker = BakerBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(baker);
        }
    }
}