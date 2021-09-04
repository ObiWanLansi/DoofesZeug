# Person

## Generally

|||
|:-|:-|
|Description|An simplified Person with an firstname, lastname, birthday and some other optional properties.|
|Namespace|DoofesZeug.Models.Human|
|BaseClass|IdentifiableEntity|

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.Human\DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|FirstName|[FirstName](../../Models/DoofesZeug.Models.Human\FirstName.md)|&#x2713;|&#x2713;|NULL|
|LastName|[LastName](../../Models/DoofesZeug.Models.Human\LastName.md)|&#x2713;|&#x2713;|NULL|
|Gender|[Gender](../../Enumerations/DoofesZeug.Models.Human\Gender.md)|&#x2713;|&#x2713;|Unknown|
|Handedness|[Handedness](../../Enumerations/DoofesZeug.Models.Human\Handedness.md)|&#x2713;|&#x2713;|Unknown|
|Profession|[Profession](../../Models/DoofesZeug.Models.Human.Professions\Profession.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|0b021dc6-5582-49bc-b9c2-ab9dfc65d3b7|

## Attributes

- Description
- Builder

## UML Diagram

![Person.png](./Person.png "Person")

## JSON Example

```json
{
  "DateOfBirth": "27.09.1974",
  "FirstName": "John",
  "LastName": "Doe",
  "Gender": "Male",
  "Handedness": "Left",
  "Profession": {
    "Id": "c814584a-60ae-4e80-b856-e6c4414f90ea",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "Id": "e3339f7b-f75a-4e3d-a759-5fe03738e82e"
}
```

