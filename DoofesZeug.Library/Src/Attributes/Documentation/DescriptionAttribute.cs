using System;

using DoofesZeug.Extensions;



namespace DoofesZeug.Attributes.Documentation
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
    public sealed class DescriptionAttribute : BaseAttribute
    {
        public string Description { get; private set; }


        public DescriptionAttribute( string strDescription ) => this.Description = strDescription;


        public void Validate( Type instance )
        {
            if( this.Description.IsEmpty() )
            {
                throw new Exception($"The description from {instance.FullName} is empty!");
            }

            if( this.Description.Length < 5 )
            {
                throw new Exception($"The description from {instance.FullName} is to short!");
            }

            if( this.Description.EndsWith(".") == false )
            {
                throw new Exception($"The description from {instance.FullName} ends not with an point!");
            }
        }
    }
}
