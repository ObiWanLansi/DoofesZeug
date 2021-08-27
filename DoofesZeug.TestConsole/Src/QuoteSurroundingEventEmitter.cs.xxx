using System;

using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.EventEmitters;



namespace DoofesZeug
{
    public sealed class QuoteSurroundingEventEmitter : ChainedEventEmitter
    {

        private static readonly Type t = typeof(string);

        public QuoteSurroundingEventEmitter( IEventEmitter nextEmitter ) : base(nextEmitter) { }



        public override void Emit( ScalarEventInfo eventInfo, IEmitter emitter )
        {
            if( eventInfo.Source.StaticType == t )
            {
                eventInfo.Style = ScalarStyle.DoubleQuoted;
            }
            
            base.Emit(eventInfo, emitter);
        }
    }
}
