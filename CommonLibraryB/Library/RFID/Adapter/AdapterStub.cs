using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.RFID.Adapter
{
    public class AdapterStub : IRFIDOperate<RFIDPackage>
    {
        public async Task<bool> GetRFIDAsync(RFIDPackage t)
        {
            return true;
        }

        public async Task<bool> SetRFIDBuzzer(RFIDPackage t, bool sw)
        {
            return true;
        }
    }
}
