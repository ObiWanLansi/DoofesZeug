using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Enums
{
    [Description("An generic Priority for stuff like emails, persons, tasks, appointments.")]
    public enum Priority : byte
    {
        /// <summary>
        /// Niedrige Priorität.
        /// </summary>
        Low,

        /// <summary>
        /// Normale Priorität.
        /// </summary>
        Normal,

        /// <summary>
        /// Hohe Priorität.
        /// </summary>
        High
    }
}
