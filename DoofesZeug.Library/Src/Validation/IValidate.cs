


namespace DoofesZeug.Validation
{
    public interface IValidate<T>
    {
        bool IsValid( T value );
    }
}
