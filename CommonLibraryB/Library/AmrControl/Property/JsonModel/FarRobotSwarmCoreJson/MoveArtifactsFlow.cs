using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class MoveArtifactsFlow
    {
        public string flowName { get; set; } = string.Empty;

        public MoveArtifactsFlowTriggerRequest post { get; set; } = new MoveArtifactsFlowTriggerRequest();

        public MoveArtifactsFlowTriggerResponse response { get; set; } = new MoveArtifactsFlowTriggerResponse();
    }

    public class MoveArtifactsFlowTriggerRequest
    {
        public MoveArtifactsFlowRequestArgs args { get; set; } = new MoveArtifactsFlowRequestArgs();
    }

    public class MoveArtifactsFlowRequestArgs
    {
        public string start_time { get; set; } = "";

        public string end_time { get; set; } = "";

        public string interval { get; set; } = "";

        public string priority { get; set; } = "";

        [JsonPropertyName("params")]
        public MoveArtifactsFlowParams Params { get; set; } = new MoveArtifactsFlowParams();
    }

    public class MoveArtifactsFlowParams
    {
        [JsonPropertyName("4")]
        public MoveArtifactsFlowNodeParam Node4 { get; set; } = new MoveArtifactsFlowNodeParam();
    }

    public class MoveArtifactsFlowNodeParam
    {
        public string assigned_robot { get; set; } = "";

        public string goal_MeSfB { get; set; } = "";

        public string artifact_id_cfjoZ { get; set; } = "";

        public string value_cfjoZ { get; set; } = "";

        public string artifact_id_VsQoQ { get; set; } = "";

        public string value_VsQoQ { get; set; } = "";
    }

    #region Response

    public class MoveArtifactsFlowTriggerResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = "";

        public MoveArtifactsFlowSwarmData swarm_data { get; set; } = new MoveArtifactsFlowSwarmData();
    }

    public class MoveArtifactsFlowSwarmData
    {
        public string flow_id { get; set; } = "";

        public string reason { get; set; } = "";
    }

    #endregion
}
