# Entities Overview


## `DoofesZeug.Models.Animals`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Animal](./DoofesZeug.Models.Animals/Animal.md)|An simplified animal with an firstname, lastname, birthday and some other optional properties.|DateOfBirth, Name, Gender, AnimalSpecies, Id|


## `DoofesZeug.Models.DateAndTime`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Date](./DoofesZeug.Models.DateAndTime/Date.md)|An date entity with day, month and a year (15.12.1948).|Day, Month, Year|
|[DateOfBirth](./DoofesZeug.Models.DateAndTime/DateOfBirth.md)|An date of birth for creatures.|Day, Month, Year|
|[Time](./DoofesZeug.Models.DateAndTime/Time.md)|An time entity with hours, minutes and the seconds (12:34:56).|Hour, Minute, Second|
|[UnixTimestamp](./DoofesZeug.Models.DateAndTime/UnixTimestamp.md)|An unix timestamp (seconds since 01.01.1970).||


## `DoofesZeug.Models.DateAndTime.Part.Date`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Day](./DoofesZeug.Models.DateAndTime.Part.Date/Day.md)|The day of an date.|Value|
|[Month](./DoofesZeug.Models.DateAndTime.Part.Date/Month.md)|The month of an date.|Value|
|[Week](./DoofesZeug.Models.DateAndTime.Part.Date/Week.md)|The week of an date in the year.|Value|
|[Year](./DoofesZeug.Models.DateAndTime.Part.Date/Year.md)|The year of an date.|Value|


## `DoofesZeug.Models.DateAndTime.Part.Time`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Hour](./DoofesZeug.Models.DateAndTime.Part.Time/Hour.md)|The hours of an time.|Value|
|[Minute](./DoofesZeug.Models.DateAndTime.Part.Time/Minute.md)|The minutes of an time.|Value|
|[Second](./DoofesZeug.Models.DateAndTime.Part.Time/Second.md)|The seconds of an time.|Value|


## `DoofesZeug.Models.Human`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[FirstName](./DoofesZeug.Models.Human/FirstName.md)|An firstname for humans.|Value|
|[LastName](./DoofesZeug.Models.Human/LastName.md)|An lastname for humans.|Value|
|[Name](./DoofesZeug.Models.Human/Name.md)|An generic entity for names.|Value|
|[Person](./DoofesZeug.Models.Human/Person.md)|An simplified person with an firstname, lastname, birthday and some other optional properties.|FirstName, LastName, DateOfBirth, Gender, Handedness, Profession, Id|


## `DoofesZeug.Models.Human.Professions`

|Entity|Description|Properties|
|:-----|:----------|:---------|
|[Baker](./DoofesZeug.Models.Human.Professions/Baker.md)|This is an specialized entitiy for an baker.|Since, Id|
|[BusDriver](./DoofesZeug.Models.Human.Professions/BusDriver.md)|This is an specialized entitiy for an busdriver.|Since, Id|
|[Carpenter](./DoofesZeug.Models.Human.Professions/Carpenter.md)|This is an specialized entitiy for an carpenter.|Since, Id|
|[Doctor](./DoofesZeug.Models.Human.Professions/Doctor.md)|This is an specialized entitiy for an doctor.|Since, Id|
|[Engineer](./DoofesZeug.Models.Human.Professions/Engineer.md)|This is an specialized entitiy for an engineer.|Since, Id|
|[FireFighter](./DoofesZeug.Models.Human.Professions/FireFighter.md)|This is an specialized entitiy for an firefighter.|Since, Id|
|[HairDresser](./DoofesZeug.Models.Human.Professions/HairDresser.md)|This is an specialized entitiy for an hairdresser.|Since, Id|
|[Nurse](./DoofesZeug.Models.Human.Professions/Nurse.md)|This is an specialized entitiy for an nurse.|Since, Id|
|[Pilot](./DoofesZeug.Models.Human.Professions/Pilot.md)|This is an specialized entitiy for an pilot.|Since, Id|
|[PoliceOfficer](./DoofesZeug.Models.Human.Professions/PoliceOfficer.md)|This is an specialized entitiy for an policeofficer.|Since, Id|
|[Soldier](./DoofesZeug.Models.Human.Professions/Soldier.md)|This is an specialized entitiy for an soldier.|Since, Id|
|[TaxiDriver](./DoofesZeug.Models.Human.Professions/TaxiDriver.md)|This is an specialized entitiy for an taxidriver.|Since, Id|
|[Teacher](./DoofesZeug.Models.Human.Professions/Teacher.md)|This is an specialized entitiy for an teacher.|Since, Id|
|[Tiler](./DoofesZeug.Models.Human.Professions/Tiler.md)|This is an specialized entitiy for an tiler.|Since, Id|
|[Unknown](./DoofesZeug.Models.Human.Professions/Unknown.md)|This is an specialized entitiy for an unknown.|Since, Id|
|[Waiter](./DoofesZeug.Models.Human.Professions/Waiter.md)|This is an specialized entitiy for an waiter.|Since, Id|
