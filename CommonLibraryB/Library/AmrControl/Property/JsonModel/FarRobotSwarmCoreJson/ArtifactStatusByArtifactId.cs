using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class ArtifactStatusByArtifactId
    {
        public string artifactId { get; set; } = string.Empty;

        public ArtifactStatusResponse response { get; set; } = new ArtifactStatusResponse();
    }

    public class ArtifactStatusResponse
    {
        public string id { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public ArtifactConfInfo conf_info { get; set; } = new ArtifactConfInfo();

        public Dictionary<string, ArtifactServiceInfo> service { get; set; } = new Dictionary<string, ArtifactServiceInfo>();

        public ArtifactStateInfo state { get; set; } = new ArtifactStateInfo();

        public double last_update_time { get; set; }

        public bool? connection_status { get; set; }
    }

    public class ArtifactConfInfo
    {
        public string version { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        public string category { get; set; } = string.Empty;

        public Dictionary<string, object> capability { get; set; } = new Dictionary<string, object>();
    }

    public class ArtifactServiceInfo
    {
        public ArtifactServiceResponse response { get; set; } = new ArtifactServiceResponse();

    }

    public class ArtifactServiceResponse
    {
        public string status { get; set; } = string.Empty;

        public string response_msg { get; set; } = string.Empty;

        public string request_id { get; set; } = string.Empty;

        public List<object> request_list { get; set; } = new List<object>();
    }

    public class ArtifactStateInfo
    {
        public Dictionary<string, JsonElement> live_info { get; set; } = new Dictionary<string, JsonElement>();

        public string state { get; set; } = string.Empty;
    }
}
