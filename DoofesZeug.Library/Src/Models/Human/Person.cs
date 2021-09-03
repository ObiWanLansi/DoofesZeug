using DoofesZeug.Attributes.Pattern;



namespace DoofesZeug.Models.Human
{
    [Builder]
    public class Person : IdentifiableEntity
    {
        public DateOfBirth DateOfBirth { get; set; } = (1, 1, 1);

        public FirstName FirstName { get; set; } = "";

        public LastName LastName { get; set; } = "";

        public Gender Gender { get; set; } = Gender.Unknown;

        //public ProfessionList Professions { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public override string ToString() => $"{this.LastName}, {this.FirstName} ({this.DateOfBirth})";
    }
}
