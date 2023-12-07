using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;



namespace DoofesZeug.Tools.Misc;

public sealed class AssemblyInformation
{
    private readonly Assembly assembly = null;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the title.
    /// </summary>
    /// <value>
    /// The title.
    /// </value>
    public string Title { get; private set; }

    /// <summary>
    /// Gets the version.
    /// </summary>
    /// <value>
    /// The version.
    /// </value>
    public string Version { get; private set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; private set; }

    /// <summary>
    /// Gets the product.
    /// </summary>
    /// <value>
    /// The product.
    /// </value>
    public string Product { get; private set; }

    /// <summary>
    /// Gets the copyright.
    /// </summary>
    /// <value>
    /// The copyright.
    /// </value>
    public string Copyright { get; private set; }

    /// <summary>
    /// Gets the company.
    /// </summary>
    /// <value>
    /// The company.
    /// </value>
    public string Company { get; private set; }

    /// <summary>
    /// Gets the unique identifier.
    /// </summary>
    /// <value>
    /// The unique identifier.
    /// </value>
    public string Guid { get; private set; }

    /// <summary>
    /// Gets the full name.
    /// </summary>
    /// <value>
    /// The full name.
    /// </value>
    public string FullName { get { return this.assembly.FullName; } }

    /// <summary>
    /// Gets the references.
    /// </summary>
    /// <value>
    /// The references.
    /// </value>
    public List<AssemblyName> References { get; private set; } = new();

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    private AssemblyInformation(Assembly assembly) => this.assembly = assembly;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Loads the information.
    /// </summary>
    public void LoadInformation()
    {
        this.References.AddRange(this.assembly.GetReferencedAssemblies());

        foreach (object attribute in this.assembly.GetCustomAttributes(false))
        {
            if (attribute is AssemblyTitleAttribute title)
            {
                this.Title = title.Title;
                continue;
            }

            if (attribute is AssemblyFileVersionAttribute fileversion)
            {
                this.Version = fileversion.Version;
                continue;
            }

            if (attribute is AssemblyDescriptionAttribute description)
            {
                this.Description = description.Description;
                continue;
            }

            if (attribute is AssemblyProductAttribute product)
            {
                this.Product = product.Product;
                continue;
            }

            if (attribute is AssemblyCopyrightAttribute copyright)
            {
                this.Copyright = copyright.Copyright;
                continue;
            }

            if (attribute is AssemblyCompanyAttribute company)
            {
                this.Company = company.Company;
                continue;
            }

            if (attribute is GuidAttribute guid)
            {
                this.Guid = guid.Value;
                continue;
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets from assembly.
    /// </summary>
    /// <param name="assembly">The assembly.</param>
    /// <returns></returns>
    public static AssemblyInformation GetFromAssembly(Assembly assembly) => new(assembly);


    /// <summary>
    /// Gets from type.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <returns></returns>
    public static AssemblyInformation GetFromType(Type t) => new(t.Assembly);


    /// <summary>
    /// Gets from file.
    /// </summary>
    /// <param name="fi">The fi.</param>
    /// <returns></returns>
    public static AssemblyInformation GetFromFile(FileInfo fi) => new(Assembly.LoadFile(fi.FullName));


    /// <summary>
    /// Gets from file.
    /// </summary>
    /// <param name="strFilename">The string filename.</param>
    /// <returns></returns>
    public static AssemblyInformation GetFromFile(string strFilename) => new(Assembly.LoadFile(strFilename));
}
