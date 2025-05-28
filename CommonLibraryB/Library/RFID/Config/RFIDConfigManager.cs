using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Library.RFID.Config
{
    public class RFIDConfigManager<E> : ManagerBase<E, RFIDConfig>
    {
        public string Directory { get; set; }
        public const string fileName = "RFIDConfig.json";

        public RFIDConfigManager(string dir) : base(dir + "Config\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, RFIDConfig>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new RFIDConfig() { device = key});
                }
            }
        }
    }
}
