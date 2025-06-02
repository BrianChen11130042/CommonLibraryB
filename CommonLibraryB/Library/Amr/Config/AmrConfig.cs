using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Manager.ModbusTcp.Master;
using CommonLibraryB.Library.Amr.Adapter;

namespace CommonLibraryB.Library.Amr.Config
{
    public class AmrConfig
    {
        public string device { get; set; }

        public EModbusTcpMaster master { get; set; } = EModbusTcpMaster.Master1;

        public EAmrSupplier supplier { get; set; } = EAmrSupplier.HikRobot_MpFoup4;
    }
}
