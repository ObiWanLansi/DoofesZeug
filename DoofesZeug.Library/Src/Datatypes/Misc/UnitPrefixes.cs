using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Datatypes.Misc
{
    [Description("All our metric prefixes in everyday use.")]
    [Link("https://en.wikipedia.org/wiki/Unit_prefix")]
    public static class UnitPrefixes
    {
        /// <summary>
        /// The exa
        /// </summary>
        public static readonly UnitPrefix Exa = new("Exa", "E", 1e18);

        /// <summary>
        /// The peta
        /// </summary>
        public static readonly UnitPrefix Peta = new("Peta", "P", 1e15);

        /// <summary>
        /// The tera
        /// </summary>
        public static readonly UnitPrefix Tera = new("Tera", "T", 1e12);

        /// <summary>
        /// The giga
        /// </summary>
        public static readonly UnitPrefix Giga = new("Giga", "G", 1e9);

        /// <summary>
        /// The mega
        /// </summary>
        public static readonly UnitPrefix Mega = new("Mega", "M", 1e6);

        /// <summary>
        /// The kilo
        /// </summary>
        public static readonly UnitPrefix Kilo = new("Kilo", "k", 1e3);

        /// <summary>
        /// The default
        /// </summary>
        public static readonly UnitPrefix Base = new("Base", "", 1);

        /// <summary>
        /// The centi
        /// </summary>
        public static readonly UnitPrefix Centi = new("Centi", "c", 1e-2);

        /// <summary>
        /// The milli
        /// </summary>
        public static readonly UnitPrefix Milli = new("Milli", "m", 1e-3);

        /// <summary>
        /// The mikro
        /// </summary>
        public static readonly UnitPrefix Mikro = new("Mikro", "µ", 1e-6);

        /// <summary>
        /// The nano
        /// </summary>
        public static readonly UnitPrefix Nano = new("Nano", "n", 1e-9);

        /// <summary>
        /// The piko
        /// </summary>
        public static readonly UnitPrefix Piko = new("Piko", "p", 1e-12);

        /// <summary>
        /// The femto
        /// </summary>
        public static readonly UnitPrefix Femto = new("Femto", "f", 1e-15);

        /// <summary>
        /// The atto
        /// </summary>
        public static readonly UnitPrefix Atto = new("Atto", "a", 1e-18);
    }
}