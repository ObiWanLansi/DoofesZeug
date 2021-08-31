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
  "Professions": null,
  "Id": "315df6ec-297d-4de9-82a8-c81aabda7a72"
}
```

