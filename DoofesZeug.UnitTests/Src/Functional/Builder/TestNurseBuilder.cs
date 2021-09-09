using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestNurseBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Nurse nurse = NurseBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(nurse);
        }
    }
}

