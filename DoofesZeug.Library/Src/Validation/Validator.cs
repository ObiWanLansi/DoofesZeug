using System;
using System.Linq;
using System.Reflection;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Validation
{
    [Description("This class is for validate an object. First it checks if the class has implemented an IValidate an call the IsValid function, and second when the interface is not implemented, every property will be checked if the ptopertytype have an validation attribute and then checks the validation.")]
    public static class Validator
    {
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="bStopAtFirstError">if set to <c>true</c> [b stop at first error].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static StringList Validate<T>( T value, bool bStopAtFirstError = false )
        {
            StringList result = new();

            // First check if the vakue implements an validator interface.
            if( value is IValidate<T> validator )
            {
                StringList val = validator.Validate(value);

                if( val != null )
                {
                    result.AddRange(val);
                }
            }

            foreach( PropertyInfo pi in from property in typeof(T).GetProperties() where property.CanRead select property )
            {
                // Second check if an property of the value have and validation attribute.

                // Third check if the type of an property have and validation attribute.
            }

            return result;
        }
    }
}
