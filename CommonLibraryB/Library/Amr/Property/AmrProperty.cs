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
        public ushort missionCompleted { get; set; }

        public RobotStatus robotStatus { get; set; } = new RobotStatus();

        /// <summary>
        /// <庫位序號, 庫位有無存在料>
        /// </summary>
        public Dictionary<ushort, ushort> dcOccupy = new Dictionary<ushort, ushort>();

        /// <summary>
        /// <庫位序號, RFID>
        /// </summary>
        public Dictionary<ushort, string> dcRfid = new Dictionary<ushort, string>();

    }

    public class GetProperty
    {
        public ushort missionStarted { get; set; }

        public ushort missionCanceled { get; set; }

        public MissionInform missionInform { get; set; } = new MissionInform();
    }

    public class RobotStatus
    {
        public int errorCode { get; set; }

        public ushort idle { get; set; }

        public ushort completed { get; set; }

        public ushort running { get; set; }
    }

    public class MissionInform
    {
        public ushort pickUpLocation { get; set; }

        public ushort pickUpLocationPort { get; set; }

        public ushort dropOffLocation { get; set; }

        public ushort dropOffLocationPort { get; set; }
    }
}
