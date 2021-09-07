using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Validation
{
    [Description("This is the interface to implement if an class want to do more complex validation over a few depended properties.")]
    public interface IValidate<T>
    {
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>An StringList with the errors, or an empty list when the validation was successfully.</returns>
        StringList Validate( T value );
    }
}
