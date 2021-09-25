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
|AverageHeight|[Centimeter](../../Entities/DoofesZeug.Entities.Science.Base.Length/Centimeter.md)|&#x2713;|&#x2713;|NULL|
|AverageWeight|[Kilogram](../../Entities/DoofesZeug.Entities.Science.Base.Weight/Kilogram.md)|&#x2713;|&#x2713;|NULL|
|BMI|Double?|&#x2713;|&#x2717;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Gender|Gender?|&#x2713;|&#x2713;|NULL|
|DateOfDeath|[DateOfDeath](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfDeath.md)|&#x2713;|&#x2713;|NULL|
|Age|Int32|&#x2713;|&#x2717;|-1|
|IsAlive|Boolean|&#x2713;|&#x2717;|False|
|Id|Guid|&#x2713;|&#x2713;|Guid.NewGuid()|

---

## Attributes

- Builder
- Description
- Example

---

## UML Diagram

![Person.png](./Person.png "Person")

---

## Code Example

```cs
namespace DoofesZeug.UnitTests.Functional.Builder
{
    [TestClass]
    public class TestPersonBuilder
    {
        [TestMethod]
        public void ExecuteTest()
        {
            Person person = PersonBuilder.New().
                WithDateOfBirth((01, 01, 1998)).
                WithFirstName("John").
                WithLastName("Doe").
                WithGender(Gender.Male).
                WithHandedness(Handedness.Both).
                WithProfession(WellKnownProfession.PoliceOfficer);

            Assert.IsNotNull(person);
        }
    }
}
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
  "BMI": 23.781211853027344,
  "DateOfBirth": "11.02.1942",
  "Gender": "Male",
  "DateOfDeath": "22.03.1984",
  "Age": 42,
  "IsAlive": false,
  "Id": "e682d2eb-b4f1-4b1c-a6ba-0deb8f77936f"
}
```

---

