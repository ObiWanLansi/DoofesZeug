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
      "Id": "d076d888-d230-412f-93e9-65578d56bf7d"
    },
    {
      "Name": "FireFighter",
      "Id": "75d29c39-985a-48f9-8040-006a2ef66f39"
    }
  ],
  "Id": "5877dfa5-54bb-4c5b-ba08-867f9e2ca55b"
}
```

