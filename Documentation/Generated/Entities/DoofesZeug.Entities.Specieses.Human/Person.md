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

## UML Diagram

![Person.png](./Person.png "Person")

---

## Code Example

```cs
using System;

using DoofesZeug.Entities.ManMade.Communication;
using DoofesZeug.Entities.Specieses;
using DoofesZeug.Entities.Specieses.Human;
using DoofesZeug.Extensions;



namespace DoofesZeug.Examples.Entities
{
    public static class PersonExample
    {
        public static void CreatePerson()
        {
            Person p = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = Gender.Male,

                DateOfBirth = (11, 02, 1942),
                DateOfDeath = (22, 03, 1942 + 42),

                Handedness = Handedness.Left,
                BloodGroup = BloodGroup.AB,
                HairColor = WellKnownHairColor.Blond,
                Religion = MajorReligion.Buddhism,
                Profession = WellKnownProfession.Engineer,
                DriverLicense = EuropeanDriverLicense.B | EuropeanDriverLicense.AM,

                AverageHeight = 174,
                AverageWeight = 72,

                Phone = new Phone
                {
                    Number = "+49 54321 424269",
                    PhoneType = PhoneType.Landline,
                    InformationType = InformationType.Private
                },
                EMailAddress = new EMailAddress
                {
                    Address = "obiwanlansi@github.com",
                    InformationType = InformationType.Business
                },
                Homepage = new Homepage
                {
                    Url = new("https://github.com/ObiWanLansi"),
                    InformationType = InformationType.Business
                }
            };

            Console.Out.WriteLineAsync(p.ToStringTable());
        }
    }
}
```

---

## Console Example

```console
┌───────────────┬──────────────────────────────────────┐
│ Property      │ Value                                │
├───────────────┼──────────────────────────────────────┤
│ FirstName     │ John                                 │
│ LastName      │ Doe                                  │
│ Handedness    │ Left                                 │
│ BloodGroup    │ AB                                   │
│ HairColor     │ Blond                                │
│ Religion      │ Buddhism                             │
│ Profession    │ Engineer                             │
│ DriverLicense │ AM, B                                │
│ AverageHeight │ 174 cm                               │
│ AverageWeight │ 72 kg                                │
│ Phone         │ +49 54321 424269                     │
│ Homepage      │ https://github.com/ObiWanLansi       │
│ EMailAddress  │ obiwanlansi@github.com               │
│ BMI           │ 23,781211853027344                   │
│ DateOfBirth   │ 11.02.1942                           │
│ Gender        │ Male                                 │
│ DateOfDeath   │ 22.03.1984                           │
│ Age           │ 42                                   │
│ IsAlive       │ False                                │
│ Id            │ bd1b8530-ea2c-4561-b4cc-01db3bb8d7d3 │
└───────────────┴──────────────────────────────────────┘
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
    "InformationType": "Private"
  },
  "Homepage": {
    "Url": "https://github.com/ObiWanLansi",
    "InformationType": "Business"
  },
  "EMailAddress": {
    "Address": "obiwanlansi@github.com",
    "InformationType": "Business"
  },
  "BMI": 23.781211853027344,
  "DateOfBirth": "11.02.1942",
  "Gender": "Male",
  "DateOfDeath": "22.03.1984",
  "Age": 42,
  "IsAlive": false,
  "Id": "bd1b8530-ea2c-4561-b4cc-01db3bb8d7d3"
}
```

---

## YAML Example

```yaml
FirstName:
  Value: John
LastName:
  Value: Doe
Handedness: Left
BloodGroup: AB
HairColor: Blond
Religion: Buddhism
Profession: Engineer
DriverLicense: AM, B
AverageHeight:
  Prefix:
    Name: Centi
    Symbol: c
    Factor: 0.01
  Unit: m
  Value: 174
AverageWeight:
  Prefix:
    Name: Kilo
    Symbol: k
    Factor: 1000
  Unit: g
  Value: 72
Phone:
  Number: +49 54321 424269
  PhoneType: Landline
  InformationType: Private
Homepage:
  Url: https://github.com/ObiWanLansi
  InformationType: Business
EMailAddress:
  Address: obiwanlansi@github.com
  InformationType: Business
BMI: 23.781211853027344
DateOfBirth:
  Day:
    Value: 11
  Month:
    Value: 2
  Year:
    Value: 1942
Gender: Male
DateOfDeath:
  Day:
    Value: 22
  Month:
    Value: 3
  Year:
    Value: 1984
Age: 42
IsAlive: false
Id: bd1b8530-ea2c-4561-b4cc-01db3bb8d7d3
```

<hr style="background: blue;" />
