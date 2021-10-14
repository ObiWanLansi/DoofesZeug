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
    "Id": "cf30c5ba-4b3a-4b69-bde3-4877b8a21150"
  },
  "Homepage": {
    "Url": "https://github.com/ObiWanLansi",
    "InformationType": "Business",
    "Id": "79b2fab6-8645-4f4e-adf1-e08fe548431d"
  },
  "EMailAddress": {
    "Address": "obiwanlansi@github.com",
    "InformationType": "Business",
    "Id": "e0425bae-b43b-4de8-84c9-8d208f32b346"
  },
  "BMI": 23.781211853027344,
  "DateOfBirth": "11.02.1942",
  "Gender": "Male",
  "DateOfDeath": "22.03.1984",
  "Age": 42,
  "IsAlive": false,
  "Id": "1101e5b2-886f-4af8-9a5a-e0daac875673"
}
```

---

