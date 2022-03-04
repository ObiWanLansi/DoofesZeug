using System;
using System.Collections.Generic;
using System.Reflection;

using DoofesZeug.Entities.DateAndTime;
using DoofesZeug.Entities.DateAndTime.Part.Date;
using DoofesZeug.Extensions;



namespace DoofesZeug.Tools.Misc
{
    public static class DateTimeSplitter
    {
        private static readonly Type DATETIME = typeof(DateTime);

        private static readonly Type DATE = typeof(Date);

        private enum DateType : byte { DateTime, Date }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


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
            if( list == null || list.Count == 0 )
            {
                return null;
            }

            if( strNameOfDateTimeProperty.IsEmpty() )
            {
                return null;
            }

            (PropertyInfo property, DateType? datetype) = ContainsDateTimeProperty<T>(strNameOfDateTimeProperty);

            if( property == null || datetype == null )
            {
                return null;
            }

            //---------------------------------------------------------------------------------------------------------

            SortedDictionary<Year, List<T>> splitted = new();

            foreach( T value in list )
            {
                object o = property.GetValue(value);

                if( o == null )
                {
                    continue;
                }

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


        public static SortedDictionary<(Year, Month), List<T>> SplitByYearAndMonth<T>( IList<T> list, string strNameOfDateTimeProperty )
        {
            if( list == null || list.Count == 0 )
            {
                return null;
            }

            if( strNameOfDateTimeProperty.IsEmpty() )
            {
                return null;
            }

            (PropertyInfo property, DateType? datetype) = ContainsDateTimeProperty<T>(strNameOfDateTimeProperty);

            if( property == null || datetype == null )
            {
                return null;
            }

            //---------------------------------------------------------------------------------------------------------

            SortedDictionary<(Year, Month), List<T>> splitted = new();

            foreach( T value in list )
            {
                object o = property.GetValue(value);

                if( o == null )
                {
                    continue;
                }

                Year year = (uint) ( datetype == DateType.Date ? (int) ( (Date) o ).Year.Value : ( (DateTime) o ).Year );
                Month month = (uint) ( datetype == DateType.Date ? (int) ( (Date) o ).Month.Value : ( (DateTime) o ).Month );

                if( splitted.ContainsKey((year, month)) )
                {
                    splitted [(year, month)].Add(value);
                }
                else
                {
                    splitted.Add((year, month), new List<T> { value });
                }
            }

            return splitted;
        }


        public static SortedDictionary<string, List<T>> Split<T, D>( IList<T> list, string strNameOfDateTimeProperty, Func<D, string> keygenerator )
        {
            if( list == null || list.Count == 0 )
            {
                return null;
            }

            if( strNameOfDateTimeProperty.IsEmpty() )
            {
                return null;
            }

            if( keygenerator == null )
            {
                return null;
            }

            (PropertyInfo property, DateType? datetype) = ContainsDateTimeProperty<T>(strNameOfDateTimeProperty);

            if( property == null || datetype == null )
            {
                return null;
            }

            //---------------------------------------------------------------------------------------------------------

            SortedDictionary<string, List<T>> splitted = new();

            foreach( T value in list )
            {
                object o = property.GetValue(value);

                if( o == null )
                {
                    continue;
                }

                string strKey = keygenerator((D) o);

                if( splitted.ContainsKey(strKey) )
                {
                    splitted [strKey].Add(value);
                }
                else
                {
                    splitted.Add(strKey, new List<T> { value });
                }
            }

            return splitted;
        }
    }
}
