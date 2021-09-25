using System;

using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotNullAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public override StringList Validate( object value ) => value == null ? new StringList { "The current value is null!" } : null;
    }
}
