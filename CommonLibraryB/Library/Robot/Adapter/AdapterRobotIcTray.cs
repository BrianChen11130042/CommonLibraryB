using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Robot.Adapter
{

    public partial class AdapterRobotIcTray
    {
        const int delay = 10;

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

    public partial class AdapterRobotIcTray : IRobotOperate<RobotPackage>
    {
        public void GetDeployData(RobotPackage t)
        {
            t.property.get.dcPortId = this.dcPortId;
        }

        public Task<bool> GetErrorCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetInRFIDScanPosAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetIsErrorAsync(RobotPackage t)
        {
            return true;
        }

        public Task<bool> GetProjectErrorCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetProjectStatusAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetSensorSignalAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetMissionDataAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetOnPositionAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetRFIDScanMotionAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }
    }
}
