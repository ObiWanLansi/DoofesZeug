using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Specieses.Animals
{
    [Description("An simplified animal with an firstname, lastname, birthday and some other optional properties.")]
    [Builder]
    public class Animal : Species
    {
        public DateOfBirth DateOfBirth { get; set; }

        public Name Name { get; set; }

        public Gender? Gender { get; set; }

        public AnimalSpecies? AnimalSpecies { get; set; }
    }
}
