using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.ManMade.Vehicles
{
    [Description("A small enumeration of some vehicles, mixed with subtypes for faster development.")]
    public enum WellKnownVehicle : byte
    {
        Bicycle,
        Car,
        Bus,
        Train,
        Airplane,
        Motorcycle
    }
}
