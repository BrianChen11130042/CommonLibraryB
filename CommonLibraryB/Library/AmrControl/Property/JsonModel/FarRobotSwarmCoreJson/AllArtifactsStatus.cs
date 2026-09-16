using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class AllArtifactsStatus
    {
        public string mode { get; set; } = string.Empty;

        public AllArtifactsStatusResponse response { get; set; } = new AllArtifactsStatusResponse();
    }

    public class AllArtifactsStatusResponse
    {
        public List<ArtifactStatusResponse> artifacts { get; set; } = new List<ArtifactStatusResponse>();
    }
}
