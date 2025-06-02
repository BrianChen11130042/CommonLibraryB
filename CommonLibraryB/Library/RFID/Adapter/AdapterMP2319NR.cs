using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.RFID.Adapter
{
    public class AdapterMP2319NR : IRFIDOperate<RFIDPackage>
    {
        public async Task<bool> GetRFIDAsync(RFIDPackage t)
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}
