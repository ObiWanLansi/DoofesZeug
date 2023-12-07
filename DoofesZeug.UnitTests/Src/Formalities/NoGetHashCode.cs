using System;
using System.Reflection;

using DoofesZeug.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Formalities;

[TestClass]
public class NoGetHashCode
{
    [TestMethod]
    public void Execute()
    {
        Type tEntityBase = typeof(Entity);

        Assembly assembly = tEntityBase.Assembly;

        foreach( Type type in assembly.ExportedTypes )
        {
            if( type.GetMethod("GetHashCode", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public) != null )
            {
                Assert.Fail($"Class {type.FullName} Have An GetHashCode Method!");
            }
        }
    }
}
