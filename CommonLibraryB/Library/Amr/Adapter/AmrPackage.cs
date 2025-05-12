using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.Amr.Config;
using CommonLibraryB.Library.Amr.Property;
using CommonLibraryB.Manager.ModbusTcp.Master;


namespace CommonLibraryB.Library.Amr.Adapter
{
    public class AmrPackage : ModbusTcpMasterPack
    {
        public IModbusMaster modbusTcpMaster { get; set; }

        public AmrConfig config { get; set; }

        public AmrProperty property { get; set; }

        public string errorLog { get; set; }

        public string informLog { get; set; }
    }
}
