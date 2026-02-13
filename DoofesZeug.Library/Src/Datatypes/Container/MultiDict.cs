using System.Collections.Generic;

namespace DoofesZeug.Datatypes.Container;



public sealed class MultiDict
{
    private readonly Dictionary<string, object> _dict = [];


    /// <summary>
    /// Adds the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="data">The data.</param>
    public void Add(string key, object data)
    {
        if (this._dict.ContainsKey(key))
        {
            object currentValue = this._dict[key];

            if (currentValue is List<object>)
            {
                (currentValue as List<object>).Add(data);
            }
            else
            {
                this._dict[key] = new List<object>() { currentValue, data };
            }
        }
        else
        {
            this._dict.Add(key, data);
        }
    }


    /// <summary>
    /// Removes the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public bool Remove(string key)
    {
        return this._dict.Remove(key);
    }


    /// <summary>
    /// Determines whether the specified key contains key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>
    ///   <c>true</c> if the specified key contains key; otherwise, <c>false</c>.
    /// </returns>
    public bool ContainsKey(string key) => this._dict.ContainsKey(key);


    /// <summary>
    /// Gets the <see cref="System.Object"/> with the specified key.
    /// </summary>
    /// <value>
    /// The <see cref="System.Object"/>.
    /// </value>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public object this[string key] => this._dict[key];

}
