using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Testing;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("")]
    [IgnoreTest]
    public sealed class EMailAddress  : IdentifiableEntity
    {
        public string Receiver { get; set; }

        public string Domain { get; set; }

        public string TopLevelDomain { get; set; }

        public InformationType? InformationType { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override StringList Validate() => throw new NotImplementedException();
    }
}
