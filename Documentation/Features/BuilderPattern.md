# Builder Pattern


I also try to implement some features like a builder pattern. In some class i put an Attribute `Builder` to the class definition
and an generator create an class with the builder pattern.

**Example:**

```cs
[Builder]
public class Person : IdentifiableEntity
{
    public DateOfBirth DateOfBirth { get; set; }

    public FirstName FirstName { get; set; }

    public LastName LastName { get; set; }
    
    public Gender Gender { get; set; }
}
```

**Builder:**

```cs
[Generated]
public static class PersonBuilder
{
    public static Person New() => new();


    public static Person WithDateOfBirth(this Person person, DoofesZeug.Models.Human.DateOfBirth dateofbirth)
    {
        person.DateOfBirth = dateofbirth;
        return person;
    }


    public static Person WithFirstName(this Person person, DoofesZeug.Models.Human.FirstName firstname)
    {
        person.FirstName = firstname;
        return person;
    }


    public static Person WithLastName(this Person person, DoofesZeug.Models.Human.LastName lastname)
    {
        person.LastName = lastname;
        return person;
    }


    public static Person WithGender(this Person person, DoofesZeug.Models.Human.Gender gender)
    {
        person.Gender = gender;
        return person;
    }
}
```

**Usage:**

```cs
Person p = PersonBuilder.New().
    WithFirstName("John").
    WithLastName("Doe").
    WithGender(Gender.Male).
    WithDateOfBirth((25, 05, 1942)));

Console.Out.WriteLine(p);
```
