using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class SerializationOptions
    {
        public bool OmitXmlDeclaration { get; set; }
        public bool Indent { get; set; }
        public Encoding TextEncoding { get; set; }
        public XmlSerializerNamespaces XmlNamespaces { get; set; }

        public SerializationOptions()
        {
            Indent = false;
            OmitXmlDeclaration = false;
            TextEncoding = Encoding.UTF8;

            XmlNamespaces = new XmlSerializerNamespaces();
        }

        /// <summary>
        /// Get the settings for a XmlWriter
        /// </summary>
        public XmlWriterSettings GetXmlWriterSettings()
        {
            return new XmlWriterSettings
            {
                OmitXmlDeclaration = OmitXmlDeclaration,
                Indent = Indent,
                Encoding = TextEncoding,
                ConformanceLevel = ConformanceLevel.Auto
            };
        }
    }
}
