using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{
    public class AdapterHikRobotC3s : IAmrOperate<AmrPackage>
    {
        public Task<bool> GetMissionInformAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetMissionIsCanceledAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetMissionIsStartedAsync(AmrPackage t)
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
