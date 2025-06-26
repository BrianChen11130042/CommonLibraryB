using CommonLibraryB.Tools.TypeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Adapter
{

    public partial class AdapterHikRobotIcTray
    {
        const int delay = 10;

        /// <summary>
        /// IC Tray有6個儲位序號
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

    public partial class AdapterHikRobotIcTray
    {
        enum EGetOperate
        {
            MissionStarted,
            TaskId,
            RFID,
            MotionType,
            PickLocId,
            PickPortId,
            DropLocId,
            DropPortId,
        }

        void getCmd(EGetOperate operate, AmrPackage t)
        {
            switch (operate)
            {
                case EGetOperate.MissionStarted:
                    cmdMissionStarted(t);
                    break;

                case EGetOperate.TaskId:
                    cmdTaskId(t);
                    break;

                case EGetOperate.RFID:
                    cmdRFID(t);
                    break;

                case EGetOperate.MotionType:
                    cmdMotionType(t);
                    break;

                case EGetOperate.PickLocId:
                    cmdPickLocId(t);
                    break;

                case EGetOperate.PickPortId:
                    cmdPickPortId(t);
                    break;

                case EGetOperate.DropLocId:
                    cmdDropLocId(t);
                    break;

                case EGetOperate.DropPortId:
                    cmdDropPortId(t);
                    break;

                default:
                    break;
            }
        }

        void cmdMissionStarted(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4001;
            t.offset = 1;
        }

        void cmdTaskId(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4100;
            t.offset = 1;
        }

        void cmdRFID(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4101;
            t.offset = 16;
        }

        void cmdMotionType(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4111;
            t.offset = 1;
        }

        void cmdPickLocId(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4112;
            t.offset = 1;
        }

        void cmdPickPortId(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4113;
            t.offset = 1;
        }

        void cmdDropLocId(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4114;
            t.offset = 1;
        }

        void cmdDropPortId(AmrPackage t)
        {
            t.station = 1;
            t.startAddress = 0x4115;
            t.offset = 1;
        }
    }

    public partial class AdapterHikRobotIcTray
    {
        void unpack(EGetOperate operate, AmrPackage t)
        {
            switch (operate)
            {
                case EGetOperate.MissionStarted:
                    upMissionStarted(t);
                    break;

                case EGetOperate.TaskId:
                    upTaskId(t);
                    break;

                case EGetOperate.RFID:
                    upRfid(t);
                    break;

                case EGetOperate.MotionType:
                    upMotionType(t);
                    break;

                case EGetOperate.PickLocId:
                    upPickLocId(t);
                    break;

                case EGetOperate.PickPortId:
                    upPickPortId(t);
                    break;

                case EGetOperate.DropLocId:
                    upDropLocId(t);
                    break;

                case EGetOperate.DropPortId:
                    upDropPortId(t);
                    break;

                default:
                    break;
            }
        }

        void upMissionStarted(AmrPackage t)
        {
            t.property.get.missionStart = t.rcmd;
        }

        void upTaskId(AmrPackage t)
        {
            t.property.get.missionData.taskId = t.rcmd;
        }

        void upRfid(AmrPackage t)
        {
            string result;

            StringUshortConverter.UshortArrayToString(t.arrayRcmd, EEndian.BigEndian, out result);

            t.property.get.missionData.RFID = result;
        }

        void upMotionType(AmrPackage t)
        {
            t.property.get.missionData.motionType = t.rcmd;
        }

        void upPickLocId(AmrPackage t)
        {
            t.property.get.missionData.pickLocId = t.rcmd;
        }

        void upPickPortId(AmrPackage t)
        {
            t.property.get.missionData.pickPortId = t.rcmd;
        }

        void upDropLocId(AmrPackage t)
        {
            t.property.get.missionData.dropLocId = t.rcmd;
        }

        void upDropPortId(AmrPackage t)
        {
            t.property.get.missionData.dropPortId = t.rcmd;
        }
    }

    public partial class AdapterHikRobotIcTray
    {
        enum ESetOperate
        {
            MissionFinish,
            MissionStart,

            Port1_Occupy,
            Port1_Id,
            Port1_Rfid,
            Port1_TaskId,

            Port2_Occupy,
            Port2_Id,
            Port2_Rfid,
            Port2_TaskId,

            Port3_Occupy,
            Port3_Id,
            Port3_Rfid,
            Port3_TaskId,

            Port4_Occupy,
            Port4_Id,
            Port4_Rfid,
            Port4_TaskId,

            Port5_Occupy,
            Port5_Id,
            Port5_Rfid,
            Port5_TaskId,

            Port6_Occupy,
            Port6_Id,
            Port6_Rfid,
            Port6_TaskId,

            ErrorCode,
        }

        void getCmd(ESetOperate operate, AmrPackage t)
        {
            switch (operate)
            {
                case ESetOperate.MissionFinish:
                    cmdMissionFinish(t);
                    break;

                case ESetOperate.MissionStart:
                    cmdMissionStart(t);
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

                case ESetOperate.Port1_TaskId:
                    cmdTaskIdPort1(t);
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

                case ESetOperate.Port2_TaskId:
                    cmdTaskIdPort2(t);
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

                case ESetOperate.Port3_TaskId:
                    cmdTaskIdPort3(t);
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

                case ESetOperate.Port4_TaskId:
                    cmdTaskIdPort4(t);
                    break;

                case ESetOperate.Port5_Occupy:
                    cmdOccupyPort5(t);
                    break;

                case ESetOperate.Port5_Id:
                    cmdIdPort5(t);
                    break;

                case ESetOperate.Port5_Rfid:
                    cmdRfidPort5(t);
                    break;

                case ESetOperate.Port5_TaskId:
                    cmdTaskIdPort5(t);
                    break;

                case ESetOperate.Port6_Occupy:
                    cmdOccupyPort6(t);
                    break;

                case ESetOperate.Port6_Id:
                    cmdIdPort6(t);
                    break;

                case ESetOperate.Port6_Rfid:
                    cmdRfidPort6(t);
                    break;

                case ESetOperate.Port6_TaskId:
                    cmdTaskIdPort6(t);
                    break;

                case ESetOperate.ErrorCode:
                    cmdErrorCode(t);
                    break;

                default:
                    break;
            }
        }

        void cmdMissionFinish(AmrPackage t)
        {
            t.cmd = t.property.set.missionFinish;
            t.station = 1;
            t.startAddress = 0x4002;
            t.offset = 1;
        }

        void cmdMissionStart(AmrPackage t)
        {
            t.cmd = t.property.set.missionStart;
            t.station = 1;
            t.startAddress = 0x4001;
            t.offset = 1;
        }

        void cmdOccupyPort1(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortId[1]];
            t.station = 1;
            t.startAddress = 0x6000;
            t.offset = 1;
        }

        void cmdIdPort1(AmrPackage t)
        {
            t.cmd = dcPortId[1];
            t.station = 1;
            t.startAddress = 0x6001;
            t.offset = 1;
        }

        void cmdRfidPort1(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRFID[dcPortId[1]],
                                                      EEndian.BigEndian,
                                                      16,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x6002;
            t.offset = 16;
        }

        void cmdTaskIdPort1(AmrPackage t)
        {
            t.cmd = t.property.set.dcTaskId[dcPortId[1]];
            t.station = 1;
            t.startAddress = 0x6012;
            t.offset = 1;
        }

        void cmdOccupyPort2(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortId[2]];
            t.station = 1;
            t.startAddress = 0x6013;
            t.offset = 1;
        }

        void cmdIdPort2(AmrPackage t)
        {
            t.cmd = dcPortId[2];
            t.station = 1;
            t.startAddress = 0x6014;
            t.offset = 1;
        }

        void cmdRfidPort2(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRFID[dcPortId[2]],
                                                      EEndian.BigEndian,
                                                      16,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x6015;
            t.offset = 16;
        }

        void cmdTaskIdPort2(AmrPackage t)
        {
            t.cmd = t.property.set.dcTaskId[dcPortId[2]];
            t.station = 1;
            t.startAddress = 0x6025;
            t.offset = 1;
        }

        void cmdOccupyPort3(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortId[3]];
            t.station = 1;
            t.startAddress = 0x6026;
            t.offset = 1;
        }

        void cmdIdPort3(AmrPackage t)
        {
            t.cmd = dcPortId[3];
            t.station = 1;
            t.startAddress = 0x6027;
            t.offset = 1;
        }

        void cmdRfidPort3(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRFID[dcPortId[3]],
                                                      EEndian.BigEndian,
                                                      16,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x6028;
            t.offset = 16;
        }

        void cmdTaskIdPort3(AmrPackage t)
        {
            t.cmd = t.property.set.dcTaskId[dcPortId[3]];
            t.station = 1;
            t.startAddress = 0x6038;
            t.offset = 1;
        }

        void cmdOccupyPort4(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortId[4]];
            t.station = 1;
            t.startAddress = 0x6039;
            t.offset = 1;
        }

        void cmdIdPort4(AmrPackage t)
        {
            t.cmd = dcPortId[4];
            t.station = 1;
            t.startAddress = 0x6040;
            t.offset = 1;
        }

        void cmdRfidPort4(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRFID[dcPortId[4]],
                                                      EEndian.BigEndian,
                                                      16,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x6041;
            t.offset = 16;
        }

        void cmdTaskIdPort4(AmrPackage t)
        {
            t.cmd = t.property.set.dcTaskId[dcPortId[4]];
            t.station = 1;
            t.startAddress = 0x6051;
            t.offset = 1;
        }

        void cmdOccupyPort5(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortId[5]];
            t.station = 1;
            t.startAddress = 0x6052;
            t.offset = 1;
        }

        void cmdIdPort5(AmrPackage t)
        {
            t.cmd = dcPortId[5];
            t.station = 1;
            t.startAddress = 0x6053;
            t.offset = 1;
        }

        void cmdRfidPort5(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRFID[dcPortId[5]],
                                                      EEndian.BigEndian,
                                                      16,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x6054;
            t.offset = 16;
        }

        void cmdTaskIdPort5(AmrPackage t)
        {
            t.cmd = t.property.set.dcTaskId[dcPortId[5]];
            t.station = 1;
            t.startAddress = 0x6064;
            t.offset = 1;
        }

        void cmdOccupyPort6(AmrPackage t)
        {
            t.cmd = t.property.set.dcOccupy[dcPortId[6]];
            t.station = 1;
            t.startAddress = 0x6065;
            t.offset = 1;
        }

        void cmdIdPort6(AmrPackage t)
        {
            t.cmd = dcPortId[6];
            t.station = 1;
            t.startAddress = 0x6066;
            t.offset = 1;
        }

        void cmdRfidPort6(AmrPackage t)
        {
            ushort[] tmp;

            StringUshortConverter.StringToUshortArray(t.property.set.dcRFID[dcPortId[6]],
                                                      EEndian.BigEndian,
                                                      16,
                                                      out tmp);
            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x6067;
            t.offset = 16;
        }

        void cmdTaskIdPort6(AmrPackage t)
        {
            t.cmd = t.property.set.dcTaskId[dcPortId[6]];
            t.station = 1;
            t.startAddress = 0x6077;
            t.offset = 1;
        }

        void cmdErrorCode(AmrPackage t)
        {
            ushort[] tmp;

            IntUshortConverter.IntToUshortArray(t.property.set.status.errorCode,
                                                EEndian.BigEndian,
                                                out tmp);

            t.arrayCmd = tmp;
            t.station = 1;
            t.startAddress = 0x607F;
            t.offset = 2;
        }
    }

    public partial class AdapterHikRobotIcTray : IAmrOperate<AmrPackage>
    {

        public async Task<bool> GetMissionStartedAsync(AmrPackage t)
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

        public async Task<bool> SetMisssionStartAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.MissionStart, t);
                await setSingleRegisterAsync(t, "mission start");

                t.informLog = "set mission start success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetMissionFinishResultAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.MissionFinish, t);
                await setSingleRegisterAsync(t, "mission finish");

                t.informLog = "set mission finish success";
                return true;

            }
            catch (Exception ex)
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

                //任務編號
                getCmd(EGetOperate.TaskId, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.TaskId, t);

                await Task.Delay(delay);

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
                getCmd(EGetOperate.PickLocId, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.PickLocId, t);

                await Task.Delay(delay);

                //取料地點儲位
                getCmd(EGetOperate.PickPortId, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.PickPortId, t);

                await Task.Delay(delay);

                //放料地點
                getCmd(EGetOperate.DropLocId, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.DropLocId, t);

                await Task.Delay(delay);

                //放料地點儲位
                getCmd(EGetOperate.DropPortId, t);
                await getSingleRegisterAsync(t);
                unpack(EGetOperate.DropPortId, t);

                t.property.get.missionData.IsScanRFID = true;

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

                //庫位1 任務編號
                getCmd(ESetOperate.Port1_TaskId, t);
                await setSingleRegisterAsync(t, "port1 task id");

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

                //庫位2 任務編號
                getCmd(ESetOperate.Port2_TaskId, t);
                await setSingleRegisterAsync(t, "port2 task id");

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

                //庫位3 任務編號
                getCmd(ESetOperate.Port3_TaskId, t);
                await setSingleRegisterAsync(t, "port3 task id");

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

                await Task.Delay(delay);

                //庫位4 任務編號
                getCmd(ESetOperate.Port4_TaskId, t);
                await setSingleRegisterAsync(t, "port4 task id");

                await Task.Delay(delay);

                //庫位5 有無料件
                getCmd(ESetOperate.Port5_Occupy, t);
                await setSingleRegisterAsync(t, "port5 occupy");

                await Task.Delay(delay);

                //庫位5 序號
                getCmd(ESetOperate.Port5_Id, t);
                await setSingleRegisterAsync(t, "port5 id");

                await Task.Delay(delay);

                //庫位5 RFID
                getCmd(ESetOperate.Port5_Rfid, t);
                await setMultiRegisterAsync(t, "port5 rfid");

                await Task.Delay(delay);

                //庫位5 任務編號
                getCmd(ESetOperate.Port5_TaskId, t);
                await setSingleRegisterAsync(t, "port5 task id");

                await Task.Delay(delay);

                //庫位6 有無料件
                getCmd(ESetOperate.Port6_Occupy, t);
                await setSingleRegisterAsync(t, "port6 occupy");

                await Task.Delay(delay);

                //庫位6 序號
                getCmd(ESetOperate.Port6_Id, t);
                await setSingleRegisterAsync(t, "port6 id");

                await Task.Delay(delay);

                //庫位6 RFID
                getCmd(ESetOperate.Port6_Rfid, t);
                await setMultiRegisterAsync(t, "port6 rfid");

                await Task.Delay(delay);

                //庫位6 任務編號
                getCmd(ESetOperate.Port6_TaskId, t);
                await setSingleRegisterAsync(t, "port6 task id");

                t.informLog = "set warehouse inform success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetErrorCodeAsync(AmrPackage t)
        {
            try
            {
                if (t.master == null)
                {
                    setModbusTcpError();
                }

                getCmd(ESetOperate.ErrorCode, t);
                await setMultiRegisterAsync(t, "error code");

                t.informLog = "set error code success";
                return true;

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public void GetDeployData(AmrPackage t)
        {
            t.property.get.locId = 456;
            t.property.get.dcPortId = this.dcPortId;
        }

    }

    public partial class AdapterHikRobotIcTray
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

            if (!t.arrayCmd.SequenceEqual(arrRes))
                throw new InvalidOperationException(string.Format("set {0} fail", register));

        }

        async Task getMultiRegisterAsync(AmrPackage t)
        {
            t.arrayRcmd = await t.master.ReadHoldingRegistersAsync((byte)t.station, (ushort)t.startAddress, (ushort)t.offset);
        }
    }
}
