using System;
using System.IO;
using System.Text;

using DoofesZeug.Extensions;
using DoofesZeug.Models.Human.Professions;

using static System.Console;



namespace DoofesZeug.SourceCode
{
    public static class ProfessionsBuilder
    {
        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\DoofesZeug.Library\Src\Generated\Professions";

        private static readonly string HEADER = @"
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        ";

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private static void GenerateProfessionModel( string profession )
        {
            //---------------------------------------------------------------------------------------------------------

            Out.WriteLineAsync($"Create model for: {profession}");

            StringBuilder sb = new(8192);

            sb.AppendLine(HEADER);
            sb.AppendLine("using DoofesZeug.Attributes;");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine("namespace DoofesZeug.Models.Human.Professions");
            sb.AppendLine("{");

            sb.AppendLine("    [Generated]");
            sb.AppendLine($"    public class {profession} : Profession");
            sb.AppendLine("    {");

            sb.AppendLine($"        public {profession}() : base(WellKnownProfession.{profession})");
            sb.AppendLine("        {");
            sb.AppendLine("        }");

            sb.AppendLine("    }");
            sb.AppendLine("}");

            //---------------------------------------------------------------------------------------------------------

            string strOutputFilename = $"{OUTPUTDIRECTORY}\\{profession}.cs";
            File.WriteAllTextAsync(strOutputFilename, sb.ToString(), Encoding.UTF8);

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void Generate()
        {
            new DirectoryInfo(OUTPUTDIRECTORY).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));
            Directory.CreateDirectory(OUTPUTDIRECTORY);

            foreach( string profession in Enum.GetNames(typeof(WellKnownProfession)) )
            {
                GenerateProfessionModel(profession);
            }
        }
    }
}
