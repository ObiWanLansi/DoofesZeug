<h1 style="font-weight:bold; letter-spacing: 10px; border-bottom: 2px solid black;">Implementation Reminder</h1>

Here are some reminders and examples when creating new entities for the library.

---

## DescriptionAttribute

Every class should have an `Description`, for generating documentation stuff:

```cs
using DoofesZeug.Attributes.Documentation;

namespace DoofesZeug.Models.Science.Base
{
    [Description("An abstract base class for all other metric values.")]
    public abstract class MetricValueBase<T> : EntityBase where T : unmanaged, IEquatable<T>
        .
        .
        .
```

---

## Equals

If you devired direct from EntityBase and have only one property, make a direct compare (eg `MetricValueBase<T>`):

```cs
public override bool Equals( object obj )
{
    if( obj == null )
    {
        return false;
    }

    if( obj is not MetricValueBase<T> other )
    {
        return false;
    }

    if( this.prefix.Equals(other.prefix) == false )
    {
        return false;
    }

    if( this.unit.Equals(other.unit) == false )
    {
        return false;
    }

    if( this.Value.Equals(other.Value) == false )
    {
        return false;
    }

    return true;
}
```  

If there is an deeper hierachy, and you have more properties, the just call the `Equals` method from `EntityBase` (eg `Person`):

```cs
public override bool Equals( object obj ) => 
    Equals(this, obj as Person);
```

---

## GetHashCode

At the GetHashCode method, always only your own properties combinend with the GetHashCode from the base (eg `Person`):

```cs
public override int GetHashCode() => 
    HashCode.Combine(base.GetHashCode(), 
        this.FirstName, this.LastName,
         this.Handedness, this.BloodGroup, this.Profession
         );
```

---

## JSON Converter

For every public, not abstract or static class there should be an JSON Converter (devired 
from `Newtonsoft.Json.JsonConverter`) and in the namespace `DoofesZeug.Converter`:

```cs
using Newtonsoft.Json;

public sealed class UnixTimestampConverter : JsonConverter
{
    private static readonly Type UNIXTIMESTAMP = typeof(UnixTimestamp);
    
    public override bool CanConvert( Type objectType ) => 
        objectType == UNIXTIMESTAMP;

    public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) => 
        reader.Value == null ? null : new UnixTimestamp(Convert.ToUInt64(reader.Value));

    public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
    {
        if( value == null )
        {
            writer.WriteNull();
            return;
        }

        writer.WriteValue((ulong) (UnixTimestamp) value);
    }
}
```

This converter must be registerd in `DoofesZeug.Library\Src\Extensions\JsonExtension.cs`, in the list
of converters.

---

## TestData Generator

For documentation and unit testing purpose, for everey entity class which is not abstract, there
should be an method in `DoofesZeug.Generators\Src\TestData\TestDataGenerator.cs` implemented:

```cs
private static Person GeneratePerson() => new()
{
    FirstName = "John",
    LastName = "Doe",
    Gender = Gender.Male,
    DateOfBirth = (27, 09, 1974),
    Handedness = Handedness.Left,
    BloodGroup = BloodGroup.AB,
    Profession = GenerateProfession<FireFighter>()
};
```

This method must be registered in the same sourcecode file in the static constructor.
