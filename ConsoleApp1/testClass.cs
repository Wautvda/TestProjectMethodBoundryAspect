using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ConsoleApp1.Steps;

namespace ConsoleApp1
{
    public class TestClass
    {
        [AOPWeaver]
        public static string SerializeXml<T>(T objectToSerialize) where T : class
        {
            return SerializeXml(objectToSerialize, new SerializationOptions());
        }

        [AOPWeaver]
        public static string SerializeXml<T>(T objectToSerialize, SerializationOptions options) where T : class
        {
            var type = typeof(T);

            var serializer = new XmlSerializer(type);
            using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, options.GetXmlWriterSettings()))
                {
                    serializer.Serialize(writer, objectToSerialize);
                    return stringWriter.ToString();
                }
            }
        }

        public Routing GetRoutingConfiguration()
        {
            return
                new Routing(
                    //RoutingXml
                    SerializeXml(
                        new RoutingModel
                        {
                            Steps = new List<Step>(new RoutingStep[]
                            {
                                new ValidationStep
                                {
                                    PerformBusinessValidation = true,
                                    PerformTransportValidation = true
                                },
                                new As4ClientStep {DestinationType = RoutingStepDestinationType.AP},
                                new TerminatorStep()
                            })
                        }
                    ),
                    //ErrorXml
                    SerializeXml(
                        new RoutingModel
                        {
                            Steps = new List<Step>(new RoutingStep[]
                            {
                                new As4ClientStep {DestinationType = RoutingStepDestinationType.NA},
                                new TerminatorStep()
                            })
                        }
                    ),
                    //ExceptionXml 
                    SerializeXml(
                        new RoutingModel
                        {
                            Steps = new List<Step>(new RoutingStep[]
                            {
                                new ExceptionHandlerStep()
                            })
                        }
                    )
                );
        }
    }

    internal sealed class StringWriterWithEncoding : StringWriter
    {
        public override Encoding Encoding { get; }

        public StringWriterWithEncoding(Encoding encoding)
        {
            Encoding = encoding;
        }
    }
}
