using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{

    public partial class AdapterHikRobotIcTray
    {
        const int delay = 1;

        /// <summary>
        /// MP Foup有4個儲位序號
        /// </summary>
        Dictionary<int, ushort> dcPortId = new Dictionary<int, ushort>()
        {
            { 1, 1111 },
            { 2, 2222 },
            { 3, 3333 },
            { 4, 4444 },
            { 5, 5555 },
            { 6, 6666 },
        };
    }

    public partial class AdapterHikRobotIcTray : IAmrOperate<AmrPackage>
    {
        public Task<bool> GetMissionInformAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> GetMissionStartedAsync(AmrPackage t)
        {
            return true;
        }

        

        public Task<bool> SetErrorCodeAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> SetMissionFinishResultAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> SetWarehouseInformAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public void GetDeployData(AmrPackage t)
        {
            t.property.get.locId = 456;
            t.property.get.dcPortId = this.dcPortId;
        }

        public Task<bool> SetMisssionStartAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }
    }
}
