using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.Robot.Adapter;
using CommonLibraryB.Manager.ModbusTcp.Master;

namespace CommonLibraryB.Library.Robot.Config
{

    public class RobotConfig
    {
        public string device { get; set; }

        public EModbusTcpMaster master { get; set; } = EModbusTcpMaster.TcpMaster1;

        public ERobotSupplier supplier { get; set; } = ERobotSupplier.TMRobot_MpFoup4;

        public int id { get; set; }
    }
}
