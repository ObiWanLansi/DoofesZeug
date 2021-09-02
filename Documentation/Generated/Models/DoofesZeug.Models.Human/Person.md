# Person

## Generally

|||
|:-|:-|
|Namespace|DoofesZeug.Models.Human|
|BaseClass|IdentifiableEntity|

## Fields

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|DateOfBirth|&#x2713;|&#x2713;||
|FirstName|FirstName|&#x2713;|&#x2713;||
|LastName|LastName|&#x2713;|&#x2713;||
|Gender|Gender|&#x2713;|&#x2713;||
|Professions|ProfessionList|&#x2713;|&#x2713;||

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;||

## Attributes

## Diagram

![Person.png](./Person.png "Person")

## Example

```json
{
  "DateOfBirth": {
    "Day": 27,
    "Month": 9,
    "Year": 1974
  },
  "FirstName": "John",
  "LastName": "Doe",
  "Gender": "Male",
  "Professions": [
    {
      "Name": "PoliceOfficer",
      "Id": "c715c32a-c339-4963-b96d-9541049381b3"
    },
    {
      "Name": "FireFighter",
      "Id": "77d7aefa-297a-486a-9787-ac39d7a3af29"
    }
  ],
  "Id": "d15b2659-8695-4075-8334-3b387c97d690"
}
```

