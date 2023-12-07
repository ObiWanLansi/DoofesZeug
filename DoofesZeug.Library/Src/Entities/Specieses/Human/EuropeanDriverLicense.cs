using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.Specieses.Human;

[Description("The european driver licenses.")]
[Link("https://de.wikipedia.org/wiki/F%C3%BChrerschein_(EU-Recht)")]
[Flags]
public enum EuropeanDriverLicense
{
    /// <summary>
    /// Zwei- oder dreirädrige Kraftfahrzeuge mit einer bauartbedingten Höchstgeschwindigkeit von bis zu 45 km/h, bis 4 kW, 50 cm³, bis 270 kg leer.[3] Vierrädrige Leichtkraftfahrzeuge bis 45 km/h, bis 6 kW, bis 50 cm³, bis 425 kg leer.
    /// </summary>
    AM = 1,

    /// <summary>
    /// Krafträder mit einem Hubraum von bis zu 125 cm³ mit einer Motorleistung von bis zu 11 kW (Leichtkrafträder) und einem Leistungsgewicht bis zu 0,1 kW/kg sowie dreirädrige Kraftfahrzeuge mit einer Leistung von bis zu 15 kW.
    /// </summary>
    A1 = 2,

    /// <summary>
    /// Krafträder mit einer Motorleistung von bis zu 35 kW und einem Leistungsgewicht bis zu 0,2 kW/kg, die nicht von einem Fahrzeug mit mehr als der doppelten Motorleistung abgeleitet sind .
    /// </summary>
    A2 = 4,

    /// <summary>
    /// Krafträder über 50 cm³ oder über 45 km/h, auch mit Beiwagen, sowie dreirädrige Kraftfahrzeuge[4] mit einer Leistung von mehr als 15 kW.
    /// </summary>
    A = 8,

    //-------------------------------------------------

    /// <summary>
    /// Mehrspurige Kraftfahrzeuge bis 550 kg Leermasse.
    /// </summary>
    B1 = 16,

    /// <summary>
    /// Mehrspurige Kraftfahrzeuge bis 3,5 t zulässiger Gesamtmasse und maximal 9 Sitzplätzen (einschließlich Fahrer) .
    /// </summary>
    B = 32,

    /// <summary>
    /// Mehrspuriges Kraftfahrzeug bis 7,5 t zulässiger Gesamtmasse, maximal 9 Sitzplätze (einschließlich Fahrer).
    /// </summary>
    C1 = 64,

    /// <summary>
    /// Symbol C.jpg 	Mehrspurige Kraftfahrzeuge über 3,5 t zulässiger Gesamtmasse, maximal 9 Sitzplätze (einschließlich Fahrer).
    /// </summary>
    C = 128,

    /// <summary>
    /// Omnibusse mit bis 17 Sitzplätzen einschließlich Fahrer und höchstens 8 m Länge.
    /// </summary>
    D1 = 256,

    /// <summary>
    /// Omnibusse mit mehr als 9 Sitzplätzen (einschließlich Fahrer).
    /// </summary>
    D = 512,

    //-------------------------------------------------

    /// <summary>
    /// Züge aus B-Zugfahrzeug und Anhänger über 0,75 t zulässiger Gesamtmasse (sofern der Zug nicht unter Klasse B fällt).
    /// </summary>
    BE = 1024,

    /// <summary>
    /// Züge aus C1-Zugfahrzeug und Anhänger über 0,75 t zulässiger Gesamtmasse, sowie Züge aus B-Zugfahrzeug und Anhänger über 3,5 t zulässiger Gesamtmasse.
    /// </summary>
    C1E = 2048,

    /// <summary>
    /// Lastzüge und Sattelkraftfahrzeuge.
    /// </summary>
    CE = 4096,

    /// <summary>
    /// Züge aus D1-Zugfahrzeug und Anhänger mit mehr als 0,75 t zulässiger Gesamtmasse.
    /// </summary>
    D1E = 8192,

    /// <summary>
    /// Züge aus D-Zugfahrzeug und Anhänger mit mehr als 0,75 t zulässiger Gesamtmasse.
    /// </summary>
    DE = 16384,

    //-------------------------------------------------

    /// <summary>
    /// Land- und forstwirtschaftliche Zugmaschinen bis 25 km/h.
    /// </summary>
    L = 32768,

    /// <summary>
    /// Dreirädrige Kleinkrafträder sowie vierrädrige Leichtkraftfahrzeuge bis jeweils 45 km/h.
    /// </summary>
    S = 65536
}
