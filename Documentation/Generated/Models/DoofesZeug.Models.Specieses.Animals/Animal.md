# Animal

## Generally

|||
|:-|:-|
|Description|An simplified animal with an firstname, lastname, birthday and some other optional properties.|
|Namespace|DoofesZeug.Models.Specieses.Animals|
|BaseClass|Species|

## Properties

### Declared

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|DateOfBirth|[DateOfBirth](../../Models/DoofesZeug.Models.DateAndTime/DateOfBirth.md)|&#x2713;|&#x2713;|NULL|
|Name|[Name](../../Models/DoofesZeug.Models.Specieses/Name.md)|&#x2713;|&#x2713;|NULL|
|Gender|Nullable`1|&#x2713;|&#x2713;|NULL|
|AnimalSpecies|Nullable`1|&#x2713;|&#x2713;|NULL|

### Inherited

|Name|Type|Read|Write|DefaultValue|
|:---|:---|:--:|:---:|:-----------|
|Id|Guid|&#x2713;|&#x2713;|ac71ce31-53d8-4aed-b109-382574a3fa95|

## Attributes

- Description
- Builder

## UML Diagram

![Animal.png](./Animal.png "Animal")

## JSON Example

```json
{
  "DateOfBirth": "10.06.1978",
  "Name": "Garfield",
  "Gender": "Male",
  "AnimalSpecies": "Cat",
  "Id": "d7e87b3d-2636-45f3-a458-6ecd535690df"
}
```

