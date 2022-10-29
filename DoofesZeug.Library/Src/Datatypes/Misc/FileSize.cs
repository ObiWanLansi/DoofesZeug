using System;

using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Datatypes.Misc
{
    /// <summary>
    /// Initialversion einen Wrappers für Dateigrößen.
    /// Sieht beim dumpen besser und schöner aus als wenn nur große Zahlen dort stehen.
    /// </summary>
    public sealed class FileSize
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public long Value { get; private set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="FileSize" /> class.
        /// </summary>
        /// <param name="lValue">The l value.</param>
        public FileSize(long lValue) => this.Value = lValue;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >(FileSize x, FileSize y) => x.Value > y.Value;


        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <(FileSize x, FileSize y) => x.Value < y.Value;


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="FileSize"/>.
        /// </summary>
        /// <param name="lValue">The l value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator FileSize(long lValue) => new(lValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="FileSize" /> to <see cref="System.Int64" />.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator long(FileSize x) => x.Value;


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Tool.GetHumanReadableSize(this.Value);
    }
}
