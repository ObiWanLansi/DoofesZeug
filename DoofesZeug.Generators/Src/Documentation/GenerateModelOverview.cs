﻿using System;
using System.IO;
using System.Reflection;
using System.Text;

using DoofesZeug.Extensions;
using DoofesZeug.Models;

using static System.Console;



namespace DoofesZeug.Documentation
{
    public static class GenerateModelOverview
    {
        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\Models";

        private static readonly Type ENTITY_BASE = typeof(EntityBase);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
            sb.AppendLine();

            sb.AppendLine($"Example".Header(2));
            sb.AppendLine();

            //---------------------------------------------------------------------------------------------------------

            string strOutputDirectory = $"{OUTPUTDIRECTORY}\\{type.Namespace}";
            if( Directory.Exists(strOutputDirectory) == false )
            {
                Directory.CreateDirectory(strOutputDirectory);
            }

            string strOutputFilename = $"{strOutputDirectory}\\{type.Name}.md";
            File.WriteAllTextAsync(strOutputFilename, sb.ToString());
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
