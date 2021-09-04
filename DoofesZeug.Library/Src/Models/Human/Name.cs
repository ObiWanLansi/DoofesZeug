using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Human
{
    [Description("")]
    public abstract class Name : EntityBase
    {
        public string Value { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Name() { }


        public Name( string value ) => this.Value = value;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //public static implicit operator Name( string value ) => new(value);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override string ToString() => this.Value;
    }
}
