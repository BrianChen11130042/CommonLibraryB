using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Manager.ModbusTcp.Master;

namespace CommonLibraryB.Library.Amr.Config
{
    public class AmrConfig
    {
        public string AmrName { get; set; }

        public string AmrId { get; set; }

        public EModbusTcpMaster tcpMaster { get; set; }
    }
}
