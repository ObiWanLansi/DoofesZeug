using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestBusDriverBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            BusDriver busdriver = BusDriverBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(busdriver);
        }
    }
}