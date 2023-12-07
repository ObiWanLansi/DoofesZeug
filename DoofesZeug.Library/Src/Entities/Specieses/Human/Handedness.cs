using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.Specieses.Human;

[Description("An simple enumeration for the handedness of an human.")]
public enum Handedness : byte
{
    // When we not know, what for an handedness an human have, the property should be null.
    // Unknown,

    Left,
    Right,
    Both
}
