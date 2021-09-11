using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestHairDresserBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            HairDresser hairdresser = HairDresserBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(hairdresser);
        }
    }
}