# Animal

## Generally

|Property|Value|
|:-|:-|
|Description|An simplified animal with an name and some other optional properties.|
|Namespace|DoofesZeug.Entities.Specieses.Animals|
|BaseClass|Species|
|SourceCode|[Animal.cs](../../../../DoofesZeug.Library/Src/Entities/Specieses/Animals/Animal.cs)|

---

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|AnimalSpecies|WellKnownAnimal?|&#x2713;|&#x2713;|NULL|
|Name|[Name](../../Entities/DoofesZeug.Entities.Specieses/Name.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Gender|Gender?|&#x2713;|&#x2713;|NULL|
|DateOfDeath|[DateOfDeath](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfDeath.md)|&#x2713;|&#x2713;|NULL|
|Age|Int32|&#x2713;|&#x2717;|-1|
|IsAlive|Boolean|&#x2713;|&#x2717;|False|
|Id|Guid|&#x2713;|&#x2713;|Guid.NewGuid()|

---

## Attributes

- Description

---

## UML Diagram

![Animal.png](./Animal.png "Animal")

---

## Code Example

```cs
An example or code snippet follows soon.
```

---

## JSON Example

```json
{
  "AnimalSpecies": "Cat",
  "Name": "Garfield",
  "DateOfBirth": "10.06.1978",
  "Gender": "Male",
  "DateOfDeath": null,
  "Age": 43,
  "IsAlive": true,
  "Id": "d9c86838-2312-4d0a-9d57-19830d485068"
}
```

---

