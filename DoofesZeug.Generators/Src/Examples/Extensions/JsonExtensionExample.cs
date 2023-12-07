using System;

using DoofesZeug.Entities.Specieses;
using DoofesZeug.Entities.Specieses.Human;
using DoofesZeug.Extensions;
using DoofesZeug.Extensions.Formats;



namespace DoofesZeug.Examples.Extensions;

public static class JsonExtensionExample
{
    public static void ConvertPlainJsonStringToReadableJsonString()
    {
        string strPlainJson = "{\"DateOfBirth\":\"25.05.1942\",\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Gender\":\"Male\",\"Handedness\":\"Both\",\"Profession\":{\"Id\":\"ceff8acd-0e3b-41a0-83c5-b1164e0e6a5e\",\"WellKnownProfessionType\":\"PoliceOfficer\",\"Since\":\"15.10.1969\"},\"Id\":\"ee8803f8-2444-4b19-917f-6b5a7e443697\"}";
        string strReadableJson = strPlainJson.ToReadableJson();

        Console.Out.WriteLineAsync(strReadableJson);
    }


    public static void ConvertEntityToPlainJson()
    {
        Person person = new()
        {
            LastName = "Maier",
            FirstName = "Marlene",
            Gender = Gender.Female,
            Handedness = Handedness.Left,
            DateOfBirth = (15, 12, 1978)
        };

        string strPlainJson = person.ToJson();

        Console.Out.WriteLineAsync(strPlainJson);
    }


    public static void ConvertEntityToPrettyJson()
    {
        Person person = new()
        {
            LastName = "Maier",
            FirstName = "Marlene",
            Gender = Gender.Female,
            Handedness = Handedness.Left,
            DateOfBirth = (15, 12, 1978)
        };

        string strPlainJson = person.ToPrettyJson();

        Console.Out.WriteLineAsync(strPlainJson);
    }


    public static void ConvertJsonToEntity()
    {
        string strJson = "{\"DateOfBirth\":\"25.05.1942\",\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Gender\":\"Male\",\"Handedness\":\"Both\",\"Profession\":{\"Id\":\"ceff8acd-0e3b-41a0-83c5-b1164e0e6a5e\",\"WellKnownProfessionType\":\"PoliceOfficer\",\"Since\":\"15.10.1969\"},\"Id\":\"ee8803f8-2444-4b19-917f-6b5a7e443697\"}";

        Person clone = strJson.FromJson<Person>();

        Console.Out.WriteLineAsync(clone.ToStringTable());
    }
}
