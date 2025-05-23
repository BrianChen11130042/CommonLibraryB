using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommonLibraryB.Tools.TypeConverter;
using Microsoft.Win32;
using static System.Collections.Specialized.BitVector32;

namespace CommonLibraryB.Library.Amr.Adapter
{
    public partial class AdapterHikRobotMpFoup
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

    public partial class AdapterHikRobotMpFoup
    {
        enum EGetOperate
        {
            MissionStarted,
            MissionCanceled,
            RFID,
            MotionType,
            PickUpLocation,
            PickUpLocationPort,
            DropOffLocation,
            DropOffLocationPort,
        }

        void getCmd(EGetOperate operate, AmrPackage t)
        {
            switch(operate)
            {
                case EGetOperate.MissionStarted:
                    cmdMissionStarted(t);
                    break;

                case EGetOperate.MissionCanceled:
                    cmdMissionCanceled(t);
                    break;

                case EGetOperate.RFID:
                    cmdRFID(t);
                    break;

                case EGetOperate.MotionType:
                    cmdMotionType(t);
                    break;

                case EGetOperate.PickUpLocation:
                    cmdPickUpLocation(t);
                    break;

                case EGetOperate.PickUpLocationPort:
                    cmdPickUpLocationPort(t);
                    break;

                case EGetOperate.DropOffLocation:
                    cmdDropOffLocation(t);
                    break;

                case EGetOperate.DropOffLocationPort:
                    cmdDropOffLocationPort(t);
                    break;

                default:
                    break;
            }
        }

        void cmdMissionStarted(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4001;
            t.offset = 1;
        }

        void cmdMissionCanceled(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4003;
            t.offset = 1;
        }

        void cmdRFID(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4100;
            t.offset = 10;
        }

        void cmdMotionType(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4110;
            t.offset = 1;
        }

        void cmdPickUpLocation(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4111;
            t.offset = 1;
        }

        void cmdPickUpLocationPort(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4112;
            t.offset = 1;
        }

        void cmdDropOffLocation(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4113;
            t.offset = 1;
        }

        void cmdDropOffLocationPort(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 4114;
            t.offset = 1;
        }
    }

    public partial class AdapterHikRobotMpFoup
    {
        void unpack(EGetOperate operate, AmrPackage t)
        {
            switch(operate)
            {
                case EGetOperate.MissionStarted:
                    upMissionStarted(t);
                    break;

                case EGetOperate.MissionCanceled:
                    upMisssionCanceled(t);
                    break;

                case EGetOperate.RFID:
                    upRfid(t);
                    break;

                case EGetOperate.MotionType:
                    upMotionType(t);
                    break;

                case EGetOperate.PickUpLocation:
                    upPickUpLocation(t);
                    break;

                case EGetOperate.PickUpLocationPort:
                    upPickUpLocationPort(t);
                    break;

                case EGetOperate.DropOffLocation:
                    upDropOffLocation(t);
                    break;

                case EGetOperate.DropOffLocationPort:
                    upDropOffLocationPort(t);
                    break;

                default:
                    break;
            }
        }

        void upMissionStarted(AmrPackage t)
        {
            t.property.get.missionStarted = t.rcmd;
        }

        void upMisssionCanceled(AmrPackage t)
        {
            t.property.get.missionCanceled = t.rcmd;
        }

        void upRfid(AmrPackage t)
        {
            string result;

            StringUshortConverter.UshortArrayToString(t.arrayRcmd, EEndian.BigEndian, out result);

            t.property.get.missionInfo.RFID = result;
        }

        void upMotionType(AmrPackage t)
        {
            t.property.get.missionInfo.motionType = t.rcmd;
        }

        void upPickUpLocation(AmrPackage t)
        {
            t.property.get.missionInfo.pickLocId = t.rcmd;
        }

        void upPickUpLocationPort(AmrPackage t)
        {
            t.property.get.missionInfo.pickPortId = t.rcmd;
        }

        void upDropOffLocation(AmrPackage t)
        {
            t.property.get.missionInfo.dropLocId = t.rcmd;
        }

        void upDropOffLocationPort(AmrPackage t)
        {
            t.property.get.missionInfo.dropPortId = t.rcmd;
        }
    }

