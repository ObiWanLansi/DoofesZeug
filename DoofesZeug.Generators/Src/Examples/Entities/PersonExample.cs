using System;

using DoofesZeug.Entities.ManMade.Communication;
using DoofesZeug.Entities.Specieses;
using DoofesZeug.Entities.Specieses.Human;
using DoofesZeug.Extensions;



namespace DoofesZeug.Examples.Entities
{
    public static class PersonExample
    {
        public static void CreatePerson()
        {
            Person p = new Person
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

                Phone = new Phone
                {
                    Number = "+49 54321 424269",
                    PhoneType = PhoneType.Landline,
                    InformationType = InformationType.Private
                },
                EMailAddress = new EMailAddress
                {
                    Address = "obiwanlansi@github.com",
                    InformationType = InformationType.Business
                },
                Homepage = new Homepage
                {
                    Url = new("https://github.com/ObiWanLansi"),
                    InformationType = InformationType.Business
                }
            };

            Console.Out.WriteLineAsync(p.ToStringTable());
        }
    }
}
