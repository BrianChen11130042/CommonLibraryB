using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Property
{
    public class AmrProperty
    {
        public string Device { get; set; }

        public SetProperty set = new SetProperty();
        public GetProperty get = new GetProperty();
    }

    public class SetProperty
    {

        /// <summary>
        /// <庫位序號, 庫位Sensor訊號判斷有無存在料(有料置1)>
        /// </summary>
        public Dictionary<ushort, ushort> dcOccupy { get; set; } = new Dictionary<ushort, ushort>();

        /// <summary>
        /// <庫位序號, RFID>
        /// </summary>
        public Dictionary<ushort, string> dcRFID { get; set; } = new Dictionary<ushort, string>();

        /// <summary>
        /// <庫位序號, 任務編號>
        /// </summary>
        public Dictionary<ushort, ushort> dcTaskId { get; set; } = new Dictionary<ushort, ushort>();

        public Status status { get; set; } = new Status();

        public ushort missionFinish { get; set; }

        public ushort missionStart { get; set; }

    }

    public class GetProperty
    {
        public ushort missionStart { get; set; }

        public ushort locId { get; set; }

        public Dictionary<int, ushort> dcPortId { get; set; }

        /// <summary>
        /// <庫位序號, 這個料件所綁定的任務編號是否任務取消>
        /// </summary>
        public Dictionary<ushort, bool> dcMissionCancel { get; set; } = new Dictionary<ushort, bool>();

        public MissionInform missionData { get; set; } = new MissionInform();
    }

    public class Status
    {
        public int errorCode { get; set; }
    }

    public class MissionInform
    {
        public bool IsScanRFID { get; set; }

        public ushort taskId { get; set; }

        public string RFID { get; set; }

        public ushort motionType { get; set; }

        public ushort pickLocId { get; set; }

        public ushort pickPortId { get; set; }

        public ushort dropLocId { get; set; }

        public ushort dropPortId { get; set; }
    }
}
