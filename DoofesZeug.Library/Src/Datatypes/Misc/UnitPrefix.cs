using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Datatypes.Misc
{
    [Description("An small class to hold the properties of an metric prefix.")]
    public sealed class UnitPrefix
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public string Symbol { get; }

        /// <summary>
        /// Gets or sets the factor.
        /// </summary>
        /// <value>
        /// The factor.
        /// </value>
        public double Factor { get; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="UnitPrefix" /> class.
        /// </summary>
        /// <param name="strName">Name of the string.</param>
        /// <param name="strSymbol">The string symblo.</param>
        /// <param name="dFactor">The d factor.</param>
        public UnitPrefix( string strName, string strSymbol, double dFactor )
        {
            this.Name = strName;
            this.Symbol = strSymbol;
            this.Factor = dFactor;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj )
        {
            if( obj == null )
            {
                return false;
            }

            if( obj is not UnitPrefix other )
            {
                return false;
            }

            if( this.Name.Equals(other.Name) == false )
            {
                return false;
            }

            if( this.Symbol.Equals(other.Symbol) == false )
            {
                return false;
            }

            if( this.Factor.Equals(other.Factor) == false )
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(this.Name, this.Symbol, this.Factor);
    }
}
