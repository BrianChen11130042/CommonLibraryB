using CommonLibraryB.Base.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Config
{
    public class AmrConfigManager<E> : ManagerBase<E, AmrConfig>
    {
        public string Directory { get; set; }
        public const string fileName = "AmrConfig.json";

        public AmrConfigManager(string dir) : base(dir + "Config\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, AmrConfig>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new AmrConfig() { Device = key});
                }
            }
        }
    }
}
