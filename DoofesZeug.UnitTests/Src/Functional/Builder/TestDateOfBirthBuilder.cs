// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------

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
            DateOfBirth dateofbirth = DateOfBirthBuilder.New().WithDay(11).WithMonth(11).WithYear(1842);
            Assert.IsNotNull(dateofbirth);
        }
    }
}

