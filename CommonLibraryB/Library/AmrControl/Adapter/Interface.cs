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

        Task<bool> SetChargeFlow(T t);

        Task<bool> GetProgressByFlowId(T t);

        Task<bool> GetProgressByTaskId(T t);
    }
}
