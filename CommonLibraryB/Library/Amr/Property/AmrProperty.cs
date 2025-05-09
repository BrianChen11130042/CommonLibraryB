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

        public List<PortStatus> listPortStatus { get; set; } = new List<PortStatus>();

        public RobotStatus robotStatus { get; set; } = new RobotStatus();
    }

    public class GetProperty
    {
        public ushort missionStarted { get; set; }

        public ushort missionCanceled { get; set; }

        public MissionInform missionInform { get; set; } = new MissionInform();
    }

    public class PortStatus
    {
        public ushort exist { get; set; }

        public ushort id { get; set; }

        public string rfid { get; set; }
    }

    public class RobotStatus
    {
        public int errorMsg { get; set; }

        public ushort idle { get; set; }

        public ushort completed { get; set; }

        public ushort running { get; set; }
    }

    public class MissionInform
    {
        public string pickUpLocation { get; set; }

        public string pickUpLocationPort { get; set; }

        public string dropOffLocation { get; set; }

        public string dropOffLocationPort { get; set; }
    }
}
