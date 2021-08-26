using DoofesZeug.Tools;



namespace DoofesZeug.Models.Human
{
    public class Name
    {
        public string Value { get; init; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private string soundex = null;

        public string Soundex
        {
            get
            {
                if( this.soundex == null )
                {
                    this.soundex = Phonetic.Soundex.Encode(this.Value);
                }
                return this.soundex;
            }
        }


        private string metaphone = null;

        public string Metaphone
        {
            get
            {
                if( this.metaphone == null )
                {
                    this.metaphone = Phonetic.Metaphone.Encode(this.Value);
                }
                return this.metaphone;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Name() { }


        public Name( string value ) => this.Value = value;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator Name( string value ) => new(value);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override string ToString() => this.Value;
    }
}
