# Animal

## Generally

|||
|:-|:-|
|Description|An simplified animal with an firstname, lastname, birthday and some other optional properties.|
|Namespace|DoofesZeug.Models.Animals|
|BaseClass|IdentifiableEntity|

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.Human/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Name|[Name](../../Models/DoofesZeug.Models.Human/Name.md)|&#x2713;|&#x2713;|NULL|
|Gender|[Gender](../../Enumerations/DoofesZeug.Models.Human/Gender.md)|&#x2713;|&#x2713;|Unknown|
|AnimalSpecies|[AnimalSpecies](../../Enumerations/DoofesZeug.Models.Animals/AnimalSpecies.md)|&#x2713;|&#x2713;|Unknown|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|0ea08136-7535-4bce-b3e5-797f71418e0f|

## Attributes

- Description
- Builder

## UML Diagram

![Animal.png](./Animal.png "Animal")

## JSON Example

```json
{
  "DateOfBirth": "10.06.1978",
  "Name": "Garfield",
  "Gender": "Male",
  "AnimalSpecies": "Cat",
  "Id": "f2fb519a-432e-4c9c-a61b-3dbfc9e92c38"
}
```

