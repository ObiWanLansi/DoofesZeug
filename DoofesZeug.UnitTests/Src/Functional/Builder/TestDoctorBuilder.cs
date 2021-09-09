using DoofesZeug.Models.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestDoctorBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Doctor doctor = DoctorBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(doctor);
        }
    }
}
        
