using System;
using System.Collections.Generic;
using System.Reflection;

using DoofesZeug.Entities.DateAndTime;
using DoofesZeug.Entities.DateAndTime.Part.Date;



namespace DoofesZeug.Tools.Misc
{
    public static class DateTimeSplitter
    {
        private static readonly Type DATETIME = typeof(DateTime);

        private static readonly Type DATE = typeof(Date);

        private enum DateType : byte { DateTime, Date }


        private static (PropertyInfo property, DateType? datetype) ContainsDateTimeProperty<T>( string strNameOfDateTimeProperty )
        {
            foreach( PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty) )
            {
                if( pi.Name.Equals(strNameOfDateTimeProperty) && pi.PropertyType.IsAssignableTo(DATE) )
                {
                    if( pi.PropertyType.IsAssignableTo(DATE) )
                    {
                        return (pi, DateType.Date);
                    }

                    if( pi.PropertyType.IsAssignableTo(DATETIME) )
                    {
                        return (pi, DateType.DateTime);
                    }

                    // When the property name is correct, but the type is different what cant't return the property!
                    break;
                }
            }

            return (null, null);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static SortedDictionary<Year, List<T>> SplitByYear<T>( IList<T> list, string strNameOfDateTimeProperty )
        {
            (PropertyInfo property, DateType? datetype) = ContainsDateTimeProperty<T>(strNameOfDateTimeProperty);

            if( property != null && datetype != null )
            {
                SortedDictionary<Year, List<T>> splitted = new();

                foreach( T value in list )
                {
                    object o = property.GetValue(value);

                    Year year = (uint) ( datetype == DateType.Date ? (int) ( (Date) o ).Year.Value : ( (DateTime) o ).Year );

                    if( splitted.ContainsKey(year) )
                    {
                        splitted [year].Add(value);
                    }
                    else
                    {
                        splitted.Add(year, new List<T> { value });
                    }
                }

                return splitted;
            }

            return null;
        }


        //public static SortedDictionary<(Year, Month), List<T>> SplitByYearAndMonth<T>( IList<T> list, string strNameOfDateTimeProperty )
        //{
        //    PropertyInfo pi = ContainsDateTimeProperty<T>(strNameOfDateTimeProperty);

        //    if( pi != null )
        //    {

        //    }

        //    return null;
        //}
    }
}
