using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson;

namespace CommonLibraryB.Library.AmrControl.Property
{
    public class AmrControlProperty
    {
        public string Device { get; set; }

        public FarRobotSwarmCoreJson farRobot { get; set; } = new FarRobotSwarmCoreJson();
    }

    
}
