using CommonLibraryB.Base.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.Amr.Property
{

    public class AmrPropertyManager<E> : ManagerBase<E, AmrProperty>
    {
        public string Directory;
        public const string fileName = "AmrProperty.json";

        public AmrPropertyManager(string dir) : base(dir + "Property\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, AmrProperty>();

            foreach(string key in keys)
            {
                if(!table.ContainsKey(key))
                {
                    table.Add(key, new AmrProperty() { Device = key });
                }
            }
        }
    }
}
