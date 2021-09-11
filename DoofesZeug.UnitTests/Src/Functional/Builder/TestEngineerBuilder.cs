using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestEngineerBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Engineer engineer = EngineerBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(engineer);
        }
    }
}