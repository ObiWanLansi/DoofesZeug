using System;
using System.Collections.Generic;
using System.Text;

namespace DoofesZeug.Extensions;



public static class IDictionaryExtension
{
    public static void ForEach<K, V>( this IDictionary<K, V> dict, Action<K, V> action )
    {
        using IEnumerator<K> e = dict.Keys.GetEnumerator();
        while( e.MoveNext() )
        {
            action(e.Current, dict [e.Current]);
        }
    }


    public static K GetKey<K, V>( this IDictionary<K, V> dict, V value )
    {
        using( IEnumerator<K> e = dict.Keys.GetEnumerator() )
        {
            while( e.MoveNext() )
            {
                if( dict [e.Current].Equals(value) )
                {
                    return e.Current;
                }
            }
        }

        return default;
    }


    public static string ToString<K, V>( this IDictionary<K, V> dict, string strDivider )
    {
        StringBuilder sb = new();

        using( IEnumerator<K> e = dict.Keys.GetEnumerator() )
        {
            while( e.MoveNext() )
            {
                sb.AppendFormat("{0}={1}{2}", e.Current, dict [e.Current], strDivider);
            }
        }

        return sb.ToString();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    public static void Join<K, V>( this SortedDictionary<K, V> dest, SortedDictionary<K, V> join ) => join.ForEach(( k, v ) =>
    {
        if( dest.ContainsKey(k) == false )
        {
            dest.Add(k, v);
        }
    });

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    public static SortedDictionary<K, V> ToSortedDictionary<K, V>( this IDictionary<K, V> dSource ) => new(dSource);


    public static Dictionary<K, V> ToDictionary<K, V>( this IDictionary<K, V> dSource ) => new(dSource);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    public static IDictionary<K, V> Where<K, V>( this IDictionary<K, V> dSource, Predicate<Tuple<K, V>> predicator )
    {
        Dictionary<K, V> dFiltered = new();

        foreach( K key in dSource.Keys )
        {
            V value = dSource [key];

            if( predicator(new Tuple<K, V>(key, value)) == true )
            {
                dFiltered.Add(key, value);
            }
        }

        return dFiltered;
    }
}
