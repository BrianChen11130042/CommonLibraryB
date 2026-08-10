using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class ChargeFlow
    {
        public ChargeFlowTriggerRequest post { get; set; } = new ChargeFlowTriggerRequest();

        public ChargeFlowTriggerResponse response { get; set; } = new ChargeFlowTriggerResponse();
    }

    #region Post

    public class ChargeFlowTriggerRequest
    {
        public ChargeFlowRequestArgs args { get; set; } = new ChargeFlowRequestArgs();
    }

    public class ChargeFlowRequestArgs
    {
        public string start_time { get; set; } = "";

        public string end_time { get; set; } = "";

        public string interval { get; set; } = "";

        public string priority { get; set; } = "";

        [JsonPropertyName("params")]
        public ChargeFlowParams Params { get; set; } = new ChargeFlowParams();
    }

    public class ChargeFlowParams
    {
        [JsonPropertyName("4")]
        public ChargeFlowNodeParam Node4 { get; set; } = new ChargeFlowNodeParam();
    }

    public class ChargeFlowNodeParam
    {
        public string assigned_robot { get; set; } = "";
        public string goal_nUvaT { get; set; } = "";
        public string percentage_nUvaT { get; set; } = "";
    }

    #endregion

    #region Response

    public class ChargeFlowTriggerResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = "";

        public ChargeFlowSwarmData swarm_data { get; set; } = new ChargeFlowSwarmData();
    }

    public class ChargeFlowSwarmData
    {
        public string flow_id { get; set; } = "";

        public string reason { get; set; } = "";
    }

    #endregion
}
