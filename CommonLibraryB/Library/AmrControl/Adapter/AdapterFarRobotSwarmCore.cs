using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public partial class AdapterFarRobotSwarmCore
    {

    }

    public partial class AdapterFarRobotSwarmCore : IAmrControlOperate<AmrControlPackage>
    {
        public Task<bool> GetAccessToken(AmrControlPackage t)
        {
            throw new NotImplementedException();
        }
    }
}
