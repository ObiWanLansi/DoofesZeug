using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.Science.Geographically.Coordinates;

[Description("An simplified geo point with lat, lon and alt (WGS84).")]
public class GeoPoint3D : Entity
{
    public Latitude Latitude { get; set; }

    public Longitude Longitude { get; set; }

    public Altitude Altitude { get; set; }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Initializes a new instance of the <see cref="GeoPoint3D"/> class.
    /// </summary>
    public GeoPoint3D()
    {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="GeoPoint3D" /> class.
    /// </summary>
    /// <param name="latitude">The latitude.</param>
    /// <param name="longitude">The longitude.</param>
    /// <param name="altitude">The altitude.</param>
    public GeoPoint3D( Latitude latitude, Longitude longitude, Altitude altitude )
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
        this.Altitude = altitude;
    }


    ///// <summary>
    ///// Initializes a new instance of the <see cref="GeoPoint3D"/> class.
    ///// </summary>
    ///// <param name="latlon">The latlon.</param>
    //public GeoPoint3D( string latlon )
    //{
    //    if( latlon.IsEmpty() )
    //    {
    //        throw new ArgumentNullException(nameof(latlon));
    //    }

    //    int index = latlon.IndexOf(',');

    //    if( index < 3 )
    //    {
    //        throw new ArgumentException("", nameof(latlon));
    //    }

    //    this.Latitude = new(latlon.Substring(0, index).Trim());
    //    this.Longitude = new(latlon.Substring(index + 1, latlon.Length - index - 1).Trim());
    //}

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals( object obj ) => Equals(this, obj as GeoPoint3D);


    ///// <summary>
    ///// Returns a hash code for this instance.
    ///// </summary>
    ///// <returns>
    ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
    ///// </returns>
    //public override int GetHashCode() => HashCode.Combine(this.Latitude, this.Longitude, this.Altitude);


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate()
    {
        StringList sl = [];

        PropertyValidate(this, sl);

        return sl;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{this.Latitude}, {this.Longitude} ({this.Altitude})";
}
