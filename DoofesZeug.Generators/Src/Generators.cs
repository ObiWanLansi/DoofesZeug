using DoofesZeug.Documentation;
using DoofesZeug.SourceCode;



namespace DoofesZeug
{
    static class Generators
    {
        static void Main( string [] args )
        {
            ModelBuilderPattern.Generate();
            GenerateModelOverview.Generate();
        }
    }
}
