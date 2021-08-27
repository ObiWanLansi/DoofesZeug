using System;
using System.Reflection;

using DoofesZeug.Models;

using static System.Console;



namespace DoofesZeug.SourceCode
{
    public static class ModelBuilderPattern
    {

        private static 


        public static void Generate()
        {
            Type tEntityBase = typeof(EntityBase);

            Assembly assembly = tEntityBase.Assembly;

            Out.WriteLineAsync($"{assembly.FullName}");

            foreach( Type type in assembly.ExportedTypes )
            {
                Out.WriteLineAsync($"{type.FullName}");
            }
        }
    }
}
