
// ----------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation!
// ----------------------------------------------------------------------------------------------------------------
        


namespace DoofesZeug.Models.Human
{
    public static class PersonBuilder
    {
        public static Person New() => new();


        public static Person DateOfBirth(this Person person, DoofesZeug.Models.Human.DateOfBirth dateofbirth)
        {
            person.DateOfBirth = dateofbirth;
            return person;
        }


        public static Person FirstName(this Person person, DoofesZeug.Models.Human.FirstName firstname)
        {
            person.FirstName = firstname;
            return person;
        }


        public static Person LastName(this Person person, DoofesZeug.Models.Human.LastName lastname)
        {
            person.LastName = lastname;
            return person;
        }


        public static Person Gender(this Person person, DoofesZeug.Models.Human.Gender gender)
        {
            person.Gender = gender;
            return person;
        }


        public static Person Id(this Person person, System.Guid id)
        {
            person.Id = id;
            return person;
        }
    }
}
