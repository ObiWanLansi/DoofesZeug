using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;



namespace DoofesZeug.Tools.Misc
{
    public sealed class AssemblyInformation
    {
        private readonly Assembly assembly = null;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public string Title { get; private set; }

        public string Version { get; private set; }

        public string Description { get; private set; }

        public string Product { get; private set; }

        public string Copyright { get; private set; }

        public string Company { get; private set; }

        public string Guid { get; private set; }

        public string FullName { get { return this.assembly.FullName; } }

        public List<AssemblyName> References { get; private set; } = new();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private AssemblyInformation( Assembly assembly ) => this.assembly = assembly;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public void LoadInformation()
        {
            this.References.AddRange(this.assembly.GetReferencedAssemblies());

            foreach( object attribute in this.assembly.GetCustomAttributes(false) )
            {
                if( attribute is AssemblyTitleAttribute title )
                {
                    this.Title = title.Title;
                    continue;
                }

                if( attribute is AssemblyFileVersionAttribute fileversion )
                {
                    this.Version = fileversion.Version;
                    continue;
                }

                if( attribute is AssemblyDescriptionAttribute description )
                {
                    this.Description = description.Description;
                    continue;
                }

                if( attribute is AssemblyProductAttribute product )
                {
                    this.Product = product.Product;
                    continue;
                }

                if( attribute is AssemblyCopyrightAttribute copyright )
                {
                    this.Copyright = copyright.Copyright;
                    continue;
                }

                if( attribute is AssemblyCompanyAttribute company )
                {
                    this.Company = company.Company;
                    continue;
                }

                if( attribute is GuidAttribute guid )
                {
                    this.Guid = guid.Value;
                    continue;
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static AssemblyInformation GetFromAssembly( Assembly assembly ) => new(assembly);


        public static AssemblyInformation GetFromType( Type t ) => new(t.Assembly);


        public static AssemblyInformation GetFromFile( FileInfo fi ) => new(Assembly.LoadFile(fi.FullName));


        public static AssemblyInformation GetFromFile( string strFilename ) => new(Assembly.LoadFile(strFilename));
    }
}
