using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Human
{
    [Description("An lastname for humans.")]
    public sealed class LastName : Name
    {
        public LastName() { }

        public LastName( string value ) : base(value) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator LastName( string value ) => new(value);
    }
}
