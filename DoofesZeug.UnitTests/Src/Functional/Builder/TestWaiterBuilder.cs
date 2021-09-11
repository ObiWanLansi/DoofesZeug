using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestWaiterBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Waiter waiter = WaiterBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(waiter);
        }
    }
}