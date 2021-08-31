using System;
using System.IO;
using System.Reflection;
using System.Text;

using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Extensions;
using DoofesZeug.Models;

using static System.Console;



namespace DoofesZeug.SourceCode
{
    public static class ModelBuilderPattern
    {
        private static readonly Type BUILDERATTRIBUTE = typeof(BuilderAttribute);

        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\DoofesZeug.Library\Src\Generated";

        private static readonly string HEADER = @"
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        ";

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static string GetPropertyTypeString( PropertyInfo pi )
        {
            string strPropertyType = pi.PropertyType.Name;

            if( pi.PropertyType.IsGenericType )
            {
                int index = strPropertyType.IndexOf('`');
                if( index > 0 )
                {
                    strPropertyType = strPropertyType.Substring(0, index);
                }

                int counter = 0;
                strPropertyType += "<";
                foreach( Type genty in pi.PropertyType.GenericTypeArguments )
                {
                    if( counter++ > 0 )
                    {
                        strPropertyType += ", ";
                    }
                    strPropertyType += genty.FullName;
                }
                strPropertyType += ">";
            }

            return $"{pi.PropertyType.Namespace}.{strPropertyType}";
        }


        private static void GenerateModelBuilder( Type type )
        {
            BuilderAttribute ba = (BuilderAttribute) type.GetCustomAttribute(BUILDERATTRIBUTE);

            if( ba == null )
            {
                return;
            }

            //---------------------------------------------------------------------------------------------------------

            Out.WriteLineAsync($"Create builder for: {type.FullName}");

            StringBuilder sb = new(8192);

            sb.AppendLine(HEADER);
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine($"namespace {type.Namespace}");
            sb.AppendLine("{");

            sb.AppendLine($"    public static class {type.Name}Builder");
            sb.AppendLine("    {");

            sb.AppendLine($"        public static {type.Name} New() => new();");


            //foreach( FieldInfo field in type.GetFields(BindingFlags.SetField | BindingFlags.Instance | BindingFlags.NonPublic) )
            foreach( PropertyInfo property in type.GetProperties() )
            {
                //Out.WriteLineAsync($"    Use property: {property.Name}");

                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine($"        public static {type.Name} With{property.Name}(this {type.Name} {type.Name.ToLower()}, {GetPropertyTypeString(property)} {property.Name.ToLower()})");
                sb.AppendLine("        {");
                //sb.AppendLine("            return null;");
                sb.AppendLine($"            {type.Name.ToLower()}.{property.Name} = {property.Name.ToLower()};");
                sb.AppendLine($"            return {type.Name.ToLower()};");

                sb.AppendLine("        }");
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");

            //---------------------------------------------------------------------------------------------------------

            string strOutputFilename = $"{OUTPUTDIRECTORY}\\{type.Name}.Builder.cs";
            File.WriteAllTextAsync(strOutputFilename, sb.ToString(), Encoding.UTF8);
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
