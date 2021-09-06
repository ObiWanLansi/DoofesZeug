// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

using DoofesZeug.Models.Animals;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestAnimalBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Animal animal = AnimalBuilder.New().WithDateOfBirth((10, 06, 1978)).WithName("Jacki").WithGender(Models.Human.Gender.Female).WithAnimalSpecies(AnimalSpecies.Horse);
            Assert.IsNotNull(animal);
        }
    }
}

