using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Robot.Property
{

    public class RobotProperty
    {
        public string device { get; set; }

        public Set set { get; set; } = new Set();

        public Get get { get; set; } = new Get();
    }

    public class Set
    {
        public ushort onPosition { get; set; }

        public Mission missionInform { get; set; } = new Mission();
    }

    public class Mission
    {
        public ushort pickUpLocation { get; set; }

        public ushort pickUpLocationPort { get; set; }

        public ushort dropOffLocation { get; set; }

        public ushort dropOffLocationPort { get; set; }
    }

    public class Get
    {
        /// <summary>
        /// <庫位序號, 庫位Sensor訊號判斷有無存在料(有料置1)>
        /// </summary>
        public Dictionary<ushort, ushort> dcOccupy { get; set; } = new Dictionary<ushort, ushort>();


        public ushort projectStatus { get; set; }

        public int projectErrorCode { get; set; } 

        public bool isError { get; set; }

        public int errorCode { get; set; }

        public string rfid { get; set; }
    }
}
