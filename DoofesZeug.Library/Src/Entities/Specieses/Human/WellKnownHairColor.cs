using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.Specieses.Human;

[Description("A small enumeration with the natural hair colors.")]
[Link("https://en.wikipedia.org/wiki/Human_hair_color")]
public enum WellKnownHairColor : byte
{
    White,
    Gray,
    Red,
    Blond,
    Brown,
    Black
}
