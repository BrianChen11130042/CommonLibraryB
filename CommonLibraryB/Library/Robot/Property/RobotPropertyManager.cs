using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Library.Robot.Property
{
    public class RobotPropertyManager<E> : ManagerBase<E, RobotProperty>
    {
        public string Directory;
        public const string fileName = "RobotProperty.json";

        public RobotPropertyManager(string dir) : base(dir + "Property\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, RobotProperty>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new RobotProperty() { device = key });
                }
            }
        }
    }
}
