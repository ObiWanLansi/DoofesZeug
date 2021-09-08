using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Human.Professions
{
    [Description("A small enumeration of some professions, for every value an corresponding entity will be created by the generator.")]
    public enum WellKnownProfession : byte
    {
        Unknown,
        FireFighter,
        PoliceOfficer,
        Nurse,
        Engineer,
        Doctor,
        HairDresser,
        Baker,
        Waiter,
        Teacher,
        Tiler,
        Carpenter,
        Soldier,
        BusDriver,
        TaxiDriver,
        Pilot
    }
}
