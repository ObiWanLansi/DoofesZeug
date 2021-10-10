using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("An simplified emailaddress.")]
    public sealed class EMailAddress : IdentifiableEntity
    {
        public string Address { get; set; }

        public InformationType? InformationType { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        
        public static implicit operator EMailAddress( string address ) => new() { Address = address };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override StringList Validate() => throw new NotImplementedException();
    }
}
