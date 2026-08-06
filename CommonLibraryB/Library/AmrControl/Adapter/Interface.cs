using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public interface IAmrControlOperate<T>
    {
        Task<bool> GetAccessToken(T t);

        Task<bool> SetMoveFlow(T t);
    }
}
