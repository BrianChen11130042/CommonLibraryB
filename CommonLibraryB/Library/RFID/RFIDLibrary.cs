using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Library.RFID.Config;
using CommonLibraryB.Library.RFID.Property;
using CommonLibraryB.Library.RFID.Adapter;
using CommonLibraryB.Manager.ModbusRtu;

namespace CommonLibraryB.Library.RFID
{
    public partial class RFIDLibrary<T>
    {
        public ModbusRtuManager modbusRtuManager;
        public RFIDConfigManager<T> configManager;
        public RFIDPropertyManager<T> propertyManager;

        public RFIDLibrary(ModbusRtuManager modbusRtuManager, RFIDConfigManager<T> configManager, RFIDPropertyManager<T> propertyManager)
        {
            this.modbusRtuManager = modbusRtuManager;
            this.configManager = configManager;
            this.propertyManager = propertyManager;
        }

        public Dictionary<T, RFIDPackage> Packages;

        public void InitPackage()
        {
            if(Packages == null)
            {
                Packages = new Dictionary<T, RFIDPackage>();

                foreach(T dev in Enum.GetValues(typeof(T)))
                {
                    Packages.Add(dev, new RFIDPackage());
                }
            }

            foreach(T dev in Enum.GetValues(typeof(T)))
            {
                Packages[dev].config = configManager.table[dev.ToString()];
                Packages[dev].property = propertyManager.table[dev.ToString()];

                if(modbusRtuManager.table.ContainsKey(Packages[dev].config.com))
                {
                    Packages[dev].port = modbusRtuManager.table[Packages[dev].config.com].serialPort;
                }
            }
        }
    }

    public partial class RFIDLibrary<T> : IRFIDOperate<T>
    {
        RFIDAdapter adapter;

        public void InitAdapter()
        {
            List<RFIDConfig> cs = configManager.table.Values.ToList();
            adapter = new RFIDAdapter(cs);
        }

        IRFIDOperate<RFIDPackage> SelectAdapter(T t)
        {
            string key = t.ToString();
            RFIDConfig c = configManager.table[key];
            return adapter[c.supplier];
        }

        public async Task<bool> GetRFIDAsync(T t)
        {
            return await SelectAdapter(t).GetRFIDAsync(Packages[t]);
        }

        public async Task<bool> SetRFIDBuzzer(T t, bool sw)
        {
            return await SelectAdapter(t).SetRFIDBuzzer(Packages[t], sw);
        }
    }
}
