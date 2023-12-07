using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Entities.DateAndTime.Part.Date;



namespace DoofesZeug.Entities.DateAndTime;

[Description("An date of death (without the time) for creatures.")]
public sealed class DateOfDeath : Date
{
    public DateOfDeath() : base() { }

    public DateOfDeath( Date date ) : base(date) { }

    public DateOfDeath( DateTime dt ) : base(dt) { }

    public DateOfDeath( Day day, Month month, Year year ) : base(day, month, year) { }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="DateOfDeath"/>.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator DateOfDeath( DateTime dt ) => new((uint) dt.Day, (uint) dt.Month, (uint) dt.Year);


    /// <summary>
    /// Performs an implicit conversion from <see cref="(Day day, Month month, Year year)"/> to <see cref="Entities.Human.DateOfDeath"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator DateOfDeath( (Day day, Month month, Year year) value ) => new(value.day, value.month, value.year);
}
