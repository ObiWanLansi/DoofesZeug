using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestPilotBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Pilot pilot = PilotBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(pilot);
        }
    }
}