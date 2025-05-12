using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Manager.ModbusTcp.Master
{

    public class ModbusTcpMasterPack
    {
        public ushort cmd { get; set; }

        public ushort rcmd { get; set; }

        public ushort[] arrayCmd { get; set; }

        public ushort[] arrayRcmd { get; set; }

        public int station { get; set; }

        public int startAddress { get; set; }

        public int offset { get; set; }
    }
}
