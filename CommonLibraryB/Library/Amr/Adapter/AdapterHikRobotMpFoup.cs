using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// MP Foup有4個儲位, 就有4個庫位序號
        /// </summary>
        Dictionary<EMpFoupPort, ushort> dcPortId = new Dictionary<EMpFoupPort, ushort>()
        {
            { EMpFoupPort.Port1, 1 },
            { EMpFoupPort.Port2, 2 },
            { EMpFoupPort.Port3, 3 },
            { EMpFoupPort.Port4, 4 }
        };
    }

    public partial class AdapterHikRobotMpFoup : IAmrOperate<AmrPackage>
    {
        public async Task<bool> GetMissionIsStartedAsync(AmrPackage t)
        {
            if (t.modbusTcpMaster == null)
            {
                t.errorLog = "modbusTcp disconnect";
                return false;
            }

            try
            {
                ushort rcmd = 0;

                rcmd = (await t.modbusTcpMaster.ReadInputRegistersAsync((byte)1, (ushort)4001, (ushort)1)).FirstOrDefault();

                t.property.get.missionStarted = rcmd;

                t.informLog = "get mission is start Success";
                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> SetMissionCompletedResultAsync(AmrPackage t)
        {
            if (t.modbusTcpMaster == null)
            {
                t.errorLog = "modbusTcp disconnect";
                return false;
            }

            try
            {
                ushort cmd = t.property.set.missionCompleted;

                await t.modbusTcpMaster.WriteSingleRegisterAsync((byte)1, (ushort)4002, cmd);

                await Task.Delay(delay);

                ushort rcmd = (await t.modbusTcpMaster.ReadHoldingRegistersAsync((byte)1, (ushort)4002, (ushort)1)).FirstOrDefault();

                if (cmd == rcmd)
                {
                    t.informLog = "set mission complete success";
                    return true;
                }
                else
                {
                    t.errorLog = "set mission complete fail";
                    return false;
                }

            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> GetMissionIsCanceledAsync(AmrPackage t)
        {
            if (t.modbusTcpMaster == null)
            {
                t.errorLog = "modbusTcp disconnect";
                return false;
            }

            try
            {
                ushort rcmd = 0;

                rcmd = (await t.modbusTcpMaster.ReadInputRegistersAsync((byte)1, (ushort)4003, (ushort)1)).FirstOrDefault();

                t.property.get.missionCanceled = rcmd;

                t.informLog = "get Mission is Cancel Success";
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
            if (t.modbusTcpMaster == null)
            {
                t.errorLog = "modbusTcp disconnect";
                return false;
            }

            try
            {
                if (!(await getPickUpLocationId(t)))
                    return false;

                await Task.Delay(delay);

                if (!(await getPickUpLocationPortId(t)))
                    return false;

                await Task.Delay(delay);

                if (!(await getDropOffLocationId(t)))
                    return false;

                await Task.Delay(delay);

                if (!(await getDropOffLocationPortId(t)))
                    return false;

                t.informLog = "get Mission Inform Success";
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
            if (t.modbusTcpMaster == null)
            {
                t.errorLog = "modbusTcp disconnect";
                return false;
            }

            try
            {
                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
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


        public Task<bool> SetRunningMessageAsync(AmrPackage t)
        {
            throw new NotImplementedException();
        }

    }

    public partial class AdapterHikRobotMpFoup
    {
        public async Task<bool> getPickUpLocationId(AmrPackage t)
        {
            try
            {
                ushort rcmd = 0;

                rcmd = (await t.modbusTcpMaster.ReadInputRegistersAsync((byte)1, (ushort)4100, (ushort)1)).FirstOrDefault();

                t.property.get.missionInform.pickUpLocationId = rcmd;

                return true;
            }
            catch(Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> getPickUpLocationPortId(AmrPackage t)
        {
            try
            {
                ushort rcmd = 0;

                rcmd = (await t.modbusTcpMaster.ReadInputRegistersAsync((byte)1, (ushort)4101, (ushort)1)).FirstOrDefault();

                t.property.get.missionInform.pickUpLocationPortId = rcmd;

                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> getDropOffLocationId(AmrPackage t)
        {
            try
            {
                ushort rcmd = 0;

                rcmd = (await t.modbusTcpMaster.ReadInputRegistersAsync((byte)1, (ushort)4102, (ushort)1)).FirstOrDefault();

                t.property.get.missionInform.dropOffLocationId = rcmd;

                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }

        public async Task<bool> getDropOffLocationPortId(AmrPackage t)
        {
            try
            {
                ushort rcmd = 0;

                rcmd = (await t.modbusTcpMaster.ReadInputRegistersAsync((byte)1, (ushort)4103, (ushort)1)).FirstOrDefault();

                t.property.get.missionInform.dropOffLocationPortId = rcmd;

                return true;
            }
            catch (Exception ex)
            {
                t.errorLog = ex.Message;
                return false;
            }
        }
    }

    public partial class AdapterHikRobotMpFoup
    {

    }
}
