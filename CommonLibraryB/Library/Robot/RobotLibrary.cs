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

        Dictionary<T, RobotPackage> packages;

        public void InitPackage()
        {
            if (packages == null)
            {
                packages = new Dictionary<T, RobotPackage>();

                foreach(T dev in Enum.GetValues(typeof(T)))
                {
                    packages.Add(dev, new RobotPackage());
                }
            }

            foreach(T dev in Enum.GetValues(typeof(T)))
            {
                packages[dev].config = configManager.table[dev.ToString()];
                packages[dev].property = propertyManager.table[dev.ToString()];

                string master = packages[dev].config.modbusTcpMaster.ToString();
                packages[dev].master = modbusTcpManager.table[master].modbusTcpMaster;
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
            return await SelectAdapter(t).GetErrorCodeAsync(packages[t]);
        }

        public async Task<bool> GetIsErrorAsync(T t)
        {
            return await SelectAdapter(t).GetIsErrorAsync(packages[t]);
        }

        public async Task<bool> GetProjectErroCodeAsync(T t)
        {
            return await SelectAdapter(t).GetProjectErroCodeAsync(packages[t]);
        }

        public async Task<bool> GetProjectStatusAsync(T t)
        {
            return await SelectAdapter(t).GetProjectStatusAsync(packages[t]);
        }

        public async Task<bool> GetRFIDAsync(T t)
        {
            return await SelectAdapter(t).GetRFIDAsync(packages[t]);
        }

        public async Task<bool> GetSensorSignalAsync(T t)
        {
            return await SelectAdapter(t).GetSensorSignalAsync(packages[t]);
        }

        public async Task<bool> SetMissionInformAsync(T t)
        {
            return await SelectAdapter(t).SetMissionInformAsync(packages[t]);
        }

        public async Task<bool> SetOnPositionAsync(T t)
        {
            return await SelectAdapter(t).SetOnPositionAsync(packages[t]);
        }
    }
}
