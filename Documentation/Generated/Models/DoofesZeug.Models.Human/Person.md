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
|Id|Guid|&#x2713;|&#x2713;|b5dc6431-b0ea-4b09-b195-3a13425a41aa|

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
    "Id": "1be36f8b-8c99-4845-8617-039ef2e9a497",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "Id": "5e975c15-4f4c-41f1-bcb5-b448beab7c5b"
}
```

