using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Manager.ModbusTcp.Master
{
    public class ModbusTcpMasterManager<E> : ManagerBase<E, TcpMasterConfig>
    {
        public string Directory;
        public const string fileName = "ModbusTcpMasterConfig.json";

        public ModbusTcpMasterManager(string dir) : base(dir + "Config\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, TcpMasterConfig>();

            foreach(string key in keys)
            {
                if (!table.ContainsKey(key))
                {
                    table.Add(key, new TcpMasterConfig(key));
                }
            }
        }
    }
}
