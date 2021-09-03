


namespace DoofesZeug.Models.Human.Professions
{
    public abstract class Profession : IdentifiableEntity
    {
        public WellKnownProfession WellKnownProfessionType { get; private set; }

        protected Profession( WellKnownProfession wkp ) => this.WellKnownProfessionType = wkp;
    }
}
