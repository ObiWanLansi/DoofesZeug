using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestSoldierBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Soldier soldier = SoldierBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(soldier);
        }
    }
}