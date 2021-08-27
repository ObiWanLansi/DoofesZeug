# DoofesZeug

This is an stupid repository for some silly and stupid tests with .net core and some github features.

## ToDo

- BaseClass EntityBase
- IdentifiableEntity : EntityBase ( die dann erst mit Guid)
- Class Color mit allen Aufzählungen aus System.Drawing.Color, sowie ToHex, ToHtml, FromHex, FromHTML, ...
- HairColor und EyeColor als Enumeration mit Standardfarben
- Project DoofesZeug.Generators
- Project DoofesZeug.UnitTests
- Enums für Religion und Nationalität
- MilitäryStuff nach DE /US (Dienstgrade z.B.)
- Split Soundex und Metaphone in different FIles, create interface Phonetic mit string Encode(string)
- Hash + Crypt + Password Class
- List<T> To DataTable
- Object 2 ASCIITable
  
| Property  | Value                              |
|:----------|-----------------------------------:|
|Id         |1d0af4a6-e00e-43cb-9867-7fd102d78618|
|Lastname   |Erika                               |
|Firstname  |Mustermann                          |
|DateOfBirth|xx.xx.xxxx                          |

- DataTable To
  -  ASCIITable
  -  CSV
  -  SQLite
  -  Markdown
- Models Categroies: Animals, Vehicles
- Countries (aus geonames generiert)
- Dienstgrade Fueerwehr, Polizei, Militär
- Kontinente Enum (sind ja nicht so viele)
- StandardValidator als Attribute für EMail, Phone, Name, aber auch ein Interface Validate um komplexere zusammenhänge validieren zu können
- Weitere Attribute: Example[] wird, dann von Generators überprüft und ggf angelegt
- Namespace Formats mit Json,Yaml und XML Exporter, bei Json und Yaml ein Comment in die erste Zeile mit EntityName
- Jeder Namespace eine README.md wie bei Java die package.html ?
