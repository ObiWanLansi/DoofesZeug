using System;
using System.Collections.Generic;
using System.Drawing;

using DoofesZeug.Datatypes.Misc;
using DoofesZeug.Entities.DateAndTime;
using DoofesZeug.Entities.Science.Base.Length;
using DoofesZeug.Entities.Science.Base.Weight;
using DoofesZeug.Tools.Enums;



namespace DoofesZeug.Tools.Misc
{
    public static class DataTypeHelper
    {
        /// <summary>
        /// Gets the text aligment.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static TextAlign GetTextAligment(Type type) => TYPETEXTALIGN.ContainsKey(type) ? TYPETEXTALIGN[type] : TextAlign.Left;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static readonly Dictionary<Type, TextAlign> TYPETEXTALIGN = new()
        {
            { typeof(byte), TextAlign.Right },
            { typeof(byte?), TextAlign.Right },
            { typeof(short), TextAlign.Right },
            { typeof(short?), TextAlign.Right },
            { typeof(int), TextAlign.Right },
            { typeof(int?), TextAlign.Right },
            { typeof(long), TextAlign.Right },
            { typeof(long?), TextAlign.Right },

            { typeof(ushort), TextAlign.Right },
            { typeof(ushort?), TextAlign.Right },
            { typeof(uint), TextAlign.Right },
            { typeof(uint?), TextAlign.Right },
            { typeof(ulong), TextAlign.Right },
            { typeof(ulong?), TextAlign.Right },

            { typeof(float), TextAlign.Right },
            { typeof(float?), TextAlign.Right },
            { typeof(double), TextAlign.Right },
            { typeof(double?), TextAlign.Right },
            { typeof(decimal), TextAlign.Right },
            { typeof(decimal?), TextAlign.Right },

            { typeof(bool), TextAlign.Center },
            { typeof(bool?), TextAlign.Center },

            { typeof(DateTime), TextAlign.Center },
            { typeof(DateTime?), TextAlign.Center },

            { typeof(TimeSpan), TextAlign.Center },
            { typeof(TimeSpan?), TextAlign.Center },

            { typeof( Color) , TextAlign.Left },
            { typeof( Color? ) , TextAlign.Left},

            { typeof( FileSize ) , TextAlign.Right },
            //{ typeof( Money ) , TextAlign.Right }

            { typeof(Date), TextAlign.Center },
            { typeof(DateOfBirth), TextAlign.Center },

            { typeof(Milligram), TextAlign.Right },
            { typeof(Gram), TextAlign.Right },
            { typeof(Kilogram), TextAlign.Right },

            { typeof(Centimeter), TextAlign.Right },
            { typeof(Meter), TextAlign.Right },
            { typeof(Kilometer), TextAlign.Right },
        };
    }
}
