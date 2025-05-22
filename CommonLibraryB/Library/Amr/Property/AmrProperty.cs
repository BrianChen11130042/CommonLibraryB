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
        public Dictionary<ushort, string> dcRfid { get; set; } = new Dictionary<ushort, string>();

        public RobotStatus robotStatus { get; set; } = new RobotStatus();

        public ushort missionCompleted { get; set; }

        public ushort resetMissionStart { get; set; }

    }

    public class GetProperty
    {
        public ushort missionStarted { get; set; }

        public ushort missionCanceled { get; set; }

        public List<ushort> listPortSerialNumber { get; set; }

        public MissionInform missionInform { get; set; } = new MissionInform();
    }

    public class RobotStatus
    {
        public int errorCode { get; set; }

        public ushort idle { get; set; }

        public ushort finish { get; set; }

        public ushort run { get; set; }
    }

    public class MissionInform
    {
        public bool isNeedScanRfid { get; set; }

        public string rfid { get; set; }

        public ushort motionType { get; set; }

        public ushort pickUpLocation { get; set; }

        public ushort pickUpLocationPort { get; set; }

        public ushort dropOffLocation { get; set; }

        public ushort dropOffLocationPort { get; set; }
    }
}
