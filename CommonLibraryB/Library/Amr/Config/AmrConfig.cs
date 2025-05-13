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
        public string Device { get; set; }

        public EModbusTcpMaster ModbusTcpMaster { get; set; } = EModbusTcpMaster.TcpMaster1;

        public EAmrSupplier AmrSupplier { get; set; } = EAmrSupplier.HikRobot_MpFoup4;

        public string Id { get; set; }

    }
}
