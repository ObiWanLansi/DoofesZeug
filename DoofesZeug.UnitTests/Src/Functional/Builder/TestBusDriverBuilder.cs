// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------


using Microsoft.VisualStudio.TestTools.UnitTesting;

using DoofesZeug.Models.Human.Professions;



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

