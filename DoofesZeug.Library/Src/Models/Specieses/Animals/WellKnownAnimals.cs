using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Specieses.Animals
{
    [Description("Some animal, mixed with subtypes for faster development.")]
    public enum WellKnownAnimals : byte
    {
        Cat,
        Dog,
        Horse,
        Cow,
        Pig,
        Donkey,
        Monkey,

        Chicken,
        Bird,
        Eagle,
        
        Shark,
        Dolphin,
        Fish,

        Giraffe,
        Elephant,
        Rhino,
        Buffalo,
        Hedgehog
    }
}