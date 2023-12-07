using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



namespace DoofesZeug.Extensions.Formats;

public static class XmlExtension
{
    public static string ToPrettyXml( this object o )
    {
        using MemoryStream ms = new();

        using( XmlTextWriter xmlwriter = new(ms, Encoding.GetEncoding("ISO-8859-1")) )
        {
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.Indentation = 4;

            new XmlSerializer(o.GetType()).Serialize(xmlwriter, o);
        }

        return Encoding.Default.GetString(ms.GetBuffer());
    }
}
