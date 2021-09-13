using DoofesZeug.Entities.Specieses;
using DoofesZeug.Entities.Specieses.Animals;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestAnimalBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Animal animal = AnimalBuilder.New().
                WithDateOfBirth((10, 06, 1978)).
                WithName("Jacki").
                WithGender(Gender.Female).
                WithAnimalSpecies(WellKnownAnimal.Horse);

            Assert.IsNotNull(animal);
        }
    }
}