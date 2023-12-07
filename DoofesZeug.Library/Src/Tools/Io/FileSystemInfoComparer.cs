using System.Collections.Generic;
using System.IO;



namespace DoofesZeug.Tools.Io;

public class FileSystemInfoComparer : IComparer<FileSystemInfo>
{
    public bool Ascending { set; get; } = true;


    public int Compare(FileSystemInfo x, FileSystemInfo y)
    {

        if (x is DirectoryInfo && y is FileInfo)
        {
            return -1;
        }

        if (x is FileInfo && y is DirectoryInfo)
        {
            return 1;
        }

        return this.Ascending ? x.FullName.CompareTo(y.FullName) : x.FullName.CompareTo(y.FullName) * -1;
    }
}

