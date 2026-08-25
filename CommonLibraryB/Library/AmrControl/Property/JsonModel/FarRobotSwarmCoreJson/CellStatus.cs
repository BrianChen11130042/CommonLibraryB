using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class CellStatus
    {
        public string map_name { get; set; } = string.Empty;
        
        public CellStatusResponse response { get; set; } = new CellStatusResponse();
    }

    public class CellStatusResponse
    {
        public List<CellStatusInfo> cells { get; set; } = new List<CellStatusInfo>();
    }

    public class CellStatusInfo
    {
        public string updater_id { get; set; } = string.Empty;

        public string area_id { get; set; } = string.Empty;

        public string cell_id { get; set; } = string.Empty;

        public string display_name { get; set; } = string.Empty;

        public string map { get; set; } = string.Empty;

        public string map_uuid { get; set; } = string.Empty;

        public CellPose pose { get; set; } = new CellPose();

        public string direction { get; set; } = string.Empty;

        public CellFunctionType function_type { get; set; } = new CellFunctionType();

        public string markers { get; set; } = string.Empty;

        public CellXyz markers_offset { get; set; } = new CellXyz();

        public string status { get; set; } = string.Empty;

        public string load { get; set; } = string.Empty;

        public CellXyz cell_size { get; set; } = new CellXyz();
    }

    public class CellPose
    {
        public CellXyz position { get; set; } = new CellXyz();

        public CellOrientation orientation { get; set; } = new CellOrientation();
    }

    public class CellOrientation
    {
        public double x { get; set; }

        public double y { get; set; }

        public double z { get; set; }

        public double w { get; set; }
    }

    public class CellXyz
    {
        public double x { get; set; }

        public double y { get; set; }

        public double z { get; set; }
    }

    public class CellFunctionType
    {
        public List<string> recognition { get; set; } = new List<string>();

        public string type { get; set; } = string.Empty;

        public string type_name { get; set; } = string.Empty;
    }
}
