using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using ConsoleApp1.Steps;

namespace ConsoleApp1
{
    [Serializable]
    public class Routing
    {
        //Routing could be modified before it is stored into message context
        public string RoutingXml { get; set; }

        public string ErrorXml { get; }

        public string ExceptionXml { get; }

        public Routing()
        {
            
        }

        public Routing(string routingXml, string errorXml, string exceptionXml)
        {
            RoutingXml = routingXml;
            ErrorXml = errorXml;
            ExceptionXml = exceptionXml;
        }
    }

    [Serializable]
    [XmlRoot(Namespace = "urn:eessi:routing", IsNullable = false, ElementName = "Routing")]
    public class RoutingModel
    {
        [XmlArray("Steps")]
        [XmlArrayItem("As4ClientStep", typeof(As4ClientStep))]
        [XmlArrayItem("TerminatorStep", typeof(TerminatorStep))]
        [XmlArrayItem("ValidationStep", typeof(ValidationStep))]
        [XmlArrayItem("ExceptionHandlerStep", typeof(ExceptionHandlerStep))]

        public List<Step> Steps { get; set; }

        public override string ToString()
        {
            if (Steps != null && Steps.Count > 0)
            {
                return string.Join(", ", Steps.Select(step => $"{step.ToString()} (Status = {step.Status})"));
            }

            return "No steps were defined.";
        }
    }

    [Serializable]
    public class Step
    {
        [XmlAttribute]
        public RoutingStepStatus Status { get; set; }
    }

    [Serializable]
    public enum RoutingStepStatus
    {
        Pending,
        InProgress,
        Completed,
        Error,
        Exception,
        Terminated,
        Ignored
    }
    
    [Serializable]
    public enum RoutingStepType
    {
        Async,
        Sync
    }

    [Serializable]
    public enum RoutingStepDestinationType
    {
        AP,
        NA,
        CSN
    }

    [Serializable]
    public enum  RoutingStepDestinationParty
    {
        To, 
        From
    }

    [Serializable]
    public enum RoutingStepAs4PayloadMode
    {
        PassThrough, 
        ContextBased,
    }

    [Serializable]
    public enum RoutingStepPushConnectionFailureAction
    {
        None,
        Error,
        Exception, 
        EsbRouter,
        Terminate       
    }

    [Serializable]
    public enum RoutingStepPullConnectionFailureAction
    {
        Exception
    }

    [Serializable]
    public enum RoutingStepPushReturnedErrorAction
    {
        None, 
        EsbRouter,
        Error,
        Exception
    }

    [Serializable]
    public enum RoutingStepPushReturnedReceiptAction
    {
        None, 
        Exception, 
        EsbRouter
    }

    [Serializable]
    public enum RoutingStepPushSuccessCriteria
    {
        NoConnectionFailure,
        ReturnedReceipt
    }

    [Serializable]
    public enum RoutingStepMonitoringStatus
    {
        None, 
        Terminated,
        Processed
    }

    [Serializable]
    public enum ToParty
    {
        From
    }

    [Serializable]
    public class RoutingStep : Step
    {
        [XmlAttribute]
        public RoutingStepType Type { get; set; }
        [XmlAttribute]
        public DateTime StartTime { get; set; }
        [XmlAttribute]
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
