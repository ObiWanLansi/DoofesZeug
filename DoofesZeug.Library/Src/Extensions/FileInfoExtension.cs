using System.IO;
using System.Text;



namespace DoofesZeug.Extensions
{
    /// <summary>
    /// Eine Erweiterungsklasse für System.IO.FileInfo .
    /// </summary>
    public static class FileInfoExtension
    {
        /// <summary>
        /// Gets the size of the file.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns></returns>
        public static string GetFileSize( this FileInfo fi )
        {
            if( fi.Length >= 1073741824 )
            {
                return $"{ (float) fi.Length / 1073741824 :F}" + " Gb";
            }

            if( fi.Length >= 1048576 )
            {
                return $"{ (float) fi.Length / 1048576 :F}" + " Mb";
            }

            if( fi.Length >= 1024 )
            {
                return $"{ (float) fi.Length / 1024 :F}" + " Kb";
            }

            return fi.Length + " Bytes";
        }


        /// <summary>
        /// Gets the filename without extension.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns></returns>
        public static string GetFilenameWithoutExtension( this FileInfo fi ) => fi.Extension.Length == 0 ? fi.Name : fi.Name.Remove(fi.Name.Length - fi.Extension.Length);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Moves to file to a other directory.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <param name="diDirectory">The di directory.</param>
        public static void MoveTo( this FileInfo fi, DirectoryInfo diDirectory ) => fi.MoveTo($"{diDirectory.FullName}\\{fi.Name}");

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Copies to file to a other directory.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <param name="di">The di.</param>
        /// <returns></returns>
        public static FileInfo CopyTo( this FileInfo fi, DirectoryInfo di ) => fi.CopyTo($"{di.FullName}\\{fi.Name}");


        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <param name="di">The di.</param>
        /// <param name="bOverwrite">if set to <c>true</c> [b overwrite].</param>
        /// <returns></returns>
        public static FileInfo CopyTo( this FileInfo fi, DirectoryInfo di, bool bOverwrite ) => fi.CopyTo($"{di.FullName}\\{fi.Name}", bOverwrite);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="cEmpty"></param>
        /// <returns></returns>
        public static string GetFileAttributes( this FileInfo fi, char cEmpty = '.' )
        {
            StringBuilder sb = new(32);

            FileAttributes fa = fi.Attributes;

            // Standard Attributes
            sb.Append(( ( fa & FileAttributes.ReadOnly ) == FileAttributes.ReadOnly ) ? 'R' : cEmpty);
            sb.Append(( ( fa & FileAttributes.Hidden ) == FileAttributes.Hidden ) ? 'H' : cEmpty);
            sb.Append(( ( fa & FileAttributes.System ) == FileAttributes.System ) ? 'S' : cEmpty);
            sb.Append(( ( fa & FileAttributes.Archive ) == FileAttributes.Archive ) ? 'A' : cEmpty);

            // Extended Attributes
            sb.Append(( ( fa & FileAttributes.Compressed ) == FileAttributes.Compressed ) ? 'C' : cEmpty);
            sb.Append(( ( fa & FileAttributes.Encrypted ) == FileAttributes.Encrypted ) ? 'E' : cEmpty);
            sb.Append(( ( fa & FileAttributes.NotContentIndexed ) == FileAttributes.NotContentIndexed ) ? cEmpty : 'I');
            sb.Append(( ( fa & FileAttributes.Temporary ) == FileAttributes.Temporary ) ? 'T' : cEmpty);

            return sb.ToString();
        }


        /// <summary>
        /// Determines whether [is read only].
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if [is read only] [the specified fi]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsReadOnly( this FileInfo fi ) => ( fi.Attributes & FileAttributes.ReadOnly ) == FileAttributes.ReadOnly;


        /// <summary>
        /// Determines whether this instance is hidden.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if the specified fi is hidden; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsHidden( this FileInfo fi ) => ( fi.Attributes & FileAttributes.Hidden ) == FileAttributes.Hidden;


        /// <summary>
        /// Determines whether this instance is system.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if the specified fi is system; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSystem( this FileInfo fi ) => ( fi.Attributes & FileAttributes.System ) == FileAttributes.System;


        /// <summary>
        /// Determines whether this instance is archive.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if the specified fi is archive; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsArchive( this FileInfo fi ) => ( fi.Attributes & FileAttributes.Archive ) == FileAttributes.Archive;


        /// <summary>
        /// Determines whether this instance is compressed.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if the specified fi is compressed; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCompressed( this FileInfo fi ) => ( fi.Attributes & FileAttributes.Compressed ) == FileAttributes.Compressed;


        /// <summary>
        /// Determines whether this instance is encrypted.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if the specified fi is encrypted; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEncrypted( this FileInfo fi ) => ( fi.Attributes & FileAttributes.Encrypted ) == FileAttributes.Encrypted;


        /// <summary>
        /// Determines whether [is not content indexed].
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if [is not content indexed] [the specified fi]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotContentIndexed( this FileInfo fi ) => ( fi.Attributes & FileAttributes.NotContentIndexed ) == FileAttributes.NotContentIndexed;


        /// <summary>
        /// Determines whether this instance is temporary.
        /// </summary>
        /// <param name="fi">The fi.</param>
        /// <returns>
        ///   <c>true</c> if the specified fi is temporary; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTemporary( this FileInfo fi ) => ( fi.Attributes & FileAttributes.Temporary ) == FileAttributes.Temporary;
    }
}