using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Adapter
{
    public interface IAmrControlAdapter<T>
    {
        Task<bool> GetAccessToken(T t);

        Task<bool> SetMoveFlow(T t);

        Task<bool> SetChargeFlow(T t);

        Task<bool> GetProgressByFlowId(T t);

        Task<bool> GetProgressByTaskId(T t);

        Task<bool> GetArtifactStatusByArtifactId(T t);

        Task<bool> SetDeleteFlowByFlowId(T t);
    }
}
