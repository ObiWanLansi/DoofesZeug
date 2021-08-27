using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace DoofesZeug.Extensions
{
    public static class DirectoryInfoExtension
    {
        /// <summary>
        /// Gets the drive information.
        /// </summary>
        /// <param name="di">The di.</param>
        /// <returns></returns>
        public static DriveInfo GetDriveInfo( this DirectoryInfo di ) => new(di.Root.FullName);


        /// <summary>
        /// Gets the type of the drive.
        /// </summary>
        /// <param name="di">The di.</param>
        /// <returns></returns>
        public static DriveType GetDriveType( this DirectoryInfo di ) => new DriveInfo(di.Root.FullName).DriveType;


        /// <summary>
        /// Gets the drive format.
        /// </summary>
        /// <param name="di">The di.</param>
        /// <returns></returns>
        public static string GetDriveFormat( this DirectoryInfo di ) => new DriveInfo(di.Root.FullName).DriveFormat;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Löscht alle Dateien mit der angegebenen Dateierweiterung aus dem Verzeichnis.
        /// </summary>
        /// <param name="di">The di.</param>
        /// <param name="lFileExtensions">The l file extensions.</param>
        public static void DeleteFiles( this DirectoryInfo di, List<string> lFileExtensions )
        {
            foreach( FileInfo fi in di.GetFiles().Where(fi => lFileExtensions.Contains(fi.Extension) == true) )
            {
                fi.Delete();
            }
        }


        /// <summary>
        /// Löscht den Inhalt des Verzeichnisses rekursiv, aber nicht das Verzeichnis selbst.
        /// Wenn bei einer Datei oder Verzeichnis ein Fehler auftritt wird einfach weitergelöscht.
        /// </summary>
        /// <param name="di">The di.</param>
        /// <param name="aExceptionHandler">a exception handler.</param>
        public static void DeleteDirectoryContentRecursiv( this DirectoryInfo di, Action<Exception> aExceptionHandler )
        {
            if( di.Exists == false )
            {
                return;
            }

            try
            {
                new List<FileInfo>(di.GetFiles()).ForEach(fi =>
             {
                 try
                 {
                     fi.Delete();
                 }
                 catch( Exception ex )
                 {
                     aExceptionHandler?.Invoke(ex);
                 }
             });
            }
            catch( Exception ex )
            {
                aExceptionHandler?.Invoke(ex);
            }

            // Falls schon was bei GetDirectories() schief geht müssen wir das natürlich auch abfangen ...
            try
            {
                //Jetzt einfach alle Verzeichnisse rekursiv löschen
                foreach( DirectoryInfo dix in di.GetDirectories() )
                {
                    DeleteDirectoryContentRecursiv(dix, aExceptionHandler);

                    try
                    {
                        // Und jetzt noch das Verzeichnis selbst
                        dix.Delete();
                    }
                    catch( Exception ex )
                    {
                        aExceptionHandler?.Invoke(ex);
                    }
                }
            }
            catch( Exception ex )
            {
                aExceptionHandler?.Invoke(ex);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Simple (recursiv) copy the content of a source directory to a destination directory.
        /// If the destination directory not exists, it'll be created. Existings files
        /// in a existring destination directory are overwritten.
        /// </summary>
        /// <param name="diSource">The source directory</param>
        /// <param name="diDestination">The destination directory</param>
        /// <param name="bRecursiv">True if a recursiv copy, otherwise false</param>
        /// <returns></returns>
        /// <example>
        ///   <code lang="C#" numberLines="true">
        /// DirectoryInfo diSource = new DirectoryInfo( @"c:\Dokumentation\Entwicklung\C# Codebook\Beispiele\05 Dateisystem" );
        /// DirectoryInfo diDestination = new DirectoryInfo( @"c:\temp\test" );
        /// diSource.CopyTo( diDestination , true );
        /// </code>
        /// </example>
        public static bool CopyTo( this DirectoryInfo diSource, DirectoryInfo diDestination, bool bRecursiv )
        {
            if( diDestination.Exists == false )
            {
                Directory.CreateDirectory(diDestination.FullName);
            }

            foreach( FileInfo fiChild in diSource.GetFiles() )
            {
                fiChild.CopyTo(diDestination, true);
            }

            if( bRecursiv == true )
            {
                foreach( DirectoryInfo diChild in diSource.GetDirectories() )
                {
                    diChild.CopyTo(new DirectoryInfo($"{diDestination.FullName}\\{diChild.Name}"), true);
                }
            }

            return true;
        }


        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="diSource">The di source.</param>
        /// <param name="diDestination">The di destination.</param>
        /// <param name="bRecursiv">if set to <c>true</c> [b recursiv].</param>
        /// <param name="aFileCopy">a file copy.</param>
        /// <param name="aDirectoryCopy">a directory copy.</param>
        /// <returns></returns>
        public static bool CopyTo( this DirectoryInfo diSource, DirectoryInfo diDestination, bool bRecursiv, Action<FileInfo, int, int> aFileCopy, Action<DirectoryInfo, int, int> aDirectoryCopy )
        {
            if( diDestination.Exists == false )
            {
                Directory.CreateDirectory(diDestination.FullName);
            }

            //---------------------------------------------------------------------------

            int iFileCounter = 0;

            FileInfo [] fiChilds = diSource.GetFiles();

            foreach( FileInfo fiChild in fiChilds )
            {
                aFileCopy?.Invoke(fiChild, ++iFileCounter, fiChilds.Length);

                fiChild.CopyTo(diDestination, true);
            }

            //---------------------------------------------------------------------------

            if( bRecursiv == true )
            {
                int iDirCounter = 0;

                DirectoryInfo [] diChilds = diSource.GetDirectories();

                foreach( DirectoryInfo diChild in diChilds )
                {
                    aDirectoryCopy?.Invoke(diChild, ++iDirCounter, diChilds.Length);

                    diChild.CopyTo(new DirectoryInfo($"{diDestination.FullName}\\{diChild.Name}"), true, aFileCopy, aDirectoryCopy);
                }
            }

            return true;
        }
    }
}
