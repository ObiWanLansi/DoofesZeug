using System;
using System.Reflection;

using DoofesZeug.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Formalities
{
    [TestClass]
    public class TestEntityProperties
    {
        [TestMethod]
        public void Execute()
        {
            Type tEntityBase = typeof(Entity);

            Assembly assembly = tEntityBase.Assembly;

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.IsClass && type.IsAssignableTo(tEntityBase) )
                {
                    Console.Out.WriteLineAsync($"{type.FullName}");

                    foreach( PropertyInfo pi in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance) )
                    {
                        Console.Out.WriteLineAsync($"    {pi.Name}");

                        Assert.IsFalse(pi.PropertyType.IsEnum, $"The Property {pi.Name} Of The Entity {type.Name} Is An Enumeration And Should Be Am Nullable Enum!");
                        Assert.IsTrue(pi.CanRead, $"The Property {pi.Name} Of The Entity {type.Name} Is Not Readable!");

                        if( type.IsAbstract == false )
                        {
                            Assert.IsTrue(pi.CanWrite, $"The Property {pi.Name} Of The Entity {type.Name} Is Not Writeable!");
                        }
                    }
                }
            }
        }
    }
}
