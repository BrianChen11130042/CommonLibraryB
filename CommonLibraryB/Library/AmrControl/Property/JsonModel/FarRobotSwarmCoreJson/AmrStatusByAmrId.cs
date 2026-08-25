using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class AmrStatusByAmrId
    {
        public string robotId { get; set; } = string.Empty;

        public bool includeArtifact { get; set; } = true;

        public AmrStatusResponse response { get; set; } = new AmrStatusResponse();
    }

    public class AmrStatusResponse
    {
        public List<AmrStatusInfo> robots { get; set; } = new List<AmrStatusInfo>();
    }
    public class AmrStatusInfo
    {
        public string robot_id { get; set; } = string.Empty;

        public string robot_name { get; set; } = string.Empty;

        public string model { get; set; } = string.Empty;

        public int mode { get; set; }

        public AmrCapability? capability { get; set; }

        public string? map { get; set; }

        public string? map_uuid { get; set; }

        public AmrLocation location { get; set; } = new AmrLocation();

        public double localization_confidence { get; set; }

        public double velocity { get; set; }

        public double? mileage { get; set; }

        public string? fleet_name { get; set; }

        public string? role { get; set; }

        public string? task_id { get; set; }

        public double battery_percent { get; set; }

        public double wifi_signal { get; set; }

        public AmrCellularInfo cellular_info { get; set; } = new AmrCellularInfo();
        
        public Dictionary<string, object>? customized_info { get; set; }

        public int connection_status { get; set; }

        public List<AmrEmbeddedArtifact> artifacts { get; set; } = new List<AmrEmbeddedArtifact>();
        
        public string last_update_time { get; set; } = string.Empty;
    }

    public class AmrCapability
    {
        public double speed { get; set; }

        public CellXyz size { get; set; } = new CellXyz();

        public double payload { get; set; }

        public string artifacts_ids { get; set; } = string.Empty;

        public string artifacts_types { get; set; } = string.Empty;

        public string behaviours { get; set; } = string.Empty;

        public string perceptions { get; set; } = string.Empty;
    }

    public class AmrLocation
    {
        public double x { get; set; }

        public double y { get; set; }

        public double yaw { get; set; }
    }

    public class AmrCellularInfo
    {
        public string imei { get; set; } = string.Empty;

        public string imsi { get; set; } = string.Empty;

        public string rsrp { get; set; } = string.Empty;

        public string rsrq { get; set; } = string.Empty;

        public string sinr { get; set; } = string.Empty;

        public string modem_mode { get; set; } = string.Empty;

        public string uim { get; set; } = string.Empty;

        public string pci { get; set; } = string.Empty;
    }

    public class AmrEmbeddedArtifact
    {
        public string id { get; set; } = string.Empty;

        public string type { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public ArtifactStateInfo state { get; set; } = new ArtifactStateInfo();

        public double last_update_time { get; set; }
    }
}
