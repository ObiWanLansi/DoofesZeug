using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("An simple link to an homepage.")]
    public sealed class Homepage : IdentifiableEntity
    {
        public Uri Url { get; set; }

        public InformationType? InformationType { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator Homepage( string url ) => new() { Url = new Uri(url) };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public override StringList Validate() => throw new NotImplementedException();
    }
}
