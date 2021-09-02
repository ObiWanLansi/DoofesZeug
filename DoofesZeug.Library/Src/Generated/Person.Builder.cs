
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human
{
    [Generated]
    public static class PersonBuilder
    {
        public static Person New() => new();


        public static Person WithDateOfBirth(this Person person, DoofesZeug.Models.Human.DateOfBirth dateofbirth)
        {
            person.DateOfBirth = dateofbirth;
            return person;
        }


        public static Person WithFirstName(this Person person, DoofesZeug.Models.Human.FirstName firstname)
        {
            person.FirstName = firstname;
            return person;
        }


        public static Person WithLastName(this Person person, DoofesZeug.Models.Human.LastName lastname)
        {
            person.LastName = lastname;
            return person;
        }


        public static Person WithGender(this Person person, DoofesZeug.Models.Human.Gender gender)
        {
            person.Gender = gender;
            return person;
        }


        public static Person WithProfessions(this Person person, DoofesZeug.Models.Human.Professions.ProfessionList professions)
        {
            person.Professions = professions;
            return person;
        }


        public static Person WithId(this Person person, System.Guid id)
        {
            person.Id = id;
            return person;
        }
    }
}
