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
|Id|Guid|&#x2713;|&#x2713;|eb2af607-9fa4-403a-96a1-dd0a12b92872|

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
    "Id": "71125905-0309-4695-8580-afa688c5dde5",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "Id": "645a7bca-83a0-4a1f-8337-0bf68bf7c7f4"
}
```

