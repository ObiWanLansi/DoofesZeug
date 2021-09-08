# Person

## Generally

|||
|:-|:-|
|Description|An simplified person with an firstname, lastname, birthday and some other optional properties.|
|Namespace|DoofesZeug.Models.Human|
|BaseClass|IdentifiableEntity|

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|FirstName|[FirstName](../../Models/DoofesZeug.Models.Human/FirstName.md)|&#x2713;|&#x2713;|NULL|
|LastName|[LastName](../../Models/DoofesZeug.Models.Human/LastName.md)|&#x2713;|&#x2713;|NULL|
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Gender|[Gender](../../Enumerations/DoofesZeug.Models.Human/Gender.md)|&#x2713;|&#x2713;|Unknown|
|Handedness|[Handedness](../../Enumerations/DoofesZeug.Models.Human/Handedness.md)|&#x2713;|&#x2713;|Unknown|
|Profession|[Profession](../../Models/DoofesZeug.Models.Human.Professions/Profession.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|429d1efe-d2af-4e24-95ed-34f466673e0b|

## Attributes

- Description
- Builder

## UML Diagram

![Person.png](./Person.png "Person")

## JSON Example

```json
{
  "FirstName": "John",
  "LastName": "Doe",
  "DateOfBirth": "27.09.1974",
  "Gender": "Male",
  "Handedness": "Left",
  "Profession": {
    "Id": "98675a0e-97c9-4377-abba-6ede746a22c7",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "Id": "a1c2eee7-15fa-4dea-b7ec-81f2de5078af"
}
```

