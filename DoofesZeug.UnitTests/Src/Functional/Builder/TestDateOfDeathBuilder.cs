using DoofesZeug.Entities.DateAndTime;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestDateOfDeathBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            DateOfDeath dateofdeath = DateOfDeathBuilder.New().
                WithDay(24).
                WithMonth(12).
                WithYear(1909);
            
            Assert.IsNotNull(dateofdeath);
        }
    }
}

