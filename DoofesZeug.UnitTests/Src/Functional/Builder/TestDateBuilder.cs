using DoofesZeug.Models.DateAndTime;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestDateBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Date date = DateBuilder.New().WithDay(24).WithMonth(12).WithYear(1234);
            Assert.IsNotNull(date);
        }
    }
}

