﻿using System.Reflection;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.Specieses.Human.Professions;



namespace DoofesZeug.Models.Specieses.Human
{
    [Description("An simplified person with an firstname, lastname, birthday and some other optional properties.")]
    [Builder]
    public class Person : Species
    {
        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public Handedness? Handedness { get; set; }

        public BloodGroup? BloodGroup { get; set; }

        public Profession Profession { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.LastName}, {this.FirstName} ({this.DateOfBirth})";


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj )
        {
            if( base.Equals(obj) == false )
            {
                return false;
            }

            if( obj is not Person other )
            {
                return false;
            }

            foreach( PropertyInfo pi in typeof(Person).GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly) )
            {
                object oThis = pi.GetValue(this);
                object oOther = pi.GetValue(other);

                if( oThis == null && oOther != null )
                {
                    return false;
                }

                if( oThis != null && oOther == null )
                {
                    return false;
                }

                if( oThis != null && oOther != null )
                {
                    if( oThis.Equals(oOther) == false )
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}