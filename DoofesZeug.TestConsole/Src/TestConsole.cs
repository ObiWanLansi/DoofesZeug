using System;
using System.Collections.Generic;

using DoofesZeug.Datasets;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Examples.Extensions;
using DoofesZeug.Extensions;
using DoofesZeug.Models.Human;

using static System.Console;



namespace DoofesZeug
{
    static class TestConsole
    {
        //static private readonly string DIV = new('-', 80);

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


        //private static string ToYaml( object o )
        //{
        //    //return new SerializerBuilder().WithEventEmitter(nextEmitter => new QuoteSurroundingEventEmitter(nextEmitter)).Build().Serialize(o);
        //    return new SerializerBuilder().Build().Serialize(o);
        //}

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            if( e.ExceptionObject is Exception ex )
            {
                Error.WriteLineAsync(ex.Message);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        static void Main( string [] args )
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //-------------------------------------------------------------------------------------

            //MathExtensionExample.GetFibonacciList();

            //-------------------------------------------------------------------------------------

            List<Person> persons = Dataset.GetPersons(20);

            int counter = 1;
            foreach( Person person in persons )
            {
                Out.WriteLineAsync($"{counter++}: {person} ({person.Gender}, {person.Handedness})");
            }

            //-------------------------------------------------------------------------------------

            //ColorBrewerExample.LoadColorBrowerAndGetOnePaleteWith5Colors();

            //string strColorBrewerJson = ApplicationResource.ReadResourceAsString("DoofesZeug.Resources.colorbrewer.json");

            //ColorBrewerCatalog cbc = ColorBrewerCatalog.Instance;

            //cbc.ForEach(( colorscheme, colorbrewer ) =>
            //{
            //    Out.WriteLineAsync($"Color scheme: {colorscheme}");
            //    foreach( string item in colorbrewer.The8 )
            //    {
            //        Out.WriteLineAsync($"    {item.ToColor()}");
            //    }
            //});

            //foreach(string colorscheme in cb.Keys)
            //{
            //    Out.WriteLine($"{colorscheme},");
            //}

            //-------------------------------------------------------------------------------------

            //Animal cat = new()
            //{
            //    AnimalSpecies = AnimalSpecies.Cat,
            //    Name = "Garfield",
            //    Gender = Gender.Male,
            //    DateOfBirth = (10, 06, 1978)
            //};

            //Out.WriteLineAsync(cat.ToPrettyJson());

            //-------------------------------------------------------------------------------------

            //LoremIpsumExample.CreateLoremIpsum();

            //JsonExtensionExample.ConvertPlainJsonStringToReadableJsonString();
            //JsonExtensionExample.ConvertEntityToPlainJson();
            //JsonExtensionExample.ConvertEntityToPrettyJson();
            //JsonExtensionExample.ConvertJsonToEntity();

            //-------------------------------------------------------------------------------------

            //FireFighter ff1 = new FireFighter { Since = (15, 10, 1942) };
            //FireFighter ff2 = new FireFighter { Since = (16, 11, 1943) };
            //FireFighter ff3 = new FireFighter { Since = (15, 10, 1942) };
            //PoliceOfficer po1 = new PoliceOfficer { Since = (15, 10, 1942) };

            //Out.WriteLineAsync($"{ff1}|{ff1}:{ff1.Equals(ff1)}");
            //Out.WriteLineAsync($"{ff1}|{ff2}:{ff1.Equals(ff2)}");
            //Out.WriteLineAsync($"{ff1}|{ff3}:{ff1.Equals(ff3)}");
            //Out.WriteLineAsync($"{ff3}|{po1}:{ff3.Equals(po1)}");

            //-------------------------------------------------------------------------------------

            //Date d = "15.10.1974";
            //DateOfBirth dob = "15.10.1974";
            //DateOfBirth dob = new("15.10.1974");
            //Out.WriteLineAsync(dob.ToString());
            //string json = dob.ToPrettyJson();
            //Out.WriteLineAsync(json);
            //DateOfBirth clone = json.FromJson<DateOfBirth>();
            //Out.WriteLineAsync(clone.ToString());

            //return;

            //DateOfBirth dob = (15, 10, 1942);
            //string json = dob.ToPrettyJson();
            //DateOfBirth clone = json.FromJson<DateOfBirth>();

            //Out.WriteLineAsync(dob.ToPrettyJson());

            //-------------------------------------------------------------------------------------

            //Hour org = 8;

            //string json = org.ToPrettyJson();
            //Out.WriteLineAsync(json);

            //Hour clone = json.FromJson<Hour>();
            //Out.WriteLineAsync(clone.ToString());

            //-------------------------------------------------------------------------------------

            //Date d = "20.02.2020";
            //Out.WriteLineAsync($"{d}");

            //Time t = "15:10:42";
            //Out.WriteLineAsync($"{t}");

            //-------------------------------------------------------------------------------------


            //Out.WriteLineAsync(DIV);

            //try
            //{
            //    string strJSON = pOriginal.ToJson();
            //    Out.WriteLineAsync(strJSON);
            //    Out.WriteLineAsync(DIV);

            //    Person pClone = strJSON.FromJson<Person>();
            //    Out.WriteLineAsync(pClone.ToStringTable(bDisplayNULL: true));
            //    Out.WriteLineAsync(DIV);

            //    Out.WriteLineAsync(strJSON.ToReadableJson());
            //}
            //catch( Exception ex )
            //{
            //    Error.WriteLineAsync(ex.Message);
            //}
        }
    }
}
