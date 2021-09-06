using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Animals
{
    [Description("Some animal species, mixed with subtypes for faster development.")]
    public enum AnimalSpecies : byte
    {
        Unknown,

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
        Hedgehog,

        Other
    }
}