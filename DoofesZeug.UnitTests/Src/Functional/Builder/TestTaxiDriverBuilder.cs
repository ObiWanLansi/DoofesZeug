using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestTaxiDriverBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            TaxiDriver taxidriver = TaxiDriverBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(taxidriver);
        }
    }
}
        
