using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Testing;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("")]
    [IgnoreTest]
    public sealed class Phone : IdentifiableEntity
    {
        public int CountryCode { get; set; }

        public string Number { get; set; }

        public PhoneType? PhoneType { get; set; }

        public InformationType? InformationType { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override StringList Validate() => throw new NotImplementedException();
    }
}
