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
|Profession|[Profession](../../Entities/DoofesZeug.Entities.Specieses.Human.Professions/Profession.md)|&#x2713;|&#x2713;|NULL|
|AverageHeight|[Centimeter](../../Entities/DoofesZeug.Entities.Science.Base.Length/Centimeter.md)|&#x2713;|&#x2713;|NULL|
|AverageWeight|[Kilogram](../../Entities/DoofesZeug.Entities.Science.Base.Weight/Kilogram.md)|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Entities/DoofesZeug.Entities.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Gender|Gender?|&#x2713;|&#x2713;|NULL|
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
                WithProfession(new FireFighter());

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
  "Profession": {
    "Id": "2edf0594-2548-497e-8f79-afb188e1651a",
    "WellKnownProfessionType": "FireFighter",
    "Since": "11.11.1942"
  },
  "AverageHeight": {
    "Prefix": {
      "Name": "Centi",
      "Symbol": "c",
      "Factor": 0.01
    },
    "Unit": "m",
    "Value": 174.0
  },
  "AverageWeight": {
    "Prefix": {
      "Name": "Kilo",
      "Symbol": "k",
      "Factor": 1000.0
    },
    "Unit": "g",
    "Value": 72.0
  },
  "DateOfBirth": "27.09.1974",
  "Gender": "Male",
  "Id": "23d249a0-646a-4759-ad92-5a5a9450d972"
}
```

---

