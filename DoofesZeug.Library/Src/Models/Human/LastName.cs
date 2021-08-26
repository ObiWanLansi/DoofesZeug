namespace DoofesZeug.Models.Human
{
    public sealed class LastName //: ModelBase
    {
        private readonly string value;

        public LastName( string value ) => this.value = value;

        public override string ToString() => this.value;

        public static implicit operator LastName( string value ) => new(value);
    }
}
