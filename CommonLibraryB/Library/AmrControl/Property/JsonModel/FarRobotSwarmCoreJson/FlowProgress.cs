using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class FlowProgress
    {
        public FlowProgressResponse response { get; set; } = new FlowProgressResponse();
    }

    public class FlowProgressResponse
    {
        public string req_id { get; set; } = "";

        public FlowProgressData data { get; set; } = new FlowProgressData();
    }

    public class FlowProgressData
    {
        public string flow_id { get; set; } = "";

        public string flow_name { get; set; } = "";

        public string fleet_name { get; set; } = "";

        public int state { get; set; }

        public string state_string { get; set; } = "";

        public double complete_percent { get; set; }

        public long scheduled_timestamp { get; set; }

        public string scheduled_timestring { get; set; } = "";

        public long updated_timestamp { get; set; }

        public string updated_timestring { get; set; } = "";

        public List<string> task_ids { get; set; } = new List<string>();
    }
}
