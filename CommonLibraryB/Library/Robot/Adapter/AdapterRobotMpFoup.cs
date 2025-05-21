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

        enum EMpFoupPort
        {
            Port1,
            Port2,
            Port3,
            Port4
        }

        /// <summary>
        /// MP Foup有4個儲位序號
        /// </summary>
        Dictionary<EMpFoupPort, ushort> dcPortSerialNo = new Dictionary<EMpFoupPort, ushort>()
        {
            { EMpFoupPort.Port1, 11111 },
            { EMpFoupPort.Port2, 22222 },
            { EMpFoupPort.Port3, 33333 },
            { EMpFoupPort.Port4, 44444 }
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

        public void GetPortSerialNoList(RobotPackage t)
        {
            t.property.get.listPortSerialNumber = dcPortSerialNo.Values.ToList();
        }
    }
}
