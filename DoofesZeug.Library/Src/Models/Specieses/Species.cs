using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Specieses
{
    [Description("An baseclass for all other entities who have an heart.")]
    public abstract class Species : IdentifiableEntity
    {
        public DateOfBirth DateOfBirth { get; set; }

        public Gender? Gender { get; set; }
    }
}
