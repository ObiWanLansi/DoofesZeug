using System;
using System.IO;
using System.Reflection;
using System.Text;

using DoofesZeug.Extensions;
using DoofesZeug.Models;
using DoofesZeug.Tools;

using static System.Console;



namespace DoofesZeug.Documentation
{
    public static class GenerateModelOverview
    {
        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\Models";

        private static readonly Type ENTITY_BASE = typeof(EntityBase);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void AppendType( Type type, StringBuilder sbPUML )
        {
            if( type.BaseType != typeof(object) )
            {
                AppendType(type.BaseType, sbPUML);
                sbPUML.AppendLine($"{type.BaseType.Name} <|-- {type.Name}");
            }

            sbPUML.AppendLine();
            sbPUML.Append(type.IsAbstract ? "abstract " : "");
            sbPUML.AppendLine($"class {type.Name} {{");

            foreach( PropertyInfo pi in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance) )
            {
                sbPUML.AppendLine($"    {pi.Name}: {pi.PropertyType.Name}");
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
            // sbPUML.AppendLine("skinparam monochrome true");
            sbPUML.AppendLine("hide empty members");

            //---------------------------------------------

            AppendType(type, sbPUML);

            //---------------------------------------------

            sbPUML.AppendLine("@enduml");

            //---------------------------------------------------------------------------------------------------------

            string strOutputFilename = $"{strOutputDirectory}\\{strDiagrammFilenamePuml}";
            File.WriteAllTextAsync(strOutputFilename, sbPUML.ToString(), Encoding.UTF8);
            GeneratorTool.PlantUml(strOutputFilename);
        }


        private static void AddGenerallyInformation( Type type, StringBuilder sb )
        {
            sb.AppendLine();
            sb.AppendLine("|||");
            sb.AppendLine("|-|-|");
            sb.AppendLine($"|Namespace|{type.Namespace}|");
            sb.AppendLine($"|BaseClass|{type.BaseType.Name}|");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateModelMarkdown( Type type )
        {
            if( type.IsAssignableTo(ENTITY_BASE) == false )
            {
                return;
            }

            //---------------------------------------------------------------------------------------------------------

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

            sb.AppendLine($"Generally".Header(2));
            // Namespace, BaseClass, ...
            AddGenerallyInformation(type, sb);
            sb.AppendLine();

            sb.AppendLine($"Fields".Header(2));
            sb.AppendLine();

            sb.AppendLine($"Attributes".Header(2));
            sb.AppendLine();

            sb.AppendLine($"Diagram".Header(2));
            GenerateUmlDiagramm(type, sb);
            sb.AppendLine();

            sb.AppendLine($"Example".Header(2));
            sb.AppendLine();

            //---------------------------------------------------------------------------------------------------------

            File.WriteAllTextAsync($"{strOutputDirectory}\\{type.Name}.md", sb.ToString(), Encoding.UTF8);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void Generate()
        {
            Assembly assembly = ENTITY_BASE.Assembly;

            Out.WriteLineAsync($"{assembly.FullName}");

            new DirectoryInfo(OUTPUTDIRECTORY).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));
            //Directory.CreateDirectory(OUTPUTDIRECTORY);

            foreach( Type type in assembly.ExportedTypes )
            {
                GenerateModelMarkdown(type);
            }
        }
    }
}