    public partial class AdapterHikRobotMpFoup
    {
        enum ESetOperate
        {
            MissionCompleted,
            ResetMissionStart,

            Port1_Occupy,
            Port1_Id,
            Port1_Rfid,

            Port2_Occupy,
            Port2_Id,
            Port2_Rfid,

            Port3_Occupy,
            Port3_Id,
            Port3_Rfid,

            Port4_Occupy,
            Port4_Id,
            Port4_Rfid,

            RobotError,
            RobotIdle,
            RobotComplete,
            RobotRun
        }

        void getCmd(ESetOperate operate, AmrPackage t)
        {
            switch(operate)
            {
                case ESetOperate.MissionCompleted:
                    cmdMissionCompleted(t);
                    break;

                case ESetOperate.ResetMissionStart:
                    cmdResetMissionStart(t);
                    break;

                case ESetOperate.Port1_Occupy:
                    cmdOccupyPort1(t);
                    break;

                case ESetOperate.Port1_Id:
                    cmdIdPort1(t);
                    break;

                case ESetOperate.Port1_Rfid:
                    cmdRfidPort1(t);
                    break;

                case ESetOperate.Port2_Occupy:
                    cmdOccupyPort2(t);
                    break;

                case ESetOperate.Port2_Id:
                    cmdIdPort2(t);
                    break;

                case ESetOperate.Port2_Rfid:
                    cmdRfidPort2(t);
                    break;

                case ESetOperate.Port3_Occupy:
                    cmdOccupyPort3(t);
                    break;

                case ESetOperate.Port3_Id:
                    cmdIdPort3(t);
                    break;

                case ESetOperate.Port3_Rfid:
                    cmdRfidPort3(t);
                    break;

                case ESetOperate.Port4_Occupy:
                    cmdOccupyPort4(t);
                    break;

                case ESetOperate.Port4_Id:
                    cmdIdPort4(t);
                    break;

                case ESetOperate.Port4_Rfid:
                    cmdRfidPort4(t);
                    break;

                case ESetOperate.RobotError:
                    cmdRobotError(t);
                    break;

                case ESetOperate.RobotIdle:
                    cmdRobotIdle(t);
                    break;

                case ESetOperate.RobotComplete:
                    cmdRobotComplete(t);
                    break;

                case ESetOperate.RobotRun:
                    cmdRobotRun(t);
                    break;

                default:
                    break;
            }
        }

        void cmdMissionCompleted(AmrPackage t)
        {
            t.cmd = t.property.set.missionCompleted;
            t.station = 1;
            t.startAddress = 4002;
            t.offset = 1;
        }

        void cmdResetMissionStart(AmrPackage t)
        {
            t.cmd = t.property.set.resetMissionStart;
            t.station = 1;
            t.startAddress = 4001;
            t.offset = 1;
        }

        void cmdOccupyPort1(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortSerialNo[EMpFoupPort.Port1]];
            t.station = 1;
            t.startAddress = 6000;
            t.offset = 1;
        }

        void cmdIdPort1(AmrPackage t)
        {
            t.cmd = dcPortSerialNo[EMpFoupPort.Port1];
            t.station = 1;
            t.startAddress = 6001;
            t.offset = 1;
        }

        void cmdRfidPort1(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRfid[dcPortSerialNo[EMpFoupPort.Port1]],
                                                      EEndian.BigEndian,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 6002;
            t.offset = 10;
        }

