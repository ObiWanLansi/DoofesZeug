using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Specieses.Animals
{
    [Description("A small enumeration of some animals, mixed with subtypes for faster development.")]
    public enum WellKnownAnimal : byte
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