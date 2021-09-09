using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;



namespace DoofesZeug.Models.Specieses.Animals
{
    [Description("An simplified animal with an firstname, lastname, birthday and some other optional properties.")]
    [Builder]
    public class Animal : Species
    {
        public AnimalSpecies? AnimalSpecies { get; set; }

        public Name Name { get; set; }
    }
}
