using DoofesZeug.Entities.Specieses.Human.Professions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestTeacherBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Teacher teacher = TeacherBuilder.New().WithSince((25, 05, 1978));
            Assert.IsNotNull(teacher);
        }
    }
}