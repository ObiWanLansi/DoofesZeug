using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Extensions;
using DoofesZeug.Models;

using static System.Console;



namespace DoofesZeug.Documentation
{
    public static class GenerateBuilderOverview
    {
        private static readonly Type BUILDERATTRIBUTE = typeof(BuilderAttribute);

        private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\Builder";

        private static readonly Type ENTITY_BASE = typeof(Entity);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateBuilderOverviewFile( List<Type> models )
        {
            StringBuilder sb = new(8192);
            sb.AppendLine("# Builder Overview");

            foreach( IGrouping<string, Type> entities in from model in models group model by model.Namespace into ng orderby ng.Key select ng )
            {
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine($"## `{entities.Key}`");
                sb.AppendLine("");

                sb.AppendLine("|Entity|Builder|");
                sb.AppendLine("|:-----|:------|");

                foreach( Type entity in from type in entities orderby type.Name select type )
                {
                    DescriptionAttribute da = (DescriptionAttribute) entity.GetCustomAttribute(typeof(DescriptionAttribute));

                    if( da == null )
                    {
                        throw new Exception($"{entity.FullName} have no valid description!");
                    }

                    da.Validate(entity);

                    string strLinkToMarkdown = $"[{entity.Name}](../Models/{entities.Key}/{entity.Name}.md)";

                    sb.AppendLine($"|{strLinkToMarkdown}|{entity.Name}Builder|");
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
                if( type.GetCustomAttribute(BUILDERATTRIBUTE) == null )
                {
                    continue;
                }

                models.Add(type);
            }

            //---------------------------------------------------------------------------------------------------------

            GenerateBuilderOverviewFile(models);
        }
    }
}
