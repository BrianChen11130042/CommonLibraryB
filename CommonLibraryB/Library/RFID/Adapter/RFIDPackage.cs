using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.RFID.Config;
using CommonLibraryB.Library.RFID.Property;
using CommonLibraryB.Manager.ModbusRtu;

namespace CommonLibraryB.Library.RFID.Adapter
{
    public class RFIDPackage : ModbusRtuPack
    {
        public RFIDConfig config { get; set; }

        public RFIDProperty property { get; set; }

        public string errorLog { get; set; }

        public string informLog { get; set; }
    }
}
