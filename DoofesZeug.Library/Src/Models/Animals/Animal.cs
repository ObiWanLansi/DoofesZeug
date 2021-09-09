using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.DateAndTime;
using DoofesZeug.Models.Human;



namespace DoofesZeug.Models.Animals
{
    [Description("An simplified animal with an firstname, lastname, birthday and some other optional properties.")]
    [Builder]
    public class Animal : IdentifiableEntity
    {
        public DateOfBirth DateOfBirth { get; set; }

        public Name Name { get; set; }

        public Gender? Gender { get; set; }

        public AnimalSpecies? AnimalSpecies { get; set; }
    }
}
