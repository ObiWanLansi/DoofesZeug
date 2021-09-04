
using System;

using DoofesZeug.Extensions;
using DoofesZeug.Models.DateAndTime;
using DoofesZeug.Models.Human;
using DoofesZeug.Models.Human.Professions;

using static System.Console;



namespace DoofesZeug
{
    static class TestConsole
    {
        static private readonly string DIV = new('-', 80);

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


            Date d = "20.02.2020";
            Out.WriteLineAsync($"{d}");

            Time t = "15:10:42";
            Out.WriteLineAsync($"{t}");

            Person pOriginal = PersonBuilder.New().
                WithFirstName("John").
                WithLastName("Doe").
                WithGender(Gender.Male).
                WithHandedness(Handedness.Both).
                WithDateOfBirth((25, 05, 1942)).
                WithProfession(new PoliceOfficer { Since = (25, 05, 1942) });

            Out.WriteLine(pOriginal.ToStringTable(bDisplayNULL: true));
            Out.WriteLine(DIV);

            try
            {
                string strJSON = pOriginal.ToPrettyJson();
                Out.WriteLine(strJSON);
                Out.WriteLine(DIV);

                Person pClone = strJSON.FromJson<Person>();
                Out.WriteLine(pClone.ToStringTable(bDisplayNULL: true));
                Out.WriteLine(DIV);
            }
            catch( Exception ex )
            {
                Error.WriteLineAsync(ex.Message);
            }
        }
    }
}
