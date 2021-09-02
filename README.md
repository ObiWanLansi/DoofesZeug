[![.NET](https://github.com/ObiWanLansi/DoofesZeug/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ObiWanLansi/DoofesZeug/actions/workflows/dotnet.yml)

<h1 style="font-weight:bold; letter-spacing: 10px; border-bottom: 2px solid black;">Doofes Zeug</h1>

- [Overview](#overview)
- [Content](#content)
  - [Entities & Models](#entities--models)
  - [Enumerations](#enumerations)
- [Features](#features)
  - [Builder Pattern](#builder-pattern)
  - [Validation](#validation)
  - [Container](#container)
  - [Formats](#formats)
- [Status](#status)
- [Useful Links](#useful-links)

---

## Overview

Doofes Zeug is an collection of some useful models/entities/classes for rapid prototyping in .net core
and / or creating some tests for development stuff. Doofes Zeug is designed so that it isn't too complicated. 
It should be easy to use. No expensive security features such as write-protected properties or lists that 
only mean additional work.

The basic idea was to have an collection of classes and enumerations for simple daily needed stuff like:
- Person
- Jobs
- Vehicles
- Geodata
- Animals

And some easy to use feaures and tools and datatypes like:
- IntegerList
- StringList
- *MD5, SHA512*
- *AES, TDES*
- Small And Easy Markdown Support / Conversion
- Small And Easy Json Support / Conversion

---

## Content 

### Entities & Models

All the entities / classes are listet in the generated [Model Overview](./Documentation/Generated/Models/README.md).

### Enumerations

All the enumerations are listet in the generated [Enumerations Overview](./Documentation/Generated/Enumerations/README.md).

---

## Features

### Builder Pattern

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
public static class PersonBuilder
{
    public static Person New() => new();

    public static Person DateOfBirth(this Person person, DoofesZeug.Models.Human.DateOfBirth dateofbirth)
    {
        person.DateOfBirth = dateofbirth;
        return person;
    }

    public static Person FirstName(this Person person, DoofesZeug.Models.Human.FirstName firstname)
    {
        person.FirstName = firstname;
        return person;
    }

    public static Person LastName(this Person person, DoofesZeug.Models.Human.LastName lastname)
    {
        person.LastName = lastname;
        return person;
    }

    public static Person Gender(this Person person, DoofesZeug.Models.Human.Gender gender)
    {
        person.Gender = gender;
        return person;
    }

    public static Person Id(this Person person, System.Guid id)
    {
        person.Id = id;
        return person;
    }
}
```

**Usage:**

```cs
Person p = PersonBuilder.New().FirstName("John").LastName("Doe").Gender(Gender.Male).DateOfBirth((25, 05, 1942));
Console.Out.WriteLine(p);
```

### Validation

An small validation of the models is planed. There are two different ways:
- Add an attribute to an property (`Min()`,`Max()`,`Range()`,`Length()`)
- Implement an interface `IValidator` in an class, which can validate more than one property an there coherences.

### Container

Some often needed (IMO) container classes:
- IntegerList
- StringList
- StringSet

### Formats

Direct/easy support for the most needed formats like:
- Json
- Yaml
- Xml
- Csv

---

## Status

**This library is current under development, the first small models/entites are implement 
to gather experience what i need in the future and what make sense to invest time.
But when there is a first version avaible, i'll put it to nuget of course.**

---

## Useful Links

Here are some useful links to helpful articles, some in english, some in german.

- https://de.wikipedia.org/wiki/Entit%C3%A4t_(Informatik)
- https://www.newtonsoft.com/json
- https://github.com/aaubry/YamlDotNet
- https://plantuml.com/en/
