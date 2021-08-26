using System;

using DoofesZeug.Models.Human;
using DoofesZeug.Models.Human.Professions;

using Newtonsoft.Json;



namespace DoofesZeug
{
    static class TestConsole
    {
        static private readonly string DIV = new string('-', 40);

        static void Main( string [] args )
        {
            FireFighter ff = new()
            {
                FirstName = "Fred",
                LastName = "Zimmer",
                Gender = Gender.Male,
                DateOfBirth = (15, 10, 1974)
            };

            Console.Out.WriteLine(ff);
            Console.Out.WriteLine(DIV);
            Console.Out.WriteLine(JsonConvert.SerializeObject(ff, Formatting.Indented));
            Console.Out.WriteLine(DIV);
        }
    }
}
