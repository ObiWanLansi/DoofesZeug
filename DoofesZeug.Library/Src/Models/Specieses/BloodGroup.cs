﻿using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Specieses
{
    [Description("An simple enumeration for the bloodgroup of an human.")]
    public enum BloodGroup : byte
    {
        A,
        B,
        AB,
        Zero
    }
}