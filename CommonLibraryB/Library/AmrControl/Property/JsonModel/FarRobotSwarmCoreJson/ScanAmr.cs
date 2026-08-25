using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class ScanAmr
    {
        public string mode { get; set; } = string.Empty;

        public string model { get; set; } = string.Empty;

        public ScanAmrResponse response { get; set; } = new ScanAmrResponse();
    }

    public class ScanAmrResponse
    {
        public string req_id { get; set; } = string.Empty;

        public int total { get; set; }

        public List<ScanAmrInfo> robots { get; set; } = new List<ScanAmrInfo>();
    }

    public class ScanAmrInfo
    {
        public string robot_id { get; set; } = string.Empty;

        public string robot_name { get; set; } = string.Empty;

        public string fleet_name { get; set; } = string.Empty;

        public string model { get; set; } = string.Empty;

        public string mode { get; set; } = string.Empty;

        public string sw_version { get; set; } = string.Empty;

        public string ip { get; set; } = string.Empty;

        public string port { get; set; } = string.Empty;

        public string mac { get; set; } = string.Empty;

        public string artifacts { get; set; } = string.Empty;
    }
}
