using CommonLibraryB.Tools.TypeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Robot.Adapter
{

    public partial class AdapterRobotIcTray
    {
        const int delay = 2;

        /// <summary>
        /// IC Tray有6個儲位序號
        /// </summary>
        Dictionary<int, ushort> dcPortId = new Dictionary<int, ushort>()
        {
            { 1, 1 },
            { 2, 2 },
            { 3, 3 },
            { 4, 4 },
            { 5, 5 },
            { 6, 6 },
        };
    }

    public partial class AdapterRobotIcTray
    {
        enum EGetOperate
        {
            ProjectStatus,
            ProjectErrorCode,
            Sensors,
            RFIDScanPos,
            IsError,
            ErrorCode
        }

        void getCmd(EGetOperate operate, RobotPackage t)
        {
            switch (operate)
            {
                case EGetOperate.ProjectStatus:
                    cmdProjectStatus(t);
                    break;

                case EGetOperate.ProjectErrorCode:
                    cmdProjectErrorCode(t);
                    break;

                case EGetOperate.Sensors:
                    cmdSensors(t);
                    break;

                case EGetOperate.RFIDScanPos:
                    cmdRFIDScanPos(t);
                    break;

                case EGetOperate.IsError:
                    cmdIsError(t);
                    break;

                case EGetOperate.ErrorCode:
                    cmdErrorCode(t);
                    break;

                default:
                    break;
            }
        }

        void cmdProjectStatus(RobotPackage t)
        {
            t.station = 1;
            t.startAddress = 9005;
            t.offset = 1;
        }

        void cmdProjectErrorCode(RobotPackage t)
        {
            t.station = 1;
            t.startAddress = 9006;
            t.offset = 2;
        }

        void cmdSensors(RobotPackage t)
        {
            t.station = 1;
            t.startAddress = 0000;
            t.offset = 6;
        }

        void cmdRFIDScanPos(RobotPackage t)
        {
            t.station = 1;
            t.startAddress = 9008;
            t.offset = 1;
        }

        void cmdIsError(RobotPackage t)
        {
            t.station = 1;
            t.startAddress = 7201;
            t.offset = 1;
        }

        void cmdErrorCode(RobotPackage t)
        {
            t.station = 1;
            t.startAddress = 7320;
            t.offset = 2;
        }
    }

    public partial class AdapterRobotIcTray
    {
        void unpack(EGetOperate operate, RobotPackage t)
        {
            switch (operate)
            {
                case EGetOperate.ProjectStatus:
                    upProjectStatus(t);
                    break;

                case EGetOperate.ProjectErrorCode:
                    upProjectErrorCode(t);
                    break;

                case EGetOperate.Sensors:
                    upSensors(t);
                    break;

                case EGetOperate.RFIDScanPos:
                    upRFIDScanPos(t);
                    break;

                case EGetOperate.IsError:
                    upIsError(t);
                    break;

                case EGetOperate.ErrorCode:
                    upErrorCode(t);
                    break;

                default:
                    break;
            }
        }

        void upProjectStatus(RobotPackage t)
        {
            t.property.get.projectStatus = t.rcmd;
        }

        void upProjectErrorCode(RobotPackage t)
        {
            int result;

            IntUshortConverter.UshortArrayToInt(t.arrayRcmd, EEndian.BigEndian, out result);

            t.property.get.projectErrorCode = result;
        }

        void upSensors(RobotPackage t)
        {
            if (t.property.get.dcOccupy == null)
            {
                t.property.get.dcOccupy = new Dictionary<ushort, bool>();
            }

            foreach (var pair in dcPortId)
            {
                if (!t.property.get.dcOccupy.ContainsKey(pair.Value))
                {
                    t.property.get.dcOccupy.Add(pair.Value, t.arrayBoolRcmd[pair.Key - 1]);
                }
                else
                {
                    t.property.get.dcOccupy[pair.Value] = t.arrayBoolRcmd[pair.Key - 1];
                }
            }
        }

        void upRFIDScanPos(RobotPackage t)
        {
            t.property.get.isRFIDScanPos = t.rcmd;
        }

        void upIsError(RobotPackage t)
        {
            t.property.get.isError = t.boolRcmd;
        }

        void upErrorCode(RobotPackage t)
        {
            int result;

            IntUshortConverter.UshortArrayToInt(t.arrayRcmd, EEndian.BigEndian, out result);

            t.property.get.errorCode = result;
        }
    }

    public partial class AdapterRobotIcTray
    {
        enum ESetOperate
        {
            OnPosition,

            TriggerError,

            PickLocId,
            PickPortId,
            DropLocId,
            DropPortId,

            RFIDScanMotion,
        }

        void getCmd(ESetOperate operate, RobotPackage t)
        {
            switch (operate)
            {
                case ESetOperate.OnPosition:
                    cmdOnPosition(t);
                    break;

                case ESetOperate.TriggerError:
                    cmdTriggerError(t);
                    break;

                case ESetOperate.PickLocId:
                    cmdPickLocId(t);
                    break;

                case ESetOperate.PickPortId:
                    cmdPickPortId(t);
                    break;

                case ESetOperate.DropLocId:
                    cmdDropLocId(t);
                    break;

                case ESetOperate.DropPortId:
                    cmdDropPortId(t);
                    break;

                case ESetOperate.RFIDScanMotion:
                    cmdRFIDScanMotion(t);
                    break;

                default:
                    break;
            }
        }

        void cmdOnPosition(RobotPackage t)
        {
            t.cmd = t.property.set.onPosition;
            t.station = 1;
            t.startAddress = 9000;
            t.offset = 1;
        }

        void cmdTriggerError(RobotPackage t)
        {
            t.cmd = t.property.set.triggerError;
            t.station = 1;
            t.startAddress = 9009;
            t.offset = 1;
        }

        void cmdPickLocId(RobotPackage t)
        {
            t.cmd = t.property.set.mission.pickLocId;
            t.station = 1;
            t.startAddress = 9001;
            t.offset = 1;
        }

        void cmdPickPortId(RobotPackage t)
        {
            t.cmd = t.property.set.mission.pickPortId;
            t.station = 1;
            t.startAddress = 9002;
            t.offset = 1;
        }

        void cmdDropLocId(RobotPackage t)
        {
            t.cmd = t.property.set.mission.dropLocId;
            t.station = 1;
            t.startAddress = 9003;
            t.offset = 1;
        }

        void cmdDropPortId(RobotPackage t)
        {
            t.cmd = t.property.set.mission.dropPortId;
            t.station = 1;
            t.startAddress = 9004;
            t.offset = 1;
        }

        void cmdRFIDScanMotion(RobotPackage t)
        {
            t.cmd = t.property.set.RFIDMotionType;
            t.station = 1;
            t.startAddress = 9008;
            t.offset = 1;
        }
    }

    public partial class AdapterRobotIcTray : IRobotOperate<RobotPackage>
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
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetMissionDataAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                //夾取機台
                getCmd(ESetOperate.PickLocId, t);
                await setSingleRegisterAsync(t, "pick loc id");

                await Task.Delay(delay);

                //夾取庫位
                getCmd(ESetOperate.PickPortId, t);
                await setSingleRegisterAsync(t, "pick port id");

                await Task.Delay(delay);

                //放置機台
                getCmd(ESetOperate.DropLocId, t);
                await setSingleRegisterAsync(t, "drop loc id");

                await Task.Delay(delay);

                //放置庫位
                getCmd(ESetOperate.DropPortId, t);
                await setSingleRegisterAsync(t, "drop port id");

                t.informLog = "set mission data success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetTriggerErrorAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.TriggerError, t);
                await setSingleRegisterAsync(t, "trigger error");

                t.informLog = "trigger robot error success";
                return true;

            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetProjectStatusAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.ProjectStatus, t);
                await getSingleHoldingRegisterAsync(t);
                unpack(EGetOperate.ProjectStatus, t);

                t.informLog = "get project status success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetProjectErrorCodeAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.ProjectErrorCode, t);
                await getMultiHoldingRegisterAsync(t);
                unpack(EGetOperate.ProjectErrorCode, t);

                t.informLog = "get project error code success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetSensorSignalAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.Sensors, t);
                await getMultiInputAsync(t);
                unpack(EGetOperate.Sensors, t);

                t.informLog = "get sensors success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetInRFIDScanPosAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.RFIDScanPos, t);
                await getSingleHoldingRegisterAsync(t);
                unpack(EGetOperate.RFIDScanPos, t);

                t.informLog = "get RFID scan pos success";
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetRFIDScanMotionAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.RFIDScanMotion, t);
                await setSingleRegisterAsync(t, "RFID motion");

                t.informLog = "set RFID scan motion success";
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetIsErrorAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.IsError, t);
                await getSingleInputAsync(t);
                unpack(EGetOperate.IsError, t);

                t.informLog = "get Is Error success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetErrorCodeAsync(RobotPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.ErrorCode, t);
                await getMultiInputRegisterAsync(t);
                unpack(EGetOperate.ErrorCode, t);

                t.informLog = "get Error Code success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public void GetDeployData(RobotPackage t)
        {
            t.property.get.dcPortId = this.dcPortId;
        }
    }

    public partial class AdapterRobotIcTray
    {
        void setModbusTcpError()
        {
            throw new InvalidOperationException("Modbus Tcp Disconnect");
        }

        async Task setSingleRegisterAsync(RobotPackage t, string register)
        {
            await t.master.WriteSingleRegisterAsync((byte)t.station, (ushort)t.startAddress, t.cmd);
        }

        async Task getSingleHoldingRegisterAsync(RobotPackage t)
        {
            t.rcmd = (await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset)).FirstOrDefault();
        }

        async Task getMultiHoldingRegisterAsync(RobotPackage t)
        {
            t.arrayRcmd = await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);
        }

        async Task getMultiInputAsync(RobotPackage t)
        {
            t.arrayBoolRcmd = await t.master.ReadInputsAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);
        }

        async Task getSingleInputAsync(RobotPackage t)
        {
            t.boolRcmd = (await t.master.ReadInputsAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset)).FirstOrDefault();
        }

        async Task getMultiInputRegisterAsync(RobotPackage t)
        {
            t.arrayRcmd = await t.master.ReadInputRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);
        }
    }
}
