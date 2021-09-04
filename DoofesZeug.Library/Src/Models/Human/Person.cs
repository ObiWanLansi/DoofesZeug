using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.Human.Professions;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Human
{
    [Description("An simplified Person with an firstname, lastname, birthday and some other optional properties.")]
    [Builder]
    public class Person : IdentifiableEntity
    {
        public DateOfBirth DateOfBirth { get; set; }

        public FirstName FirstName { get; set; } 

        public LastName LastName { get; set; } 

        public Gender Gender { get; set; } 

        public Handedness Handedness { get; set; }

        public Profession Profession { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public override string ToString() => $"{this.LastName}, {this.FirstName} ({this.DateOfBirth})";
    }
}
