namespace DoofesZeug.Models.Human.Professions
{
    public abstract class Profession : IdentifiableEntity
    {
        public string Name { get; private set; }

        protected Profession( string strProfessionName ) => this.Name = strProfessionName;
    }
}
