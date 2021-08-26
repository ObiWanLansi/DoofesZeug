namespace DoofesZeug.Models.Human
{
    public sealed class FirstName //: ModelBase
    {
        private readonly string value;

        public FirstName( string value ) => this.value = value;

        public override string ToString() => this.value;

        public static implicit operator FirstName( string value ) => new(value);
    }
}
