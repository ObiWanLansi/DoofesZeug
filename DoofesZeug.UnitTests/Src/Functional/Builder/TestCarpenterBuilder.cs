using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestCarpenterBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Carpenter carpenter = CarpenterBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(carpenter);
        }
    }
}
        
