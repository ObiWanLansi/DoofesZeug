using DoofesZeug.Models.DateAndTime;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestTimeBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Time time = TimeBuilder.New().
                WithHour(12).
                WithMinute(34).
                WithSecond(56);

            Assert.IsNotNull(time);
        }
    }
}