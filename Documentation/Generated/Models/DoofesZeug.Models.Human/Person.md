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
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.Human\DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|FirstName|[FirstName](../../Models/DoofesZeug.Models.Human\FirstName.md)|&#x2713;|&#x2713;|NULL|
|LastName|[LastName](../../Models/DoofesZeug.Models.Human\LastName.md)|&#x2713;|&#x2713;|NULL|
|Gender|[Gender](../../Enumerations/DoofesZeug.Models.Human\Gender.md)|&#x2713;|&#x2713;|Unknown|
|Handedness|[Handedness](../../Enumerations/DoofesZeug.Models.Human\Handedness.md)|&#x2713;|&#x2713;|Unknown|
|Profession|[Profession](../../Models/DoofesZeug.Models.Human.Professions\Profession.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|bd335e6a-9cf7-4d01-a28f-69adc4e3138d|

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
    "Id": "2bf111bb-b2cf-4e8c-8a68-2509700f6a61",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "Id": "da969128-f451-42ba-a109-7dc53a7e290a"
}
```

