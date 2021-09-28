using System;
using System.IO;
using System.Xml.Serialization;

namespace DesignPatterns2.Cap8
{
    public class GeradorDeXml
    {
        public string GeraXml(object o)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, o);
            return writer.ToString();
        }
    }
}