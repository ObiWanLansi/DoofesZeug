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
|Id|Guid|&#x2713;|&#x2713;|d32494b3-0e32-4dd0-8c58-0c5cee6dad36|

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
  "Id": "95ebc4b5-8c65-44b1-aae8-20c1818e23ce"
}
```