        void cmdOccupyPort2(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortSerialNo[EMpFoupPort.Port2]];
            t.station = 1;
            t.startAddress = 6012;
            t.offset = 1;
        }

        void cmdIdPort2(AmrPackage t)
        {
            t.cmd = dcPortSerialNo[EMpFoupPort.Port2];
            t.station = 1;
            t.startAddress = 6013;
            t.offset = 1;
        }

        void cmdRfidPort2(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRfid[dcPortSerialNo[EMpFoupPort.Port2]],
                                                      EEndian.BigEndian,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 6014;
            t.offset = 10;
        }

        void cmdOccupyPort3(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortSerialNo[EMpFoupPort.Port3]];
            t.station = 1;
            t.startAddress = 6024;
            t.offset = 1;
        }

        void cmdIdPort3(AmrPackage t)
        {
            t.cmd = dcPortSerialNo[EMpFoupPort.Port3];
            t.station = 1;
            t.startAddress = 6025;
            t.offset = 1;
        }

        void cmdRfidPort3(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRfid[dcPortSerialNo[EMpFoupPort.Port3]],
                                                      EEndian.BigEndian,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 6026;
            t.offset = 10;
        }

        void cmdOccupyPort4(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortSerialNo[EMpFoupPort.Port4]];
            t.station = 1;
            t.startAddress = 6036;
            t.offset = 1;
        }

        void cmdIdPort4(AmrPackage t)
        {
            t.cmd = dcPortSerialNo[EMpFoupPort.Port4];
            t.station = 1;
            t.startAddress = 6037;
            t.offset = 1;
        }

        void cmdRfidPort4(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRfid[dcPortSerialNo[EMpFoupPort.Port4]],
                                                      EEndian.BigEndian,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 6038;
            t.offset = 10;
        }

        void cmdRobotError(AmrPackage t)
        {
            ushort[] tmp;

            IntUshortConverter.IntToUshortArray(t.property.set.robotStatus.errorCode,
                                                EEndian.BigEndian,
                                                out tmp);

            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 6078;
            t.offset = 2;
        }

        void cmdRobotIdle(AmrPackage t)
        {
            t.cmd = t.property.set.robotStatus.idle;
            t.station = 1;
            t.startAddress = 6080;
            t.offset = 1;
        }

        void cmdRobotComplete(AmrPackage t)
        {
            t.cmd = t.property.set.robotStatus.finish;
            t.station = 1;
            t.startAddress = 6081;
            t.offset = 1;
        }

        void cmdRobotRun(AmrPackage t)
        {
            t.cmd = t.property.set.robotStatus.run;
            t.station = 1;
            t.startAddress = 6082;
            t.offset = 1;
        }
    }

    public partial class AdapterHikRobotMpFoup : IAmrOperate<AmrPackage>
    {
        public async Task<bool> GetIsMissionStartedAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.MissionStarted, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.MissionStarted, t);

                t.informLog = "get is mission start Success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetMisssionStartedResetAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.ResetMissionStart, t);
                await setSingleRegisterAsync(t, "mission start reset");

                t.informLog = "reset mission start success";
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetMissionCompletedResultAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.MissionCompleted, t);
                await setSingleRegisterAsync(t, "mission complete");

                t.informLog = "set mission complete success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetIsMissionCanceledAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(EGetOperate.MissionCanceled, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.MissionCanceled, t);

                t.informLog = "get is mission cancel success";
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetMissionInformAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                //目標料件RFID條碼
                getCmd(EGetOperate.RFID, t);
                await getMultiRegisterAsync(t);
                unpack(EGetOperate.RFID, t);

                await Task.Delay(delay);

                //上層機構動作類型
                getCmd(EGetOperate.MotionType, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.MotionType, t);

                await Task.Delay(delay);

                //取料地點
                getCmd(EGetOperate.PickUpLocation, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.PickUpLocation, t);

                await Task.Delay(delay);

                //取料地點儲位
                getCmd(EGetOperate.PickUpLocationPort, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.PickUpLocationPort, t);

                await Task.Delay(delay);

                //放料地點
                getCmd(EGetOperate.DropOffLocation, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.DropOffLocation, t);

                await Task.Delay(delay);

                //放料地點儲位
                getCmd(EGetOperate.DropOffLocationPort, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.DropOffLocationPort, t);

                t.property.get.missionInfo.scanRFID = false;

                t.informLog = "get mission inform success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetWarehouseInformAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                //庫位1 有無料件
                getCmd(ESetOperate.Port1_Occupy, t);
                await setSingleRegisterAsync(t, "port1 occupy");

                await Task.Delay(delay);

                //庫位1 序號
                getCmd(ESetOperate.Port1_Id, t);
                await setSingleRegisterAsync(t, "port1 id");

                await Task.Delay(delay);

                //庫位1 RFID
                getCmd(ESetOperate.Port1_Rfid, t);
                await setMultiRegisterAsync(t, "port1 rfid");

                await Task.Delay(delay);

                //庫位2 有無料件
                getCmd(ESetOperate.Port2_Occupy, t);
                await setSingleRegisterAsync(t, "port2 occupy");

                await Task.Delay(delay);

                //庫位2 序號
                getCmd(ESetOperate.Port2_Id, t);
                await setSingleRegisterAsync(t, "port2 id");

                await Task.Delay(delay);

                //庫位2 RFID
                getCmd(ESetOperate.Port2_Rfid, t);
                await setMultiRegisterAsync(t, "port2 rfid");

                await Task.Delay(delay);

                //庫位3 有無料件
                getCmd(ESetOperate.Port3_Occupy, t);
                await setSingleRegisterAsync(t, "port3 occupy");

                await Task.Delay(delay);

                //庫位3 序號
                getCmd(ESetOperate.Port3_Id, t);
                await setSingleRegisterAsync(t, "port3 id");

                await Task.Delay(delay);

                //庫位3 RFID
                getCmd(ESetOperate.Port3_Rfid, t);
                await setMultiRegisterAsync(t, "port3 rfid");

                await Task.Delay(delay);

                //庫位4 有無料件
                getCmd(ESetOperate.Port4_Occupy, t);
                await setSingleRegisterAsync(t, "port4 occupy");

                await Task.Delay(delay);

                //庫位4 序號
                getCmd(ESetOperate.Port4_Id, t);
                await setSingleRegisterAsync(t, "port4 id");

                await Task.Delay(delay);

                //庫位4 RFID
                getCmd(ESetOperate.Port4_Rfid, t);
                await setMultiRegisterAsync(t, "port4 rfid");

                t.informLog = "set warehouse inform success";
                return true;
                
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetRobotErrorMsgAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.RobotError, t);
                await setMultiRegisterAsync(t, "robot error signal");

                t.informLog = "set robot error signal success";
                return true;

            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetRobotFinishMsgAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.RobotComplete, t);
                await setSingleRegisterAsync(t, "robot complete signal");

                t.informLog = "set robot complete signal success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetRobotIdleMsgAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.RobotIdle, t);
                await setSingleRegisterAsync(t, "robot idle signal");

                t.informLog = "set robot idle signal success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetRobotRunMsgAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.RobotRun, t);
                await setSingleRegisterAsync(t, "robot running signal");

                t.informLog = "set robot running signal success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public void GetPortSerialNoList(AmrPackage t)
        {
            t.property.get.listPortSerialNumber = dcPortSerialNo.Values.ToList();
        }
    }

    public partial class AdapterHikRobotMpFoup
    {
        void setModbusTcpError()
        {
            throw new InvalidOperationException("Modbus Tcp Disconnect");
        }

        async Task setSingleRegisterAsync(AmrPackage t, string register)
        {
            await t.master.WriteSingleRegisterAsync((byte)t.station, (ushort)t.startAddress, t.cmd);

            await Task.Delay(delay);

            ushort res = (await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset)).FirstOrDefault();

            if (t.cmd != res)
                throw new InvalidOperationException(string.Format("set {0} fail", register));
        }

        async Task getSingleRegisterAsync(AmrPackage t)
        {
            t.rcmd = (await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset)).FirstOrDefault();
        }

        async Task setMultiRegisterAsync(AmrPackage t, string register)
        {
            //reset
            ushort[] arrReset = Enumerable.Repeat((ushort)0, t.offset).ToArray();
            await t.master.WriteMultipleRegistersAsync((byte)t.station, (ushort)t.startAddress, arrReset);

            await Task.Delay(delay);

            ushort[] arrResetRes = await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);

            await Task.Delay(delay);

            if (!arrReset.SequenceEqual(arrResetRes))
                throw new InvalidOperationException(string.Format("set {0} fail", register));

            //write multi register
            await t.master.WriteMultipleRegistersAsync((byte)t.station, (ushort)t.startAddress, t.arrayCmd);

            await Task.Delay(delay);

            ushort[] arrRes = await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);

            if(! t.arrayCmd.SequenceEqual(arrRes))
                throw new InvalidOperationException(string.Format("set {0} fail", register));

        }

        async Task getMultiRegisterAsync(AmrPackage t)
        {
            t.arrayRcmd = await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);
        }
    }
}
