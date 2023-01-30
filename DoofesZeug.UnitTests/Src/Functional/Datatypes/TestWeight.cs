using DoofesZeug.Entities.Science.Base;
using DoofesZeug.Entities.Science.Base.Weight;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Datatypes
{
    [TestClass]
    public class TestWeight
    {
        [TestMethod]
        public void ExecuteWeightTest()
        {
            Gram g = 82_000;
            Kilogram kg = 82;
            Milligram mg = 82;

            Assert.AreNotEqual<MetricValueBase>(kg, mg);
            Assert.IsTrue(g.LogicallyEquals(kg));
            Assert.IsFalse(kg.LogicallyEquals(mg));
        }
    }
}
