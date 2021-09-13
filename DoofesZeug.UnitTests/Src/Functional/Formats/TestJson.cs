﻿using System;
using System.Reflection;

using DoofesZeug.Extensions;
using DoofesZeug.Models;
using DoofesZeug.TestData;

using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace DoofesZeug.UnitTests.Functional.Formats
{
    [TestClass]
    public class TestJson
    {
        [TestMethod]
        public void TestEntityJsonConverter()
        {
            Type tEntityBase = typeof(Entity);

            Assembly assembly = tEntityBase.Assembly;

            foreach( Type type in assembly.ExportedTypes )
            {
                if( type.IsAssignableTo(tEntityBase) && type.IsAbstract == false )
                {
                    Console.Out.WriteLineAsync(type.FullName);

                    object oOriginal = TestDataGenerator.GenerateTestData(type);
                    Assert.IsNotNull(oOriginal);

                    string json = oOriginal.ToPrettyJson();
                    Assert.IsNotNull(json);
                    Assert.IsTrue(json.Length > 0);

                    object oClone = json.FromJson(type);

                    try
                    {
                        Assert.IsNotNull(oClone);
                        Assert.AreEqual(oOriginal, oClone);
                    }
                    catch( Exception ex )
                    {
                        // For debugging purpose we catch the exception so that we can set an breakpoint for debugging.
                        Assert.Fail(ex.Message);
                    }
                }
            }
        }
    }
}
