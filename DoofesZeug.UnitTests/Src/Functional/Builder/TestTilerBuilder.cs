using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestTilerBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Tiler tiler = TilerBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(tiler);
        }
    }
}
        
