using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human
{
    [Builder]
    public class Person : ModelBase
    {
        public DateOfBirth DateOfBirth { get; init; }

        public FirstName FirstName { get; init; }

        public LastName LastName { get; init; }
        
        public Gender Gender { get; init; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public override string ToString() => $"{this.LastName}, {this.FirstName}";
    }
}
