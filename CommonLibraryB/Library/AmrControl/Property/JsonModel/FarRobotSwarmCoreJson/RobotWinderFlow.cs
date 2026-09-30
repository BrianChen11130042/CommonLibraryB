using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class RobotWinderFlow
    {
        public string flowName { get; set; } = string.Empty;

        public RobotWinderFlowTriggerRequest post { get; set; } = new RobotWinderFlowTriggerRequest();

        public RobotWinderFlowTriggerResponse response { get; set; } = new RobotWinderFlowTriggerResponse();
    }

    public class RobotWinderFlowTriggerRequest
    {
        public RobotWinderFlowRequestArgs args { get; set; } = new RobotWinderFlowRequestArgs();
    }

    public class RobotWinderFlowRequestArgs
    {
        public string start_time { get; set; } = "";

        public string end_time { get; set; } = "";

        public string interval { get; set; } = "";

        public string priority { get; set; } = "";

        [JsonPropertyName("params")]
        public RobotWinderFlowParams Params { get; set; } = new RobotWinderFlowParams();
    }
    public class RobotWinderFlowParams
    {
        [JsonPropertyName("4")]
        public RobotWinderFlowNodeParam Node4 { get; set; } = new RobotWinderFlowNodeParam();
    }

    public class RobotWinderFlowNodeParam
    {
        public string assigned_robot { get; set; } = "";

        public string goal_Oy8t1 { get; set; } = "";

        public string artifact_id_aBJDC { get; set; } = "";

        public string value_aBJDC { get; set; } = "";

        public string artifact_id_hdN6Z { get; set; } = "";

        public string value_hdN6Z { get; set; } = "";

        public string artifact_id_6zfN9 { get; set; } = "";

        public string value_6zfN9 { get; set; } = "";
    }

    public class RobotWinderFlowTriggerResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = "";

        public RobotWinderFlowSwarmData swarm_data { get; set; } = new RobotWinderFlowSwarmData();
    }

    public class RobotWinderFlowSwarmData
    {
        public string flow_id { get; set; } = "";

        public string reason { get; set; } = "";
    }
}
