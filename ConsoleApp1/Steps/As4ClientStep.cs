using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1.Steps
{
    [Serializable]
    public class As4ClientStep : RoutingStep
    {
        public As4ClientStep()
        {
            // Explicitly assign 'False' as default for readability
            PullCanExpire = false;
        }

        [XmlElement]
        public RoutingStepDestinationType DestinationType { get; set; }
        [XmlElement]
        public RoutingStepDestinationParty DestinationParty { get; set; }
        [XmlElement]
        public RoutingStepAs4PayloadMode As4PayloadMode { get; set; }
        [XmlElement]
        public RoutingStepPushConnectionFailureAction PushConnectionFailureAction { get; set; }
        [XmlElement]
        public RoutingStepPullConnectionFailureAction PullConnectionFailureAction { get; set; }
        [XmlElement]
        public RoutingStepPushReturnedErrorAction PushReturnedErrorAction { get; set; }
        [XmlElement]
        public RoutingStepPushReturnedReceiptAction PushReturnedReceiptAction { get; set; }
        [XmlElement]
        public RoutingStepPushSuccessCriteria PushSuccessCriteria { get; set; }
        [XmlElement]
        public bool PerformIntelligentRouting { get; set; }
        [XmlElement]
        public bool PullCanExpire { get; set; }
        [XmlElement]
        public int RoutingPropertyExpirationInHours { get; set; }
    }
}
