using System;
using System.Collections.Generic;
using System.Reflection;

using DoofesZeug.Entities.DateAndTime;
using DoofesZeug.Entities.DateAndTime.Part.Date;



namespace DoofesZeug.Tools.Misc
{
    public static class DateTimeSplitter
    {
        //private static readonly Type DATETIME = typeof(DateTime);
        private static readonly Type DATE = typeof(Date);


        private static PropertyInfo ContainsDateTimeProperty<T>( string strNameOfDateTimeProperty )
        {
            foreach( PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty) )
            {
                if( pi.Name.Equals(strNameOfDateTimeProperty) && pi.PropertyType.IsAssignableTo(DATE) )
                {
                    return pi;
                }
            }

            return null;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static SortedDictionary<Year, List<T>> SplitByYear<T>( IList<T> list, string strNameOfDateTimeProperty )
        {
            PropertyInfo pi = ContainsDateTimeProperty<T>(strNameOfDateTimeProperty);

            if( pi != null )
            {
                SortedDictionary<Year, List<T>> splitted = new SortedDictionary<Year, List<T>>();

                foreach( T value in list )
                {
                    Date date = (Date) pi.GetValue(value);

                    //Year year = new Year((uint) dt.Year);

                    //if( splitted.ContainsKey(year) )
                    //{

                    //}
                    //else
                    //{
                    //    splitted.Add(year, new List<T> { value });
                    //}
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
