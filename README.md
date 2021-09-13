[![.NET](https://github.com/ObiWanLansi/DoofesZeug/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ObiWanLansi/DoofesZeug/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/ObiWanLansi/DoofesZeug/blob/main/LICENSE)
![GitHub Release](https://img.shields.io/github/v/release/ObiWanLansi/DoofesZeug?label=GitHub)
![Nuget](https://img.shields.io/nuget/v/ObiWanLansi.DoofesZeut?label=NuGet)

<h1 style="font-weight:bold; letter-spacing: 10px; border-bottom: 2px solid black;">Doofes Zeug</h1>

- [The Idea](#the-idea)
- [Overview](#overview)
  - [Entities](#entities)
  - [Enumerations](#enumerations)
  - [Builder](#builder)
  - [Examples](#examples)
- [Further Features](#further-features)
- [Current Status](#current-status)
- [Useful Links](#useful-links)
- [Used Data](#used-data)

---

## The Idea

Doofes Zeug is an collection of some useful models/entities/classes for rapid prototyping in .net core
and / or creating some tests for development stuff. Doofes Zeug is designed so that it isn't too complicated. 
It should be easy to use. No expensive security features such as write-protected properties or lists that 
only mean additional work.

The basic idea was to have an collection of classes and enumerations for simple daily needed stuff like:

- Person
- Professions
- Vehicles
- Geodata
- Animals

And some easy to use feaures, tools and datatypes like:

- IntegerList
- StringList
- *MD5, SHA512*
- *AES, TDES*
- Small And Easy Markdown Support / Conversion
- Small And Easy Json Support / Conversion

---

## Overview

### Entities

All the entities / classes are listet in the generated [Entity Overview](./Documentation/Generated/Models/README.md).

### Enumerations

All the enumerations are listet in the generated [Enumerations Overview](./Documentation/Generated/Enumerations/README.md).

### Builder

For some entities are builder avaible and listed in [Builder Overview](./Documentation/Generated/Builder/README.md).

### Examples

There are some [examples](./DoofesZeug.TestConsole/Src/Examples) avaible. At the moment there are not that many, but of course there are more and more.

---

## Further Features

- [Builder Pattern](./Documentation/Features/BuilderPattern.md)
- [Entity Validation](./Documentation/Features/EntityValidation.md)
- [Format Extension](./Documentation/Features/FormatExtension.md)
- [Additional Datatypes](./Documentation/Features/AdditionalDatatypes.md)

---

## Current Status

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

---

## Used Data

- [Color Brewer](https://colorbrewer2.org/)
