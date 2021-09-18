using System;

using DoofesZeug.Extensions;



namespace DoofesZeug.Attributes.Documentation
{
    //[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum)]
    public sealed class LinkAttribute : BaseAttribute
    {
        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public string Destination { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="LinkAttribute"/> class.
        /// </summary>
        /// <param name="strDestination">The string destination.</param>
        public LinkAttribute( string strDestination ) => this.Destination = strDestination;


        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="Exception">
        /// The destination from {instance.FullName} is empty!
        /// or
        /// The destination from {instance.FullName} starts not with 'https://'!
        /// </exception>
        public void Validate( Type instance )
        {
            if( this.Destination.IsEmpty() )
            {
                throw new Exception($"The destination from {instance.FullName} is empty!");
            }

            if( this.Destination.StartsWith("https://") == false )
            {
                throw new Exception($"The destination from {instance.FullName} starts not with 'https://'!");
            }
        }
    }
}
