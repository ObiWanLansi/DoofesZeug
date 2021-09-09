using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Specieses.Human
{
    [Description("An firstname for humans.")]
    public sealed class FirstName : Name
    {
        public FirstName() { }


        public FirstName( string value ) : base(value) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator FirstName( string value ) => new(value);
    }
}
