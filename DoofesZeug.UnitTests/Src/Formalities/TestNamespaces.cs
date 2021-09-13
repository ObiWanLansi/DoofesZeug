using System;
using System.IO;
using System.Reflection;

using DoofesZeug.Attributes;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Entities;
using DoofesZeug.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTest.Formalities
{
    //[TestClass]
    public class TestNamespaces
    {
        private static readonly string SOURCE = @"..\..\..\..\DoofesZeug.Library\Src";

        private static readonly StringSet IGNORE = new()
        {
            "DoofesZeug.Tools.Misc.TypeEnum",
            "DoofesZeug.Tools.Misc.ColorBrewerScheme",
            "DoofesZeug.Tools.Misc.ColorBrewerCatalog",
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        [TestMethod]
        public void Execute()
        {
            Type tEntityBase = typeof(Entity);

            Assembly assembly = tEntityBase.Assembly;

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.GetCustomAttribute(typeof(GeneratedAttribute)) != null )
                {
                    // We skip the autogenerated code.
                    continue;
                }

                if( IGNORE.Contains(type.FullName) )
                {
                    // We skip the ignored types.
                    continue;
                }

                Console.Out.WriteLineAsync(type.FullName);

                string strName = type.Name;
                string strNamespace = type.Namespace;

                Assert.IsFalse(strNamespace.IsEmpty());
                Assert.IsTrue(strNamespace.StartsWith("DoofesZeug."));

                strNamespace = strNamespace [11..];
                int iIndex = strName.IndexOf("`");
                if( iIndex > 0 )
                {
                    strName = strName.Substring(0, iIndex);
                }

                string strSourceFile = $"{SOURCE}\\{ strNamespace.Replace('.', '\\') }\\{strName}.cs";
                Assert.IsTrue(File.Exists(strSourceFile));
            }
        }
    }
}
