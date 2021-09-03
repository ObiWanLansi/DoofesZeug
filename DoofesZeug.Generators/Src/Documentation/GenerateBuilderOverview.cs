using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

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

        private static readonly Type ENTITY_BASE = typeof(EntityBase);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void GenerateModelOverviewFile( List<Type> models )
        {
            StringBuilder sb = new(8192);
            sb.AppendLine("# Builder Overview");

            foreach( IGrouping<string, Type> entities in from model in models group model by model.Namespace into ng orderby ng.Key select ng )
            {
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine($"## Namespace `{entities.Key}`");
                sb.AppendLine("");

                sb.AppendLine("|Builder|Source|Entity|");
                sb.AppendLine("|:----- |:----:|:----:|");

                string strPath = entities.Key [11..].Replace('.', '/');

                foreach( Type entity in from type in entities orderby type.Name select type )
                {
                    //string strLinkToMarkdown = $"[{entity.Name}](./{entities.Key}/{entity.Name}.md)";
                    //string strLinkToSource = $"[&#x273F;](../../../DoofesZeug.Library/Src/{strPath}/{entity.Name}.cs)";
                    //string strLinkToDiagram = $"[&#x273F;](./{entities.Key}/{entity.Name}.png)";
                    //string strLinkToJSONTest = $"[&#x273F;](./{entities.Key}/{entity.Name}.json)";

                    //sb.AppendLine($"|{strLinkToMarkdown}|{strLinkToSource}|{strLinkToDiagram}|{strLinkToJSONTest}|");
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

            GenerateModelOverviewFile(models);
        }
    }
}
