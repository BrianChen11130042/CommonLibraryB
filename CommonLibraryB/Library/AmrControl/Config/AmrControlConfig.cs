using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Adapter;
using CommonLibraryB.Manager.WebApiClient;

namespace CommonLibraryB.Library.AmrControl.Config
{
    public class AmrControlConfig
    {
        public string device { get; set; }

        public EWebApiClient client { get; set; } = EWebApiClient.Client1;

        public EAmrControlSupplier supplier { get; set; } = EAmrControlSupplier.FarRobotSwarmCore;
    }
}
