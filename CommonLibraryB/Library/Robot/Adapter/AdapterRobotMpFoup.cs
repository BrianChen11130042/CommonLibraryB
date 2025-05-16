using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Robot.Adapter
{

    public class AdapterRobotMpFoup : IRobotOperate<RobotPackage>
    {
        public Task<bool> GetErrorCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsErrorAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetProjectErroCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetProjectStatusAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetRFIDAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetSensorSignalAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetMissionInformAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetOnPositionAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }
    }
}
