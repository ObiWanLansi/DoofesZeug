using DoofesZeug.Documentation;



namespace DoofesZeug
{
    static class Generators
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main( string [] args )
        {
            GenerateEntityOverview.Generate();
            GenerateEnumerationsOverview.Generate();
        }
    }
}
