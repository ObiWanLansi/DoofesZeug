using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestFireFighterBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            FireFighter firefighter = FireFighterBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(firefighter);
        }
    }
}
        
