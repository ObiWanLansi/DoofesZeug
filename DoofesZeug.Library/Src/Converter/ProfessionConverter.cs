using System;

using DoofesZeug.Extensions;
using DoofesZeug.Models.DateAndTime;
using DoofesZeug.Models.Specieses.Human.Professions;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace DoofesZeug.Converter
{
    public sealed class ProfessionConverter : JsonConverter
    {
        private static readonly Type PROFESSION = typeof(Profession);

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert( Type objectType ) => objectType.IsAssignableTo(PROFESSION);


        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            JObject jsonObject = JObject.Load(reader);

            string id = null;
            string wkpt = null;
            string since = null;

            foreach( JProperty property in jsonObject.Properties() )
            {
                switch( property.Name )
                {
                    case nameof(Profession.Id):
                        id = (string) property.Value;
                        break;

                    case nameof(Profession.WellKnownProfessionType):
                        wkpt = (string) property.Value;
                        break;

                    case nameof(Profession.Since):
                        since = (string) property.Value;
                        break;

                    default:
                        throw new Exception($"Unknown Property: '{property.Name}'!");
                }
            }

            if( id.IsNotEmpty() && wkpt.IsNotEmpty() )
            {
                Guid guid = Guid.Parse(id);
                WellKnownProfession wkp = (WellKnownProfession) Enum.Parse(typeof(WellKnownProfession), wkpt);
                Date date = null;

                if( since.IsNotEmpty() )
                {
                    date = since;
                }

                // This is a little bit static, i wish to make it more dynamic ...
                return wkp switch
                {
                    WellKnownProfession.FireFighter => new FireFighter { Id = guid, Since = date },
                    WellKnownProfession.PoliceOfficer => new PoliceOfficer { Id = guid, Since = date },
                    WellKnownProfession.Nurse => new Nurse { Id = guid, Since = date },
                    WellKnownProfession.Engineer => new Engineer { Id = guid, Since = date },
                    WellKnownProfession.Doctor => new Doctor { Id = guid, Since = date },
                    WellKnownProfession.HairDresser => new HairDresser { Id = guid, Since = date },
                    WellKnownProfession.Baker => new Baker { Id = guid, Since = date },
                    WellKnownProfession.Waiter => new Waiter { Id = guid, Since = date },
                    WellKnownProfession.Teacher => new Teacher { Id = guid, Since = date },
                    WellKnownProfession.Tiler => new Tiler { Id = guid, Since = date },
                    WellKnownProfession.Carpenter => new Carpenter { Id = guid, Since = date },
                    WellKnownProfession.Soldier => new Soldier { Id = guid, Since = date },
                    WellKnownProfession.BusDriver => new BusDriver { Id = guid, Since = date },
                    WellKnownProfession.TaxiDriver => new TaxiDriver { Id = guid, Since = date },
                    WellKnownProfession.Pilot => new Pilot { Id = guid, Since = date },
                    _ => throw new Exception($"Unimplemented Profession: '{wkp}'!"),
                };
            }

            throw new Exception($"Can't Not Create The Profession From: '{jsonObject}'!");
        }


        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if( value == null )
            {
                writer.WriteNull();
                return;
            }

            Profession profession = (Profession) value;
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(Profession.Id));
            writer.WriteValue(profession.Id);

            writer.WritePropertyName(nameof(Profession.WellKnownProfessionType));
            writer.WriteValue(profession.WellKnownProfessionType.ToString());

            writer.WritePropertyName(nameof(Profession.Since));
            writer.WriteValue(profession.Since.ToString());

            writer.WriteEndObject();
        }
    }
}
