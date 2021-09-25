# Entities Overview


## `DoofesZeug.Entities.DateAndTime`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Date](./DoofesZeug.Entities.DateAndTime/Date.md)|An date entity with day, month and a year (15.12.1948).|Day, Month, Year|
|[DateOfBirth](./DoofesZeug.Entities.DateAndTime/DateOfBirth.md)|An date of birth (without the time) for creatures.|Day, Month, Year|
|[DateOfDeath](./DoofesZeug.Entities.DateAndTime/DateOfDeath.md)|An date of death (without the time) for creatures.|Day, Month, Year|
|[Time](./DoofesZeug.Entities.DateAndTime/Time.md)|An time entity with hours, minutes and the seconds (12:34:56).|Hour, Minute, Second|
|[UnixTimestamp](./DoofesZeug.Entities.DateAndTime/UnixTimestamp.md)|An unix timestamp (seconds since 01.01.1970).||


## `DoofesZeug.Entities.DateAndTime.Part.Date`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Day](./DoofesZeug.Entities.DateAndTime.Part.Date/Day.md)|The day of an date.|Value|
|[Month](./DoofesZeug.Entities.DateAndTime.Part.Date/Month.md)|The month of an date.|Value|
|[Week](./DoofesZeug.Entities.DateAndTime.Part.Date/Week.md)|The week of an date in the year.|Value|
|[Year](./DoofesZeug.Entities.DateAndTime.Part.Date/Year.md)|The year of an date.|Value|


## `DoofesZeug.Entities.DateAndTime.Part.Time`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Hour](./DoofesZeug.Entities.DateAndTime.Part.Time/Hour.md)|The hours of an time.|Value|
|[Minute](./DoofesZeug.Entities.DateAndTime.Part.Time/Minute.md)|The minutes of an time.|Value|
|[Second](./DoofesZeug.Entities.DateAndTime.Part.Time/Second.md)|The seconds of an time.|Value|


## `DoofesZeug.Entities.Science.Base.Length`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Centimeter](./DoofesZeug.Entities.Science.Base.Length/Centimeter.md)|This entity represents just a centimeter.|Prefix, Unit, Value|
|[Kilometer](./DoofesZeug.Entities.Science.Base.Length/Kilometer.md)|This entity represents just a kilometer.|Prefix, Unit, Value|
|[Meter](./DoofesZeug.Entities.Science.Base.Length/Meter.md)|This entity represents just a meter.|Prefix, Unit, Value|


## `DoofesZeug.Entities.Science.Base.Weight`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Gram](./DoofesZeug.Entities.Science.Base.Weight/Gram.md)|This entity represents just a gram.|Prefix, Unit, Value|
|[Kilogram](./DoofesZeug.Entities.Science.Base.Weight/Kilogram.md)|This entity represents just a kilogram.|Prefix, Unit, Value|
|[Milligram](./DoofesZeug.Entities.Science.Base.Weight/Milligram.md)|This entity represents just a milligram.|Prefix, Unit, Value|


## `DoofesZeug.Entities.Science.Geographically.Base`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[GeoPoint](./DoofesZeug.Entities.Science.Geographically.Base/GeoPoint.md)|An simplified geo point with lat, lon and alt (WGS84).|Latitude, Longitude, Id|
|[Latitude](./DoofesZeug.Entities.Science.Geographically.Base/Latitude.md)|An simplified latitude (WGS84).|Value|
|[Longitude](./DoofesZeug.Entities.Science.Geographically.Base/Longitude.md)|An simplified longitude (WGS84).|Value|


## `DoofesZeug.Entities.Specieses`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Name](./DoofesZeug.Entities.Specieses/Name.md)|An generic name for any species.|Value|


## `DoofesZeug.Entities.Specieses.Animals`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Animal](./DoofesZeug.Entities.Specieses.Animals/Animal.md)|An simplified animal with an firstname, lastname, birthday and some other optional properties.|AnimalSpecies, Name, DateOfBirth, Gender, DateOfDeath, Id|


## `DoofesZeug.Entities.Specieses.Human`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[FirstName](./DoofesZeug.Entities.Specieses.Human/FirstName.md)|An firstname for humans.|Value|
|[LastName](./DoofesZeug.Entities.Specieses.Human/LastName.md)|An lastname for humans.|Value|
|[Person](./DoofesZeug.Entities.Specieses.Human/Person.md)|An simplified person with an firstname, lastname, birthday and some other optional properties.|FirstName, LastName, Handedness, BloodGroup, HairColor, Religion, Profession, AverageHeight, AverageWeight, DateOfBirth, Gender, DateOfDeath, Id|
