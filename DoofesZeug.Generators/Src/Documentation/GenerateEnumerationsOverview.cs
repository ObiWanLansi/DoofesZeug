using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Extensions;
using DoofesZeug.Models;
using DoofesZeug.Tools;

using static System.Console;



namespace DoofesZeug.Documentation
{
    public static class GenerateEnumerationsOverview
    {
        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\Enumerations";

        private static readonly Type ENTITY_BASE = typeof(Entity);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void AppendEnum( Type type, StringBuilder sbPUML )
        {
            sbPUML.AppendLine();
            sbPUML.AppendLine($"enum {type.Name} {{");

            foreach( object value in Enum.GetValues(type) )
            {
                sbPUML.AppendLine($"    {value}");
            }

            sbPUML.AppendLine("}");
            sbPUML.AppendLine();
        }


        private static void GenerateUmlDiagramm( Type type, StringBuilder sb )
        {
            string strOutputDirectory = $"{OUTPUTDIRECTORY}\\{type.Namespace}";
            string strDiagrammFilenamePng = $"{type.Name}.png";
            string strDiagrammFilenamePuml = $"{type.Name}.puml";

            //---------------------------------------------------------------------------------------------------------

            sb.AppendLine();
            sb.AppendLine($"![{strDiagrammFilenamePng}](./{strDiagrammFilenamePng} \"{type.Name}\")");

            //---------------------------------------------------------------------------------------------------------

            StringBuilder sbPUML = new(8192);

            sbPUML.AppendLine("@startuml");
            sbPUML.AppendLine("skinparam monochrome true");
            sbPUML.AppendLine("hide empty members");

            //---------------------------------------------

            AppendEnum(type, sbPUML);

            //---------------------------------------------

            sbPUML.AppendLine("@enduml");

            //---------------------------------------------------------------------------------------------------------

            string strOutputFilename = $"{strOutputDirectory}\\{strDiagrammFilenamePuml}";
            File.WriteAllTextAsync(strOutputFilename, sbPUML.ToString(), Encoding.UTF8);
            GeneratorTool.PlantUml(strOutputFilename);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateEnumerationFile( Type type )
        {
            string strOutputDirectory = $"{OUTPUTDIRECTORY}\\{type.Namespace}";

            if( Directory.Exists(strOutputDirectory) == false )
            {
                Directory.CreateDirectory(strOutputDirectory);
            }

            //---------------------------------------------------------------------------------------------------------

            Out.WriteLineAsync($"Create markdown for: {type.FullName}");

            StringBuilder sb = new(8192);

            sb.AppendLine($"{type.Name}".Header(1));
            sb.AppendLine();

            sb.AppendLine($"Diagram".Header(2));
            GenerateUmlDiagramm(type, sb);

            //---------------------------------------------------------------------------------------------------------

            File.WriteAllTextAsync($"{strOutputDirectory}\\{type.Name}.md", sb.ToString(), Encoding.UTF8);
        }


        private static void GenerateEnumerationOverviewFile( List<Type> enumerations )
        {
            StringBuilder sb = new(8192);
            sb.AppendLine("# Enumerations Overview");

            foreach( IGrouping<string, Type> enumerationgroup in from enumeration in enumerations group enumeration by enumeration.Namespace into ng orderby ng.Key select ng )
            {
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine($"## `{enumerationgroup.Key}`");
                sb.AppendLine("");

                sb.AppendLine("|Enumeration|Description|Values|");
                sb.AppendLine("|:----------|:----------|:-----|");

                string strPath = enumerationgroup.Key [11..].Replace('.', '/');

                foreach( Type enumeration in from type in enumerationgroup orderby type.Name select type )
                {
                    DescriptionAttribute da = (DescriptionAttribute) enumeration.GetCustomAttribute(typeof(DescriptionAttribute));

                    if( da == null )
                    {
                        throw new Exception($"{enumeration.FullName} have no description!");
                    }

                    da.Validate(enumeration);

                    string strLinkToMarkdown = $"[{enumeration.Name}](./{enumerationgroup.Key}/{enumeration.Name}.md)";

                    sb.AppendLine($"|{strLinkToMarkdown}|{da.Description}|{Enum.GetNames(enumeration).ToFlatString()}|");
                }
            }

            File.WriteAllTextAsync($"{OUTPUTDIRECTORY}\\README.md", sb.ToString(), Encoding.UTF8);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void Generate()
        {
            Assembly assembly = ENTITY_BASE.Assembly;

            Out.WriteLineAsync();
            Out.WriteLineAsync($"{assembly.FullName}");

            new DirectoryInfo(OUTPUTDIRECTORY).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));

            //---------------------------------------------------------------------------------------------------------

            List<Type> enumerations = new();

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.IsEnum == false )
                {
                    continue;
                }
                enumerations.Add(type);
            }

            //---------------------------------------------------------------------------------------------------------

            enumerations.ForEach(enumeration => GenerateEnumerationFile(enumeration));

            GenerateEnumerationOverviewFile(enumerations);
        }
    }
}
