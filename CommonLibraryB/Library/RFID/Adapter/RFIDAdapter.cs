using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibraryB.Base.Adapter;
using CommonLibraryB.Library.RFID.Config;

namespace CommonLibraryB.Library.RFID.Adapter
{
    public enum ERFIDSupplier { MP2319NR }

    public class RFIDAdapter : AdapterBase<RFIDConfig, ERFIDSupplier, IRFIDOperate<RFIDPackage>>
    {
        public RFIDAdapter(List<RFIDConfig> keys):base(keys)
        {

        }

        protected override void InitAdapter(List<RFIDConfig> keys)
        {
            foreach(var v in keys)
            {
                ERFIDSupplier supplier = v.supplier;

                if (table.ContainsKey(supplier))
                    continue;

                switch(supplier)
                {
                    case ERFIDSupplier.MP2319NR:
                        table.Add(supplier, new AdapterMP2319NR());
                        break;
                }

            }
        }
    }
}
