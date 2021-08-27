using System.IO;



namespace DoofesZeug.Extensions
{
    public static class FileSystemInfoExtension
    {
        /// <summary>
        /// Renames the specified fsi.
        /// </summary>
        /// <param name="fsi">The fsi.</param>
        /// <param name="strNewFilename">The STR new filename.</param>
        public static void Rename( this FileSystemInfo fsi, string strNewFilename )
        {
            string strFullFilename = $"{( fsi is FileInfo ? ( fsi as FileInfo ).DirectoryName : ( fsi as DirectoryInfo ).Parent.FullName )}\\{strNewFilename}";

            if( fsi is FileInfo )
            {
                ( fsi as FileInfo ).MoveTo(strFullFilename);
            }
            else
            {
                string strTempDirectoryname = $"{strFullFilename}.temp";
                ( fsi as DirectoryInfo ).MoveTo(strTempDirectoryname);
                ( fsi as DirectoryInfo ).MoveTo(strFullFilename);
            }
        }
    }
}
