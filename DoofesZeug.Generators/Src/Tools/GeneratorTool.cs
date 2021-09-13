using System;
using System.Diagnostics;
using System.IO;

using DoofesZeug.Extensions;



namespace DoofesZeug.Tools
{
    public static class GeneratorTool
    {
        [Conditional("RELEASE")]
        public static void PlantUml( string strAbsolutePumlFilename )
        {
            FileInfo fiPUML = new(strAbsolutePumlFilename);

            using Process p = new();

            p.StartInfo.FileName = @"C:\Tools\PlantUML\puml.bat";
            p.StartInfo.Arguments = fiPUML.Name;
            p.StartInfo.WorkingDirectory = fiPUML.DirectoryName;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;

            p.Start();

            string strOutput = p.StandardOutput.ReadToEnd().Trim();
            string strError = p.StandardError.ReadToEnd().Trim();

            p.WaitForExit();

            if( p.ExitCode != 0 )
            {
                Console.Out.WriteLineAsync($"ExitCode: {p.ExitCode}");
            }

            if( strOutput.IsNotEmpty() )
            {
                Console.Out.WriteLineAsync(strOutput);
            }

            if( strError.IsNotEmpty() )
            {
                Console.Error.WriteLineAsync(strError);
            }

            if( p.ExitCode != 0 )
            {
                throw new Exception(strError);
            }
        }
    }
}
