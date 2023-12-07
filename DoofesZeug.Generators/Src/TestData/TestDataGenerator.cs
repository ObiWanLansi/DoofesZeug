using System;
using System.Collections.Generic;

using DoofesZeug.Entities.DateAndTime;
using DoofesZeug.Entities.DateAndTime.Part;
using DoofesZeug.Entities.DateAndTime.Part.Date;
using DoofesZeug.Entities.DateAndTime.Part.Time;
using DoofesZeug.Entities.ManMade.Communication;
using DoofesZeug.Entities.Science.Base.Length;
using DoofesZeug.Entities.Science.Base.Weight;
using DoofesZeug.Entities.Science.Geographically.Coordinates;
using DoofesZeug.Entities.Specieses;
using DoofesZeug.Entities.Specieses.Animals;
using DoofesZeug.Entities.Specieses.Human;



namespace DoofesZeug.TestData;

public static class TestDataGenerator
{
    private static readonly SortedDictionary<string, Func<object>> GENERATORS = new();

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    static TestDataGenerator()
    {
        GENERATORS.Add(typeof(UnixTimestamp).FullName, GenerateUnixTimestamp);
        GENERATORS.Add(typeof(Name).FullName, GenerateName);

        GENERATORS.Add(typeof(Person).FullName, GeneratePerson);
        GENERATORS.Add(typeof(FirstName).FullName, GenerateFirstName);
        GENERATORS.Add(typeof(LastName).FullName, GenerateLastName);

        GENERATORS.Add(typeof(DateOfBirth).FullName, GenerateDateOfBirth);
        GENERATORS.Add(typeof(DateOfDeath).FullName, GenerateDateOfDeath);
        GENERATORS.Add(typeof(Date).FullName, GenerateDate);
        GENERATORS.Add(typeof(Time).FullName, GenerateTime);

        GENERATORS.Add(typeof(Day).FullName, GenerateDateTimePart<Day>);
        GENERATORS.Add(typeof(Month).FullName, GenerateDateTimePart<Month>);
        GENERATORS.Add(typeof(Year).FullName, GenerateDateTimePart<Year>);
        GENERATORS.Add(typeof(Week).FullName, GenerateDateTimePart<Week>);
        GENERATORS.Add(typeof(Hour).FullName, GenerateDateTimePart<Hour>);
        GENERATORS.Add(typeof(Minute).FullName, GenerateDateTimePart<Minute>);
        GENERATORS.Add(typeof(Second).FullName, GenerateDateTimePart<Second>);

        GENERATORS.Add(typeof(Animal).FullName, GenerateAnimal);

        GENERATORS.Add(typeof(Altitude).FullName, GenerateAltitude);
        GENERATORS.Add(typeof(Latitude).FullName, GenerateLatitude);
        GENERATORS.Add(typeof(Longitude).FullName, GenerateLongitude);
        GENERATORS.Add(typeof(GeoPoint2D).FullName, GenerateGeoPoint2D);
        GENERATORS.Add(typeof(GeoPoint3D).FullName, GenerateGeoPoint3D);

        GENERATORS.Add(typeof(Centimeter).FullName, GenerateCentimeter);
        GENERATORS.Add(typeof(Meter).FullName, GenerateMeter);
        GENERATORS.Add(typeof(Kilometer).FullName, GenerateKilometer);

        GENERATORS.Add(typeof(Milligram).FullName, GenerateMilligram);
        GENERATORS.Add(typeof(Gram).FullName, GenerateGram);
        GENERATORS.Add(typeof(Kilogram).FullName, GenerateKilogram);

        GENERATORS.Add(typeof(EMailAddress).FullName, GenerateEMailAddress);
        GENERATORS.Add(typeof(Phone).FullName, GeneratePhone);
        GENERATORS.Add(typeof(Homepage).FullName, GenerateHomepage);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static Altitude GenerateAltitude() => new(42);

    private static Latitude GenerateLatitude() => new(49.759646524258756);

    private static Longitude GenerateLongitude() => new(6.644282639342397);

    private static GeoPoint2D GenerateGeoPoint2D() => new(49.759646524258756, 6.644282639342397);

    private static GeoPoint3D GenerateGeoPoint3D() => new(49.759646524258756, 6.644282639342397, 1234);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static Centimeter GenerateCentimeter() => new(142);
    private static Meter GenerateMeter() => new(1.42);
    private static Kilometer GenerateKilometer() => new(12.34);

    private static Milligram GenerateMilligram() => new(123);
    private static Gram GenerateGram() => new(42_123);
    private static Kilogram GenerateKilogram() => new(42);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static UnixTimestamp GenerateUnixTimestamp() => UnixTimestamp.Now();

    private static T GenerateDateTimePart<T>() where T : DateTimePart
    {
        DateTimePart dtp = (DateTimePart) Activator.CreateInstance(typeof(T));
        dtp.Value = 3;
        return (T) dtp;
    }

    private static Date GenerateDate() => (11, 11, 1942);

    private static Time GenerateTime() => (12, 43, 56);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static Phone GeneratePhone() => new() { Number = "+49 54321 424269", PhoneType = PhoneType.Landline, InformationType = InformationType.Private };

    private static EMailAddress GenerateEMailAddress() => new() { Address = "obiwanlansi@github.com", InformationType = InformationType.Business };

    private static Homepage GenerateHomepage() => new() { Url = new("https://github.com/ObiWanLansi"), InformationType = InformationType.Business };

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static Name GenerateName() => new("HurzFurz");

    private static LastName GenerateLastName() => new("Mustermann");

    private static FirstName GenerateFirstName() => new("Erika");

    private static DateOfBirth GenerateDateOfBirth() => (24, 12, 1948);

    private static DateOfBirth GenerateDateOfDeath() => (16, 06, 1948 + 42);

    private static Person GeneratePerson() => new()
    {
        FirstName = "John",
        LastName = "Doe",
        Gender = Gender.Male,

        DateOfBirth = (11, 02, 1942),
        DateOfDeath = (22, 03, 1942 + 42),

        Handedness = Handedness.Left,
        BloodGroup = BloodGroup.AB,
        HairColor = WellKnownHairColor.Blond,
        Religion = MajorReligion.Buddhism,
        Profession = WellKnownProfession.Engineer,
        DriverLicense = EuropeanDriverLicense.B | EuropeanDriverLicense.AM,

        AverageHeight = 174,
        AverageWeight = 72,

        Phone = new() { Number = "+49 54321 424269", PhoneType = PhoneType.Landline, InformationType = InformationType.Private },
        EMailAddress = new() { Address = "obiwanlansi@github.com", InformationType = InformationType.Business },
        Homepage = new() { Url = new("https://github.com/ObiWanLansi"), InformationType = InformationType.Business }
    };

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static Animal GenerateAnimal() => new()
    {
        AnimalSpecies = WellKnownAnimal.Cat,
        Name = "Garfield",
        Gender = Gender.Male,
        DateOfBirth = (10, 06, 1978)
    };

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Generates the test data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GenerateTestData<T>() => (T) GenerateTestData(typeof(T));


    /// <summary>
    /// Generates the test data.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    public static object GenerateTestData( Type type ) => GENERATORS.ContainsKey(type.FullName)
            ? GENERATORS [type.FullName]()
            : throw new ArgumentException($"For the type '{type.FullName}' is no data generator avaible!", nameof(type));
}
