using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Human.Professions
{
    public abstract class Profession : IdentifiableEntity
    {
        public WellKnownProfession WellKnownProfessionType { get; private set; }

        public Date Since { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        protected Profession( WellKnownProfession wkp ) => this.WellKnownProfessionType = wkp;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public override string ToString() => $"{this.WellKnownProfessionType}";
    }
}
