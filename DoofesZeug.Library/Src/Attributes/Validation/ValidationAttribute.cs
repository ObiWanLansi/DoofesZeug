using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Attributes.Validation
{
    public abstract class ValidationAttribute : BaseAttribute
    {
        public abstract StringList Validate( object value );
    }
}
