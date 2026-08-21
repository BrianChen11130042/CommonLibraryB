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

        public MoveFlow moveFlow { get; set; } = new MoveFlow();

        public ChargeFlow chargeFlow { get; set; } = new ChargeFlow();

        public FlowProgress flowProgress { get; set; } = new FlowProgress();

        public TaskProgress taskProgress { get; set; } = new TaskProgress();

        public ArtifactStatus artifactStatus { get; set; } = new ArtifactStatus();

        public DeleteFlow deleteFlow { get; set; } = new DeleteFlow();

    }
}
