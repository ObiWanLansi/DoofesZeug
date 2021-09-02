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
      "Id": "5890ef68-3035-497e-a34c-787ca2990dc6"
    },
    {
      "Name": "FireFighter",
      "Id": "acf0fe29-08da-45ed-a6f4-b3e74c7aa713"
    }
  ],
  "Id": "bc5e4362-141d-48a8-80b7-ec8953ea51d9"
}
```

