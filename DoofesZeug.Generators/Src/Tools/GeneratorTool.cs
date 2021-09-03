using System;
using System.Diagnostics;
using System.IO;

using DoofesZeug.Extensions;



namespace DoofesZeug.Tools
{
    public static class GeneratorTool
    {
        //[Conditional("RELEASE")]
        public static void PlantUml( string strAbsolutePumlFilename )
        {
            FileInfo fiPUML = new(strAbsolutePumlFilename);

            using Process p = new();

            p.StartInfo.FileName = @"C:\Lanser\Tools\PlantUML\puml.bat";
            //p.StartInfo.FileName = @"C:\Tools\PlanetUML\puml.bat";
            p.StartInfo.Arguments = fiPUML.Name;
            p.StartInfo.WorkingDirectory = fiPUML.DirectoryName;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;

            try
            {
                p.Start();

                string strOutput = p.StandardOutput.ReadToEnd().Trim();
                string strError = p.StandardError.ReadToEnd().Trim();

                p.WaitForExit();

                if( strOutput.IsNotEmpty() )
                {
                    Console.Out.WriteLineAsync(strOutput);
                }

                if( strError.IsNotEmpty() )
                {
                    Console.Error.WriteLineAsync(strError);
                }
            }
            catch( Exception ex )
            {
                Console.Error.WriteLineAsync(ex.Message);
            }
        }
    }
}
