using System;



namespace DoofesZeug.Attributes.Documentation
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
    public sealed class DescriptionAttribute : BaseAttribute
    {
        public string Description { get; private set; }

        public DescriptionAttribute( string strDescription ) => this.Description = strDescription;
    }
}
