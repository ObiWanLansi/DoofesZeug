﻿using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Extensions;



namespace DoofesZeug.Entities.Science.Geographically.Base
{
    [Description("An simplified geo point with lat, lon and alt (WGS84).")]
    public class GeoPoint : IdentifiableEntity
    {
        public Latitude Latitude { get; set; }

        public Longitude Longitude { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPoint"/> class.
        /// </summary>
        public GeoPoint()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPoint"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public GeoPoint( Latitude latitude, Longitude longitude )
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="GeoPoint"/> class.
        /// </summary>
        /// <param name="latlon">The latlon.</param>
        public GeoPoint( string latlon )
        {
            if( latlon.IsEmpty() )
            {
                throw new ArgumentNullException(nameof(latlon));
            }

            int index = latlon.IndexOf(',');

            if( index < 3 )
            {
                throw new ArgumentException("", nameof(latlon));
            }

            this.Latitude = new(latlon.Substring(0, index).Trim());
            this.Longitude = new(latlon.Substring(index + 1, latlon.Length - index - 1).Trim());
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj )
        {
            if( obj == null )
            {
                return false;
            }

            if( obj is not GeoPoint other )
            {
                return false;
            }

            if( this.Latitude.Equals(other.Latitude) == false )
            {
                return false;
            }

            if( this.Longitude.Equals(other.Longitude) == false )
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
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), this.Latitude, this.Longitude);


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate() => throw new NotImplementedException();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{this.Latitude}, {this.Longitude}";
    }
}
