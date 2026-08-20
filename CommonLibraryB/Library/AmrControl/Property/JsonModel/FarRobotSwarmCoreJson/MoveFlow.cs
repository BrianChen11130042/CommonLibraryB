using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class MoveFlow
    {
        public string flowName { get; set; } = string.Empty;

        public MoveFlowTriggerRequest post { get; set; } = new MoveFlowTriggerRequest();

        public MoveFlowTriggerResponse response { get; set; } = new MoveFlowTriggerResponse();
    }

    #region Post

    public class MoveFlowTriggerRequest
    {
        public MoveFlowRequestArgs args { get; set; } = new MoveFlowRequestArgs();
    }

    public class MoveFlowRequestArgs
    {
        public string start_time { get; set; } = "";

        public string end_time { get; set; } = "";

        public string interval { get; set; } = "";

        public string priority { get; set; } = "";

        [JsonPropertyName("params")]
        public MoveFlowParams Params { get; set; } = new MoveFlowParams();
    }

    public class MoveFlowParams
    {
        [JsonPropertyName("4")]
        public MoveFlowNodeParam Node4 { get; set; } = new MoveFlowNodeParam();
    }

    public class MoveFlowNodeParam
    {
        public string assigned_robot { get; set; } = "";

        public string goal_tynXx { get; set; } = "";
    }

    #endregion

    #region response

    public class MoveFlowTriggerResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = "";

        public MoveFlowSwarmData swarm_data { get; set; } = new MoveFlowSwarmData();
    }

    public class MoveFlowSwarmData
    {
        public string flow_id { get; set; } = "";

        public string reason { get; set; } = "";
    }

    #endregion
}
