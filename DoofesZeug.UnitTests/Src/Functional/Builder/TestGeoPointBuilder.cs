using DoofesZeug.Entities.Science.Geographically.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestGeoPointBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            GeoPoint geopoint = GeoPointBuilder.New().WithLatitude(49.759646524258756).WithLongitude(6.644282639342397);
            Assert.IsNotNull(geopoint);
        }
    }
}