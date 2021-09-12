


using DoofesZeug.Attributes.Documentation;

namespace DoofesZeug.Models.Science.Base
{
    [Description("An abstract base class for all other metric values.")]
    public abstract class MetricValueBase<T> : EntityBase
    {
        public T Value { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        protected MetricValueBase()
        {
        }


        protected MetricValueBase( T value ) => this.Value = value;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------




    }
}
