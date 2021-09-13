
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class WaiterBuilder
    {
        public static Waiter New() => new();


        public static Waiter WithSince(this Waiter waiter, DoofesZeug.Entities.DateAndTime.Date since)
        {
            waiter.Since = since;
            return waiter;
        }
    }
}
