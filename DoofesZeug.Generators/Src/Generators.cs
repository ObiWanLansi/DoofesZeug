using DoofesZeug.Documentation;
using DoofesZeug.SourceCode;



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
            ModelBuilderPattern.Generate();
            ProfessionsBuilder.Generate();

            GenerateModelOverview.Generate();
            GenerateEnumerationsOverview.Generate();
            GenerateBuilderOverview.Generate();
        }
    }
}
