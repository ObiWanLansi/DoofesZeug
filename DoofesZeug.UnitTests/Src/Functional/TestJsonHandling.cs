using System;
using System.Reflection;

using DoofesZeug.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DoofesZeug.UnitTests.Functional
{
    [TestClass]
    public class TestJsonHandling
    {

        [TestMethod]
        public void Execute()
        {
            Type tEntityBase = typeof(EntityBase);

            Assembly assembly = tEntityBase.Assembly;

            foreach( Type type in assembly.ExportedTypes )
            {
                if(type.IsAssignableTo(tEntityBase))
                {
                    Console.Out.WriteLineAsync(type.FullName);

                }
            }
        }
    }
}
