using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using DoofesZeug.Converter;
using DoofesZeug.Models.DateAndTime.Part;
using DoofesZeug.Models.DateAndTime.Part.Time;
using DoofesZeug.Models.Human;
using DoofesZeug.Models.Human.Professions;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using YamlDotNet.Serialization;



namespace DoofesZeug
{
    static class TestConsole
    {
        static private readonly string DIV = new('-', 40);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static string ToXml( object o )
        {
            using MemoryStream ms = new();

            using( XmlTextWriter xmlwriter = new(ms, Encoding.GetEncoding("ISO-8859-1")) )
            {
                xmlwriter.Formatting = System.Xml.Formatting.Indented;
                xmlwriter.Indentation = 4;

                try
                {
                    new XmlSerializer(o.GetType()).Serialize(xmlwriter, o);
                }
                finally
                {
                    xmlwriter.Close();
                    ms.Close();
                }
            }

            return Encoding.Default.GetString(ms.GetBuffer());
        }


        private static string ToJson( object o )
        {
            JsonSerializerSettings settings = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            settings.Converters.Add(new StringEnumConverter());
            settings.Converters.Add(new NameConverter());
            settings.Converters.Add(new DateTimePartConverter());

            return JsonConvert.SerializeObject(o, settings);
        }


        private static string ToYaml( object o )
        {
            //return new SerializerBuilder().WithEventEmitter(nextEmitter => new QuoteSurroundingEventEmitter(nextEmitter)).Build().Serialize(o);
            return new SerializerBuilder().Build().Serialize(o);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


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

            //-----------------------------------------------------------------

            Console.Out.WriteLine(ToXml(ff));
            Console.Out.WriteLine(DIV);

            //-----------------------------------------------------------------

            Console.Out.WriteLine(ToJson(ff));
            Console.Out.WriteLine(DIV);

            //-----------------------------------------------------------------

            Console.Out.WriteLine(ToYaml(ff));
            Console.Out.WriteLine(DIV);

            //-----------------------------------------------------------------

            PoliceOfficer po = PoliceOfficerBuilder.New().FirstName("Hans").LastName("Schmitz").Gender(Gender.Male).DateOfBirth((25, 05, 1942));

            Console.Out.WriteLine(ToJson(po));
            Console.Out.WriteLine(DIV);

            //-----------------------------------------------------------------
        }
    }
}
