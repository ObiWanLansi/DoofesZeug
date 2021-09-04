using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Human.Professions
{
    [Description("The baseclass for all other professions.")]
    public abstract class Profession : IdentifiableEntity
    {
        public WellKnownProfession WellKnownProfessionType { get; private set; }

        public Date Since { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected Profession( WellKnownProfession wkp ) => this.WellKnownProfessionType = wkp;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public override string ToString() => $"{this.WellKnownProfessionType} ({this.Since})";
    }
}
