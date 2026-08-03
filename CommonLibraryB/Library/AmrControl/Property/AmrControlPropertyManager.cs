using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Manager;

namespace CommonLibraryB.Library.AmrControl.Property
{
    public class AmrControlPropertyManager<E> : ManagerBase<E, AmrControlProperty>
    {
        public string Directory;
        public const string fileName = "AmrControlProperty.json";

        public AmrControlPropertyManager(string dir) : base(dir + "Property\\" + fileName)
        {
            Directory = dir;
        }

        public override void GenerateDefaultTable()
        {
            table = new Dictionary<string, AmrControlProperty>();

            foreach(string key in keys)
            {
                if (!table.ContainsKey(key))
                {
                    table.Add(key, new AmrControlProperty() { Device = key});
                }
            }
        }
    }
}
