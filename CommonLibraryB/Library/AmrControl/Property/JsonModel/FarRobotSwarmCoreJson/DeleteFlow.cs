using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class DeleteFlow
    {
        public string flowId { get; set; } = string.Empty;

        public DeleteFlowResponse response { get; set; } = new DeleteFlowResponse();
    }

    public class DeleteFlowResponse
    {
        public int system_status_code { get; set; }

        public string system_message { get; set; } = string.Empty;

        public DeleteFlowSwarmData swarm_data { get; set; } = new DeleteFlowSwarmData();
    }

    public class DeleteFlowSwarmData
    {
        public string flow_id { get; set; } = string.Empty;
    }
}
