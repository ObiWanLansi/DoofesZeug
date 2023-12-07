using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.Specieses;

[Description("An simple enumeration for the bloodgroup of an human.")]
[Link("https://en.wikipedia.org/wiki/Blood_type")]
public enum BloodGroup : byte
{
    A,
    B,
    AB,
    Zero
}
