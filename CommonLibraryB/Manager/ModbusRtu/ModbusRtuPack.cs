using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Manager.ModbusRtu
{
    public class ModbusRtuPack
    {
        public SerialPort Port { get; set; }

        public byte[] cmd { get; set; }

        public byte[] rcmd { get; set; }
    }
}
