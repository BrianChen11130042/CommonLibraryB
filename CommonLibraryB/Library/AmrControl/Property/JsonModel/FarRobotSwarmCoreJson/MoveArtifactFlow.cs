using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class MoveArtifactFlow
    {
        public string flowName { get; set; } = string.Empty;

        public MoveArtifactFlowTriggerRequest post { get; set; } = new MoveArtifactFlowTriggerRequest();

        public MoveArtifactFlowTriggerResponse response { get; set; } = new MoveArtifactFlowTriggerResponse();
    }

    #region Post

    public class MoveArtifactFlowTriggerRequest
    {
        public MoveArtifactFlowRequestArgs args { get; set; } = new MoveArtifactFlowRequestArgs();
    }

    public class MoveArtifactFlowRequestArgs
    {
        public string start_time { get; set; } = "";

        public string end_time { get; set; } = "";

        public string interval { get; set; } = "";

        public string priority { get; set; } = "";

        [JsonPropertyName("params")]
        public MoveArtifactFlowParams Params { get; set; } = new MoveArtifactFlowParams();
    }

    public class MoveArtifactFlowParams
    {
        [JsonPropertyName("5")]
        public MoveArtifactFlowNodeParam Node5 { get; set; } = new MoveArtifactFlowNodeParam();
    }

    public class MoveArtifactFlowNodeParam
    {
        public string assigned_robot { get; set; } = "";

        public string goal_dxlVB { get; set; } = "";

        public string artifact_id_0i3II { get; set; } = "";

        public string value_0i3II { get; set; } = "";
    }

    #endregion

    #region Response

    public class MoveArtifactFlowTriggerResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = "";

        public MoveArtifactFlowSwarmData swarm_data { get; set; } = new MoveArtifactFlowSwarmData();
    }

    public class MoveArtifactFlowSwarmData
    {
        public string flow_id { get; set; } = "";

        public string reason { get; set; } = "";
    }

    #endregion
}
