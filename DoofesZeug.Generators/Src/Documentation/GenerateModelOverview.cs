using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using DoofesZeug.Extensions;
using DoofesZeug.Models;
using DoofesZeug.TestData;
using DoofesZeug.Tools;

using static System.Console;



namespace DoofesZeug.Documentation
{
    public static class GenerateModelOverview
    {
        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\Models";

        private static readonly Type ENTITY_BASE = typeof(EntityBase);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateJsonExample( Type type, StringBuilder sb )
        {
            sb.AppendLine();

            //if( type.IsAbstract )
            //{
            //    sb.AppendLine($"*The Entity {type.Name} is abstract, so we can't not create an json example!*");
            //    return;
            //}

            //bool bDefaultConstructor = false;
            //foreach( ConstructorInfo constructor in type.GetConstructors() )
            //{
            //    if( constructor.GetParameters().Length == 0 )
            //    {
            //        bDefaultConstructor = true;
            //        break;
            //    }
            //}

            //if( bDefaultConstructor == false )
            //{
            //    sb.AppendLine($"*The Entity {type.Name} have no default constructor, so we can't not create an json example!*");
            //    return;
            //}

            object oResult = TestDataGenerator.GenerateTestData(type);

            if( oResult != null )
            {
                sb.AppendLine("```json");
                sb.AppendLine(oResult.ToPrettyJson());
                sb.AppendLine("```");
            }
        }

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
            sbPUML.AppendLine("skinparam monochrome true");
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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void AddFields( Type type, StringBuilder sb, bool bInherited )
        {
            sb.AppendLine();
            sb.AppendLine($"### {( bInherited ? "Inherited" : "Declared" )}");
            sb.AppendLine();
            sb.AppendLine("|Name|Type|Read|Write|DefaultValue|");
            sb.AppendLine("|:---|:---|:--:|:---:|:-----------|");

            //var properties = bInherited ? type.GetProperties( BindingFlags.Public | BindingFlags.Instance) : type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            foreach( PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance) )
            {
                if( bInherited == true && pi.DeclaringType == type )
                {
                    continue;
                }

                if( bInherited == false && pi.DeclaringType != type )
                {
                    continue;
                }

                //sbPUML.AppendLine($"    {pi.Name}: {pi.PropertyType.Name}");
                sb.AppendLine($"|{pi.Name}|{pi.PropertyType.Name}|{( pi.CanRead ? "&#x2713;" : "&#x2717;" )}|{( pi.CanWrite ? "&#x2713;" : "&#x2717;" )}||");
            }
        }

        private static void AddGenerallyInformation( Type type, StringBuilder sb )
        {
            sb.AppendLine();
            sb.AppendLine("|||");
            sb.AppendLine("|:-|:-|");
            sb.AppendLine($"|Namespace|{type.Namespace}|");
            sb.AppendLine($"|BaseClass|{type.BaseType.Name}|");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateModelFile( Type type )
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

            //if( type.IsEnum == false )
            {
                sb.AppendLine($"Generally".Header(2));
                // Namespace, BaseClass, ...
                AddGenerallyInformation(type, sb);
                sb.AppendLine();

                sb.AppendLine($"Fields".Header(2));
                AddFields(type, sb, false);
                AddFields(type, sb, true);
                sb.AppendLine();

                sb.AppendLine($"Attributes".Header(2));
                sb.AppendLine();

                sb.AppendLine($"Diagram".Header(2));
                //#if RELEASE
                GenerateUmlDiagramm(type, sb);
                //#endif
                sb.AppendLine();

                sb.AppendLine($"Example".Header(2));
                GenerateJsonExample(type, sb);
                sb.AppendLine();
            }

            //---------------------------------------------------------------------------------------------------------

            File.WriteAllTextAsync($"{strOutputDirectory}\\{type.Name}.md", sb.ToString(), Encoding.UTF8);
        }


        private static void GenerateModelOverviewFile( List<Type> models )
        {
            StringBuilder sb = new(8192);
            sb.AppendLine("# Entities Overview");

            foreach( IGrouping<string, Type> entities in from model in models group model by model.Namespace into ng orderby ng.Key select ng )
            {
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine($"## Namespace `{entities.Key}`");
                sb.AppendLine("");

                sb.AppendLine("|Entity|Source|Diagram|JSON Example|");
                sb.AppendLine("|:-----|:----:|:-----:|:----------:|");

                string strPath = entities.Key [11..].Replace('.', '/');

                foreach( Type entity in from type in entities orderby type.Name select type )
                {
                    string strLinkToMarkdown = $"[{entity.Name}](./{entities.Key}/{entity.Name}.md)";
                    string strLinkToSource = $"[&#x273F;](../../../DoofesZeug.Library/Src/{strPath}/{entity.Name}.cs)";
                    string strLinkToDiagram = $"[&#x273F;](./{entities.Key}/{entity.Name}.png)";
                    string strLinkToJSONTest = $"[&#x273F;](./{entities.Key}/{entity.Name}.json)";

                    sb.AppendLine($"|{strLinkToMarkdown}|{strLinkToSource}|{strLinkToDiagram}|{strLinkToJSONTest}|");
                }
            }

            File.WriteAllTextAsync($"{OUTPUTDIRECTORY}\\README.md", sb.ToString(), Encoding.UTF8);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void Generate()
        {
            Assembly assembly = ENTITY_BASE.Assembly;

            Out.WriteLineAsync($"{assembly.FullName}");

            new DirectoryInfo(OUTPUTDIRECTORY).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));

            //---------------------------------------------------------------------------------------------------------

            List<Type> models = new();

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.IsAssignableTo(ENTITY_BASE) == false )
                {
                    continue;
                }
                models.Add(type);
            }

            //---------------------------------------------------------------------------------------------------------

            models.ForEach(model => GenerateModelFile(model));

            GenerateModelOverviewFile(models);
        }
    }
}
