﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Container;
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

        private static void AddAttributes( Type type, StringBuilder sb )
        {
            sb.AppendLine();

            //sb.AppendLine("|Name|Value|");
            //sb.AppendLine("|:---|");
            foreach( object attribute in type.GetCustomAttributes(false) )
            {
                string strName = attribute.GetType().Name;
                if( strName.EndsWith("Attribute") )
                {
                    strName = strName.Substring(0, strName.Length - 9);
                }
                sb.AppendLine($"- {strName}");
            }
        }


        private static void AddFields( Type type, StringBuilder sb, bool bInherited )
        {
            sb.AppendLine();
            sb.AppendLine($"### {( bInherited ? "Inherited" : "Declared" )}");
            sb.AppendLine();
            sb.AppendLine("|Name|Type|Read|Write|DefaultValue|");
            sb.AppendLine("|:---|:---|:--:|:---:|:-----------|");

            object instance = Activator.CreateInstance(type);

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

                string strPropertyType = pi.PropertyType.Name;
                if( pi.PropertyType.Namespace.StartsWith("DoofesZeug.") )
                {
                    string strPath = $"../../{( pi.PropertyType.IsEnum ? "Enumerations" : "Models" )}/{pi.PropertyType.Namespace}";

                    strPropertyType = $"[{pi.PropertyType.Name}]({strPath}/{pi.PropertyType.Name}.md)";
                }

                object value = pi.GetValue(instance);
                sb.AppendLine($"|{pi.Name}|{strPropertyType}|{( pi.CanRead ? "&#x2713;" : "&#x2717;" )}|{( pi.CanWrite ? "&#x2713;" : "&#x2717;" )}|{( value != null ? value : "NULL" )}|");
            }
        }


        private static void AddGenerallyInformation( Type type, StringBuilder sb )
        {
            DescriptionAttribute da = (DescriptionAttribute) type.GetCustomAttribute(typeof(DescriptionAttribute));

            if( da == null )
            {
                throw new Exception($"{type.FullName} have no valid description!");
            }

            da.Validate(type);

            sb.AppendLine();
            sb.AppendLine("|||");
            sb.AppendLine("|:-|:-|");
            sb.AppendLine($"|Description|{da.Description}|");
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
                AddGenerallyInformation(type, sb);
                sb.AppendLine();

                sb.AppendLine($"Properties".Header(2));
                AddFields(type, sb, false);
                AddFields(type, sb, true);
                sb.AppendLine();

                sb.AppendLine($"Attributes".Header(2));
                AddAttributes(type, sb);
                sb.AppendLine();

                sb.AppendLine($"UML Diagram".Header(2));
                GenerateUmlDiagramm(type, sb);
                sb.AppendLine();

                sb.AppendLine($"JSON Example".Header(2));
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
                sb.AppendLine($"## `{entities.Key}`");
                sb.AppendLine("");

                sb.AppendLine("|Entity|Description|Properties|");
                sb.AppendLine("|:-----|:----------|:---------|");

                //string strPath = entities.Key [11..].Replace('.', '/');

                foreach( Type entity in from type in entities orderby type.Name select type )
                {
                    DescriptionAttribute da = (DescriptionAttribute) entity.GetCustomAttribute(typeof(DescriptionAttribute));

                    if( da == null )
                    {
                        throw new Exception($"{entity.FullName} have no valid description!");
                    }

                    da.Validate(entity);

                    string strLinkToMarkdown = $"[{entity.Name}](./{entities.Key}/{entity.Name}.md)";

                    StringList properties = new(from property in entity.GetProperties(BindingFlags.Public | BindingFlags.Instance) where property.CanWrite == true select property.Name);

                    sb.AppendLine($"|{strLinkToMarkdown}|{da.Description}|{properties.ToFlatString()}|");
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

            List<Type> models = new();

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.IsAssignableTo(ENTITY_BASE) == false )
                {
                    Out.WriteLine($"Skip EntityBase: {type.FullName}");
                    continue;
                }

                if( type.IsAbstract == true )
                {
                    Out.WriteLine($"Skip Abstract: {type.FullName}");
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
