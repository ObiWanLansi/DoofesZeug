using System;
using System.IO;
using System.Reflection;
using System.Text;

using DoofesZeug.Attributes;
using DoofesZeug.Extensions;
using DoofesZeug.Models;

using static System.Console;



namespace DoofesZeug.SourceCode
{
    public static class ModelBuilderPattern
    {
        private static readonly Type BUILDERATTRIBUTE = typeof(BuilderAttribute);

        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\DoofesZeug.Library\Src\Generated";

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateModelBuilder( Type type )
        {
            BuilderAttribute ba = (BuilderAttribute) type.GetCustomAttribute(BUILDERATTRIBUTE);

            if( ba == null )
            {
                return;
            }

            Out.WriteLineAsync($"Create builder for: {type.FullName}");

            //---------------------------------------------------------------------------------------------------------

            StringBuilder sb = new(8192);

            sb.AppendLine($"namespace {type.Namespace}");
            sb.AppendLine("{");

            sb.AppendLine($"    public sealed class {type.Name}Builder");
            sb.AppendLine("    {");

            //foreach( FieldInfo field in type.GetFields(BindingFlags.SetField | BindingFlags.Instance | BindingFlags.NonPublic) )
            foreach( PropertyInfo property in type.GetProperties() )
            {
                Out.WriteLineAsync($"    Use property: {property.Name}");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            //---------------------------------------------------------------------------------------------------------

            string strOutputFilename = $"{OUTPUTDIRECTORY}\\{type.Name}.Builder.cs";
            File.WriteAllTextAsync(strOutputFilename, sb.ToString());
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void Generate()
        {
            Type tEntityBase = typeof(EntityBase);

            Assembly assembly = tEntityBase.Assembly;

            Out.WriteLineAsync($"{assembly.FullName}");

            new DirectoryInfo(OUTPUTDIRECTORY).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));
            Directory.CreateDirectory(OUTPUTDIRECTORY);

            foreach( Type type in assembly.ExportedTypes )
            {
                GenerateModelBuilder(type);
            }
        }
    }
}
