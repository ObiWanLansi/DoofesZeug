
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Animals
{
    [Generated]
    public static class AnimalBuilder
    {
        public static Animal New() => new();


        public static Animal WithDateOfBirth(this Animal animal, DoofesZeug.Models.DateAndTime.DateOfBirth dateofbirth)
        {
            animal.DateOfBirth = dateofbirth;
            return animal;
        }


        public static Animal WithName(this Animal animal, DoofesZeug.Models.Human.Name name)
        {
            animal.Name = name;
            return animal;
        }


        public static Animal WithGender(this Animal animal, DoofesZeug.Models.Human.Gender gender)
        {
            animal.Gender = gender;
            return animal;
        }


        public static Animal WithAnimalSpecies(this Animal animal, DoofesZeug.Models.Animals.AnimalSpecies animalspecies)
        {
            animal.AnimalSpecies = animalspecies;
            return animal;
        }
    }
}
