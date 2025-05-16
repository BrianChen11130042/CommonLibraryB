using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.Robot.Config;
using CommonLibraryB.Library.Robot.Property;
using NModbus;

namespace CommonLibraryB.Library.Robot.Adapter
{
    public class RobotPackage
    {
        public IModbusMaster master { get; set; }

        public RobotConfig config { get; set; }

        public RobotProperty property { get; set; }

        public string errorLog { get; set; }

        public string informLog { get; set; }
    }
}
