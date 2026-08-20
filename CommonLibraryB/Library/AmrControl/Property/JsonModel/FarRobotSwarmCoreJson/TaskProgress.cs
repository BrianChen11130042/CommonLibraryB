using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class TaskProgress
    {
        public string taskId { get; set; } = string.Empty;

        public TaskProgressResponse response { get; set; } = new TaskProgressResponse();
    }

    public class TaskProgressResponse
    {
        public string req_id { get; set; } = "";

        public TaskProgressData data { get; set; } = new TaskProgressData();
    }

    public class TaskProgressData
    {
        public string task_id { get; set; } = "";

        public string task_name { get; set; } = "";

        public int state { get; set; }

        public string state_string { get; set; } = "";

        public string priority { get; set; } = "";

        public string robot_id { get; set; } = "";

        public double complete_percent { get; set; }

        public string status_code { get; set; } = "";

        public string status_msg { get; set; } = "";

        public long arrival_timestamp { get; set; }

        public string arrival_timestring { get; set; } = "";

        public long updated_timestamp { get; set; }

        public string updated_timestring { get; set; } = "";
    }
}
