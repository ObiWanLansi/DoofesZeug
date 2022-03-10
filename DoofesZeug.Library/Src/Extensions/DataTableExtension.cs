using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

using DoofesZeug.Datatypes.Container;
using DoofesZeug.Exceptions;
using DoofesZeug.Tools.Enums;
using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataTableExtension
    {
        /// <summary>
        /// The c splitter
        /// </summary>
        private static readonly char [] COMMASEPERATEDVALUES_SPLITTER = { ';' };

        /// <summary>
        /// The splitter
        /// </summary>
        private static readonly char [] MARKDOWNTABLE_SPLITTER = { '|' };

        /// <summary>
        /// The ci
        /// </summary>
        private static readonly CultureInfo CI = new("en-US");

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Erzeugt aus der DataTable eine einfache CSV Datei mit einem Strichpunkt als Feldtrenner und \n\r als Zeilentrenner.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="strOutputFilename">The string output filename.</param>
        public static void SaveAsCsvFile( this DataTable dt, string strOutputFilename )
        {
            if( File.Exists(strOutputFilename) == true )
            {
                File.Delete(strOutputFilename);
            }

            //-----------------------------------------------------------------

            using( StreamWriter swCsv = new(new BufferedStream(new FileStream(strOutputFilename, FileMode.Create)), Encoding.UTF8) )
            {
                foreach( DataColumn dc in dt.Columns )
                {
                    swCsv.Write("{0};", dc.ColumnName);
                }

                swCsv.WriteLine();

                foreach( DataRow dr in dt.Rows )
                {
                    for( int iColumn = 0 ; iColumn < dr.ItemArray.Length ; iColumn++ )
                    {
                        swCsv.Write("{0};", dr.ItemArray [iColumn]);
                    }

                    swCsv.WriteLine();
                }

                swCsv.Close();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the column as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <param name="iColumnIndex">Index of the i column.</param>
        /// <returns></returns>
        public static List<T> GetColumnAsList<T>( this DataTable dt, int iColumnIndex )
        {
            if( iColumnIndex >= dt.Columns.Count )
            {
                return null;
            }

            List<T> list = new(dt.Rows.Count);

            foreach( DataRow dr in dt.Rows )
            {
                list.Add((T) dr [iColumnIndex]);
            }

            return list;
        }


        /// <summary>
        /// Gets the column as list with convertible.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <param name="iColumnIndex">Index of the i column.</param>
        /// <returns></returns>
        public static List<T> GetColumnAsListWithConvertible<T>( this DataTable dt, int iColumnIndex ) where T : IConvertible
        {
            if( iColumnIndex >= dt.Columns.Count )
            {
                return null;
            }

            List<T> list = new(dt.Rows.Count);

            foreach( DataRow dr in dt.Rows )
            {
                object value = dr [iColumnIndex];
                list.Add((T) Convert.ChangeType(value, typeof(T)));
            }

            return list;
        }


        /// <summary>
        /// Gets the column as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <param name="strColumnName">Name of the string column.</param>
        /// <returns></returns>
        public static List<T> GetColumnAsList<T>( this DataTable dt, string strColumnName )
        {
            foreach( DataColumn dc in dt.Columns )
            {
                if( dc.ColumnName.EqualsIgnoreCase(strColumnName) == true )
                {
                    return GetColumnAsList<T>(dt, dc.Ordinal);
                }
            }

            return null;
        }


        /// <summary>
        /// Gets the column as list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt.</param>
        /// <param name="dc">The dc.</param>
        /// <returns></returns>
        public static List<T> GetColumnAsList<T>( this DataTable dt, DataColumn dc ) => GetColumnAsList<T>(dt, dc.Ordinal);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the structure as data table.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static DataTable GetStructureAsDataTable( this DataTable dt )
        {
            DataTable dtStructure = new(dt.TableName);

            dtStructure.Columns.AddRange(new []
            {
                new DataColumn ( "Ordinal" , typeof(int) ),
                new DataColumn ( "Name" , typeof(string) ),
                new DataColumn ( "DataType" , typeof(string) )
            });

            foreach( DataColumn dc in dt.Columns )
            {
                dtStructure.Rows.Add(dc.Ordinal, dc.ColumnName, dc.DataType.Name);
            }

            return dtStructure;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Loads from markdown table.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="bDetectDataType">if set to <c>true</c> [b detect data type].</param>
        /// <returns></returns>
        /// <exception cref="ParseException">The Line #{iLineCounter + 1} Have {strSplitted.Length } Columns But Only {iDetectedColumns} Was Detected In The Header!</exception>
        public static DataTable LoadFromMarkdownTable( string strContent, bool bDetectDataType = false )
        {
            if( string.IsNullOrEmpty(strContent) )
            {
                return null;
            }

            string strLine = null;
            int iLineCounter = 0;

            DataTable dt = new();
            int iDetectedColumns = -1;

            using( StringReader sr = new(strContent) )
            {
                while( null != ( strLine = sr.ReadLine() ) )
                {
                    strLine = strLine.Trim();

                    // Leere Zeilen oder Zeilen mit einer Raute am Anfang ignorieren wir
                    if( strLine.Length == 0 || strLine [0] == '#' )
                    {
                        continue;
                    }

                    //REMARK:  Leere Einträge dürfen wir nicht einfach überspringen, die Celle ist ja gültig, nur eventuell leer.
                    //string [] strSplitted = strLine.Split(SPLITTER, iLineCounter < 2 ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
                    string [] strSplitted = strLine.Split(MARKDOWNTABLE_SPLITTER, StringSplitOptions.None);

                    if( strSplitted [0].Trim().IsEmpty() )
                    {
                        StringList sl = new(strSplitted);
                        sl.RemoveAt(0);
                        strSplitted = sl.ToArray();
                    }


                    int iLastIndex = strSplitted.Length - 1;

                    if( strSplitted [iLastIndex].Trim().IsEmpty() )
                    {
                        StringList sl = new(strSplitted);
                        sl.RemoveAt(iLastIndex);
                        strSplitted = sl.ToArray();
                    }

                    // Ok, die erste Zeile, anhand derer Stellen wir nun die Anzahl der Columns fest und deren Namen
                    if( iLineCounter == 0 )
                    {
                        foreach( string strColumnName in strSplitted )
                        {
                            dt.Columns.Add(strColumnName.Trim(), typeof(string));
                        }

                        iDetectedColumns = strSplitted.Length;
                    }

                    // Ok, die zweite Zeile beschreibt die Ausrichtung
                    if( iLineCounter == 1 )
                    {
                        int iColumnCounter = 0;

                        foreach( string strPart in strSplitted )
                        {
                            string strAlignment = strPart.Trim();

                            TextAlign ta = TextAlign.Left;

                            // :- (Left) brauchen wir gar nicht erst zu checken ist ja sowieso Default ...
                            if( strAlignment.StartsWith(":") && strAlignment.EndsWith(":") )
                            {
                                ta = TextAlign.Center;
                            }
                            else
                            {
                                if( strAlignment.EndsWith(":") )
                                {
                                    ta = TextAlign.Right;
                                }
                            }

                            dt.Columns [iColumnCounter].ExtendedProperties.Add(nameof(TextAlign), ta);

                            iColumnCounter++;
                        }
                    }

                    // Wenn nur noch Daten Zeilen kommen
                    if( iLineCounter > 1 )
                    {
                        if( strSplitted.Length > iDetectedColumns )
                        {
                            throw new ParseException($"The Line #{iLineCounter + 1} Have {strSplitted.Length } Columns But Only {iDetectedColumns} Was Detected In The Header!");
                        }

                        // TODO: Wenn LineCounter== 2 noch durch Header laufen und wie beii CSV: bDetectDataType ? GetTypeOfColumn(strValue) : typeof(string)

                        // Ein bissel aufräumen können wir schon ...
                        for( int iCounter = 0 ; iCounter < strSplitted.Length ; iCounter++ )
                        {
                            strSplitted [iCounter] = strSplitted [iCounter].Trim();
                        }

                        dt.Rows.Add(strSplitted);
                    }

                    iLineCounter++;
                }
            }

            return dt;
        }


        /// <summary>
        /// Loads from markdown table file.
        /// </summary>
        /// <param name="strMDFilename">The string md filename.</param>
        /// <returns></returns>
        public static DataTable LoadFromMarkdownTableFile( string strMDFilename ) => LoadFromMarkdownTable(File.ReadAllText(strMDFilename, Encoding.Default));


        /// <summary>
        /// Loads from markdown table file.
        /// </summary>
        /// <param name="fileMDFile">The file md file.</param>
        /// <returns></returns>
        public static DataTable LoadFromMarkdownTableFile( FileInfo fiMDFile ) => LoadFromMarkdownTableFile(fiMDFile.FullName);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Loads from CSV.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="bDetectDataType">if set to <c>true</c> [b detect data type].</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Die erste Zeile zum bestimmen der Spalten konnte nicht ermittelt werden!
        /// or
        /// Die erste Zeile enthält keine Spalten!
        /// or
        /// Die zweite Spalte enthält bereits keine Daten mehr!
        /// or
        /// Die zweite Spalte hat bereits eine andere Spaltenanzahl als die erste Zeile!
        /// or
        /// Die Feldlänge der Zeile {iLineCounter} stimmt nicht mit dem Vorgabewert {iColumnCount} überein!
        /// </exception>
        public static DataTable LoadFromCsv( string strContent, bool bDetectDataType = false )
        {
            using( StringReader sr = new(strContent) )
            {
                DataTable dt = new();

                string strFirstLine = sr.ReadLine();

                // Die erste Zeile benötigen wir für die Spaltennamen und Anzahl der Spalten bestimmen zu können ...
                if( strFirstLine.IsEmpty() )
                {
                    throw new ParseException("Die erste Zeile zum bestimmen der Spalten konnte nicht ermittelt werden!");
                }
                // Die Spalten ermitteln ...
                if( strFirstLine.EndsWith(";") )
                {
                    strFirstLine = strFirstLine.Substring(0, strFirstLine.Length - 1);
                }

                string [] strSplittedColumns = strFirstLine.Trim().Split(COMMASEPERATEDVALUES_SPLITTER);

                if( strSplittedColumns.Length == 0 )
                {
                    throw new ParseException("Die erste Zeile enthält keine Spalten!");
                }

                foreach( string strColumnName in strSplittedColumns )
                {
                    dt.Columns.Add(strColumnName);
                }

                //-----------------------------------------------------

                // Die Anzahl der Spalten merken wir uns mal für später
                int iColumnCount = strSplittedColumns.Length;

                //-----------------------------------------------------

                string strSecondLine = sr.ReadLine();

                // Wenn wir nochnicht einmal eine zweite Zeile mit den ersten Daten haben brauchen wir auch nicht weiterzumachen ...
                if( strSecondLine.IsEmpty() )
                {
                    throw new ParseException("Die zweite Spalte enthält bereits keine Daten mehr!");
                }

                // ReSharper disable once PossibleNullReferenceException
                if( strSecondLine.EndsWith(";") )
                {
                    strSecondLine = strSecondLine.Substring(0, strSecondLine.Length - 1);
                }

                // Jetzt überprüfen wir ob auch die Anzahl der Spalten übereinstimmt, jetzt dürfen wir allerdings die leeren Spalten nicht ignorieren ...
                strSplittedColumns = strSecondLine.Trim().Split(COMMASEPERATEDVALUES_SPLITTER);

                if( strSplittedColumns.Length != iColumnCount )
                {
                    throw new ParseException("Die zweite Spalte hat bereits eine andere Spaltenanzahl als die erste Zeile!");
                }

                //-----------------------------------------------------

                int iIndex = 0;

                foreach( string strValue in strSplittedColumns )
                {
                    dt.Columns [iIndex++].DataType = bDetectDataType ? GetTypeOfColumn(strValue) : typeof(string);
                }

                //-----------------------------------------------------

                AddRow(dt, strSplittedColumns);

                //-----------------------------------------------------

                string strLine;
                ulong iLineCounter = 1; // -> Die erste Zeilen haben wir ja schon, also nicht bei 0 anfangen ...

                do
                {
                    iLineCounter++;

                    strLine = sr.ReadLine();

                    if( !string.IsNullOrEmpty(strLine) )
                    {
                        // Zeilen die mit # anfangen sind Kommentarzeilen und werden von uns ignoriert !
                        if( strLine [0] == '#' )
                        {
                            continue;
                        }

                        if( strLine.EndsWith(";") )
                        {
                            strLine = strLine.Substring(0, strLine.Length - 1);
                        }

                        string [] strSplitted = strLine.Trim().Split(COMMASEPERATEDVALUES_SPLITTER);

                        if( strSplitted.Length == iColumnCount )
                        {
                            AddRow(dt, strSplitted);
                        }
                        else
                        {
                            throw new ParseException($"Die Feldlänge der Zeile {iLineCounter} stimmt nicht mit dem Vorgabewert {iColumnCount} überein!");
                        }
                    }
                } while( strLine != null );

                //-----------------------------------------------------

                sr.Close();

                return dt;
            }
        }


        /// <summary>
        /// Loads the CSV from file.
        /// </summary>
        /// <param name="fiCSVFile">The fi CSV file.</param>
        /// <param name="bDetectDataType">if set to <c>true</c> [b detect data type].</param>
        /// <returns></returns>
        public static DataTable LoadFromCsvFile( FileInfo fiCSVFile, bool bDetectDataType = false ) => LoadFromCsv(File.ReadAllText(fiCSVFile.FullName), bDetectDataType);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Adds the row.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="strSplitted">The string splitted.</param>
        private static void AddRow( DataTable dt, string [] strSplitted )
        {
            List<object> data = new(64);

            for( int iCounter = 0 ; iCounter < strSplitted.Length ; iCounter++ )
            {
                data.Add(strSplitted [iCounter]);
            }

            dt.Rows.Add(data.ToArray());
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the type of column.
        /// </summary>
        /// <param name="strColumnContent">Content of the string column.</param>
        /// <returns></returns>
        public static Type GetTypeOfColumn( string strColumnContent )
        {
            try
            {
                long.Parse(strColumnContent);
                return typeof(long);

            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            //-------------------------------------

            // Schauen ob es Fließkommazahl ist
            try
            {
                double.Parse(strColumnContent);
                return typeof(double);
            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            // Bei Fließkomma müssen wir zweimal schauen, auch mit Punkt als Dezimaltrenner ...
            try
            {
                double.Parse(strColumnContent, CI);
                return typeof(double);
            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            //-------------------------------------

            // Vielleicht ist es ein Bool
            try
            {
                bool.Parse(strColumnContent);
                return typeof(bool);

            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            //-------------------------------------

            try
            {
                DateTime.ParseExact(strColumnContent, Tool.DATETIMEFORMATS, CultureInfo.CurrentCulture, DateTimeStyles.None);
                return typeof(DateTime);
            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            //-------------------------------------

            // Eine GUID könnte es natürlich auch noch sein ...
            try
            {
                Guid.Parse(strColumnContent);
                return typeof(Guid);
            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            //-------------------------------------

            try
            {
                TimeSpan.Parse(strColumnContent);
                return typeof(TimeSpan);
            }
            catch( Exception )
            {
                // Ignorieren und mit dem nächsten möglichen Datentyp weitermachen ...
            }

            //-------------------------------------

            // Wenn alles nichts hilft ist es ein String    

            return typeof(string);
        }
    }
}
