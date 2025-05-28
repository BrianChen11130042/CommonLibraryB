using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Library.RFID.Property
{
    public class RFIDPropertyManager<E> : ManagerBase<E, RFIDProperty>
    {
        public string Directory;
        public const string fileName = "RFIDProperty.json";

        public RFIDPropertyManager(string dir) :base(dir + "Property\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, RFIDProperty>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new RFIDProperty() { device = key });
                }
            }
        }
    }
}
