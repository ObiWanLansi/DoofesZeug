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
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Name|[Name](../../Models/DoofesZeug.Models.Human/Name.md)|&#x2713;|&#x2713;|NULL|
|Gender|[Gender](../../Enumerations/DoofesZeug.Models.Human/Gender.md)|&#x2713;|&#x2713;|Unknown|
|AnimalSpecies|[AnimalSpecies](../../Enumerations/DoofesZeug.Models.Animals/AnimalSpecies.md)|&#x2713;|&#x2713;|Unknown|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|716c763e-5045-4c74-9474-0d7ddd88ccc0|

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
  "Id": "4e4dc69a-705c-4c7c-aa98-eb1e0443095a"
}
```

