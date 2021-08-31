using System;
using System.Collections.Generic;

using DoofesZeug.Extensions;
using DoofesZeug.Models.Human;
using DoofesZeug.Models.Human.Professions;



namespace DoofesZeug
{
    static class TestConsole
    {
        static private readonly string DIV = new('-', 40);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //private static string ToXml( object o )
        //{
        //    using MemoryStream ms = new();

        //    using( XmlTextWriter xmlwriter = new(ms, Encoding.GetEncoding("ISO-8859-1")) )
        //    {
        //        xmlwriter.Formatting = System.Xml.Formatting.Indented;
        //        xmlwriter.Indentation = 4;

        //        try
        //        {
        //            new XmlSerializer(o.GetType()).Serialize(xmlwriter, o);
        //        }
        //        finally
        //        {
        //            xmlwriter.Close();
        //            ms.Close();
        //        }
        //    }

        //    return Encoding.Default.GetString(ms.GetBuffer());
        //}


        //private static string ToJson( object o )
        //{
        //    JsonSerializerSettings settings = new()
        //    {
        //        Formatting = Newtonsoft.Json.Formatting.Indented
        //    };

        //    settings.Converters.Add(new StringEnumConverter());
        //    settings.Converters.Add(new NameConverter());
        //    settings.Converters.Add(new DateTimePartConverter());

        //    return JsonConvert.SerializeObject(o, settings);
        //}


        //private static string ToYaml( object o )
        //{
        //    //return new SerializerBuilder().WithEventEmitter(nextEmitter => new QuoteSurroundingEventEmitter(nextEmitter)).Build().Serialize(o);
        //    return new SerializerBuilder().Build().Serialize(o);
        //}

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        static void Main( string [] args )
        {
            Person p = PersonBuilder.New().
                WithFirstName("John").
                WithLastName("Doe").
                WithGender(Gender.Male).
                WithDateOfBirth((25, 05, 1942)).
                WithProfessions(ProfessionList.Of(new PoliceOfficer(), new FireFighter()));

            Console.Out.WriteLine(p.ToPrettyJson());
            Console.Out.WriteLine(DIV);
        }
    }
}
