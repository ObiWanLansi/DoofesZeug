// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestTimeBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Time time = TimeBuilder.New().WithHour(12).WithMinute(34).WithSecond(56);
            Assert.IsNotNull(time);
        }
    }
}

