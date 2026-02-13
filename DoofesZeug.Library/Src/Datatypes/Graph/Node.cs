using System;

using DoofesZeug.Datatypes.Container;

namespace DoofesZeug.Datatypes.Graph;



public sealed class Node
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>
    /// The id.
    /// </value>
    public string Id { get; private set; }

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
    public SimpleProperties Properties { get; set; } = [];

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    public Node() => this.Id = Guid.NewGuid().ToString();


    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => $"[{this.Id}]: {this.Label}";
}