using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("An simple phonenumber.")]
    public sealed class Phone : IdentifiableEntity
    {
        public string Number { get; set; }

        public PhoneType? PhoneType { get; set; }

        public InformationType? InformationType { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator Phone( string number ) => new() { Number = number };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override StringList Validate() => throw new NotImplementedException();
    }
}
