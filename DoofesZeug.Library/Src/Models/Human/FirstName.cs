namespace DoofesZeug.Models.Human
{
    public sealed class FirstName : Name
    {
        public FirstName() { }


        public FirstName( string value ) : base(value) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator FirstName( string value ) => new(value);
    }
}
