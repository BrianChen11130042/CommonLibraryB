using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.RFID.Adapter;

namespace CommonLibraryB.Library.RFID.Config
{
    public class RFIDConfig
    {
        public string device { get; set; }

        public ERFIDSupplier supplier { get; set; } = ERFIDSupplier.MP2319NR;
    }
}
