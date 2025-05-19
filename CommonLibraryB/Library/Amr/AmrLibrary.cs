using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Manager.ModbusTcp.Master;
using CommonLibraryB.Library.Amr.Config;
using CommonLibraryB.Library.Amr.Property;
using Microsoft.AspNetCore.Mvc.Formatters;
using CommonLibraryB.Library.Amr.Adapter;

namespace CommonLibraryB.Library.Amr
{

    public partial class AmrLibrary<T>
    {
        public ModbusTcpMasterManager modbusTcpMasterManager;
        public AmrConfigManager<T> configManager;
        public AmrPropertyManager<T> propertyManager;

        public AmrLibrary(ModbusTcpMasterManager modbusTcpMasterManager, AmrConfigManager<T> configManager, 
                          AmrPropertyManager<T> propertyManager)
        {
            this.modbusTcpMasterManager = modbusTcpMasterManager;
            this.configManager = configManager;
            this.propertyManager = propertyManager;
        }

        public Dictionary<T, AmrPackage> Packages;

        public void InitPackage()
        {
            if(Packages == null)
            {
                Packages = new Dictionary<T, AmrPackage>();

                foreach(T dev in Enum.GetValues(typeof(T)))
                {
                    Packages.Add(dev, new AmrPackage());
                }
            }

            foreach(T dev in Enum.GetValues(typeof(T)))
            {
                Packages[dev].config = configManager.table[dev.ToString()];
                Packages[dev].property = propertyManager.table[dev.ToString()];

                string master = configManager.table[dev.ToString()].master.ToString();
                Packages[dev].master = modbusTcpMasterManager.table[master].modbusTcpMaster;
            }
        }

    }

    public partial class AmrLibrary<T> : IAmrOperate<T>
    {
        AmrAdapter adapter;

        public void InitAdapter()
        {
            List<AmrConfig> cs = configManager.table.Values.ToList();
            adapter = new AmrAdapter(cs);
        }

        IAmrOperate<AmrPackage> SelectAdapter(T t)
        {
            string key = t.ToString();
            AmrConfig c = configManager.table[key];
            return adapter[c.supplier];
        }

        public async Task<bool> GetMissionInformAsync(T t)
        {
            return await SelectAdapter(t).GetMissionInformAsync(Packages[t]);
        }

        public async Task<bool> GetIsMissionCanceledAsync(T t)
        {
            return await SelectAdapter(t).GetIsMissionCanceledAsync(Packages[t]);
        }

        public async Task<bool> GetIsMissionStartedAsync(T t)
        {
            return await SelectAdapter(t).GetIsMissionStartedAsync(Packages[t]);
        }

        public async Task<bool> SetRobotCompletedMessageAsync(T t)
        {
            return await SelectAdapter(t).SetRobotCompletedMessageAsync(Packages[t]);
        }

        public async Task<bool> SetRobotErrorMessageAsync(T t)
        {
            return await SelectAdapter(t).SetRobotErrorMessageAsync(Packages[t]);
        }

        public async Task<bool> SetRobotIdleMessageAsync(T t)
        {
            return await SelectAdapter(t).SetRobotIdleMessageAsync(Packages[t]);
        }

        public async Task<bool> SetMissionCompletedResultAsync(T t)
        {
            return await SelectAdapter(t).SetMissionCompletedResultAsync(Packages[t]);
        }

        public async Task<bool> SetRobotRunningMessageAsync(T t)
        {
            return await SelectAdapter(t).SetRobotRunningMessageAsync(Packages[t]);
        }

        public async Task<bool> SetWarehouseInformAsync(T t)
        {
            return await SelectAdapter(t).SetWarehouseInformAsync(Packages[t]);
        }

    }
}
