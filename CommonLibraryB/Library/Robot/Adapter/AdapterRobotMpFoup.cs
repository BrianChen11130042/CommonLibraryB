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

    public partial class AdapterRobotMpFoup
    {

    }

    public partial class AdapterRobotMpFoup
    {
        enum ESetOperate
        {
            OnPosition,

        }

        void getCmd(ESetOperate operate, RobotPackage t)
        {
            switch(operate)
            {
                case ESetOperate.OnPosition:
                    cmdOnPosition(t);
                    break;

                default:
                    break;
            }
        }

        void cmdOnPosition(RobotPackage t)
        {
            t.cmd = 1;
            t.station = 1;
            t.startAddress = 9000;
            t.offset = 1;
        }
    }

    public partial class AdapterRobotMpFoup : IRobotOperate<RobotPackage>
    {
        public async Task<bool> SetOnPositionAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.OnPosition, t);
                await setSingleRegisterAsync(t, "on position");

                t.informLog = "set robot on position success";
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public Task<bool> GetErrorCodeAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetIsErrorAsync(RobotPackage t)
        {
            return true;
            //throw new NotImplementedException();
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


        public void GetDeployData(RobotPackage t)
        {
            t.property.get.dcPortId = this.dcPortId;
        }

        public Task<bool> SetRFIDScanMotionAsync(RobotPackage t)
        {
            throw new NotImplementedException();
        }
    }

    public partial class AdapterRobotMpFoup
    {
        void setModbusTcpError()
        {
            throw new InvalidOperationException("Modbus Tcp Disconnect");
        }

        async Task setSingleRegisterAsync(RobotPackage t, string register)
        {
            await t.master.WriteSingleRegisterAsync((byte)t.station, (ushort)t.startAddress, t.cmd);

            await Task.Delay(delay);

            ushort res = (await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset)).FirstOrDefault();

            if (t.cmd != res)
                throw new InvalidOperationException(string.Format("set robot {0} fail", register));
        }
    }
}
