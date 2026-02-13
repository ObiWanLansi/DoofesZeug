using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Entities;
using DoofesZeug.Extensions;
using DoofesZeug.Extensions.Formats;
using DoofesZeug.TestData;
using DoofesZeug.Tools;

using static System.Console;



namespace DoofesZeug.Documentation;

public static class GenerateEntityOverview
{
    private static readonly string OUTPUTDIRECTORY = @"O:\DoofesZeug\Documentation\Generated\Entities";

    private static readonly string EXAMPLEDIRECTORY = @"O:\DoofesZeug\DoofesZeug.Generators\Src\Examples";

    private static readonly Type ENTITY_BASE = typeof(Entity);

    private static readonly SortedDictionary<string, string> EXAMPLES = [];

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    static GenerateEntityOverview()
    {
        foreach( FileInfo fi in new DirectoryInfo(EXAMPLEDIRECTORY).GetFiles("*.cs", SearchOption.AllDirectories) )
        {
            if( fi.Name.EndsWith("Example.cs") )
            {
                string type = fi.Name.Substring(0, fi.Name.Length - "Example.cs".Length);
                EXAMPLES.Add(type, fi.FullName);
            }
        }
    }


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private static void GenerateCodeExample( Type type, StringBuilder sb )
    {
        sb.AppendLine();

        sb.AppendLine("```cs");

        if( EXAMPLES.ContainsKey(type.Name) )
        {
            sb.Append(File.ReadAllText(EXAMPLES [type.Name]));
        }
        else
        {
            sb.AppendLine("An example or code snippet follows soon.");
        }

        sb.AppendLine("```");
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    public static void AppendType( Type type, StringBuilder sbPUML )
    {
        if( type.BaseType != null && type.BaseType != typeof(object) )
        {
            AppendType(type.BaseType, sbPUML);
            sbPUML.AppendLine($"{TypeExtension.GetTypeName(type.BaseType, false)} <|-- {TypeExtension.GetTypeName(type, false)}");
            //sbPUML.AppendLine($"{type.BaseType.Name} <|-- {type.Name}");
        }

        sbPUML.AppendLine();
        sbPUML.Append(type.IsAbstract ? "abstract " : "");
        sbPUML.AppendLine($"class {TypeExtension.GetTypeName(type, false)} {{");

        foreach( PropertyInfo pi in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance) )
        {
            sbPUML.AppendLine($"    {pi.Name}: {TypeExtension.GetTypeName(pi.PropertyType, true)}");
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
        sbPUML.AppendLine("hide empty members");
        sbPUML.AppendLine("skinparam monochrome true");
        sbPUML.AppendLine("skinparam backgroundcolor transparent");

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


    private static void AddProperties( Type type, StringBuilder sb, bool bInherited )
    {
        sb.AppendLine();
        sb.AppendLine($"### {( bInherited ? "Inherited" : "Declared" )}");
        sb.AppendLine();
        sb.AppendLine("|Name|Type|Read|Write|DefaultValue|");
        sb.AppendLine("|:---|:---|:--:|:---:|:-----------|");

        object instance = Activator.CreateInstance(type);

        int iPropertyCounter = 0;
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

            string strPropertyType = TypeExtension.GetTypeName(pi.PropertyType, true);
            if( pi.PropertyType.Namespace.StartsWith("DoofesZeug.") )
            {
                string strPath = $"../../{( pi.PropertyType.IsEnum ? "Enumerations" : "Entities" )}/{pi.PropertyType.Namespace}";

                strPropertyType = $"[{pi.PropertyType.Name}]({strPath}/{pi.PropertyType.Name}.md)";
            }

            object value = pi.Name.Equals(nameof(IdentifiableEntity.Id)) ? "Guid.NewGuid()" : pi.GetValue(instance);

            sb.AppendLine($"|{pi.Name}|{strPropertyType}|{( pi.CanRead ? "&#x2713;" : "&#x2717;" )}|{( pi.CanWrite ? "&#x2713;" : "&#x2717;" )}|{ value ?? "NULL" }|");
            iPropertyCounter++;
        }

        // Wenn kein Property ermittelt wurde müssen wir zumindesten eine leere Zeile ausgeben damit es richtich dargestellt wird.
        if( iPropertyCounter == 0 )
        {
            sb.AppendLine("|    |    |    |     |            |");
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

        string strSourceCode = $"../../../../DoofesZeug.Library/Src/{type.Namespace [11..].Replace('.', '/')}/{type.Name}.cs";

        sb.AppendLine();
        sb.AppendLine("|Property|Value|");
        sb.AppendLine("|:-|:-|");
        sb.AppendLine($"|Description|{da.Description}|");
        sb.AppendLine($"|Namespace|{type.Namespace}|");
        // The generated documentation is not for abstract basetypes avaible, so it make no sense to link them.
        //sb.AppendLine($"|BaseClass|[{GetTypeName(type.BaseType, true)}](../{type.BaseType.Name})|");
        sb.AppendLine($"|BaseClass|{TypeExtension.GetTypeName(type.BaseType, true)}|");
        sb.AppendLine($"|SourceCode|[{type.Name}.cs]({strSourceCode})|");
        //sb.AppendLine($"|Example||");

        foreach( LinkAttribute link in type.GetCustomAttributes<LinkAttribute>() )
        {
            link.Validate(type);
            sb.AppendLine($"|See Also|{link.Destination}|");
        }
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

        sb.AppendLine($"# {type.Name}");
        sb.AppendLine();

        sb.AppendLine("## Generally");
        AddGenerallyInformation(type, sb);
        sb.AppendLine();

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine("## Properties");
        AddProperties(type, sb, false);
        AddProperties(type, sb, true);
        sb.AppendLine();

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine("## UML Diagram");
        GenerateUmlDiagramm(type, sb);
        sb.AppendLine();

        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine("## Code Example");
        GenerateCodeExample(type, sb);
        sb.AppendLine();

        object testobject = TestDataGenerator.GenerateTestData(type);

        if( testobject != null )
        {
            sb.AppendLine("---");
            sb.AppendLine();
            sb.AppendLine("## Console Example");
            sb.AppendLine();
            sb.AppendLine("```console");
            sb.Append(testobject.ToStringTable());
            sb.AppendLine("```");
            sb.AppendLine();

            sb.AppendLine("---");
            sb.AppendLine();
            sb.AppendLine("## JSON Example");
            sb.AppendLine();
            sb.AppendLine("```json");
            sb.AppendLine(testobject.ToPrettyJson());
            sb.AppendLine("```");
            sb.AppendLine();

            sb.AppendLine("---");
            sb.AppendLine();
            sb.AppendLine("## YAML Example");
            sb.AppendLine();
            sb.AppendLine("```yaml");
            sb.Append(testobject.ToPrettyYaml());
            sb.AppendLine("```");
            sb.AppendLine();
        }

        //---------------------------------------------------------------------------------------------------------

        sb.AppendLine("<hr style=\"background: blue;\" />");

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

                StringList properties = new(from property in entity.GetProperties(BindingFlags.Public | BindingFlags.Instance) where property.CanRead == true select property.Name);

                sb.AppendLine($"|{strLinkToMarkdown}|{da.Description}|{properties.ToFlatString()}|");
            }
        }

        sb.AppendLine();
        sb.AppendLine("<hr style=\"background: blue;\" />");

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

        List<Type> models = [];

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
