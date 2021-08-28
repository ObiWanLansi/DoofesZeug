using System;
using System.Collections.Generic;
using System.IO;
using System.Text;



namespace DoofesZeug.Extensions
{
    /// <summary>
    /// A Extension Class For The String Class With Markdown Functions.
    /// </summary>
    public static class MarkdownExtension
    {
        /// <summary>
        /// The temporary StringBuilder for private use.
        /// </summary>
        private static readonly StringBuilder sbTemp = new(512);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// The table of content
        /// </summary>
        /// <returns></returns>
        public static readonly string TableOfContent = "[//]: # (TOC)";

        /// <summary>
        /// A Parting Line.
        /// </summary>
        /// <returns></returns>
        public static readonly string PartingLine = "---";


        /// <summary>
        /// Converts the string into a bold string.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string Bold( this string strContent ) => $"**{strContent}**";


        /// <summary>
        /// Converts the string into a italic string.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string Italic( this string strContent ) => $"*{strContent}*";


        /// <summary>
        /// Converts the string into a strikethrough string.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string Strikethrough( this string strContent ) => $"~~{strContent}~~";


        /// <summary>
        /// Converts the string into a header string.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="iLevel">The level.</param>
        /// <returns></returns>
        public static string Header( this string strContent, uint iLevel )
        {
            if( iLevel == 0 )
            {
                throw new ArgumentException("The level must be above 0!");
            }

            if( iLevel > 6 )
            {
                throw new ArgumentException("The level must be below 7!");
            }

            return $"{new string('#', (int) iLevel)} {strContent}";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Create a Hyperlink from the link with caption.
        /// </summary>
        /// <param name="strLink">The link.</param>
        /// <param name="strCaption">The caption.</param>
        /// <returns></returns>
        public static string Hyperlink( this string strLink, string strCaption = null ) => string.IsNullOrEmpty(strCaption) ? strLink : $"[{strCaption}]({strLink})";


        /// <summary>
        /// Create a Hyperlink from the link with caption and tooltip.
        /// </summary>
        /// <param name="strLink">The link.</param>
        /// <param name="strCaption">The caption.</param>
        /// <param name="strTooltip">The tooltip.</param>
        /// <returns></returns>
        public static string Hyperlink( this string strLink, string strCaption, string strTooltip ) => $"[{strCaption}]({strLink} \"{strTooltip}\")";


        /// <summary>
        /// Create a Image from the source with a alttext.
        /// </summary>
        /// <param name="strImageSource">The image source.</param>
        /// <param name="strAltText">The alt text.</param>
        /// <returns></returns>
        public static string Image( this string strImageSource, string strAltText = null ) => string.IsNullOrEmpty(strAltText) ? $"![]({strImageSource})" : $"![{strAltText}]({strImageSource} \"{strAltText}\")";

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Generics the list.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="strPrefix">The string prefix.</param>
        /// <returns></returns>
        private static string GenericList<T>( this IEnumerable<T> items, string strPrefix )
        {
            sbTemp.Clear();

            foreach( T item in items )
            {
                sbTemp.AppendLine($"{strPrefix}{item}");
            }

            return sbTemp.ToString();
        }


        /// <summary>
        /// Create a unordered list.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static string UnorderedList<T>( this IEnumerable<T> items ) => GenericList(items, "* ");


        /// <summary>
        /// Create a ordered list.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static string OrderedList<T>( this IEnumerable<T> items ) => GenericList(items, "1. ");


        /// <summary>
        /// Create a taskslist.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static string TaskList( this IEnumerable<object> items ) => GenericList(items, "- [ ] ");


        /// <summary>
        /// Blockquotes the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static string BlockQuote( this IEnumerable<string> items ) => GenericList(items, "> ");

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <param name="strFilename">The string filename.</param>
        /// <returns></returns>
        public static string GetLanguage( FileInfo fiSourceFile )
        {
            switch( fiSourceFile.Extension.ToLower() )
            {
                case ".cs":
                    return "csharp";

                case ".java":
                    return "java";

                case ".js":
                    return "javascript";

                case ".php":
                    return "php";

                case ".py":
                case ".pyw":
                    return "python";

                case ".rb":
                case ".rbw":
                    return "ruby";

                case ".ps1":
                    return "powershell";

                case ".xml":
                    return "xml";

                case ".sql":
                    return "sql";

                case ".r":
                    return "r";

                case ".json":
                    return "json";

                case ".yaml":
                    return "yaml";

                case ".h":
                case ".c":
                case ".hpp":
                case ".cpp":
                    return "cpp";

                case ".bat":
                case ".sh":
                    return "bash";

            }

            return "";
        }


        /// <summary>
        /// Sources the code.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="strType">Type of the string.</param>
        /// <returns></returns>
        public static string SourceCode( this string strContent, string strType = null )
        {
            sbTemp.Clear();

            sbTemp.AppendLine($"```{strType ?? ""}");
            sbTemp.AppendLine(strContent);
            sbTemp.AppendLine("```");

            return sbTemp.ToString();
        }


        /// <summary>
        /// Sources the code.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="strType">Type of the string.</param>
        /// <returns></returns>
        public static string SourceCode( this IEnumerable<string> lines, string strType = null )
        {
            sbTemp.Clear();

            sbTemp.AppendLine($"```{strType ?? ""}");

            foreach( string strLine in lines )
            {
                sbTemp.AppendLine(strLine);
            }

            sbTemp.AppendLine("```");

            return sbTemp.ToString();
        }


        /// <summary>
        /// Sources the code.
        /// </summary>
        /// <param name="fiSourceFile">The fi source file.</param>
        /// <param name="strType">Type of the string.</param>
        /// <returns></returns>
        public static string SourceCode( this FileInfo fiSourceFile, string strType = null )
        {
            sbTemp.Clear();

            if( string.IsNullOrEmpty(strType) )
            {
                strType = GetLanguage(fiSourceFile);
            }

            sbTemp.AppendLine($"```{strType ?? ""}");

            sbTemp.AppendLine(File.ReadAllText(fiSourceFile.FullName));

            sbTemp.AppendLine("```");

            return sbTemp.ToString();
        }
    }
}
