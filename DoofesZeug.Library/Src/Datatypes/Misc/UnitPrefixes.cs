using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Datatypes.Misc
{
    [Description("All our metric prefixes in everyday use (https://en.wikipedia.org/wiki/Unit_prefix).")]
    public static class UnitPrefixes
    {
        /// <summary>
        /// The exa
        /// </summary>
        public static readonly UnitPrefix Exa = new UnitPrefix("Exa", "E", 1e18);

        /// <summary>
        /// The peta
        /// </summary>
        public static readonly UnitPrefix Peta = new UnitPrefix("Peta", "P", 1e15);

        /// <summary>
        /// The tera
        /// </summary>
        public static readonly UnitPrefix Tera = new UnitPrefix("Tera", "T", 1e12);

        /// <summary>
        /// The giga
        /// </summary>
        public static readonly UnitPrefix Giga = new UnitPrefix("Giga", "G", 1e9);

        /// <summary>
        /// The mega
        /// </summary>
        public static readonly UnitPrefix Mega = new UnitPrefix("Mega", "M", 1e6);

        /// <summary>
        /// The kilo
        /// </summary>
        public static readonly UnitPrefix Kilo = new UnitPrefix("Kilo", "k", 1e3);

        /// <summary>
        /// The default
        /// </summary>
        public static readonly UnitPrefix Base = new UnitPrefix("Base", "", 1);

        /// <summary>
        /// The milli
        /// </summary>
        public static readonly UnitPrefix Milli = new UnitPrefix("Milli", "m", 1e-3);

        /// <summary>
        /// The mikro
        /// </summary>
        public static readonly UnitPrefix Mikro = new UnitPrefix("Mikro", "µ", 1e-6);

        /// <summary>
        /// The nano
        /// </summary>
        public static readonly UnitPrefix Nano = new UnitPrefix("Nano", "n", 1e-9);

        /// <summary>
        /// The piko
        /// </summary>
        public static readonly UnitPrefix Piko = new UnitPrefix("Piko", "p", 1e-12);

        /// <summary>
        /// The femto
        /// </summary>
        public static readonly UnitPrefix Femto = new UnitPrefix("Femto", "f", 1e-15);

        /// <summary>
        /// The atto
        /// </summary>
        public static readonly UnitPrefix Atto = new UnitPrefix("Atto", "a", 1e-18);
    }
}