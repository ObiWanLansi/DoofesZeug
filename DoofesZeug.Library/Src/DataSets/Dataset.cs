using System;
using System.Collections.Generic;

using DoofesZeug.Container;
using DoofesZeug.Extensions;



namespace DoofesZeug.DataSets
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Dataset
    {
        /// <summary>
        /// The names female
        /// </summary>
        public static readonly StringSet NUMBER_SPOKEN = new()
        {
            "Null",
            "Eins",
            "Zwei",
            "Drei",
            "Vier",
            "Fünf",
            "Sechs",
            "Sieben",
            "Acht",
            "Neun"
        };


        /// <summary>
        /// The names female
        /// </summary>
        public static readonly StringSet NAMES_FEMALE = new()
        {
            "Erna",
            "Paula",
            "Monika",
            "Hildegard",
            "Sabine",
            "Anke",
            "Gerda",
            "Erika",
            "Magdalena",
            "Nicole",
            "Sylvia",
            "Mathilde",
            "Hanna",
            "Jennifer",
            "Gabriele",
            "Sonja",
            "Frederike"
        };

        /// <summary>
        /// The names male
        /// </summary>
        public static readonly StringSet NAMES_MALE = new()
        {
            "Ernst",
            "Paul",
            "Stefan",
            "Werner",
            "Sebastian",
            "Arno",
            "Thomas",
            "Lars",
            "Sven",
            "Heiko",
            "Hugo",
            "Vin",
            "Jörg",
            "Michael",
            "Rolf",
            "Franz"
        };

        /// <summary>
        /// The surname
        /// </summary>
        public static readonly StringSet SURNAME = new()
        {
            "Meier",
            "Müller",
            "Schmidt",
            "Lanser",
            "Zimmermann",
            "Maier",
            "Hansen",
            "Jung",
            "Schweinsteiger",
            "Bertram",
            "Weber",
            "Wagner",
            "Koch",
            "Bauer",
            "Wolf",
            "Schulz"
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// The bundeslaender
        /// </summary>
        public static readonly StringSet BUNDESLAENDER = new()
        {
            "Baden-Württemberg",
            "Bayern",
            "Berlin",
            "Brandenburg",
            "Bremen",
            "Hamburg",
            "Hessen",
            "Mecklenburg-Vorpommern",
            "Niedersachsen",
            "Nordrhein-Westfalen",
            "Rheinland-Pfalz",
            "Saarland",
            "Sachsen",
            "Sachsen-Anhalt",
            "Schleswig-Holstein",
            "Thüringen"
        };

        /// <summary>
        /// The regierungsbezirke
        /// </summary>
        public static readonly StringSet REGIERUNGSBEZIRKE = new()
        {
            "Arnsberg",
            "Berlin",
            "Brandenburg",
            "Braunschweig",
            "Bremen",
            "Chemnitz",
            "Darmstadt",
            "Dessau",
            "Detmold",
            "Dresden",
            "Düsseldorf",
            "Freiburg",
            "Gießen",
            "Halle",
            "Hamburg",
            "Hannover",
            "Karlsruhe",
            "Kassel",
            "Koblenz",
            "Köln",
            "Leipzig",
            "Luneburg",
            "Magdeburg",
            "Mecklenburg-Vorpommern",
            "Mittelfranken",
            "Munster",
            "Niederbayern",
            "Oberbayern",
            "Oberfranken",
            "Oberpfalz",
            "Rheinhessen-Pfalz",
            "Saarland",
            "Schleswig-Holstein",
            "Schwaben",
            "Stuttgart",
            "Thüringen",
            "Trier",
            "Tübingen",
            "Unterfranken",
            "Weser-Ems"
        };

        /// <summary>
        /// The landkreise
        /// </summary>
        public static readonly StringSet LANDKREISE = new()
        {
            "Aachen",
            "Aachen Städte",
            "Ahrweiler",
            "Aichach-Friedberg",
            "Alb-Donau",
            "Altenburger Land",
            "Altenkirchen",
            "Altmarkkreis Salzwedel",
            "Altötting",
            "Alzey-Worms",
            "Amberg Städte",
            "Amberg-Sulzbach",
            "Ammerland",
            "Anhalt-Zerbst",
            "Annaberg",
            "Ansbach",
            "Ansbach Städte",
            "Aschaffenburg",
            "Aschaffenburg Städte",
            "Aschersleben-Staßfurt",
            "Aue-Schwarzenberg",
            "Augsburg",
            "Augsburg Städte",
            "Aurich",
            "Bad Doberan",
            "Bad Dürkheim",
            "Bad Kissingen",
            "Bad Kreuznach",
            "Bad Tölz-Wolfratshausen",
            "Baden-Baden Städte",
            "Bamberg",
            "Bamberg Städte",
            "Barnim",
            "Bautzen",
            "Bayreuth",
            "Bayreuth Städte",
            "Berchtesgadener Land",
            "Bergstraße",
            "Berlin",
            "Bernburg",
            "Bernkastel-Wittlich",
            "Biberach",
            "Bielefeld Städte",
            "Birkenfeld",
            "Bitburg-Prüm",
            "Bitterfeld",
            "Bochum Städte",
            "Bodensee",
            "Bonn Städte",
            "Borken",
            "Bottrop Städte",
            "Brandenburg an der Havel Städte",
            "Braunschweig Städte",
            "Breisgau-Hochschwarzwald",
            "Bremen Städte",
            "Burgenlandkreis",
            "Böblingen",
            "Bördekreis",
            "Calw",
            "Celle",
            "Cham",
            "Chemnitz Städte",
            "Chemnitzer Land",
            "Cleves",
            "Cloppenburg",
            "Coburg",
            "Coburg Städte",
            "Cochem-Zell",
            "Coesfeld",
            "Cologne Städte",
            "Cottbus Städte",
            "Cuxhaven",
            "Dachau",
            "Dahme-Spreewald",
            "Darmstadt Städte",
            "Darmstadt-Dieburg",
            "Deggendorf",
            "Delitzsch",
            "Demmin",
            "Dessau Städte",
            "Diepholz",
            "Dillingen",
            "Dingolfing-Landau",
            "Dithmarschen",
            "Donau-Ries",
            "Donnersbergkreis",
            "Dortmund Städte",
            "Dresden Städte",
            "Duisburg Städte",
            "Döbeln",
            "Düren",
            "Düsseldorf Städte",
            "Ebersberg",
            "Eichsfeld",
            "Eichstätt",
            "Elbe-Elster",
            "Emden Städte",
            "Emmendingen",
            "Emsland",
            "Ennepe-Ruhr",
            "Enz",
            "Erding",
            "Erfurt Städte",
            "Erlangen Städte",
            "Erlangen-Höchstadt",
            "Essen Städte",
            "Esslingen",
            "Euskirchen",
            "Flensburg Städte",
            "Forchheim",
            "Frankenthal Städte",
            "Frankfurt am Main Städte",
            "Frankfurt am Oder Städte",
            "Freiberg",
            "Freiburg",
            "Freising",
            "Freudenstadt",
            "Freyung-Grafenau",
            "Friesland",
            "Fulda",
            "Fürstenfeldbruck",
            "Fürth",
            "Fürth Städte",
            "Garmisch-Partenkirchen",
            "Gelsenkirchen Städte",
            "Gera Städte",
            "Germersheim",
            "Gießen",
            "Gifhorn",
            "Goslar",
            "Gotha",
            "Grafschaft Bentheim",
            "Greifswald Städte",
            "Greiz",
            "Groß-Gerau",
            "Göppingen",
            "Görlitz Städte",
            "Göttingen",
            "Günzburg",
            "Güstrow",
            "Gütersloh",
            "Hagen Städte",
            "Halberstadt",
            "Halle Städte",
            "Hamburg Städte",
            "Hamelin-Pyrmont",
            "Hamm Städte",
            "Hanover",
            "Harburg",
            "Havelland",
            "Haßberge",
            "Heidelberg Städte",
            "Heidenheim",
            "Heilbronn",
            "Heilbronn Städte",
            "Heinsberg",
            "Helmstedt",
            "Herford",
            "Herne Städte",
            "Hersfeld-Rotenburg",
            "Hildburghausen",
            "Hildesheim",
            "Hochsauerlandkreis",
            "Hochtaunuskreis",
            "Hof",
            "Hof Städte",
            "Hohenlohe",
            "Holzminden",
            "Höxter",
            "Ilm-Kreis",
            "Ingolstadt Städte",
            "Jena Städte",
            "Jerichower Land",
            "Kaiserslautern",
            "Kaiserslautern Städte",
            "Kamenz",
            "Karlsruhe",
            "Karlsruhe Städte",
            "Kassel",
            "Kassel Städte",
            "Kaufbeuren Städte",
            "Kelheim",
            "Kempten Städte",
            "Kiel Städte",
            "Kitzingen",
            "Koblenz Städte",
            "Konstanz",
            "Krefeld Städte",
            "Kronach",
            "Kulmbach",
            "Kusel",
            "Kyffhäuserkreis",
            "Köthen",
            "Lahn-Dill-Kreis",
            "Landau Städte",
            "Landsberg",
            "Landshut",
            "Landshut Städte",
            "Lauenburg",
            "Leer",
            "Leipzig Städte",
            "Leipziger Land",
            "Leverkusen Städte",
            "Lichtenfels",
            "Limburg-Weilburg",
            "Lindau",
            "Lippe",
            "Ludwigsburg",
            "Ludwigshafen Städte",
            "Ludwigslust",
            "Löbau-Zittau",
            "Lörrach",
            "Lübeck Städte",
            "Lüchow-Dannenberg",
            "Lüneburg",
            "Magdeburg Städte",
            "Main-Kinzig-Kreis",
            "Main-Spessart",
            "Main-Tauber",
            "Main-Taunus-Kreis Städte",
            "Mainz Städte",
            "Mainz-Bingen",
            "Mannheim Städte",
            "Mansfelder Land",
            "Marburg-Biedenkopf",
            "Mayen-Koblenz",
            "Mecklenburg-Strelitz",
            "Meißen",
            "Memmingen Städte",
            "Merseburg-Querfurt",
            "Merzig-Wadern",
            "Mettmann",
            "Miesbach",
            "Miltenberg",
            "Minden-Lübbecke",
            "Mittlerer Erzgebirgskreis",
            "Mittweida",
            "Muldentalkreis",
            "München Städte",
            "Märkisch-Oderland",
            "Märkischer Kreis",
            "Mönchengladbach Städte",
            "Mühldorf",
            "Mülheim Städte",
            "München",
            "Münster Städte",
            "Müritz",
            "Neckar-Odenwald-Kreis",
            "Neu-Ulm",
            "Neubrandenburg Städte",
            "Neuburg-Schrobenhausen",
            "Neumarkt",
            "Neumünster Städte",
            "Neunkirchen",
            "Neustadt",
            "Neustadt Städte",
            "Neustadt-Bad Windsheim",
            "Neuwied",
            "Niederschlesischer Oberlausitzkreis",
            "Nienburg",
            "Nordfriesland",
            "Nordhausen",
            "Nordvorpommern",
            "Nordwestmecklenburg",
            "Northeim",
            "Nuremberg Städte",
            "Nürnberger Land",
            "Oberallgäu",
            "Oberbergischer Kreis",
            "Oberhausen Städte",
            "Oberhavel",
            "Oberspreewald-Lausitz",
            "Odenwaldkreis",
            "Oder-Spree",
            "Offenbach",
            "Offenbach am Main Städte",
            "Ohrekreis",
            "Oldenburg",
            "Oldenburg Städte",
            "Olpe",
            "Ortenaukreis",
            "Osnabrück",
            "Osnabrück Städte",
            "Ostalbkreis",
            "Ostallgäu",
            "Osterholz",
            "Osterode",
            "Ostholstein",
            "Ostprignitz-Ruppin",
            "Ostvorpommern",
            "Paderborn",
            "Parchim",
            "Passau",
            "Passau Städte",
            "Peine",
            "Pfaffenhofen",
            "Pforzheim Städte",
            "Pinneberg",
            "Plauen Städte",
            "Plön",
            "Potsdam Städte",
            "Potsdam-Mittelmark",
            "Prignitz",
            "Quedlinburg",
            "Rastatt",
            "Ravensburg",
            "Recklinghausen",
            "Regen",
            "Regensburg",
            "Regensburg Städte",
            "Rems-Murr-Kreis",
            "Remscheid Städte",
            "Rendsburg-Eckernförde",
            "Reutlingen",
            "Rhein-Erft-Kreis",
            "Rhein-Hunsrück",
            "Rhein-Kreis Neuss",
            "Rhein-Lahn",
            "Rhein-Neckar-Kreis",
            "Rhein-Pfalz-Kreis",
            "Rhein-Sieg",
            "Rheingau-Taunus-Kreis",
            "Rheinisch-Bergischer Kreis",
            "Rhön-Grabfeld",
            "Riesa-Großenhain",
            "Rosenheim",
            "Rosenheim Städte",
            "Rostock Städte",
            "Rotenburg",
            "Roth",
            "Rottal-Inn",
            "Rottweil",
            "Rügen",
            "Saale-Holzland",
            "Saale-Orla",
            "Saalfeld-Rudolstadt",
            "Saalkreis",
            "Saarbrücken Städte",
            "Saarlouis",
            "Saarpfalz",
            "Salzgitter Städte",
            "Sangerhausen",
            "Sankt Wendel",
            "Schaumburg",
            "Schleswig-Flensburg",
            "Schmalkalden-Meiningen",
            "Schwabach Städte",
            "Schwalm-Eder-Kreis",
            "Schwandorf",
            "Schwarzwald-Baar-Kreis",
            "Schweinfurt",
            "Schweinfurt Städte",
            "Schwerin Städte",
            "Schwäbisch Hall",
            "Schönebeck",
            "Segeberg",
            "Siegen-Wittgenstein",
            "Sigmaringen",
            "Soest",
            "Solingen Städte",
            "Soltau-Fallingbostel",
            "Sonneberg",
            "Speyer Spires Städte",
            "Spree-Neiße",
            "Stade",
            "Starnberg",
            "Steinburg",
            "Steinfurt",
            "Stendal",
            "Stollberg",
            "Stormarn",
            "Stralsund Städte",
            "Straubing Städte",
            "Straubing-Bogen",
            "Stuttgart Städte",
            "Suhl Städte",
            "Sächsische Schweiz",
            "Sömmerda",
            "Südliche Weinstraße",
            "Südwestpfalz",
            "Teltow-Fläming",
            "Tirschenreuth",
            "Torgau-Oschatz",
            "Traunstein",
            "Trier Städte",
            "Trier-Saarburg",
            "Tuttlingen",
            "Tübingen",
            "Uckermark",
            "Uecker-Randow",
            "Uelzen",
            "Ulm Städte",
            "Unna",
            "Unstrut-Hainich",
            "Unterallgäu",
            "Vechta",
            "Verden",
            "Viersen",
            "Vogelsbergkreis",
            "Vogtlandkreis",
            "Vulkaneifel",
            "Waldeck-Frankenberg",
            "Waldshut",
            "Warendorf",
            "Wartburgkreis",
            "Weiden Städte",
            "Weilheim-Schongau",
            "Weimar Städte",
            "Weimarer Land",
            "Weißenburg-Gunzenhausen",
            "Weißenfels",
            "Weißeritzkreis",
            "Wernigerode",
            "Werra-Meißner-Kreis",
            "Wesel",
            "Wesermarsch",
            "Westerwaldkreis",
            "Wetteraukreis",
            "Wiesbaden Städte",
            "Wilhelmshaven Städte",
            "Wismar Städte",
            "Wittenberg",
            "Wittmund",
            "Wolfenbüttel",
            "Wolfsburg Städte",
            "Worms Städte",
            "Wunsiedel",
            "Wuppertal Städte",
            "Würzburg",
            "Würzburg Städte",
            "Zollernalbkreis",
            "Zweibrücken Städte",
            "Zwickau Städte",
            "Zwickauer Land"
        };


        /// <summary>
        /// The german cities
        /// </summary>
        public static readonly StringSet GERMAN_CITIES = new()
        {
            "Aachen",
            "Augsburg",
            "Bergisch Gladbach",
            "Berlin",
            "Bielefeld",
            "Bochum",
            "Bonn",
            "Bottrop",
            "Braunschweig",
            "Bremen",
            "Bremerhaven",
            "Chemnitz",
            "Cottbus",
            "Darmstadt",
            "Dortmund",
            "Dresden",
            "Duisburg",
            "Düsseldorf",
            "Erfurt",
            "Erlangen",
            "Essen",
            "Frankfurt am Main",
            "Freiburg im Breisgau",
            "Fürth",
            "Gelsenkirchen",
            "Göttingen",
            "Gütersloh",
            "Hagen",
            "Halle (Saale)",
            "Hamburg",
            "Hamm",
            "Hannover",
            "Heidelberg",
            "Heilbronn",
            "Herne",
            "Hildesheim",
            "Ingolstadt",
            "Jena",
            "Kaiserslautern",
            "Karlsruhe",
            "Kassel",
            "Kiel",
            "Koblenz",
            "Krefeld",
            "Köln",
            "Leipzig",
            "Leverkusen",
            "Ludwigshafen am Rhein",
            "Lübeck",
            "Magdeburg",
            "Mainz",
            "Mannheim",
            "Moers",
            "Mönchengladbach",
            "Mülheim an der Ruhr",
            "München",
            "Münster",
            "Neuss",
            "Nürnberg",
            "Oberhausen",
            "Offenbach am Main",
            "Oldenburg",
            "Osnabrück",
            "Paderborn",
            "Pforzheim",
            "Potsdam",
            "Recklinghausen",
            "Regensburg",
            "Remscheid",
            "Reutlingen",
            "Rostock",
            "Saarbrücken",
            "Salzgitter",
            "Siegen",
            "Solingen",
            "Stuttgart",
            "Trier",
            "Ulm",
            "Wiesbaden",
            "Wolfsburg",
            "Wuppertal",
            "Würzburg"
        };


        /// <summary>
        /// The europe countries
        /// </summary>
        public static readonly StringSet EUROPE_COUNTRIES = new()
        {
            "Albanien",
            "Andorra",
            "Belgien",
            "Bosnien und Herzegowina",
            "Bulgarien",
            "Deutschland",
            "Dänemark",
            "Estland",
            "Finnland",
            "Frankreich",
            "Griechenland",
            "Irland",
            "Island",
            "Italien",
            "Kasachstan",
            "Kosovo",
            "Kroatien",
            "Lettland",
            "Liechtenstein",
            "Litauen",
            "Luxemburg",
            "Malta",
            "Monaco",
            "Montenegro",
            "Niederlande",
            "Nordmazedonien",
            "Norwegen",
            "Österreich",
            "Polen",
            "Portugal",
            "Republik Moldau",
            "Rumänien",
            "Russland",
            "San Marino",
            "Schweden",
            "Schweiz",
            "Serbien",
            "Slowakei",
            "Slowenien",
            "Spanien",
            "Türkei",
            "Tschechien",
            "Ukraine",
            "Ungarn",
            "Vatikanstadt",
            "Vereinigtes Königreich",
            "Weißrussland"
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the number list.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="stop">The stop.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static List<float> GetNumberList( float start, float stop, float step = 1 )
        {
            List<float> lValues = new((int) ( stop - start ));

            for( float fCounter = start ; fCounter <= stop ; fCounter += step )
            {
                lValues.Add(fCounter);
            }

            return lValues;
        }


        /// <summary>
        /// Gets the number list.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="stop">The stop.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static List<double> GetNumberList( double start, double stop, double step = 1 )
        {
            List<double> lValues = new((int) ( stop - start ));

            for( double fCounter = start ; fCounter <= stop ; fCounter += step )
            {
                lValues.Add(fCounter);
            }

            return lValues;
        }


        /// <summary>
        /// Gets the range number list.
        /// </summary>
        /// <param name="start">The i start.</param>
        /// <param name="stop">The i stop.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        public static List<int> GetNumberList( int start, int stop, int step = 1 )
        {
            List<int> lValues = new(stop - start);

            for( int iCounter = start ; iCounter <= stop ; iCounter += step )
            {
                lValues.Add(iCounter);
            }

            return lValues;
        }


        /// <summary>
        /// Gets the ordered number list.
        /// </summary>
        /// <param name="iNumberCount">The i number count.</param>
        /// <returns></returns>
        public static List<int> GetNumberList( int iNumberCount )
        {
            List<int> lValues = new(iNumberCount);

            for( int iCounter = 0 ; iCounter < iNumberCount ; iCounter++ )
            {
                lValues.Add(iCounter);
            }

            return lValues;
        }


        /// <summary>
        /// Gets the random number list.
        /// </summary>
        /// <param name="iNumberCount">The i number count.</param>
        /// <param name="iMinValue">The i minimum value.</param>
        /// <param name="iMaxValue">The i maximum value.</param>
        /// <returns></returns>
        public static List<int> GetRandomNumberList( int iNumberCount, int iMinValue, int iMaxValue )
        {
            Random r = new();

            List<int> lValues = new(iNumberCount);

            for( int iCounter = 0 ; iCounter < iNumberCount ; iCounter++ )
            {
                // Bei uns ist der MaxValue inklusive ...
                lValues.Add(r.Next(iMinValue, iMaxValue + 1));
            }

            return lValues;
        }


        /// <summary>
        /// Gets the prime numbers.
        /// </summary>
        /// <param name="iNumberCount">The i number count.</param>
        /// <returns></returns>
        public static List<int> GetPrimeNumbers( int iNumberCount )
        {
            List<int> lValues = new(iNumberCount);

            for( int iCounter = 0 ; iCounter < iNumberCount ; iCounter++ )
            {
                if( iCounter.IsPrime() == true )
                {
                    lValues.Add(iCounter);
                }
            }

            return lValues;
        }


        /// <summary>
        /// Gets the fibonacci.
        /// </summary>
        /// <param name="iNumberCount">The i number count.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<int> GetFibonacci( int iNumberCount )
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the timeline.
        /// </summary>
        /// <param name="dtStart">The dt start.</param>
        /// <param name="dtEnd">The dt end.</param>
        /// <param name="tsDelta">The ts delta.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Das Startdatum darf nicht größe als das Enddatum sein !</exception>
        public static List<DateTime> GetTimeline( DateTime dtStart, DateTime dtEnd, TimeSpan tsDelta )
        {
            if( dtStart > dtEnd )
            {
                throw new ArgumentException("Das Startdatum darf nicht größe als das Enddatum sein !");
            }

            List<DateTime> lTimeLine = new(9);

            while( dtStart < dtEnd )
            {
                lTimeLine.Add(dtStart);
                dtStart += tsDelta;
            }

            //// Wir gehen beim Endatum von inklusive aus ...
            //lTimeLine.Add( dtStart );

            return lTimeLine;
        }


        /// <summary>
        /// Generiert eine Timeline von dem Startdatum bis zu dem Endatum mit jeweils einem Tag Abstand.
        /// </summary>
        /// <param name="dtStart">The dt start.</param>
        /// <param name="dtEnd">The dt end.</param>
        /// <returns></returns>
        public static List<DateTime> GetTimeline( DateTime dtStart, DateTime dtEnd ) => GetTimeline(dtStart, dtEnd, new TimeSpan(1, 0, 0, 0));


        /// <summary>
        /// Generiert eine Timeline von dem Startdatum bis zu dem aktuellen Datum mit jeweils einem Tag Abstand.
        /// </summary>
        /// <param name="dtStart">The dt start.</param>
        /// <returns></returns>
        public static List<DateTime> GetTimeline( DateTime dtStart ) => GetTimeline(dtStart, DateTime.Now, new TimeSpan(1, 0, 0, 0));
    }
}
