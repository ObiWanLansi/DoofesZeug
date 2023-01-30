using DoofesZeug.Entities.Science.Base;
using DoofesZeug.Entities.Science.Base.Length;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Datatypes
{
    [TestClass]
    public class TestLength
    {
        [TestMethod]
        public void ExecuteLengthTest()
        {
            Centimeter cm = 174;
            Meter m = 1.74;
            Kilometer km = 174;

            Assert.AreNotEqual<MetricValueBase>(cm, m);
            Assert.IsTrue(cm.LogicallyEquals(m));
            Assert.IsFalse(km.LogicallyEquals(m));
        }
    }
}
