using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.AmrControl.Config;
using CommonLibraryB.Library.AmrControl.Property;
using CommonLibraryB.Manager.WebApiClient;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public class AmrControlPackage : WebApiClientPack
    {
        public AmrControlConfig config { get; set; }

        public AmrControlProperty property { get; set; }

        public string errorLog { get; set; }

        public SemaphoreSlim gate { get; } = new SemaphoreSlim(1, 1);
    }
}
