# Person

## Generally

|||
|:-|:-|
|Description|An simplified person with an firstname, lastname, birthday and some other optional properties.|
|Namespace|DoofesZeug.Models.Specieses.Human|
|BaseClass|Species|
|SourceCode|[Person.cs](../../../../DoofesZeug.Library/Src/Models/Specieses/Human/Person.cs)|
|Example||

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|FirstName|[FirstName](../../Models/DoofesZeug.Models.Specieses.Human/FirstName.md)|&#x2713;|&#x2713;|NULL|
|LastName|[LastName](../../Models/DoofesZeug.Models.Specieses.Human/LastName.md)|&#x2713;|&#x2713;|NULL|
|Handedness|Handedness?|&#x2713;|&#x2713;|NULL|
|BloodGroup|BloodGroup?|&#x2713;|&#x2713;|NULL|
|Profession|[Profession](../../Models/DoofesZeug.Models.Specieses.Human.Professions/Profession.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Gender|Gender?|&#x2713;|&#x2713;|NULL|
|Id|Guid|&#x2713;|&#x2713;|Guid.NewGuid()|

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
  "Handedness": "Left",
  "BloodGroup": "AB",
  "Profession": {
    "Id": "7afb5969-32e4-4b4b-b4fe-063f323cb94c",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "DateOfBirth": "27.09.1974",
  "Gender": "Male",
  "Id": "4c27f2ff-4e63-4747-b1cc-138fe839b4e5"
}
```

