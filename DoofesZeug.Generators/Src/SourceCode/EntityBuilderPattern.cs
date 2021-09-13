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
    public static class EntityBuilderPattern
    {
        private static readonly Type BUILDERATTRIBUTE = typeof(BuilderAttribute);

        private static readonly string OUTPUTDIRECTORYBUILDER = @"O:\DoofesZeug\DoofesZeug.Library\Src\Generated\Builder";
        private static readonly string OUTPUTDIRECTORYUNITTEST = @"O:\DoofesZeug\DoofesZeug.UnitTests\Src\Functional\Builder";

        private static readonly string HEADER = @"
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        ";


        private static readonly string UNITTEST_TEMPLATE = @"

using Microsoft.VisualStudio.TestTools.UnitTesting;

using $NAMESPACE$;



namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class Test$BUILDER$Builder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Assert.Fail(""Not Yet Implemented!"");
$EXECCODE$
        }
    }
}
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
            Out.WriteLineAsync($"Create ModelBuilder for: {type.FullName}");

            StringBuilder sb = new(8192);

            sb.AppendLine(HEADER);
            sb.AppendLine("using DoofesZeug.Attributes;");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine($"namespace {type.Namespace}");
            sb.AppendLine("{");

            sb.AppendLine("    [Generated]");
            sb.AppendLine($"    public static class {type.Name}Builder");
            sb.AppendLine("    {");

            sb.AppendLine($"        public static {type.Name} New() => new();");


            //foreach( FieldInfo field in type.GetFields(BindingFlags.SetField | BindingFlags.Instance | BindingFlags.NonPublic) )
            foreach( PropertyInfo property in type.GetProperties() )
            {
                if( property.Name == nameof(IdentifiableEntity.Id) )
                {
                    continue;
                }

                if( property.CanWrite == false )
                {
                    continue;
                }
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

            string strOutputFilename = $"{OUTPUTDIRECTORYBUILDER}\\{type.Name}Builder.cs";
            File.WriteAllTextAsync(strOutputFilename, sb.ToString(), Encoding.UTF8);
        }


        private static void GenerateBuilderTestTemplate( Type type )
        {
            string strOutputFilename = $"{OUTPUTDIRECTORYUNITTEST}\\Test{type.Name}Builder.cs";

            if( File.Exists(strOutputFilename) )
            {
                Out.WriteLineAsync($"Skip UnitTest for: {type.FullName}");
                return;
            }

            //---------------------------------------------------------------------------------------------------------

            Out.WriteLineAsync($"Create UnitTest for: {type.FullName}");

            StringBuilder sb = new(4096);

            sb.AppendLine(HEADER);

            //---------------------------------------------------------------------------------------------------------

            string strClassNameModel = type.Name;
            string strInstanceName = type.Name.Lower();
            string strClassNameBuilder = $"{type.Name}Builder";

            StringBuilder sbMethods = new(2048);

            foreach( PropertyInfo property in type.GetProperties() )
            {
                if( property.Name == nameof(IdentifiableEntity.Id) )
                {
                    continue;
                }

                if( property.CanWrite == false )
                {
                    continue;
                }

                sbMethods.Append($".With{property.Name}(null)");
            }

            //---------------------------------------------------------------------------------------------------------

            StringBuilder sbCode = new(2048);

            sbCode.AppendLine($"            {strClassNameModel} {strInstanceName} = {strClassNameBuilder}.New(){sbMethods};");
            sbCode.AppendLine($"            Assert.IsNotNull({strInstanceName});");

            sb.AppendLine(UNITTEST_TEMPLATE.Replace("$NAMESPACE$", type.Namespace).Replace("$BUILDER$", type.Name).Replace("$EXECCODE$", sbCode.ToString()));

            //---------------------------------------------------------------------------------------------------------

            File.WriteAllTextAsync(strOutputFilename, sb.ToString(), Encoding.UTF8);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void Generate()
        {
            Type tEntityBase = typeof(Entity);

            Assembly assembly = tEntityBase.Assembly;

            Out.WriteLineAsync();
            Out.WriteLineAsync($"{assembly.FullName}");

            new DirectoryInfo(OUTPUTDIRECTORYBUILDER).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));
            Directory.CreateDirectory(OUTPUTDIRECTORYBUILDER);

            //new DirectoryInfo(OUTPUTDIRECTORYUNITTEST).DeleteDirectoryContentRecursiv(ex => Error.WriteLineAsync(ex.Message));
            //Directory.CreateDirectory(OUTPUTDIRECTORYUNITTEST);

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.GetCustomAttribute(BUILDERATTRIBUTE) == null )
                {
                    continue;
                }

                GenerateModelBuilder(type);
                GenerateBuilderTestTemplate(type);
            }
        }
    }
}
