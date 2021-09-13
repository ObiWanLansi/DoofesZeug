
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class TaxiDriverBuilder
    {
        public static TaxiDriver New() => new();


        public static TaxiDriver WithSince(this TaxiDriver taxidriver, DoofesZeug.Entities.DateAndTime.Date since)
        {
            taxidriver.Since = since;
            return taxidriver;
        }
    }
}
