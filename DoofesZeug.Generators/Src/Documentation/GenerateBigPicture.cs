using System;
using System.IO;
using System.Reflection;
using System.Text;

using DoofesZeug.Entities;
using DoofesZeug.Extensions;
using DoofesZeug.Tools;

using static System.Console;



namespace DoofesZeug.Documentation
{
    public static class GenerateBigPicture
    {
        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\BigPicture";

        private static readonly Type ENTITY_BASE = typeof(Entity);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void Generate()
        {
            Assembly assembly = ENTITY_BASE.Assembly;

            Out.WriteLineAsync();
            Out.WriteLineAsync($"{assembly.FullName}");

            new DirectoryInfo(OUTPUTDIRECTORY).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));

            //---------------------------------------------------------------------------------------------------------

            StringBuilder sbPUML = new(8192);

            sbPUML.AppendLine("@startuml");
            sbPUML.AppendLine("skinparam monochrome true");
            sbPUML.AppendLine("hide empty members");

            // THe problem is that some classes have more subclasses, that means that they are more than once listet in big picture.
            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.IsInterface )
                {
                    continue;
                }

                if( type.IsEnum )
                {
                    continue;
                }

                GenerateEntityOverview.AppendType(type, sbPUML);
            }

            sbPUML.AppendLine("@enduml");

            //---------------------------------------------------------------------------------------------------------

            if( Directory.Exists(OUTPUTDIRECTORY) == false )
            {
                Directory.CreateDirectory(OUTPUTDIRECTORY);
            }

            string strOutputFilename = $"{OUTPUTDIRECTORY}\\DoofesZeug.puml";
            File.WriteAllTextAsync(strOutputFilename, sbPUML.ToString(), Encoding.UTF8);
            GeneratorTool.PlantUml(strOutputFilename);
        }
    }
}
