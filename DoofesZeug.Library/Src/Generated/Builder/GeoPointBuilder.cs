
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Science.Geographically.Base
{
    [Generated]
    public static class GeoPointBuilder
    {
        public static GeoPoint New() => new();


        public static GeoPoint WithLatitude(this GeoPoint geopoint, DoofesZeug.Entities.Science.Geographically.Base.Latitude latitude)
        {
            geopoint.Latitude = latitude;
            return geopoint;
        }


        public static GeoPoint WithLongitude(this GeoPoint geopoint, DoofesZeug.Entities.Science.Geographically.Base.Longitude longitude)
        {
            geopoint.Longitude = longitude;
            return geopoint;
        }
    }
}
