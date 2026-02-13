using System;
using System.Reflection;

using DoofesZeug.Datatypes.Container;
using DoofesZeug.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Formalities;

[TestClass]
public class TestEnumeration
{
    private static readonly StringSet IGNORE =
    [
        "DoofesZeug.Tools.Misc.ColorBrewerScheme"
    ];


    [TestMethod]
    public void Execute()
    {
        Type tEntityBase = typeof(Entity);

        Assembly assembly = tEntityBase.Assembly;

        foreach( Type type in assembly.ExportedTypes )
        {
            if( IGNORE.Contains(type.FullName) )
            {
                // We skip the ignored types.
                continue;
            }

            Console.Out.WriteLineAsync($"{type.FullName}");

            if( type.IsEnum )
            {
                // No Unknowns in the enumeration
                Assert.IsFalse(Enum.IsDefined(type, "Unknown"), $"The Enumeration {type.Name} Should Not Have An Value 'Unknown'!");

                // Not more than 32 values
                Assert.IsFalse(Enum.GetValues(type).Length > 32, $"The Enumeration {type.Name} Should Not Have More Than 32 Values!");
                continue;
            }
        }
    }
}
