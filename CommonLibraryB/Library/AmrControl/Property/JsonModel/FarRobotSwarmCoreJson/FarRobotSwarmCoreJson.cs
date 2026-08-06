using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class FarRobotSwarmCoreJson
    {
        public AccessToken accessToken { get; set; } = new AccessToken();

        public string flowName { get; set; } = string.Empty;

        public MoveFlow moveFlow { get; set; } = new MoveFlow();

    }
}
