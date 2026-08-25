using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class FlowName
    {
        public string fleetName { get; set; } = string.Empty;

        public FlowNameResponse response { get; set; } = new FlowNameResponse();
    }

    public class FlowNameResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = string.Empty;

        public List<FlowNameSwarmData> swarm_data { get; set; } = new List<FlowNameSwarmData>();
    }

    public class FlowNameSwarmData
    {
        public string fleet_name { get; set; } = string.Empty;

        public List<string> flows { get; set; } = new List<string>();
    }
}
