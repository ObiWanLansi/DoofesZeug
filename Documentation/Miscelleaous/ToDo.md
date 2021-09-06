# ToDo List

## ToDo

- Attributes 
  - `[Example(Source="RatatuiExample.cs")]` mit Verweis auf Beispiel , kann dann in der generierten Doku direkt als inline mit ran gezogen oder einfach nur verlinkkt werden.
  - ~~`[UnitTest(Source="")]` mit Verweis auf den UnitTest. Aber warum nochmal hatte ich die Idee ?~~
- Wie bekommt man bei .net core die CodeCoverage raus ? Über VisualStudio ?
- Für später: DataTypesColumnAligments als statische klasse mit einer funktion `TextAlign GetAligment(Type t)`
- Money
  - Dollar
  - Euro
- Temperature (https://de.wikipedia.org/wiki/Temperatur)
  - Kelivin
  - Fahrenheit
  - Celcius
- Ein kleines GraphModel und erzeugung von diaggraph oder basic yed files ?
- Support für aufruf gnuplot für kleinere Diagramme zwischendurch ?
- Feature WizardTSupportool mit fragen / antworten wie bei erstellen dotnet init, oder anderen tools ?
- MatheStuff, z.b geometrische Figuren Rectangle, Circle, und direkt mit ein paar Meßmethoden?
- Generic Singelton Pattern
- Implement Observer Pattern in EntityBase ?
- An Attribute for an field description and one for type description?
- VCard support ?
- Class Color mit allen Aufzählungen aus System.Drawing.Color, sowie ToHex, ToHtml, FromHex, FromHTML, ...
- HairColor und EyeColor als Enumeration mit Standardfarben
- MilitäryStuff nach DE /US (Dienstgrade z.B.)
- Hash + Crypt + Password Class
- List<T> To DataTable
- ~~Colors -> an enumeration lie System.Drawing.Color, but without an reference to System.Drawing.dll~~
  > Check if we can use the original System.Drawing.Color under linux, then it make no sense to create a new implementation.
- DataTable To
  -  ASCIITable
  -  CSV
  -  SQLite
  -  Markdown
- Models Categroies: Animals, Vehicles
- Enum Nationalität?
- Countries (aus geonames generiert)
- Dienstgrade Feuerwehr, Polizei, Militär
- StandardValidator als Attribute für EMail, Phone, Name, aber auch ein Interface Validate um komplexere zusammenhänge validieren zu können
- Weitere Attribute: Example[] wird, dann von Generators überprüft und ggf angelegt
- Namespace Formats mit Json, Yaml und XML Exporter, bei Json und Yaml ein Comment in die erste Zeile mit EntityName


## Done

- Object To ASCIITable
- All entities should implement the equals interface ...
- Kontinente Enum (sind ja nicht so viele)
- Fill EntityOverview Files with the stuff.
- Enum für WeltReligion .
- Builder Overview
- ~~Generate Document mit all Attributes, too ...~~
  > Currently there are not as many attributes as it would be worthwhile.
- List Attributs in model
- Enum Values To Enum.md
- Und bei EntityOverview die Properties mit aufnhemen.
- Profession: Add abstract Enumeartion Field, damit wenn als JSON wir auch eine Unterscheidung haben.
- Enumerations Markdown List Values
- ~~Jeder Namespace eine README.md wie bei Java die package.html ?~~
