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
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.Human\DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Name|[Name](../../Models/DoofesZeug.Models.Human\Name.md)|&#x2713;|&#x2713;|NULL|
|Gender|[Gender](../../Enumerations/DoofesZeug.Models.Human\Gender.md)|&#x2713;|&#x2713;|Unknown|
|AnimalSpecies|[AnimalSpecies](../../Enumerations/DoofesZeug.Models.Animals\AnimalSpecies.md)|&#x2713;|&#x2713;|Unknown|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|75bef381-a447-442b-a9f1-16831b6def7b|

## Attributes

- Description
- Builder

## UML Diagram

![Animal.png](./Animal.png "Animal")

## JSON Example

```json
{
  "DateOfBirth": "10.06.1978",
  "Name": {
    "Value": "Garfield"
  },
  "Gender": "Male",
  "AnimalSpecies": "Cat",
  "Id": "9400883e-f5d4-487f-a886-9aa238123f06"
}
```

