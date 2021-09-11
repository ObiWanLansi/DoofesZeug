using DoofesZeug.Models.DateAndTime;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestDateOfBirthBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            DateOfBirth dateofbirth = DateOfBirthBuilder.New().
                WithDay(11).
                WithMonth(11).
                WithYear(1842);

            Assert.IsNotNull(dateofbirth);
        }
    }
}