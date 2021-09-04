﻿using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools
{
    [Description("")]
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
