using System;
using System.Xml.Serialization;

namespace ConsoleApp1.Steps
{
    [Serializable]
    public class ExceptionHandlerStep : RoutingStep { }

    [Serializable]
    public class TerminatorStep : RoutingStep
    {
        [XmlElement]
        public RoutingStepMonitoringStatus MonitoringStatus { get; set; }
    }

    [Serializable]
    public class CdmRetrieveStep : RoutingStep
    {
        [XmlElement]
        public ToParty ToParty { get; set; }
    }

    [Serializable]
    public class ValidationStep: RoutingStep
    {
        public bool PerformBusinessValidation { get; set; }
       
        public bool PerformTransportValidation { get; set; }
    }
}
