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
|Gender|Nullable`1|&#x2713;|&#x2713;|NULL|
|Handedness|Nullable`1|&#x2713;|&#x2713;|NULL|
|BloodGroup|Nullable`1|&#x2713;|&#x2713;|NULL|
|Profession|[Profession](../../Models/DoofesZeug.Models.Human.Professions/Profession.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|360456e8-517a-42f0-b568-5f67e9cbecbf|

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
  "BloodGroup": null,
  "Profession": {
    "Id": "ca7cf2f9-fb16-4377-b9c2-4e7abdb598a2",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "Id": "775e15d1-b454-48ec-9a0e-6b26189714c4"
}
```

