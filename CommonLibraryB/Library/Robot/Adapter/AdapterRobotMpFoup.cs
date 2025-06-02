using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Robot.Adapter
{
    public partial class AdapterRobotMpFoup
    {
        const int delay = 10;

        /// <summary>
        /// MP Foup有4個儲位序號
        /// </summary>
        Dictionary<int, ushort> dcPortId = new Dictionary<int, ushort>()
        {
            { 1, 11111 },
            { 2, 22222 },
            { 3, 33333 },
            { 4, 44444 }
        };
    }

    public partial class AdapterRobotMpFoup : IRobotOperate<RobotPackage>
    {
        public Task<bool> GetErrorCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetIsErrorAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }


        public Task<bool> GetProjectErrorCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetProjectStatusAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetInRFIDScanPosAsync(RobotPackage t)
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

        public void GetDcPortId(RobotPackage t)
        {
            t.property.get.dcPortId = this.dcPortId;
        }

        public Task<bool> SetRFIDScanMotionAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }
    }
}
