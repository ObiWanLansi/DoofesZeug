using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Validation
{
    [Description("")]
    public interface IValidate<T>
    {
        bool IsValid( T value );
    }
}
