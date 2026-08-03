using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Library.AmrControl.Config
{
    public class AmrControlConfigManager<E> : ManagerBase<E, AmrControlConfig>
    {
        public string Directory { get; set; }
        public const string fileName = "AmrControlConfig.json";

        public AmrControlConfigManager(string dir) : base(dir + "Config\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, AmrControlConfig>();

            foreach(string key in keys)
            {
                if (!table.ContainsKey(key))
                {
                    table.Add(key, new AmrControlConfig() { device = key});
                }
            }
        }
    }
}
