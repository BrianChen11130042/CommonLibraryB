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

        public ArtifactStatusByArtifactId artifactStatusByArtifactId { get; set; } = new ArtifactStatusByArtifactId();

        public DeleteFlow deleteFlow { get; set; } = new DeleteFlow();

        public FlowName flowName { get; set; } = new FlowName();

        public ScanAmr scanAmr { get; set; } = new ScanAmr();

        public CellStatus cellStatus { get; set; } = new CellStatus();

        public AmrStatusByAmrId amrStatusByAmrId { get; set; } = new AmrStatusByAmrId();

    }
}
