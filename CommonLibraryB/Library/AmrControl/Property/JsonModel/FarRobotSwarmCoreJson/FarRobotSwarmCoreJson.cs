using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class FarRobotSwarmCoreJson
    {
        public string flowName { get; set; } = string.Empty;

        public string flowId { get; set; } = string.Empty;

        public string taskId { get; set; } = string.Empty;

        public AccessToken accessToken { get; set; } = new AccessToken();

        public MoveFlow moveFlow { get; set; } = new MoveFlow();

        public FlowProgress flowProgress { get; set; } = new FlowProgress();

        public TaskProgress taskProgress { get; set; } = new TaskProgress();

    }
}
