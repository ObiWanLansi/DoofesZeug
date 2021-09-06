// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

using DoofesZeug.Models.DateAndTime;



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

