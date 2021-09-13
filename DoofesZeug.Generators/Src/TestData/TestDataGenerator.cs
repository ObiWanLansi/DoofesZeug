using System;
using System.Collections.Generic;

using DoofesZeug.Models.DateAndTime;
using DoofesZeug.Models.DateAndTime.Part;
using DoofesZeug.Models.DateAndTime.Part.Date;
using DoofesZeug.Models.DateAndTime.Part.Time;
using DoofesZeug.Models.Science.Base.Length;
using DoofesZeug.Models.Science.Base.Weight;
using DoofesZeug.Models.Science.Geographically.Base;
using DoofesZeug.Models.Specieses;
using DoofesZeug.Models.Specieses.Animals;
using DoofesZeug.Models.Specieses.Human;
using DoofesZeug.Models.Specieses.Human.Professions;



namespace DoofesZeug.TestData
{
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

            GENERATORS.Add(typeof(Baker).FullName, GenerateProfession<Baker>);
            GENERATORS.Add(typeof(Carpenter).FullName, GenerateProfession<Carpenter>);
            GENERATORS.Add(typeof(Doctor).FullName, GenerateProfession<Doctor>);
            GENERATORS.Add(typeof(Engineer).FullName, GenerateProfession<Engineer>);
            GENERATORS.Add(typeof(FireFighter).FullName, GenerateProfession<FireFighter>);
            GENERATORS.Add(typeof(HairDresser).FullName, GenerateProfession<HairDresser>);
            GENERATORS.Add(typeof(Nurse).FullName, GenerateProfession<Nurse>);
            GENERATORS.Add(typeof(PoliceOfficer).FullName, GenerateProfession<PoliceOfficer>);
            GENERATORS.Add(typeof(Teacher).FullName, GenerateProfession<Teacher>);
            GENERATORS.Add(typeof(Tiler).FullName, GenerateProfession<Tiler>);
            GENERATORS.Add(typeof(Waiter).FullName, GenerateProfession<Waiter>);
            GENERATORS.Add(typeof(BusDriver).FullName, GenerateProfession<BusDriver>);
            GENERATORS.Add(typeof(TaxiDriver).FullName, GenerateProfession<TaxiDriver>);
            GENERATORS.Add(typeof(Soldier).FullName, GenerateProfession<Soldier>);
            GENERATORS.Add(typeof(Pilot).FullName, GenerateProfession<Pilot>);

            GENERATORS.Add(typeof(DateOfBirth).FullName, GenerateDateOfBirth);
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

            //GENERATORS.Add(typeof(Altitude).FullName, GenerateAltitude);
            GENERATORS.Add(typeof(Latitude).FullName, GenerateLatitude);
            GENERATORS.Add(typeof(Longitude).FullName, GenerateLongitude);
            GENERATORS.Add(typeof(GeoPoint).FullName, GenerateGeoPoint);

            GENERATORS.Add(typeof(Meter).FullName, GenerateMeter);
            GENERATORS.Add(typeof(Kilometer).FullName, GenerateKilometer);
            GENERATORS.Add(typeof(Gram).FullName, GenerateGram);

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //private static Altitude GenerateAltitude() => new(42);

        private static Latitude GenerateLatitude() => new(49.759646524258756);

        private static Longitude GenerateLongitude() => new(6.644282639342397);

        private static GeoPoint GenerateGeoPoint() => new(49.759646524258756, 6.644282639342397);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static Meter GenerateMeter() => new(42.42);

        private static Kilometer GenerateKilometer() => new(12.34);

        private static Gram GenerateGram() => new(1234);

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


        private static Name GenerateName() => new("HurzFurz");

        private static LastName GenerateLastName() => "Mustermann";

        private static FirstName GenerateFirstName() => "Erika";

        private static DateOfBirth GenerateDateOfBirth() => (24, 12, 1948);

        private static Person GeneratePerson() => new()
        {
            FirstName = "John",
            LastName = "Doe",
            Gender = Gender.Male,
            DateOfBirth = (27, 09, 1974),
            Handedness = Handedness.Left,
            BloodGroup = BloodGroup.AB,
            Profession = GenerateProfession<FireFighter>()
        };

        private static T GenerateProfession<T>() where T : Profession
        {
            Profession p = (Profession) Activator.CreateInstance(typeof(T));
            p.Since = (11, 11, 1942);
            return (T) p;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static Animal GenerateAnimal() => new()
        {
            AnimalSpecies = AnimalSpecies.Cat,
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
}
