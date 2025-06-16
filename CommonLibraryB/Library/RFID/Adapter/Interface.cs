using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.RFID.Adapter
{
    public interface IRFIDOperate<T>
    {
        public Task<bool> GetRFIDAsync(T t);

        public Task<bool> SetRFIDBuzzer(T t, bool sw);
    }
}
