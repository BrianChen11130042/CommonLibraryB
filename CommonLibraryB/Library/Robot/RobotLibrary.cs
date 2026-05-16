using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Manager.ModbusTcp.Master;
using CommonLibraryB.Library.Robot.Config;
using CommonLibraryB.Library.Robot.Property;
using CommonLibraryB.Library.Robot.Adapter;

namespace CommonLibraryB.Library.Robot
{
    public partial class RobotLibrary<T>
    {
        public ModbusTcpMasterManager modbusTcpManager;
        public RobotConfigManager<T> configManager;
        public RobotPropertyManager<T> propertyManager;

        public RobotLibrary(ModbusTcpMasterManager modbusTcpManager,
                            RobotConfigManager<T> configManager,
                            RobotPropertyManager<T> propertyManager)
        {
            this.modbusTcpManager = modbusTcpManager;
            this.configManager = configManager;
            this.propertyManager = propertyManager;
        }

        public Dictionary<T, RobotPackage> Packages;

        public void InitPackage()
        {
            if (Packages == null)
            {
                Packages = new Dictionary<T, RobotPackage>();

                foreach(T dev in Enum.GetValues(typeof(T)))
                {
                    Packages.Add(dev, new RobotPackage());
                }
            }

            foreach(T dev in Enum.GetValues(typeof(T)))
            {
                Packages[dev].config = configManager.table[dev.ToString()];
                Packages[dev].property = propertyManager.table[dev.ToString()];

                string master = Packages[dev].config.master.ToString();
                Packages[dev].master = modbusTcpManager.table[master].modbusTcpMaster;
            }
        }
    }

    public partial class RobotLibrary<T> : IRobotOperate<T>
    {
        RobotAdapter adapter;

        public void InitAdpater()
        {
            List<RobotConfig> cs = configManager.table.Values.ToList();
            adapter = new RobotAdapter(cs);
        }

        IRobotOperate<RobotPackage> SelectAdapter(T t)
        {
            string key = t.ToString();
            RobotConfig c = configManager.table[key];
            return adapter[c.supplier];
        }

        public async Task<bool> GetErrorCodeAsync(T t)
        {
            return await SelectAdapter(t).GetErrorCodeAsync(Packages[t]);
        }

        public async Task<bool> GetIsErrorAsync(T t)
        {
            return await SelectAdapter(t).GetIsErrorAsync(Packages[t]);
        }

        public async Task<bool> GetProjectErrorCodeAsync(T t)
        {
            return await SelectAdapter(t).GetProjectErrorCodeAsync(Packages[t]);
        }

        public async Task<bool> GetProjectStatusAsync(T t)
        {
            return await SelectAdapter(t).GetProjectStatusAsync(Packages[t]);
        }

        public async Task<bool> GetInRFIDScanPosAsync(T t)
        {
            return await SelectAdapter(t).GetInRFIDScanPosAsync(Packages[t]);
        }

        public async Task<bool> GetSensorSignalAsync(T t)
        {
            return await SelectAdapter(t).GetSensorSignalAsync(Packages[t]);
        }

        public async Task<bool> SetMissionDataAsync(T t)
        {
            return await SelectAdapter(t).SetMissionDataAsync(Packages[t]);
        }

        public async Task<bool> SetOnPositionAsync(T t)
        {
            return await SelectAdapter(t).SetOnPositionAsync(Packages[t]);
        }

        public async Task<bool> SetRFIDScanMotionAsync(T t)
        {
            return await SelectAdapter(t).SetRFIDScanMotionAsync(Packages[t]);
        }

        public async Task<bool> SetTriggerErrorAsync(T t)
        {
            return await SelectAdapter(t).SetTriggerErrorAsync(Packages[t]);
        }

        public void GetDeployData(T t)
        {
            SelectAdapter(t).GetDeployData(Packages[t]);
        }
    }
}
