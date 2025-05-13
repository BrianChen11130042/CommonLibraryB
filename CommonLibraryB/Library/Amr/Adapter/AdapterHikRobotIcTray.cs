using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{

    public partial class AdapterHikRobotIcTray
    {
        /// <summary>
        /// IC Tray有6個儲位, 就有6個庫位序號
        /// </summary>
        public List<ushort> listPortId = new List<ushort>()
        {
            1,
            2,
            3,
            4,
            5,
            6,
        };
    }

    public partial class AdapterHikRobotIcTray : IAmrOperate<AmrPackage>
    {
        public Task<bool> GetMissionInformAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsMissionCanceledAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsMissionStartedAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetCompletedMessageAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetErrorMessageAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetIdleMessageAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetMissionCompletedResultAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetRunningMessageAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetWarehouseInformAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }
    }
}
