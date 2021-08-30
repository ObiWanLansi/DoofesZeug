using System;
using System.Collections.Generic;

using DoofesZeug.Models.DateAndTime;
using DoofesZeug.Models.Human;
using DoofesZeug.Models.Human.Professions;



namespace DoofesZeug.TestData
{
    public static class TestDataGenerator
    {
        private static readonly SortedDictionary<string, Func<object>> GENERATORS = new();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        static TestDataGenerator()
        {
            //GENERATORS.Add(typeof(UnixTimestamp).FullName, GenerateUnixTimestamp);


            GENERATORS.Add(typeof(Person).FullName, GeneratePerson);
            GENERATORS.Add(typeof(FireFighter).FullName, GenerateFireFighter);
            GENERATORS.Add(typeof(PoliceOfficer).FullName, GeneratePoliceOfficer);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private static UnixTimestamp GenerateUnixTimestamp() => UnixTimestamp.Now();


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static Person GeneratePerson() => new() { FirstName = "John", LastName = "Doe", Gender = Gender.Male, DateOfBirth = (27, 09, 1974) };


        private static FireFighter GenerateFireFighter() => new() { FirstName = "John", LastName = "Doe", Gender = Gender.Male, DateOfBirth = (27, 09, 1974) };


        private static PoliceOfficer GeneratePoliceOfficer() => new() { FirstName = "John", LastName = "Doe", Gender = Gender.Male, DateOfBirth = (27, 09, 1974) };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static object GenerateTestData( Type t ) => GENERATORS.ContainsKey(t.FullName) ? GENERATORS [t.FullName]() : null;
    }
}
