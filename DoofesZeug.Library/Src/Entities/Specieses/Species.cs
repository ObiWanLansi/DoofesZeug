using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Entities.DateAndTime;



namespace DoofesZeug.Entities.Specieses
{
    [Description("An baseclass for all other entities who have an heart.")]
    public abstract class Species : IdentifiableEntity
    {
        public DateOfBirth DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public DateOfDeath DateOfDeath { get; set; }

        //---------------------------------------------------------------------


        public uint? Age
        {
            get
            {
                if( this.DateOfBirth == null )
                {
                    return null;
                }

                return this.DateOfDeath == null ? this.DateOfBirth.Years(Date.Now) : this.DateOfBirth.Years(this.DateOfDeath);
            }
        }

        public bool IsAlive => this.DateOfBirth != null && this.DateOfDeath == null;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj ) => Equals(this, obj as Species);


        ///// <summary>
        ///// Returns a hash code for this instance.
        ///// </summary>
        ///// <returns>
        ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        ///// </returns>
        //public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), this.DateOfBirth, this.Gender, this.DateOfDeath);


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate()
        {
            StringList sl = new();

            if( this.DateOfBirth == null )
            {
                sl.Add("The dateofbirth is null!");
            }
            else
            {
                sl.AddRange(this.DateOfBirth.Validate());
            }

            if( this.Gender == null )
            {
                sl.Add("The gender is null!");
            }

            if( this.DateOfDeath != null )
            {
                sl.AddRange(this.DateOfDeath.Validate());

                if( (DateTime) this.DateOfBirth > (DateTime) this.DateOfDeath )
                {
                    sl.Add("The dateofbirth is bigger than the dateofdeath!");
                }
            }

            return sl;
        }
    }
}
