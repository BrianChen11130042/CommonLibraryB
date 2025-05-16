using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Library.Robot.Config
{

    public class RobotConfigManager<E> : ManagerBase<E, RobotConfig>
    {
        public string Directory { get; set; }
        public const string fileName = "RobotConfig.json";

        public RobotConfigManager(string dir) : base(dir + "Config\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, RobotConfig>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new RobotConfig() { device = key });
                }
            }
        }
    }
}
