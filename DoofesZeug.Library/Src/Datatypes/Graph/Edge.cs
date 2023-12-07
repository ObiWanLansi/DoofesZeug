using System;

using DoofesZeug.Datatypes.Container;

namespace DoofesZeug.Datatypes.Graph;



public sealed class Edge
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>
    /// The id.
    /// </value>
    public string Id { get; private set; }

    /// <summary>
    /// Gets or sets the source.
    /// </summary>
    /// <value>
    /// The source.
    /// </value>
    public Node Source { get; set; }

    /// <summary>
    /// Gets or sets the destination.
    /// </summary>
    /// <value>
    /// The destination.
    /// </value>
    public Node Destination { get; set; }

    /// <summary>
    /// Gets or sets the direction.
    /// </summary>
    /// <value>
    /// The direction.
    /// </value>
    public Direction? Direction { get; set; }

    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    /// <value>
    /// The label.
    /// </value>
    public string Label { get; set; }

    /// <summary>
    /// Gets or sets the properties.
    /// </summary>
    /// <value>
    /// The properties.
    /// </value>
    public SimpleProperties Properties { get; set; } = new();

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Initializes a new instance of the <see cref="Edge"/> class.
    /// </summary>
    public Edge() => this.Id = Guid.NewGuid().ToString();

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => $"[{this.Id}]: {this.Label}";

} // end public sealed class Edge