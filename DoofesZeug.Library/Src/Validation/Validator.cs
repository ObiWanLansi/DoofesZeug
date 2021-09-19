using System;

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
        public static StringList Validate( object value, bool bStopAtFirstError = false )
        {
            return null;
        }
    }
}
