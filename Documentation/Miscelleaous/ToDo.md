<h1 style="font-weight:bold; letter-spacing: 10px; border-bottom: 2px solid black;">ToDo & Done List</h1>

Don't worry about this mixed german and english stuff. Sometimes i've a brainfuck and then
i write down the stuff in the fastest way, mostly in note form.

---

## ToDo

- IExample und dann in DoofesZeug.Generators ein Namespace Example, die Beispiele heißen dann immer XXXXXExample und implementieren
  Examples, aus der TestConsole alles raus. IExample.Execute(TextWriter out).
- ToStringTable: bool DeclaredOnly, PropertySortOrder.FromBaseDown / ToBaseUp
- ToStringTree: ggf. auch ein GenericTree Klasse in die man so ziemlich alles reinpumpen kann.
  > Cool wäre natürlich auch analog zo DataTable ein DataTree zu haben.
  > Wenn wir einen DataTree haben, könnte man ja auch überlegen ein JSON/XML/YAML To DataTree zu machen?
- Europe.Germany.RheinlandPfalz.Trier GAdm Generator
- DataSourceAttribute zu den entsprechenden Klassen ?
- Proeprties To Dictionary `public static Dictionary<string, string> FlatPropertiesToDictionary( this object o )`.
- Geometry Rectangle<T> where T: Kilometer, Millimeter or Meter
- Dataset Generate Person:
  - auch ein paar Enumerations leer lassen.
  - Generate Full or All Features and Basic Features. Action<Person> manipulator.
- AssemblyStatisticsGenerator (Namespaces,Classes,Interfaces,Enums) Count, ReferencedAssemblies?
- Generate class overview for other classes which are not an entity.
- Entities: Genre, Artist, Album, Sampler, Movie, Book.
- MarkdownExtension
  - static public void Link(this Uri uri, string strToolTip=null) und dann wenn null WebClient.Download getTitle ?
  - static public void Image(this string strFilename,string alt=null,string placeholder,bool footnote mit alt)?
- Erstellung und Verlinkung der Beispiele.
- RatioHelper.
- Aus world.sqlite die Villages, Cities and Towns extrahieren.
- DataTable Extension mit
  - `ReAssign` - convert an string column to an enumeration column, or an string colum to an user defined datetime (Func<> as parameter).
  - `ReCode` - convert enumerations to there int values or strings to soundex, methaphone, md5, ...
- Money (Currency)
  - Dollar
  - Euro
- Temperature (https://de.wikipedia.org/wiki/Temperatur)
  - Kelivin
  - Fahrenheit
  - Celcius
- Speed (m/s, km/h).
- EarthQuakes
- ~~Zoidac als Enum und~~ in DateTime Extension GetZoidac
- Ein kleines GraphModel und erzeugung von diaggraph oder basic yed files ?
- Flatten JSON / XML ?
- Support für aufruf gnuplot für kleinere Diagramme zwischendurch ?
- MatheStuff, z.b geometrische Figuren Rectangle, Circle, und direkt mit ein paar Meßmethoden?
- VCard support ?
- Kleiner einfacher Support für PlantUML?
- List<T> To DataTable
- DataTable To
  -  ASCIITable
  -  CSV
  -  SQLite
  -  Markdown
- Geht sowas mittles Operatorenüberladung : DataTable["HalfWidth"] = DataTable["Width"] >> 1 <br/>
  > Persons["WeightGram"] = Persons["Weight"] * 1e3
- Countries (aus geonames oder gadm generiert)
- Dienstgrade Feuerwehr, Polizei, Militär ?
- List<T> bei Object mit DateTime:
    - SortedList<T> GetItems[Day?,Month?,Year?](List<T> list) <br/>
      > ? bedeutet immer kann null sein, z.B.: GetItems<Person>(null,null,1974), oder GetItems<Person>(null,10,null)
    - SortedList<T> GetItems[Week?,Year?](List<T> list) <br/>
      > Entweder ist in T nur ein DateTime, oder Date drinn, oder ich muss das Property als Argument übergeben, oder das Property hat ein Attribut welches gecheckt werden kann
    - Split by Year: SortedDictionary<Year> SplitByYear(persons);
    - Split by Month: SortedDictionary<Month> SplitByMonth(persons);


## Done

- ExampleAttribute weg
- Remove all GetHashCode implementations.
- ~~Implement Observer Pattern in base class Entity?~~
- ~~Generic Singelton Pattern?~~
- ~~Lazy Load Wrapper?~~
- Entites for EMail, Homepage, Phone.
- GeoConvert für Lat, Lon und Alt.
- ~~StandardValidator als Attribute für EMail, Phone, Name, aber auch ein Interface Validate um komplexere zusammenhänge validieren zu können.~~
- HairColor und EyeColor als Enumeration mit Standardfarben.
- ~~Feature WizardSupportool mit fragen / antworten wie bei erstellen dotnet init, oder anderen tools ?~~
- Für später: DataTypesColumnAligments als statische klasse mit einer funktion `TextAlign GetAligment(Type t)`
- Anfangen mit Gramm, Meter, ...
- ~~Try to create one big class diagram with PlantUML.~~
  > Currently with the avaible methods it is not possible because the itereate everytime from bottom to top, so that some classes
  > we have more than once!
- ~~Another BaseType for ValueTypes ?~~
  > I forgotten reason why todo this?
- Subfolder for the extension `Format`, `Database`, ...
- Entity vs. Model, unify, prefer Entity (don't forget to rename the namespaces, too).
- New Attribute Link, referes to articels for further information. No Links in the Description, check in the unit tests...
- ~~Class Color mit allen Aufzählungen aus System.Drawing.Color, sowie ToHex, ToHtml, FromHex, FromHTML, ...~~
  > System.Drawing.Color ist unter .bet core verfügbar.
- ~~Colors -> an enumeration lie System.Drawing.Color, but without an reference to System.Drawing.dll~~
  > Check if we can use the original System.Drawing.Color under linux, then it make no sense to create a new implementation.
- Die Beispiele müssen schon irgendwie in den EntityModels verlinkt oder inline sein, um besser zu verstehen was ich mit dem Entity machen kann. Gerade bei Date, Time und sowas, auch mit den operatoren, ....
- Hash + Crypt + Password Class
- Attributes 
  - `[Example(Source="RatatuiExample.cs")]` mit Verweis auf Beispiel , kann dann in der generierten Doku direkt als inline mit ran gezogen oder einfach nur verlinkkt werden.
  - ~~`[UnitTest(Source="")]` mit Verweis auf den UnitTest. Aber warum nochmal hatte ich die Idee ?~~
- Wie bekommt man bei .net core die CodeCoverage raus ? Über VisualStudio ?
  > Plugin für die IDE
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

<hr style="background: blue;" />