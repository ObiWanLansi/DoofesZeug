# Person

## Generally

|Property|Value|
|:-|:-|
|Description|An simplified person with an firstname, lastname, birthday and some other optional properties.|
|Namespace|DoofesZeug.Entities.Specieses.Human|
|BaseClass|Species|
|SourceCode|[Person.cs](../../../../DoofesZeug.Library/Src/Entities/Specieses/Human/Person.cs)|

---

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|FirstName|[FirstName](../../Entities/DoofesZeug.Entities.Specieses.Human/FirstName.md)|&#x2713;|&#x2713;|NULL|
|LastName|[LastName](../../Entities/DoofesZeug.Entities.Specieses.Human/LastName.md)|&#x2713;|&#x2713;|NULL|
|Handedness|Handedness?|&#x2713;|&#x2713;|NULL|
|BloodGroup|BloodGroup?|&#x2713;|&#x2713;|NULL|
|HairColor|WellKnownHairColor?|&#x2713;|&#x2713;|NULL|
|Religion|MajorReligion?|&#x2713;|&#x2713;|NULL|
|Profession|WellKnownProfession?|&#x2713;|&#x2713;|NULL|
|DriverLicense|EuropeanDriverLicense?|&#x2713;|&#x2713;|NULL|
|AverageHeight|[Centimeter](../../Entities/DoofesZeug.Entities.Science.Base.Length/Centimeter.md)|&#x2713;|&#x2713;|NULL|
|AverageWeight|[Kilogram](../../Entities/DoofesZeug.Entities.Science.Base.Weight/Kilogram.md)|&#x2713;|&#x2713;|NULL|
|Phone|[Phone](../../Entities/DoofesZeug.Entities.ManMade.Communication/Phone.md)|&#x2713;|&#x2713;|NULL|
|Homepage|[Homepage](../../Entities/DoofesZeug.Entities.ManMade.Communication/Homepage.md)|&#x2713;|&#x2713;|NULL|
|EMailAddress|[EMailAddress](../../Entities/DoofesZeug.Entities.ManMade.Communication/EMailAddress.md)|&#x2713;|&#x2713;|NULL|
|BMI|Double?|&#x2713;|&#x2717;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Gender|Gender?|&#x2713;|&#x2713;|NULL|
|DateOfDeath|[DateOfDeath](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfDeath.md)|&#x2713;|&#x2713;|NULL|
|Age|UInt32?|&#x2713;|&#x2717;|NULL|
|IsAlive|Boolean|&#x2713;|&#x2717;|False|
|Id|Guid|&#x2713;|&#x2713;|Guid.NewGuid()|

---

## Attributes

- Description

---

## UML Diagram

![Person.png](./Person.png "Person")

---

## Code Example

```cs
An example or code snippet follows soon.
```

---

## JSON Example

```json
{
  "FirstName": "John",
  "LastName": "Doe",
  "Handedness": "Left",
  "BloodGroup": "AB",
  "HairColor": "Blond",
  "Religion": "Buddhism",
  "Profession": "Engineer",
  "DriverLicense": "AM, B",
  "AverageHeight": {
    "Prefix": "Centi",
    "Unit": "m",
    "Value": 174.0
  },
  "AverageWeight": {
    "Prefix": "Kilo",
    "Unit": "g",
    "Value": 72.0
  },
  "Phone": {
    "Number": "+49 54321 424269",
    "PhoneType": "Landline",
    "InformationType": "Private",
    "Id": "650767d6-ac60-48de-9abc-191c2e6684f8"
  },
  "Homepage": {
    "Url": "https://github.com/ObiWanLansi",
    "InformationType": "Business",
    "Id": "5561ff82-086e-4e67-8cb4-9ee9be92c63a"
  },
  "EMailAddress": {
    "Address": "obiwanlansi@github.com",
    "InformationType": "Business",
    "Id": "084c0e17-ec26-49f2-b56f-714e1f9950a5"
  },
  "BMI": 23.781211853027344,
  "DateOfBirth": "11.02.1942",
  "Gender": "Male",
  "DateOfDeath": "22.03.1984",
  "Age": 42,
  "IsAlive": false,
  "Id": "6433755f-ffc0-4b35-a502-0bf91406550f"
}
```

---

