using System;

using DoofesZeug.Extensions;



namespace DoofesZeug.Attributes.Documentation;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
public sealed class DescriptionAttribute : BaseAttribute
{
    /// <summary>
    /// Gets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    public string Description { get; private set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="DescriptionAttribute"/> class.
    /// </summary>
    /// <param name="strDescription">The string description.</param>
    public DescriptionAttribute(string strDescription) => this.Description = strDescription;


    /// <summary>
    /// Validates the specified instance.
    /// </summary>
    /// <param name="instance">The instance.</param>
    /// <exception cref="Exception">
    /// The description from {instance.FullName} is empty!
    /// or
    /// The description from {instance.FullName} is to short!
    /// or
    /// The description from {instance.FullName} ends not with an point!
    /// </exception>
    public void Validate(Type instance)
    {
        if (this.Description.IsEmpty())
        {
            throw new Exception($"The description from {instance.FullName} is empty!");
        }

        if (this.Description.Length < 5)
        {
            throw new Exception($"The description from {instance.FullName} is to short!");
        }

        if (this.Description.EndsWith(".") == false)
        {
            throw new Exception($"The description from {instance.FullName} ends not with an point!");
        }

        if (this.Description.Contains("https://"))
        {
            throw new Exception($"The description from {instance.FullName} containts an link to a webpage. Please use the LinkAttribute!!");
        }
    }
}
