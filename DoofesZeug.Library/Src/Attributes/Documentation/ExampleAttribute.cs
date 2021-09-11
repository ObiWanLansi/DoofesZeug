using System;
using System.IO;
using System.Text;

using DoofesZeug.Extensions;



namespace DoofesZeug.Attributes.Documentation
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum)]
    public sealed class ExampleAttribute : BaseAttribute
    {
        /// <summary>
        /// Gets the source file.
        /// </summary>
        /// <value>
        /// The source file.
        /// </value>
        public string SourceFile { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAttribute"/> class.
        /// </summary>
        /// <param name="sourceFile">The source file.</param>
        public ExampleAttribute( string sourceFile ) => this.SourceFile = sourceFile;


        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="System.Exception">
        /// The SourceFile from {instance.FullName} is empty!
        /// or
        /// The SourceFile from {instance.FullName} is to short!
        /// </exception>
        public void Validate( Type instance )
        {
            if( this.SourceFile.IsEmpty() )
            {
                throw new Exception($"The SourceFile from {instance.FullName} is empty!");
            }

            if( this.SourceFile.Length < 5 )
            {
                throw new Exception($"The SourceFile from {instance.FullName} is to short!");
            }
        }


        /// <summary>
        /// Appends the inline example.
        /// </summary>
        /// <param name="sb">The sb.</param>
        /// <exception cref="System.Exception"></exception>
        public void AppendInlineExample( StringBuilder sb )
        {
            if( File.Exists(this.SourceFile) )
            {
                bool bNamespaceFound = false;

                sb.AppendLine("```cs");
                foreach( string line in File.ReadAllLines(this.SourceFile, Encoding.Default) )
                {
                    if( line.StartsWith("namespace ") == true )
                    {
                        bNamespaceFound = true;
                    }

                    if( bNamespaceFound )
                    {
                        sb.AppendLine(line.TrimEnd());
                    }
                }
                sb.AppendLine("```");
            }
            else
            {
                throw new Exception($"{this.SourceFile} not exists!");
            }
        }
    }
}
