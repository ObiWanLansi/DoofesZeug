
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human
{
    [Generated]
    public static class PersonBuilder
    {
        public static Person New() => new();


        public static Person WithFirstName(this Person person, DoofesZeug.Entities.Specieses.Human.FirstName firstname)
        {
            person.FirstName = firstname;
            return person;
        }


        public static Person WithLastName(this Person person, DoofesZeug.Entities.Specieses.Human.LastName lastname)
        {
            person.LastName = lastname;
            return person;
        }


        public static Person WithHandedness(this Person person, System.Nullable<DoofesZeug.Entities.Specieses.Human.Handedness> handedness)
        {
            person.Handedness = handedness;
            return person;
        }


        public static Person WithBloodGroup(this Person person, System.Nullable<DoofesZeug.Entities.Specieses.BloodGroup> bloodgroup)
        {
            person.BloodGroup = bloodgroup;
            return person;
        }


        public static Person WithHairColor(this Person person, System.Nullable<DoofesZeug.Entities.Specieses.Human.WellKnownHairColor> haircolor)
        {
            person.HairColor = haircolor;
            return person;
        }


        public static Person WithReligion(this Person person, System.Nullable<DoofesZeug.Entities.Specieses.Human.MajorReligion> religion)
        {
            person.Religion = religion;
            return person;
        }


        public static Person WithProfession(this Person person, DoofesZeug.Entities.Specieses.Human.Professions.Profession profession)
        {
            person.Profession = profession;
            return person;
        }


        public static Person WithAverageHeight(this Person person, DoofesZeug.Entities.Science.Base.Length.Centimeter averageheight)
        {
            person.AverageHeight = averageheight;
            return person;
        }


        public static Person WithAverageWeight(this Person person, DoofesZeug.Entities.Science.Base.Weight.Kilogram averageweight)
        {
            person.AverageWeight = averageweight;
            return person;
        }


        public static Person WithDateOfBirth(this Person person, DoofesZeug.Entities.DateAndTime.DateOfBirth dateofbirth)
        {
            person.DateOfBirth = dateofbirth;
            return person;
        }


        public static Person WithGender(this Person person, System.Nullable<DoofesZeug.Entities.Specieses.Gender> gender)
        {
            person.Gender = gender;
            return person;
        }
    }
}
